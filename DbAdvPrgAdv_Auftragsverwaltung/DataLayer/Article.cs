using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(7,2)")]
        public double Price { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
