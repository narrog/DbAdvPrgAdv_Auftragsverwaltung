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

            // Migrate ausführen 
            using (var context = new OrderContext())
            {
                context.Database.Migrate();
            }
            UpdateGrid();
        }

        private void CmdCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            var windowCustomer = new BearbeiteKunde(this,0);
            windowCustomer.Show();
        }

        private void CmdEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Kunde)GrdCustomer.SelectedItem;
            var windowCustomer = new BearbeiteKunde(this, selected.KundeID);
            windowCustomer.Show();
        }

        private void CmdDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                var selected = (Kunde)GrdCustomer.SelectedItem;
                var toDelete = context.Kunden.Find(selected.KundeID);
                context.Kunden.Remove(toDelete);
                context.SaveChanges();
                UpdateGrid();
            }
        }

        /* Artikel-Gruppen */
        private void CmdCreateArticleGroup_OnClick(object sender, RoutedEventArgs e) {
            var windowGroup = new BearbeiteGruppe(this, 0);
            windowGroup.Show();
        }

        private void CmdEditArticleGroup_OnClick(object sender, RoutedEventArgs e) {
            var selected = (Gruppe)GrdArticleGroup.SelectedItem;
            var windowCustomer = new BearbeiteGruppe(this, selected.GruppeID);
            windowCustomer.Show();
        }

        // Tabellen befüllen
        public void UpdateGrid()
        {
            using (var context = new OrderContext())
            {
                GrdCustomer.ItemsSource = context.Kunden.ToList();
                GrdOrder.ItemsSource = context.Aufträge.ToList();
                GrdArticle.ItemsSource = context.Artikel.ToList();
                GrdArticleGroup.ItemsSource = context.Gruppen.ToList();
            }
        }


     
    }
}
