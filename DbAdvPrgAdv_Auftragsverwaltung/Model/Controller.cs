using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using Castle.Core.Internal;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    public class Controller
    {
        public Controller()
        {
            GetDatabase();
        }

        public List<Customer> Customers { get; set; }
        public List<City> Cities { get; set; }
        public List<Article> Articles { get; set; }
        public List<Group> Groups { get; set; }
        public List<Order> Orders { get; set; }
        public List<Position> Positions { get; set; }
        public Customer SelectedCustomer { get; set; }

        public void GetDatabase()
        {
            using (var context = new OrderContext())
            {
                Customers?.Clear();
                Customers = context.Customers.ToList();
                Cities?.Clear();
                Cities = context.Cities.ToList();
                Articles?.Clear();
                Articles = context.Articles.ToList();
                Groups?.Clear();
                Groups = context.Groups.ToList();
                Orders?.Clear();
                Orders = context.Orders.ToList();
                Positions?.Clear();
                Positions = context.Positions.ToList();
            }
        }

        public void SelectCustomer(int id)
        {
            if (id == 0)
            {
                SelectedCustomer = new Customer();
            }
            else
            {
                using (var context = new OrderContext())
                {
                    SelectedCustomer = context.Customers.Find(id);
                }
            }
        }

        public void SaveCustomer()
        {
            using (var context = new OrderContext())
            {
                if (SelectedCustomer.CustomerID != 0)
                {
                    foreach (var current in context.Customers)
                    {
                        if (current.CustomerID == SelectedCustomer.CustomerID)
                        {
                            current.Adress = SelectedCustomer.Adress;
                            current.CityID = SelectedCustomer.CityID;
                            current.Email = SelectedCustomer.Email;
                            current.Name = SelectedCustomer.Name;
                            current.Password = SelectedCustomer.Password;
                            current.Vorname = SelectedCustomer.Vorname;
                            current.Website = SelectedCustomer.Website;
                        }
                    }
                }
                else
                {
                    context.Customers.Add(SelectedCustomer);
                }
                context.SaveChanges();
            }
        }
    }
}
