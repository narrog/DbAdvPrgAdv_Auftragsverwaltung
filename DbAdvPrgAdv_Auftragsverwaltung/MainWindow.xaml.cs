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
            var windowCustomer = new BearbeiteKunde(this);
            windowCustomer.Show();
        }

        private void CmdEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var windowCustomer = new BearbeiteKunde(this);
            var ID = GrdCustomer.SelectedItem;
            MessageBox.Show(Convert.ToString(ID));
            windowCustomer.Show();
        }

        private void CmdDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

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
