using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Castle.Core.Internal;
using DbAdvPrgAdv_Auftragsverwaltung.Form;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainVM _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new MainVM();
            // Migrate ausführen 
            // **************************************************************************************************
            //using (var context = new OrderContext())
            //{
            //    context.Database.Migrate();
            //}
            // **************************************************************************************************
            UpdateGrid();
        }
        /* Customers */
        private void CmdCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            var windowCustomer = new EditCustomer(this,new Customer() {City = new City()});
            windowCustomer.Show();
        }
        private void CmdEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Customer)GrdCustomer.SelectedItem;

            if (selected != null) {
                var windowCustomer = new EditCustomer(this, selected);
                windowCustomer.Show();
            }
            else {
                MessageBox.Show("Bitte Kunde auswählen");
            }
        }
        private void CmdDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Customer)GrdCustomer.SelectedItem;

            if (selected != null)
            {
                _vm.DeleteCustomerById(selected.CustomerID);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Bitte Kunde auswählen");
            }
            
        }
        private void CmdSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            GrdCustomer.ItemsSource = _vm.SearchCustomerByName(TxtCustomerSearch.Text);
        }
        /* Article */
        private void CmdCreateArticle_OnClick(object sender, RoutedEventArgs e) {
            var windowGroup = new EditArticle(this, new Article() {Group = new Group()});
            windowGroup.Show();
        }
        private void CmdEditArticle_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Article)GrdArticle.SelectedItem;

            if (selected != null) {
                var windowCustomer = new EditArticle(this, selected);
                windowCustomer.Show();
            }
            else {
                MessageBox.Show("Bitte Artikel auswählen");
            }
        }
        private void CmdDeleteArticle_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Article)GrdArticle.SelectedItem;

            if (selected != null)
            {
                _vm.DeleteArticleById(selected.ArticleID);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Bitte Artikel auswählen");
            }
        }
        private void CmdSearchArticle_Click(object sender, RoutedEventArgs e)
        {
            GrdArticle.ItemsSource = _vm.SearchArticleByName(TxtArticleSearch.Text);
        }

        /* Article-Groups */
        private void CmdCreateArticleGroup_OnClick(object sender, RoutedEventArgs e) {
            var windowGroup = new EditGroup(this, new Group() {Parent = new Group()});
            windowGroup.Show();
        }
        private void CmdEditArticleGroup_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Group)GrdArticleGroup.SelectedItem;
            if (selected != null)
            {
                var windowCustomer = new EditGroup(this, selected);
                windowCustomer.Show();
            }
            else
            {
                MessageBox.Show("Bitte Gruppe auswählen");
            }
        }
        private void CmdDeleteArticleGroup_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Group)GrdArticleGroup.SelectedItem;

            if (selected != null)
            {
                _vm.DeleteGroupById(selected.GroupID);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Bitte Gruppe auswählen");
            }
        }
        private void CmdSearchArticleGroup_Click(object sender, RoutedEventArgs e)
        {
            GrdArticleGroup.ItemsSource = _vm.SearchGroupByName(TxtGroupSearch.Text);
        }
        private void CmdTreeViewGroup_OnClick(object sender, RoutedEventArgs e) {
            var windowTree = new TreeViewWindow();
            windowTree.Show();
        }
        /* Bestellungen */
        private void CmdCreateOrder_OnClick(object sender, RoutedEventArgs e) {
            var windowGroup = new EditOrder(this, new Order(){ Customer = new Customer(), Positions = new List<Position>()});
            windowGroup.Show();
        }

        private void CmdEditOrder_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Order)GrdOrder.SelectedItem;
            if (selected != null) {
                var windowCustomer = new EditOrder(this, selected);
                windowCustomer.Show();
            }
            else {
                MessageBox.Show("Bitte Bestellung auswählen");
            }
        }
        private void CmdDeleteOrder_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Order)GrdOrder.SelectedItem;
            if (selected != null)
            {
                _vm.DeleteOrderById(selected.OrderID);
                UpdateGrid();
            }
            else
            {
                MessageBox.Show("Bitte Bestellung auswählen");
            }
            
        }
        private void CmdSearchOrder_Click(object sender, RoutedEventArgs e)
        {
            var searchList = new List<Order>();
            int searchID;
            
            if (TxtOrderSearch.Text.IsNullOrEmpty())
            {
                GrdOrder.ItemsSource = _vm.GetOrders();
            }
            else
            {
                if (int.TryParse(TxtOrderSearch.Text, out searchID))
                {
                    searchList.Add(_vm.GetOrderByID(searchID));
                    GrdOrder.ItemsSource = searchList;
                }
                else
                {
                    MessageBox.Show("Bitte gültige ID eingeben");
                }
            }
        }
        private void CmdShowBalance_OnClick(object sender, RoutedEventArgs e)
        {
            var windowYoy = new YoyWindow();
            windowYoy.Show();
        }
        private void CmdShowInvoice_OnClick(object sender, RoutedEventArgs e)
        {
            var windowInvoice = new InvoiceWindow();
            windowInvoice.Show();
        }
        // Tabellen befüllen
        public void UpdateGrid()
        {
            GrdCustomer.ItemsSource = _vm.GetCustomers();
            GrdOrder.ItemsSource = _vm.GetOrders();
            GrdArticle.ItemsSource = _vm.GetArticles();
            GrdArticleGroup.ItemsSource = _vm.GetGroups();
        }
    }
}
