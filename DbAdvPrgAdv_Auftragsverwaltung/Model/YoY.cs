using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Yoy
    {
        public Yoy(string quartal, string artikel, string yoyArtikel)
        {
            Quartal = quartal;
            Kategorie = artikel;
            YearOverYear = yoyArtikel;
        }
        public string Quartal { get; set; }
        public string Kategorie { get; set; }
        public string YearOverYear { get; set; }
    }
}
