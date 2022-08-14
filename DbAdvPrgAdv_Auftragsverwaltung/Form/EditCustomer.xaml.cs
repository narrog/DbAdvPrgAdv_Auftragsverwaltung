using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                try
                {
                    using (var context = new OrderContext())
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
                    else if (RegEx_Mail(TxtEMail.Text) == false)
                    {
                        throw new ArgumentException("Bitte E-Mail-Adresse überprüfen");
                    }
                    else if (RegEx_Web(TxtWebsite.Text) == false)
                    {
                        throw new ArgumentException("Bitte Webseite überprüfen");
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

                    context.SaveChanges();
                    }
                    Main.UpdateGrid();
                    Close();
                }
                catch (ArgumentException arg)
                {
                    MessageBox.Show(arg.Message);
                }

        }
        private bool RegEx_Mail(string input)
        {
            // string pattern = @"(?:[a-z0-9!#$%&'*+=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+=?^_`{|}~-]+)*|(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*)@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])/i";
            string pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(input);
            
            if (matches.Count > 0)
            {
                return true;
            }       

            return false;
        }
        private bool RegEx_Web(string input)
        {
            if (input == "")
            {
                return true;
            }
            else
            {
                string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

                Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(input);

                if (matches.Count > 0)
                {
                    return true;
                }

                return false;
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
