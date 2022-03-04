using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Yoy
    {
        public Yoy(string quartal, string kat, string yoy)
        {
            Quartal = quartal;
            Kategorie = kat;
            YoyPercent = yoy;
        }
        public string Quartal { get; set; }
        public string Kategorie { get; set; }
        public string YoyPercent { get; set; }
    }
}
