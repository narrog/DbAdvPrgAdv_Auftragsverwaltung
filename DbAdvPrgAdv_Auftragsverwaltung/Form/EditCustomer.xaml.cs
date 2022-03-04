using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        public EditCustomer(MainWindow mainWindow, Customer selected)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedCustomer = selected;
            this.DataContext = this;
            using (var context = new OrderContext())
            {
                Cities = context.Cities.ToList();
            }
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

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                try
                {
                    if (TxtPLZ.Text == "" || TxtCity.Text == "")
                    {
                        throw new ArgumentException("Bitte einen Ort eingeben");
                    }
                    else
                    {
                        // Kontrolle ob Ortschaft bereits vorhanden ist
                        SelectedCustomer.City = context.Cities
                            .FirstOrDefault(x => x.PLZ == SelectedCustomer.City.PLZ);
                        // -> Falls nicht, wird eine neue Ortschaft erstellt
                        if (SelectedCustomer.City == null)
                        {
                            SelectedCustomer.City = new City() { PLZ = Convert.ToInt32(TxtPLZ.Text), CityName = TxtCity.Text };
                        }

  

                        if (SelectedCustomer.CustomerID == 0)
                        {
                            context.Customers.Add(SelectedCustomer);
                        }
                        else
                        {
                            SelectedCustomer = context.Customers.Find(SelectedCustomer.CustomerID);

                            var existsCity = context.Cities
                                .FirstOrDefault(x => x.PLZ == Convert.ToInt32(TxtPLZ.Text));
                            if (existsCity == null)
                            {
                                SelectedCustomer.City = new City() { PLZ = Convert.ToInt32(TxtPLZ.Text), CityName = TxtCity.Text };
                            }
                            else
                            {
                                SelectedCustomer.CityID = existsCity.CityID;
                            }

                            SelectedCustomer.Name = TxtName.Text;
                            SelectedCustomer.Vorname = TxtVorname.Text;
                            SelectedCustomer.Adress = TxtAdress.Text;
                            SelectedCustomer.Email = TxtEMail.Text;
                            SelectedCustomer.Website = TxtWebsite.Text;
                            SelectedCustomer.Password = PwdPassword.Password;

                            context.Customers.Update(SelectedCustomer);
                        }
                    }
                }
                catch (ArgumentException arg)
                {
                    MessageBox.Show(arg.Message);
                }
                
                context.SaveChanges();
            }
            Main.UpdateGrid();
            Close();
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
