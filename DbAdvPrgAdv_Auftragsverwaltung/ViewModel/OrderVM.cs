using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel {
    internal class OrderVM {
        private readonly OrderRepository _orderRep;
        private readonly CustomerRepository _customerRep;

        public OrderVM() {
            _orderRep = new OrderRepository();
            _customerRep = new CustomerRepository();
        }
        public List<Customer> GetAllCustomers() {
            return _customerRep.GetAll();
        }
        public Customer GetCustomerById(int id) {
            return _customerRep.GetById(id);
        }
        public Order GetOrderById(int id) {
            return _orderRep.GetById(id);
        }
        public void AddOrder(Order order) {
            _orderRep.Add(order);
        }
        public void UpdateOrder(Order order) {
            _orderRep.Add(order);
        }
    }
}
