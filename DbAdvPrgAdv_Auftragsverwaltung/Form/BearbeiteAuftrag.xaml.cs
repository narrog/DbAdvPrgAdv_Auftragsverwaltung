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
    /// Interaction logic for BearbeiteAuftrag.xaml
    /// </summary>
    public partial class BearbeiteAuftrag : Window {
        public BearbeiteAuftrag(MainWindow mainWindow, int selectedID) {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;

            using (var context = new OrderContext()) {

                // CmbBox Kunden füllen
                var customer = context.Kunden;
                foreach (var item in customer) {
                    CmbCustomer.Items.Add((item.KundeID + " " + item.Name + " " + item.Vorname));

                }
                // CmbBox Artikel füllen
                var article = context.Artikel;
                foreach (var item in article) {
                    CmbArticle.Items.Add((item.Bezeichnung));

                }

                if (SelectedID != 0) {
                    //TxtNameGroup.Text = selected.Name;
                    //ParentGroupID = context.Gruppen.Find(SelectedID).ParentID;
                    var selected = context.Aufträge.Find(SelectedID);
                    CustomerID = context.Aufträge.Find(SelectedID).KundeID;
                    var auftragID = context.Aufträge.Find(SelectedID).AuftragID;
                    ArticleID = context.Positionen.Find(auftragID).ArtikelID;

                    // CmbBox Wert auswählen // gibt momentan aktuellen Wert aus
                    var selectedCustomer = context.Kunden.Find(CustomerID).KundeID + " " + context.Kunden.Find(selectedID).Name + " " + context.Kunden.Find(selectedID).Vorname;
                    CmbCustomer.SelectedItem = selectedCustomer;
                    var selectedArticle = context.Artikel.Find(ArticleID).ArtikelID;
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
