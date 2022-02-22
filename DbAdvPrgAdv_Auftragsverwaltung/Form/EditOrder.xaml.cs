using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window {
        public EditOrder(MainWindow mainWindow, Order selected) {
            InitializeComponent();
            Main = mainWindow;
            SelectedOrder = selected;
            Amount = 1;
            this.DataContext = this;

            using (var context = new OrderContext())
            {
                if (SelectedOrder.OrderID == 0)
                {
                    Number = 1;
                    context.Orders.Add(SelectedOrder);
                    context.SaveChanges();
                }
                else
                {
                    Number = SelectedOrder.Positions.Count + 1;
                }
                Articles = context.Articles.ToList();
                Customers = context.Customers.ToList();
            }

            // CmbBox Customers füllen
            foreach (var item in Customers) {
                CmbCustomer.Items.Add((item.CustomerID + " " + item.Name + " " + item.Vorname));
                if (item.CustomerID == SelectedOrder.CustomerID)
                {
                    CmbCustomer.SelectedItem = item.CustomerID + " " + item.Name + " " + item.Vorname;
                }
            }
            // CmbBox Article füllen
            foreach (var item in Articles) {
                CmbArticle.Items.Add(item.Name);
            }
            TxtQuantity.Text = Convert.ToString(Amount);
            UpdateGrid();
        }
        public MainWindow Main { get; set; }
        public Order SelectedOrder { get; set; }
        public List<Article> Articles { get; set; }
        public List<Customer> Customers { get; set; }
        public Position SelectedPosition { get; set; }
        public int Amount { get; set; }
        public int Number { get; set; }

        private void CmdAbort_OnClick(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }

        private void CmdSave_OnClick(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (CmbCustomer.Text != "")
                {
                    var customerID = CmbCustomer.Text.Split(' ');
                    foreach (var item in Customers)
                    {
                        if (item.CustomerID == Convert.ToInt32(customerID[0]))
                        {
                            SelectedOrder.Customer = item;
                        }
                    }
                    using (var context = new OrderContext())
                    {
                        context.Orders.Update(SelectedOrder);
                        context.SaveChanges();
                    }
                    Main.UpdateGrid();
                    Close();
                }
                else {
                    if (CmbCustomer.Text == "") {
                        throw new ArgumentException("Bitte Kunde auswählen.");
                    }
                }
            }
            catch (ArgumentException arg) 
            {
                MessageBox.Show(arg.Message);
            }
        }



        private void CmbArticle_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePrice();
        }

        private void CmdAddPos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double Price;
                int Amount;
                var PriceParsed = double.TryParse(TxtPriceTotal.Text, out Price);
                var AmountParsed = int.TryParse(TxtQuantity.Text, out Amount);
                // geht nur weiter, wenn beide CmbBoxen ausgefüllt sind & Preis + Anzahl gültig sind.
                if (CmbArticle.Text != "" && AmountParsed && PriceParsed)
                {
                    Article selectedArticle = null;
                    foreach (var item in Articles)
                    {
                        if (item.Name == CmbArticle.Text)
                        {
                            selectedArticle = item;
                        }
                    }

                    if (SelectedPosition == null)
                    {
                        SelectedOrder.Positions.Add(new Position() { Article = selectedArticle, Count = Convert.ToInt32(TxtQuantity.Text), Number = Number++, Order = SelectedOrder });
                    }
                    else
                    {
                        var pos = new Position()
                        {
                            Article = selectedArticle, Count = Convert.ToInt32(TxtQuantity.Text), Order = SelectedOrder,
                            Number = SelectedPosition.Number
                        };
                        foreach (var selectedOrderPosition in SelectedOrder.Positions)
                        {
                            if (selectedOrderPosition.Number == pos.Number)
                            {
                                SelectedOrder.Positions.Remove(selectedOrderPosition);
                            }
                        }
                        SelectedOrder.Positions.Add(pos);
                    }
                    TxtQuantity.Text = "1";
                    CmbArticle.SelectedIndex = -1;
                    UpdateGrid();
                }
                else
                {
                    if (CmbArticle.Text == "")
                    {
                        throw new ArgumentException("Bitte Artikel auswählen.");
                    }
                    else if (!PriceParsed || !AmountParsed)
                    {
                        throw new ArgumentException("Bitte Preis & Anzahl als Zahl eingeben");
                    }
                }
            }
            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message);
            }
        }

        #region Edit Positions
        // Funktioniert aktuell noch nicht
        private void CmdEditPos_Click(object sender, EventArgs e)
        {
            if (GrdPositions.SelectedItem == null)
            {
                MessageBox.Show("Bitte Position auswählen");
            }
            else
            {
                Position selectedPosition = (Position)GrdPositions.SelectedItem;
                foreach (var pos in SelectedOrder.Positions)
                {
                    if (pos.Number == selectedPosition.Number)
                    {
                        SelectedPosition = pos;
                    }
                }
                TxtPrice.Text = Convert.ToString(SelectedPosition.Article.Price);
                TxtQuantity.Text = Convert.ToString(SelectedPosition.Count);
                CmbArticle.SelectedItem = SelectedPosition.Article.Name;
            }
        }

        private void CmdDelPos_Click(object sender, RoutedEventArgs e)
        {
            if (GrdPositions.SelectedItem == null)
            {
                MessageBox.Show("Bitte Position auswählen");
            }
            else
            {
                Position selected = (Position)GrdPositions.SelectedItem;
                foreach (var selectedOrderPosition in SelectedOrder.Positions)
                {
                    if (selectedOrderPosition.Number == selected.Number)
                    {
                        SelectedOrder.Positions.Remove(selectedOrderPosition);
                    }
                }
                UpdateGrid();
            }
        }
        #endregion

        private void TxtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            UpdatePrice();
        }

        private void UpdatePrice()
        {
            var amountParse = int.TryParse(TxtQuantity.Text, out var amount);
            if (amountParse)
            {
                TxtPrice.Text = "";
                foreach (var item in Articles)
                {
                    if (item.Name == (string)CmbArticle.SelectedItem)
                    {
                        TxtPrice.Text = Convert.ToString(item.Price);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte Anzahl als Ganzzahl angeben");
            }
        }
        private void UpdateGrid()
        {
            GrdPositions.ItemsSource = SelectedOrder.Positions.ToList();
            double sum = 0;
            foreach (var item in SelectedOrder.Positions)
            {
                sum = sum + item.Article.Price * item.Count;
            }

            TxtPriceTotal.Text = Convert.ToString(sum);
        }
    }
}
