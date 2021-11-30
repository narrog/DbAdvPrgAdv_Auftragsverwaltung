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
        public int Auftrag_ID { get; set; }
        public virtual Auftrag Auftrag { get; set; }
        public int Artikel_ID { get; set; }
        public virtual Artikel Artikel { get; set; }
        public int Anzahl { get; set; }

    }
}
