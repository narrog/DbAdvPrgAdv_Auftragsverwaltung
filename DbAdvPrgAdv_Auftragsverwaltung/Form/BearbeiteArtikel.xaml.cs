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
    /// Interaction logic for BearbeiteArtikel.xaml
    /// </summary>
    public partial class BearbeiteArtikel : Window {
        public BearbeiteArtikel(MainWindow mainWindow, int selectedID, int gruppeID) {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;
            GruppeID = gruppeID;

            using (var context = new OrderContext()) {
                var selected = context.Artikel.Find(SelectedID);
                if (SelectedID != 0) {
                    TxtBezeichnung.Text = selected.Bezeichnung;
                    TxtPreis.Text = Convert.ToString(selected.Preis);
                }

                if (GruppeID != 0)
                {
                    // CmbBox füllen
                    var kategorie = context.Gruppen;
                    foreach (var item in kategorie) {
                        CmbGruppe.Items.Add((item.Name));
                    }
                    // Kategorie anzeigen

                    var gruppe = context.Gruppen.Find(GruppeID).Name;
                    CmbGruppe.SelectedItem = gruppe;
                }
                
            }

        }
        public MainWindow Main { get; set; }
        private List<Gruppe> Kategorien { get; set; }
        public int SelectedID { get; set; }
        public int GruppeID { get; set; }

        private void CmdAbortArticle_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmdSaveArticle_OnClick(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                try
                {
                    var kategorieID = context.Gruppen.Where(x => x.Name.Equals(CmbGruppe.Text))
                        .FirstOrDefault()
                        .GruppeID;
                    var preis = Convert.ToDouble(TxtPreis.Text);
                    if (SelectedID == 0)
                    {
                        
                        var artikel = new Artikel() { Bezeichnung = TxtBezeichnung.Text, Preis = preis, GruppeID = kategorieID};
                        context.Artikel.Add(artikel);
                    }
                    else {
                        var artikel = context.Artikel.Where(x => x.ArtikelID.Equals(SelectedID))
                            .FirstOrDefault();
                        artikel.Bezeichnung = TxtBezeichnung.Text;
                        artikel.Preis = Convert.ToDouble(TxtPreis.Text);
                        artikel.GruppeID = kategorieID;
                    }

                    context.SaveChanges();
                }

                catch (FormatException)
                {
                    MessageBox.Show("Bitte gültigen Preis eingeben");
                }

            }
            Main.UpdateGrid();
            Close();

        }
    }
}
