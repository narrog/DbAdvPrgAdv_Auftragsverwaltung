using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window {

        private readonly OrderVM _orderVM;
        public EditOrder(MainWindow mainWindow, Order selected) {
            InitializeComponent();
            Main = mainWindow;
            SelectedOrder = selected;
            this.DataContext = this;
            _orderVM = new OrderVM();

            using (var context = new OrderContext()) {
                if (SelectedOrder.OrderID == 0) {
                    Number = 1;
                }
                else {
                    Number = SelectedOrder.Positions.Count + 1;
                }
                Customers = context.Customers.ToList();
            }

            // *** Versuch Context zu ersetzen ***/
            //
            //if (SelectedOrder.OrderID == 0) {
            //    Number = 1;
            //}
            //else {
            //    Number = SelectedOrder.Positions.Count + 1;
            //}
            //Customers = _orderVM.GetAllCustomers();

            // CmbBox Customers füllen
            foreach (var item in Customers) {
                CmbCustomer.Items.Add(item.CustomerID + " " + item.Name + " " + item.Vorname);
                if (item.CustomerID == SelectedOrder.CustomerID) {
                    CmbCustomer.SelectedItem = item.CustomerID + " " + item.Name + " " + item.Vorname;
                }
            }
            UpdateGrid();
        }
        public MainWindow Main { get; set; }
        public Order SelectedOrder { get; set; }
        public List<Customer> Customers { get; set; }
        public int Number { get; set; }

        private void CmdAbort_OnClick(object sender, RoutedEventArgs e) {
            Main.UpdateGrid();
            Close();
        }

        private void CmdSave_OnClick(object sender, RoutedEventArgs e) {
            // *** Versuch Context zu ersetzen ***/
            //SelectedOrder.OrderDate = DateTime.Now;
            //_orderVM.UpdateOrder(SelectedOrder);

            using (var context = new OrderContext()) {
                SelectedOrder.OrderDate = DateTime.Now;
                context.Orders.Update(SelectedOrder);
                context.SaveChanges();
            }
            Main.UpdateGrid();
            Close();
        }

        private void CmdAddPos_Click(object sender, RoutedEventArgs e) {
            // *** Versuch Context zu ersetzen ***/
            //SelectedOrder.OrderDate = DateTime.Now;
            //var id = Convert.ToInt32(CmbCustomer.Text.Split()[0]);
            //SelectedOrder.Customer = _orderVM.GetCustomerById(id);
            //if (SelectedOrder.OrderID == 0)
            //    _orderVM.AddOrder(SelectedOrder);
            //else
            //    _orderVM.UpdateOrder(SelectedOrder);
            //SelectedOrder = _orderVM.GetOrderById(SelectedOrder.OrderID);

            using (var context = new OrderContext()) {
                SelectedOrder.OrderDate = DateTime.Now;
                var id = Convert.ToInt32(CmbCustomer.Text.Split()[0]);
                SelectedOrder.Customer = context.Customers.Find(id);
                if (SelectedOrder.OrderID == 0) {
                    context.Orders.Add(SelectedOrder);
                }
                else {
                    context.Orders.Update(SelectedOrder);
                }
                context.SaveChanges();
                SelectedOrder = context.Orders.Find(SelectedOrder.OrderID);
            }
            var windowPosition = new EditPosition(this, new Position() { Article = new Article(), Number = this.Number, Order = SelectedOrder, OrderID = SelectedOrder.OrderID }, true);
            windowPosition.Show();
        }
        private void CmdDelPos_Click(object sender, RoutedEventArgs e) {
            using (var context = new OrderContext()) {
                var selected = (Position)GrdPositions.SelectedItem;
                var toDelete = context.Positions
                    .FirstOrDefault(x => x.ArticleID == selected.ArticleID && x.OrderID == selected.OrderID);
                context.Positions.Remove(toDelete);
                context.SaveChanges();
                SelectedOrder = context.Orders.Find(SelectedOrder.OrderID);
                UpdateGrid();
            }
        }

        public void UpdateGrid() {
            // *** Versuch Context zu ersetzen ***/
            //SelectedOrder = _orderVM.GetOrderById(SelectedOrder.OrderID);
            //GrdPositions.ItemsSource = SelectedOrder.Positions.ToList();
            //double sum = 0;
            //foreach (var item in SelectedOrder.Positions) {
            //    sum = sum + item.Article.Price * item.Count;
            //}
            //SelectedOrder.PriceTotal = sum;
            //TxtPriceTotal.Text = SelectedOrder.PriceTotal.ToString();
            //_orderVM.UpdateOrder(SelectedOrder);

            using (var context = new OrderContext()) {
                SelectedOrder = context.Orders
                    .Include("Positions")
                    .FirstOrDefault(x => x.OrderID == SelectedOrder.OrderID);

                GrdPositions.ItemsSource = SelectedOrder.Positions.ToList();
                double sum = 0;
                foreach (var item in SelectedOrder.Positions) {
                    sum = sum + item.Article.Price * item.Count;
                }
                SelectedOrder.PriceTotal = sum;
                TxtPriceTotal.Text = SelectedOrder.PriceTotal.ToString();
                context.Orders.Update(SelectedOrder);
            }
        }
    }
}
