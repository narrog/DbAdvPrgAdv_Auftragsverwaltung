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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DbAdvPrgAdv_Auftragsverwaltung.Form;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Customer> cust;
            // Migrate ausführen 
            using (var context = new OrderContext())
            {
                context.Database.Migrate();
            }
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
            using (var context = new OrderContext())
            {
                var selected = (Customer)GrdCustomer.SelectedItem;
                var toDelete = context.Customers.Find(selected.CustomerID);
                context.Customers.Remove(toDelete);
                context.SaveChanges();
                UpdateGrid();
            }
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
            using (var context = new OrderContext()) {
                var selected = (Article)GrdArticle.SelectedItem;
                var toDelete = context.Articles.Find(selected.ArticleID);
                context.Articles.Remove(toDelete);
                context.SaveChanges();
                UpdateGrid();
            }
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
            using (var context = new OrderContext()) {
                var selected = (Group)GrdArticleGroup.SelectedItem;
                var toDelete = context.Groups.Find(selected.GroupID);
                context.Groups.Remove(toDelete);
                context.SaveChanges();
                UpdateGrid();
            }
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
                MessageBox.Show("Bitte Gruppe auswählen");
            }
        }

        private void CmdSearchOrder_OnClick(object sender, RoutedEventArgs e) {
            throw new NotImplementedException();
        }

        private void CmdDeleteOrder_OnClick(object sender, RoutedEventArgs e) {
            using (var context = new OrderContext()) {
                var selected = (Order)GrdOrder.SelectedItem;
                var toDelete = context.Orders.Find(selected.OrderID);
                context.Orders.Remove(toDelete);
                context.SaveChanges();
                UpdateGrid();
            }
        }
        private void CmdShowBalance_OnClick(object sender, RoutedEventArgs e)
        {
            var windowBalance = new ShowBalance();
            windowBalance.Show();
        }
        // Tabellen befüllen
        public void UpdateGrid()
        {
            using (var context = new OrderContext())
            {
                GrdCustomer.ItemsSource = context.Customers.Include("City").ToList();
                GrdOrder.ItemsSource = context.Orders.Include("Customer").Include("Positions").ToList();
                GrdArticle.ItemsSource = context.Articles.Include("Group").Include("Positions").ToList();
                GrdArticleGroup.ItemsSource = context.Groups.Include("Articles").ToList();
            }
        }

    }
}
