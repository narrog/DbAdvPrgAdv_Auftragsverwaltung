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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice()
        {
            InitializeComponent();


        }

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerStreet { get; set; }
        public int CustomerZIP { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceID { get; set; }
        public double InvoiceNet { get; set; }
        public double InvoiceGross { get; set; }


        private void CmdFilter_OnClick(object sender, RoutedEventArgs e)
        {
            var windowInvoiceFilter = new InvoiceFilter(this);
            windowInvoiceFilter.Show();
        }

        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void UpdateGrid()
        {
            
            using (var context = new OrderContext())
            {
                
            }
        }
    }
}
