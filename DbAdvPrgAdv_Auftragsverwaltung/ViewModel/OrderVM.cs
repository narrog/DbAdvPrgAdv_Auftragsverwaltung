using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel {
    internal class OrderVM {
        private readonly IOrderRepository _orderRep;
        private readonly ICustomerRepository _customerRep;
        private readonly IPositionRepository _positionRep;

        public OrderVM(IOrderRepository ordRepo,ICustomerRepository custRepo, IPositionRepository posRepo) {
            _orderRep = ordRepo;
            _customerRep = custRepo;
            _positionRep = posRepo;
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
            _orderRep.Update(order);
        }
        public void DeletePosition(int orderId, int articleId)
        {
            _positionRep.DeleteByCombinedId(orderId, articleId);
        }
    }
}
