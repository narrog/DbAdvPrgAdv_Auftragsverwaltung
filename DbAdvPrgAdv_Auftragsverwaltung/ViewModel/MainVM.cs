using System.Collections.Generic;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class MainVM
    {
        private readonly CustomerRepository _customerRep;
        private readonly OrderRepository _orderRep;
        private readonly ArticleRepository _articleRep;
        private readonly GroupRepository _groupRep;
        public MainVM()
        {
            _customerRep = new CustomerRepository();
            _orderRep = new OrderRepository(); 
            _articleRep = new ArticleRepository();
            _groupRep = new GroupRepository();
        }
        public List<Customer> GetCustomers()
        {
            return _customerRep.GetAll();
        }
        public List<Customer> SearchCustomerByName(string name)
        {
            return _customerRep.SearchByName(name);
        }
        public void DeleteCustomerById(int id)
        {
            _customerRep.DeleteById(id);
        }
        public List<Order> GetOrders()
        {
            return _orderRep.GetAll();
        }
        public Order GetOrderByID(int id)
        {
            return _orderRep.GetById(id);
        }
        public void DeleteOrderById(int id)
        {
            _orderRep.DeleteById(id);
        }
        public List<Article> GetArticles()
        {
            return _articleRep.GetAll();
        }
        public List<Article> SearchArticleByName(string name)
        {
            return _articleRep.SearchByName(name);
        }
        public void DeleteArticleById(int id)
        {
            _articleRep.DeleteById(id);
        }
        public List<Group> GetGroups()
        {
            return _groupRep.GetAll();
        }
        public void DeleteGroupById(int id)
        {
            _groupRep.DeleteById(id);
        }
        public List<Group> SearchGroupByName(string name)
        {
            return _groupRep.SearchByName(name);
        }
    }
}
