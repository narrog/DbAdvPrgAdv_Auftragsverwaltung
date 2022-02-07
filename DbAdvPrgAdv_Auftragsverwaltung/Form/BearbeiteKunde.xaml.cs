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
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for BearbeiteKunde.xaml
    /// </summary>
    public partial class BearbeiteKunde : Window
    {
        public BearbeiteKunde(MainWindow mainWindow, int selectedID)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;
            using (var context = new OrderContext())
            {
                if (SelectedID != 0)
                {
                    var selected = context.Kunden.Find(SelectedID);
                    TxtName.Text = selected.Name;
                    TxtVorname.Text = selected.Vorname;
                    TxtStrasse.Text = selected.Strasse;
                    TxtPLZ.Text = Convert.ToString(selected.Ort.PLZ);
                    TxtOrt.Text = selected.Ort.Ortschaft;
                    TxtEMail.Text = selected.Email;
                    TxtWebseite.Text = selected.Webseite;
                    TxtPasswort.Text = selected.Passwort;
                }

                Orte = context.Orte.ToList();
            }
        }
        public MainWindow Main { get; set; }
        private List<Ort> Orte { get; set; }
        public int SelectedID { get; set; }
        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                var ort = context.Orte
                    .Where(x => x.PLZ.Equals(Convert.ToInt32(TxtPLZ.Text)))
                    .FirstOrDefault();
                if (ort == null)
                {
                    ort = new Ort() {PLZ = Convert.ToInt32(TxtPLZ.Text), Ortschaft = TxtOrt.Text};
                }
                if (SelectedID == 0)
                {
                    var kunde = new Kunde() { Name = TxtName.Text, Vorname = TxtVorname.Text, Strasse = TxtStrasse.Text, Email = TxtEMail.Text, Webseite = TxtWebseite.Text, Passwort = TxtPasswort.Text, Ort = ort };
                    context.Kunden.Add(kunde);
                }
                else
                {
                    var kunde = context.Kunden
                        .Where(x => x.KundeID.Equals(SelectedID))
                        .FirstOrDefault();
                    kunde.Name = TxtName.Text;
                    kunde.Vorname = TxtVorname.Text;
                    kunde.Strasse = TxtStrasse.Text;
                    kunde.Email = TxtEMail.Text;
                    kunde.Webseite = TxtWebseite.Text;
                    kunde.Passwort = TxtPasswort.Text;
                    kunde.Ort = ort;
                }
                context.SaveChanges();
            }
            Main.UpdateGrid();
            Close();
        }
        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TxtPLZ_KeyUp(object sender, KeyEventArgs e)
        {
            TxtOrt.IsEnabled = true;
            foreach (var ort in Orte)
            {
                if (Convert.ToString(ort.PLZ) == TxtPLZ.Text)
                {
                    TxtOrt.Text = ort.Ortschaft;
                    TxtOrt.IsEnabled = false;
                }
            }
        }
    }
}
