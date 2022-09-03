using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ModelDTO
{
    internal class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
        public int CityID { get; set; }
    }
}
