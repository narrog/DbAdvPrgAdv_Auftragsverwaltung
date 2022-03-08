using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Invoice
    {
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
    }
}
