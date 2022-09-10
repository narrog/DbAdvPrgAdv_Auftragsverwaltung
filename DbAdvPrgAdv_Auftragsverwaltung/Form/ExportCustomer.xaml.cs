using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;
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
using System.Xml.Serialization;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for ExportCustomer.xaml
    /// </summary>
    public partial class ExportCustomer : Window
    {
        public ExportCustomer(Customer cust)
        {
            InitializeComponent();
            Cust = cust;
            TemporalDate = DateTime.Now;
            this.DataContext = this;
        }
        public DateTime TemporalDate { get; set; }
        private Customer Cust { get;}
        private void CmdExportXML_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                var tempCust = context.Customers.TemporalAsOf(TemporalDate).FirstOrDefault(x => x.CustomerID == Cust.CustomerID);
                var xml = new XmlSerializer(tempCust.GetType());
                xml.Serialize(Console.Out,tempCust);
            }
        }
        private void CmdExportJSON_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
