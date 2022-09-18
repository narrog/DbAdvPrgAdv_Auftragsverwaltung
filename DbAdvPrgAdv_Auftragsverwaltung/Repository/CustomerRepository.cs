using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal class CustomerRepository : RepositoryBase<Customer>,ICustomerRepository
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
        public override List<Customer> SearchByName(string name)
        {
            using (var context = new OrderContext())
            {
                return context.Customers.Where(x => x.Name.Contains(name) || x.Vorname.Contains(name)).ToList();
            }
        }
        public override void Add(Customer entity)
        {
            using (var context = new OrderContext())
            {
                entity.City = null;
                context.Customers.Add(entity);
                context.SaveChanges();
            }
        }

        public override void Update(Customer entity)
        {
            using (var context = new OrderContext())
            {
                context.Customers.Update(entity);
                context.SaveChanges();
            }
        }
        public override void DeleteById(int id)
        {
            using (var context = new OrderContext())
            {
                context.Customers.Remove(GetById(id));
                context.SaveChanges();
            }
        }

        public List<Customer> GetAllTemporal(DateTime date)
        {
            using (var context = new OrderContext())
            {
                return context.Customers.TemporalAsOf(date).ToList();
            }
        }
    }
}
