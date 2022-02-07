using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Artikel
    {
        public int ArtikelID { get; set; }
        public string Bezeichnung { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public double Preis { get; set; }
        public int GruppeID { get; set; }
        public virtual Gruppe Gruppe { get; set; }

        public virtual ICollection<Position> Positionen { get; set; }
    }
}
