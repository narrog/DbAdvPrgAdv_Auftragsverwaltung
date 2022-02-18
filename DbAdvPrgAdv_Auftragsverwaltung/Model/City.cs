using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class City
    {
        public int CityID { get; set; }
        public int PLZ { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

    }
}
