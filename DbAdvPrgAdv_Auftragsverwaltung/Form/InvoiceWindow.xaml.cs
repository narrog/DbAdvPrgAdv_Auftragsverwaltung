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
using Castle.Core.Internal;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        public InvoiceWindow()
        {
            
            InitializeComponent();
            this.DataContext = this;
            Invoices = GetInvoices();

            using (var context = new OrderContext())
            {
                Groups = context.Groups.ToList();
                Articles = context.Articles.ToList();
            }


            DatePickerFrom.DisplayDateEnd = DateTime.Now;
            DatePickerTo.SelectedDate = DateTime.Now;
            DatePickerTo.DisplayDateEnd = DateTime.Now;

        }
        public List<Group> Groups { get; set; }
        public List<Article> Articles { get; set; }
        public List<Invoice> Invoices { get; set; }

        
        // wird für Filter benötigt
        private string CustomerName { get; set; }
        private string Group { get; set; }
        private string Article { get; set; }
        private DateTime DateFrom { get; set; }
        private DateTime DateTo { get; set; }


        private void CmdFilter_OnClick(object sender, RoutedEventArgs e)
        {
            DateTo = Convert.ToDateTime(DatePickerTo.Text);

            
            if (DatePickerFrom.Text.IsNullOrEmpty())
            {
                DateFrom = DateTime.MinValue;
            }
            else
            {
                if (DateTo > Convert.ToDateTime(DatePickerFrom.Text))
                {
                    DateFrom = Convert.ToDateTime(DatePickerFrom.Text);
                }
                else
                {
                    MessageBox.Show($"*Datum von* darf nicht grösser sein als *Datum bis* \r\n" +
                                    $"Bitte korrigieren, ansonsten wird 01.01.0001 verwendet!");
                }
            }
            //Invoices.Clear();
            Invoices = GetInvoices(dateFrom: DateFrom, dateTo: DateTo);
            GrdInvoice.ItemsSource = Invoices;

        }

        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public List<Invoice> GetInvoices()
        {
            var invoice = new List<Invoice>();
            using (var context = new OrderContext())
            {
                var orders = context.Orders.ToList();

                foreach (var item in orders)
                {
                    var customer = item.Customer;
                    var invoiceItem = new Invoice()
                    {
                        CustomerID = customer.CustomerID,
                        CustomerName = customer.Name + customer.Vorname,
                        CustomerStreet = customer.Adress, 
                        CustomerZIP = customer.City.PLZ,
                        CustomerCity = customer.City.CityName,
                        CustomerCountry = "Schweiz",
                        InvoiceDate = item.OrderDate,
                        InvoiceID = item.OrderID,
                        InvoiceNet = item.PriceTotal,
                        InvoiceGross = item.PriceTotal * 1.08
                    };
                    invoice.Add(invoiceItem);
                }

            }

            return invoice;
        }
        public List<Invoice> GetInvoices(DateTime dateFrom, DateTime dateTo)
        {
            var invoice = new List<Invoice>();
            using (var context = new OrderContext())
            {
                var orders = context.Orders.ToList().Where(x => x.OrderDate > dateFrom).Where(x => x.OrderDate < dateTo);

                foreach (var item in orders)
                {
                    var customer = item.Customer;

                    var invoiceItem = new Invoice()
                    {
                        CustomerID = customer.CustomerID,
                        CustomerName = customer.Name + " " + customer.Vorname,
                        CustomerStreet = customer.Adress,
                        CustomerZIP = customer.City.PLZ,
                        CustomerCity = customer.City.CityName,
                        CustomerCountry = "Schweiz",
                        InvoiceDate = item.OrderDate,
                        InvoiceID = item.OrderID,
                        InvoiceNet = item.PriceTotal,
                        InvoiceGross = item.PriceTotal * 1.08
                    };
                    invoice.Add(invoiceItem);
                }

            }

            return invoice;
        }
    }
}
