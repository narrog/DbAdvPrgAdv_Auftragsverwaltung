using DbAdvPrgAdv_Auftragsverwaltung.DTO;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    internal class ExportCustomerVM
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICityRepository _cityRepository;
        public ExportCustomerVM(ICustomerRepository custRepo, ICityRepository cityRepo)
        {
            _customerRepository = custRepo;
            _cityRepository = cityRepo;
        }
        public List<Customer> GetCustomersTemporal(DateTime date)
        {
            return _customerRepository.GetAllTemporal(date);
        }
        public void ExportXML(DateTime tempDate)
        {
            var customers = CustomersToDTO(tempDate);
            var xml = new XmlSerializer(typeof(List<CustomerDTO>));
            using (var writer = new StreamWriter("customers.xml"))
            {
                xml.Serialize(writer, customers);
            }
        }
        public void ExportJSON(DateTime tempDate)
        {
            var customers = CustomersToDTO(tempDate);
            var fileStream = File.Open("customers.json",FileMode.Create);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(JsonSerializer.Serialize(customers));
            }
        }
        public void ImportXML()
        {
            var xml = new XmlSerializer(typeof(List<CustomerDTO>));
            List<CustomerDTO> customers = new List<CustomerDTO>();
            using (var reader = new StreamReader("customers.xml"))
            {
                customers = (List<CustomerDTO>)xml.Deserialize(reader);
            }
            DTOsToCustomers(customers);
        }
        public void ImportJSON()
        {
            var fileStream = File.Open("customers.json", FileMode.Open);
            var customers = (List<CustomerDTO>)JsonSerializer.Deserialize(fileStream, typeof(List<CustomerDTO>));
            DTOsToCustomers(customers);
        }
        private List<CustomerDTO> CustomersToDTO(DateTime tempDate)
        {
            var tempCust = GetCustomersTemporal(tempDate);
            List<CustomerDTO> tempCustDTO = new List<CustomerDTO>();
            foreach (var cust in tempCust)
            {
                var custDTO = new CustomerDTO()
                {
                    CustomerNr = cust.CustomerID,
                    Name = $"{cust.Vorname} {cust.Name}",
                    Adress = new Address()
                    {
                        Street = cust.Adress,
                        PostalCode = Convert.ToString(_cityRepository.GetById(cust.CityID).PLZ)
                    },
                    Email = cust.Email,
                    Website = cust.Website,
                    Password = cust.Password
                };
                tempCustDTO.Add(custDTO);
            }
            return tempCustDTO;
        }
        private void DTOsToCustomers(List<CustomerDTO> customers)
        {
            foreach(var item in customers)
            {
                if (item.CustomerNr == 0)
                _customerRepository.Add(new Customer()
                {
                    Vorname = item.Name.Split(" ")[0],
                    Name = item.Name.Split(" ")[1],
                    Adress = item.Adress.Street,
                    CityID = _cityRepository.GetByPLZ(Convert.ToInt32(item.Adress.PostalCode)).CityID,
                    Email = item.Email,
                    Website = item.Website,
                    Password= item.Password
                });
            }
        }
    }
}
