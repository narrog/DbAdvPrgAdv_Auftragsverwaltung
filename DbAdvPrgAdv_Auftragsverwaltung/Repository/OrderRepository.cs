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

        public override Order GetById(int id)
        {
            using (var context = new OrderContext())
            {
                return context.Orders.FirstOrDefault(x => x.OrderID == id);
            }
        }
        public override List<Order> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
        public override void Add(Order entity)
        {
            using (var context = new OrderContext())
            {
                context.Orders.Add(entity);
                context.SaveChanges();
            }
        }

        public override void Update(Order entity)
        {
            using (var context = new OrderContext())
            {
                context.Orders.Update(entity);
                context.SaveChanges();
            }
        }
        public override void DeleteById(int id)
        {
            using (var context = new OrderContext())
            {
                context.Orders.Remove(GetById(id));
                context.SaveChanges();
            }
        }
    }
}
