using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.DTO
{
    public class CustomerDTO
    {
        public int CustomerNr { get; set; }
        public string Name { get; set; }
        public Address Adress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
    }
    public class Address
    {
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
