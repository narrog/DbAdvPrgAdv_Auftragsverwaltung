using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public BearbeiteKunde(MainWindow mainWindow, Kunde selected)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedCustomer = selected;
            this.DataContext = this;
            using (var context = new OrderContext())
            {
                Orte = context.Orte.ToList();
            }
            foreach (var ort in Orte)
            {
                if (SelectedCustomer.Ort.PLZ == ort.PLZ)
                {
                    TxtOrt.Text = ort.Ortschaft;
                }
            }
        }
        public MainWindow Main { get; set; }
        private List<Ort> Orte { get; set; }
        public Kunde SelectedCustomer { get; set; }

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                if (TxtPLZ.Text == "" || TxtOrt.Text == "")
                {
                    throw new ArgumentException("Bitte einen Ort eingeben");
                }
                else
                {
                    SelectedCustomer.Ort = context.Orte
                        .FirstOrDefault(x => x.PLZ == SelectedCustomer.Ort.PLZ);
                    if (SelectedCustomer.Ort == null)
                    {
                        SelectedCustomer.Ort = new Ort() { PLZ = Convert.ToInt32(TxtPLZ.Text), Ortschaft = TxtOrt.Text };
                    }

                    if (SelectedCustomer.KundeID == 0)
                    {
                        context.Kunden.Add(SelectedCustomer);
                    }
                    else
                    {
                        context.Kunden.Update(SelectedCustomer);
                    }
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
            TxtOrt.Text = "";
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
