using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    internal interface IOrderRepository
    {
        public List<Order> GetAll();
        public Order GetById(int id);
        public List<Order> SearchByName(string name);
        public void Add(Order entity);
        public void Update(Order entity);
        public void DeleteById(int id);
    }
}
