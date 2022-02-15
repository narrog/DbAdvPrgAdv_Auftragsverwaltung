using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Gruppe
    {
        public int GruppeID { get; set; }
        public string Name { get; set; }
        public int ParentID  { get; set; }

        public virtual ICollection<Artikel> Artikels { get; set; }
    }
}
