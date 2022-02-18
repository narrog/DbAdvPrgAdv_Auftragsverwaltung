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
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int ArticleID { get; set; }
        public virtual Article Article { get; set; }
        public int Count { get; set; }

    }
}
