using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class OrderRepository : RepositoryBase<Order>
    {
        public override List<Order> GetAll()
        {
            using (var context = new OrderContext())
            {
                return context.Orders.Include("Customer").Include("Positions").ToList();
            }
        }

        public override Order GetById(int ID)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.FirstOrDefault(x => x.OrderID == ID);
            }
        }
    }
}
