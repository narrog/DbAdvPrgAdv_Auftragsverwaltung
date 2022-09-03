using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class CustomerRepository : RepositoryBase<Customer>
    {
        public override List<Customer> GetAll()
        {
            using (var context = new OrderContext())
            {
                return context.Customers.Include("City").ToList();
            }
        }

        public override Customer GetById(int ID)
        {
            using (var context = new OrderContext())
            {
                return context.Customers.FirstOrDefault(x => x.CustomerID == ID);
            }
        }
    }
}
