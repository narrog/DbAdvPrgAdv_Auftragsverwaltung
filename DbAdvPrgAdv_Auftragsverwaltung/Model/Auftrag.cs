using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Auftrag
    {
        public int AuftragID { get; set; }
        public DateTime Datum { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public double PreisTotal { get; set; }
        public int Kunde_ID { get; set; }
        public virtual Kunde Kunde { get; set; }

        public virtual ICollection<Position> Positionen { get; set; }
    }
}
