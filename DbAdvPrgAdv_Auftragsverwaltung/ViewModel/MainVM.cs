using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class MainVM
    {
        private readonly CustomerRepository _customerRep;
        private readonly OrderRepository _orderRep;
        public MainVM()
        {
            _customerRep = new CustomerRepository();
            _orderRep = new OrderRepository();
        }
        public List<Customer> GetCustomers()
        {
            return _customerRep.GetAll();
        }
        public List<Order> GetOrders()
        {
            return _orderRep.GetAll();
        }
    }
}
