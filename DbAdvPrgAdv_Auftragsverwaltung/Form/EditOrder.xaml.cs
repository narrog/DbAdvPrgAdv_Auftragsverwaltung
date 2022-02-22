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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for EditOrder.xaml
    /// </summary>
    public partial class EditOrder : Window {
        public EditOrder(MainWindow mainWindow, int selectedID) {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;

            using (var context = new OrderContext()) {

                // CmbBox Customers füllen
                var customer = context.Customers;
                foreach (var item in customer) {
                    CmbCustomer.Items.Add((item.CustomerID + " " + item.Name + " " + item.Vorname));

                }
                // CmbBox Article füllen
                var article = context.Articles;
                foreach (var item in article) {
                    CmbArticle.Items.Add((item.Name));

                }

                if (SelectedID != 0) {
                    //TxtNameGroup.Text = selected.Name;
                    //ParentGroupID = context.Groups.Find(SelectedID).ParentID;
                    var selected = context.Orders.Find(SelectedID);
                    CustomerID = context.Orders.Find(SelectedID).CustomerID;
                    var OrderID = context.Orders.Find(SelectedID).OrderID;
                    ArticleID = context.Positions.Find(OrderID).ArticleID;

                    // CmbBox Wert auswählen // gibt momentan aktuellen Wert aus
                    var selectedCustomer = context.Customers.Find(CustomerID).CustomerID + " " + context.Customers.Find(selectedID).Name + " " + context.Customers.Find(selectedID).Vorname;
                    CmbCustomer.SelectedItem = selectedCustomer;
                    var selectedArticle = context.Articles.Find(ArticleID).ArticleID;
                    CmbArticle.SelectedItem = selectedArticle;
                }
            }
        }
        public MainWindow Main { get; set; }
        public int SelectedID { get; set; }
        public int ArticleID { get; set; }
        public int CustomerID { get; set; }

        private void CmdAbort_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmdSave_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
