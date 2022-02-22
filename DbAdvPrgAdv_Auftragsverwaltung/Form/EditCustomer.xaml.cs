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
        }
        public MainWindow Main { get; set; }
        private List<City> Cities { get; set; }
        public Customer SelectedCustomer { get; set; }

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                if (TxtPLZ.Text == "" || TxtCity.Text == "")
                {
                    throw new ArgumentException("Bitte einen City eingeben");
                }
                else
                {
                    SelectedCustomer.City = context.Cities
                        .FirstOrDefault(x => x.PLZ == SelectedCustomer.City.PLZ);
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
                        context.Customers.Update(SelectedCustomer);
                    }
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
