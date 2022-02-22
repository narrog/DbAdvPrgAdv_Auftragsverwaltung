using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
                CmbArticle.Items.Add((item.Name));
            }

            TxtQuantity.Text = Convert.ToString(Amount);

        }
        public MainWindow Main { get; set; }
        public Order SelectedOrder { get; set; }
        public List<Article> Articles { get; set; }
        public List<Customer> Customers { get; set; }

        public int Amount { get; set; }

        private void CmdAbort_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmdSave_OnClick(object sender, RoutedEventArgs e)
        {
            try {
                double Price;
                int Amount;
                var PriceParsed = double.TryParse(TxtPriceTotal.Text, out Price);
                var AmountParsed = int.TryParse(TxtQuantity.Text, out Amount);
                // geht nur weiter, wenn beide CmbBoxen ausgefüllt sind & Preis + Anzahl gültig sind.
                if (CmbCustomer.Text != "" && CmbArticle.Text != "" && AmountParsed && PriceParsed)
                {
                    var PriceTotal = Price * Amount;
                    var customerID = CmbCustomer.Text.Split(' ');

                    using (var context = new OrderContext())
                    {
                        if (SelectedOrder.OrderID == 0) {

                            var Order = new Order() { OrderDate = DateTime.Now, CustomerID = Convert.ToInt32(customerID[0]), PriceTotal = PriceTotal };
                            context.Orders.Add(Order);
                            //var Position = new Position() { ArticleID = ArticleID, OrderID = Order.OrderID, Count = Amount };
                            //context.Positions.Add(Position);
                        }
                        else {
                            var Order = context.Orders
                                .FirstOrDefault(x => x.OrderID.Equals(SelectedOrder.OrderID));
                            Order.CustomerID = Convert.ToInt32(customerID[0]);
                            Order.PriceTotal = Price;
                        }

                        context.SaveChanges();

                        Main.UpdateGrid();
                        Close();
                    }
                }
                else {
                    if (CmbCustomer.Text == "") {
                        throw new ArgumentException("Bitte Kunde auswählen.");
                    }
                    else if (CmbArticle.Text == "") {
                        throw new ArgumentException("Bitte Artikel auswählen.");
                    }
                    else if (!PriceParsed || !AmountParsed) {
                        throw new ArgumentException("Bitte Preis & Anzahl als Zahl eingeben");
                    }
                }
            }

            catch (ArgumentException arg) {
                MessageBox.Show(arg.Message);
            }
        }



        private void CmbArticle_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int amount;
            var amountParse = int.TryParse(TxtQuantity.Text, out amount);

            if (amountParse)
            {
                foreach (var item in Articles)
                {
                    if (item.Name == CmbArticle.Text)
                    {
                        TxtPrice.Text = Convert.ToString(item.Price);
                        TxtPriceTotal.Text = Convert.ToString(item.Price * Convert.ToInt32(TxtQuantity.Text));
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte Anzahl als Ganzzahl angeben");
            }
            
        }
    }
}
