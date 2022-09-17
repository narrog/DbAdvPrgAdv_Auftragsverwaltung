using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Autofac;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
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
            var container = BuildAutofacContainer();
            _orderVM = container.Resolve<OrderVM>();

            if (SelectedOrder.OrderID == 0)
            {
                Number = 1;
            }
            else
            {
                Number = SelectedOrder.Positions.Count + 1;
            }
            Customers = _orderVM.GetAllCustomers();

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
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PositionRepository>().As<IPositionRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<OrderVM>();
            return builder.Build();
        }
        private void CmdAbort_OnClick(object sender, RoutedEventArgs e) {
            Main.UpdateGrid();
            Close();
        }

        private void CmdSave_OnClick(object sender, RoutedEventArgs e) {
            SelectedOrder.OrderDate = DateTime.Now;
            _orderVM.UpdateOrder(SelectedOrder);

            Main.UpdateGrid();
            Close();
        }

        private void CmdAddPos_Click(object sender, RoutedEventArgs e) {
            SelectedOrder.OrderDate = DateTime.Now;
            SelectedOrder.Customer = _orderVM
                .GetCustomerById(Convert.ToInt32(CmbCustomer.Text.Split()[0]));
            SelectedOrder.CustomerID = SelectedOrder.Customer.CustomerID;
            if (SelectedOrder.OrderID == 0)
            {
                _orderVM.AddOrder(SelectedOrder);
            }
            else
                _orderVM.UpdateOrder(SelectedOrder);

            var windowPosition = new EditPosition(this, new Position() { Article = new Article(), Number = this.Number, Order = SelectedOrder, OrderID = SelectedOrder.OrderID }, true);
            windowPosition.Show();
        }
        private void CmdDelPos_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Position)GrdPositions.SelectedItem;
            _orderVM.DeletePosition(selected.OrderID, selected.ArticleID);
            UpdateGrid();
        }

        public void UpdateGrid() {
            if (SelectedOrder.OrderID != 0)
            {
                UpdateOrderView();
                SelectedOrder = _orderVM.GetOrderById(SelectedOrder.OrderID);
            }
            GrdPositions.ItemsSource = SelectedOrder.Positions.ToList();
        }
        private void UpdateOrderView()
        {
            SelectedOrder = _orderVM.GetOrderById(SelectedOrder.OrderID);
            double sum = 0;
            foreach (var item in SelectedOrder.Positions)
            {
                sum = sum + item.Article.Price * item.Count;
            }
            SelectedOrder.PriceTotal = sum;
            TxtPriceTotal.Text = SelectedOrder.PriceTotal.ToString();
            _orderVM.UpdateOrder(SelectedOrder);
        }
    }
}
