using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class CustomerVM
    {
        private readonly CustomerRepository _customerRep;
        private readonly CityRepository _cityRep;

        public CustomerVM()
        {
            _customerRep = new CustomerRepository();
            _cityRep = new CityRepository();
        }
        public List<Customer> GetCustomers()
        {
            return _customerRep.GetAll();
        }
        public List<Customer> SearchCustomerByName(string name)
        {
            return _customerRep.SearchByName(name);
        }
        public void AddCustomer(Customer cust)
        {
            _customerRep.Add(cust);
        }
        public void UpdateCustomer(Customer cust)
        {
            _customerRep.Update(cust);
        }
        public void DeleteCustomerById(int id)
        {
            _customerRep.DeleteById(id);
        }
        public List<City> GetCities()
        {
            return _cityRep.GetAll();
        }
        public City GetCityById(int id)
        {
            return _cityRep.GetById(id);
        }
        public City GetCityByPLZ(int plz)
        {
            return _cityRep.GetByPLZ(plz);
        }
        public void AddCity(City city)
        {
            _cityRep.Add(city);
        }
    }
}
