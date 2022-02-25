using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        public EditCustomer(VMMain viewModel, int id)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            ViewModel.Contr.SelectCustomer(id);
            InitializeComponent();
        }
        public VMMain ViewModel { get; set; }

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Contr.SaveCustomer();
            ViewModel.Contr.GetDatabase();
            Close();
        }
        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Contr.GetDatabase();
            Close();
        }

        private void TxtPLZ_KeyUp(object sender, KeyEventArgs e)
        {
            TxtCity.IsEnabled = true;
            TxtCity.Text = "";
            foreach (var City in ViewModel.Contr.Cities)
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
