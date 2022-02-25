using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DbAdvPrgAdv_Auftragsverwaltung.Form;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    public class VMMain
    {
        public VMMain()
        {
            Contr = new Controller();
        }

        public Controller Contr { get; set; }
        public List<Customer> Customers => Contr.Customers;
        public List<Article> Articles => Contr.Articles;
        public List<Group> Groups => Contr.Groups;
        public List<Order> Orders => Contr.Orders;
        public Customer SelectedCustomer => Contr.SelectedCustomer;
    }
}
