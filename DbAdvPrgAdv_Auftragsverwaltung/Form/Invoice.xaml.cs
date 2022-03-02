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
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice()
        {
            this.DataContext = this;
            InitializeComponent();

            UpdateGrid();
        }

        private List<Order> Orders { get; set; }
        public static string CustomerName { get; set; }
        public static string Group { get; set; }
        public static string Article { get; set; }
        public static string DateFrom { get; set; }
        public static string DateTo { get; set; }


        private void CmdFilter_OnClick(object sender, RoutedEventArgs e)
        {
            var windowInvoiceFilter = new InvoiceFilter(this);
            windowInvoiceFilter.Show();
        }

        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Tabelle befüllen
        public void UpdateGrid()
        {
            using (var context = new OrderContext())
            {
                Orders = context.Orders.ToList();
            }

            foreach (var item in Orders)
            {
                   
            }
        }

    }
}
