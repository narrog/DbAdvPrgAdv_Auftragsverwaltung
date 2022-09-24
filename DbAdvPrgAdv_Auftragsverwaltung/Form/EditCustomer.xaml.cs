using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Autofac;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private readonly CustomerVM _customerVM;
        public EditCustomer(MainWindow mainWindow, Customer selected)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedCustomer = selected;
            this.DataContext = this;
            var container = BuildAutofacContainer();
            _customerVM = container.Resolve<CustomerVM>();
            Cities = _customerVM.GetCities();
            foreach (var City in Cities)
            {
                if (SelectedCustomer.City.PLZ == City.PLZ)
                {
                    TxtCity.Text = City.CityName;
                }
            }

            if (SelectedCustomer.CustomerID != 0)
            {
                PwdPassword.Password = SelectedCustomer.Password;
            }
        }
        public MainWindow Main { get; set; }
        private List<City> Cities { get; set; }
        public Customer SelectedCustomer { get; set; }
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<CustomerVM>();
            return builder.Build();
        }
        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int PLZ;
                var PlzParsed = Int32.TryParse(TxtPLZ.Text, out PLZ);
                if (!PlzParsed || TxtPLZ.Text.Length < 4)
                {
                    throw new ArgumentException("Bitte PLZ überprüfen");
                }
                else if (PlzParsed && (TxtPLZ.Text == "" || TxtCity.Text == ""))
                {
                    throw new ArgumentException("Bitte einen Ort eingeben");
                }
                else if (SelectedCustomer.RegEx_Mail(TxtEMail.Text) == false)
                {
                    throw new ArgumentException("Bitte E-Mail-Adresse überprüfen");
                }
                else if (SelectedCustomer.RegEx_Web(TxtWebsite.Text) == false)
                {
                    throw new ArgumentException("Bitte Webseite überprüfen");
                }

                else if (SelectedCustomer.RegEx_Password(PwdPassword.Password) == false)
                {
                    throw new ArgumentException("Passwort-Richtlinien \r\n" +
                        "min. 8 Zeichen \r\n" +
                        "min. 1 Buchstaben \r\n" +
                        "min. 1 Zahl \r\n" +
                        "min. 1 Sonderzeichen");
                }
                else
                {
                    
                    var city = _customerVM.GetCityByPLZ(Convert.ToInt32(TxtPLZ.Text));
                    if (city == null)
                    {
                        SelectedCustomer.City = new City() { PLZ = Convert.ToInt32(TxtPLZ.Text), CityName = TxtCity.Text };
                        _customerVM.AddCity(SelectedCustomer.City);
                    }
                    SelectedCustomer.City = _customerVM.GetCityByPLZ(Convert.ToInt32(TxtPLZ.Text));
                    SelectedCustomer.CityID = SelectedCustomer.City.CityID;
                    if (SelectedCustomer.CustomerID == 0)
                    {
                        _customerVM.AddCustomer(SelectedCustomer);
                    }
                    else
                    {
                        _customerVM.UpdateCustomer(SelectedCustomer);
                    }
                }
                Main.UpdateGrid();
                Close();
            }
            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message);
            }

        }
       
        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }

        private void TxtPLZ_KeyUp(object sender, KeyEventArgs e)
        {
            TxtCity.IsEnabled = true;
            TxtCity.Text = "";
            foreach (var City in Cities)
            {
                if (Convert.ToString(City.PLZ) == TxtPLZ.Text)
                {
                    TxtCity.Text = City.CityName;
                    TxtCity.IsEnabled = false;
                }
            }
        }
    }
}
