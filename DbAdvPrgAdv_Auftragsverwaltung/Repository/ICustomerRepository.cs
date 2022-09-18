using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface ICustomerRepository
    {
        public List<Customer> GetAll();
        public List<Customer> GetAllTemporal(DateTime date);
        public Customer GetById(int id);
        public abstract List<Customer> SearchByName(string name);
        public abstract void Add(Customer entity);
        public abstract void Update(Customer entity);
        public abstract void DeleteById(int id);
    }
}
