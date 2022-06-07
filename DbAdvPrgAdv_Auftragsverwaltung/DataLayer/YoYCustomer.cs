using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    public class YoyCustomer
    {
        public YoyCustomer(string quartal, string artikel,string customer, string yoyArtikel)
        {
            Quartal = quartal;
            Kategorie = artikel;
            Customer = customer;
            YearOverYear = yoyArtikel;
        }
        public string Quartal { get; set; }
        public string Kategorie { get; set; }
        public string Customer { get; set; }
        public string YearOverYear { get; set; }
    }
}