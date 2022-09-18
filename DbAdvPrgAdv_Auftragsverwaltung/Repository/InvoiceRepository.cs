using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class InvoiceRepository : IInvoiceRepository
    {
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
