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
            UpdateGrid();
        }
        public MainWindow Main { get; set; }
        public Order SelectedOrder { get; set; }
        public List<Customer> Customers { get; set; }
        public int Number { get; set; }

        private void CmdAbort_OnClick(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }

        private void CmdSave_OnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                SelectedOrder.OrderDate = DateTime.Now;
                context.Orders.Update(SelectedOrder);
                context.SaveChanges();
            }
            Main.UpdateGrid();
            Close();
        }

        private void CmdAddPos_Click(object sender, RoutedEventArgs e)
        {
            var windowPosition = new EditPosition(this, new Position() {Article = new Article(), Number = this.Number, Order = SelectedOrder}, true);
            windowPosition.Show();
        }
        private void CmdEditPos_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Position)GrdPositions.SelectedItem;

            if (selected != null)
            {
                var windowPosition = new EditPosition(this, selected, false);
                windowPosition.Show();
            }
            else
            {
                MessageBox.Show("Bitte eine Position auswählen");
            }
        }
        private void CmdDelPos_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                var selected = (Position)GrdPositions.SelectedItem;
                var toDelete = context.Positions
                    .FirstOrDefault(x => x.ArticleID == selected.ArticleID && x.OrderID == selected.OrderID);
                context.Positions.Remove(toDelete);
                context.SaveChanges();
                UpdateGrid();
            }
        }

        public void UpdateGrid()
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
