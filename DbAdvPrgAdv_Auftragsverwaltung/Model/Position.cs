using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Position
    {
        public int Nummer { get; set; }
        public int AuftragID { get; set; }
        public virtual Auftrag Auftrag { get; set; }
        public int ArtikelID { get; set; }
        public virtual Artikel Artikel { get; set; }
        public int Anzahl { get; set; }

    }
}
