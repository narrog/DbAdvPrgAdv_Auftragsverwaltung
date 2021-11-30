using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Ort
    {
        public int OrtID { get; set; }
        public int PLZ { get; set; }
        public string Ortschaft { get; set; }

        public virtual ICollection<Kunde> Kunden { get; set; }

    }
}
