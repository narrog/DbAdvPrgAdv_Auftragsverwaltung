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
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for BearbeiteKunde.xaml
    /// </summary>
    public partial class BearbeiteKunde : Window
    {
        public BearbeiteKunde(MainWindow mainWindow)
        {
            InitializeComponent();
            Main = mainWindow;
            using (var context = new OrderContext())
            {
                Orte = context.Orte.ToList();
                CmbPLZ.ItemsSource = Orte;
                CmbPLZ.DisplayMemberPath = "PLZ";
                CmbPLZ.SelectedValuePath = "OrtID";
            }
        }
        public MainWindow Main { get; set; }
        public List<Ort> Orte { get; set; }
        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            var newCust = new Kunde() {Name = TxtName.Text, Vorname = TxtVorname.Text, Strasse = TxtStrasse.Text,Email = TxtEMail.Text,Webseite = TxtWebseite.Text, Passwort = TxtPasswort.Text, Ort_ID = Convert.ToInt16(CmbPLZ.SelectedValue)};
            using (var context = new OrderContext())
            {
                context.Kunden.Add(newCust);
            }
            Main.UpdateGrid();
        }
        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbPLZ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var ort in Orte)
            {
                if (Convert.ToInt16(CmbPLZ.SelectedValue) == ort.OrtID)
                {
                    TxtOrt.Text = ort.Ortschaft;
                }
            }
        }
    }
}
