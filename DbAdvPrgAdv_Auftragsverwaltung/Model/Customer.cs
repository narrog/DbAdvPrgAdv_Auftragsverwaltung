using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Password { get; set; }
        public int CityID { get; set; }
        public virtual City City { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Customer LoadOne(int id)
        {
            using (var context = new OrderContext())
            {
                return context.Customers
                    .Include(x => x.Orders)
                    .Include(x => x.City)
                    .FirstOrDefault(x => x.CustomerID == id);
            }
        }
    }
}
