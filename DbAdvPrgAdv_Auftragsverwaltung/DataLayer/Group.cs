using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    public class Group
    {
        public int GroupID { get; set; }
        public string Name { get; set; }
        public int? ParentID  { get; set; }
        public virtual Group Parent { get; set; }
        public virtual List<Group> Children { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        //public bool Equals(Group obj) {
        //    return this.Name == obj.Name;
        //}
    }
}
