using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public double PriceTotal { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
