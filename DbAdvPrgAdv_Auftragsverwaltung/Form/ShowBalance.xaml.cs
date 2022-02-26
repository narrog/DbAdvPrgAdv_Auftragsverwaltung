using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for ShowBalance.xaml
    /// </summary>
    public partial class ShowBalance : Window
    {
        public ShowBalance()
        {
            InitializeComponent();
            UpdateGrid();
        }

        public void UpdateGrid()
        {
            using (var context = new OrderContext())
            {
                GrdBalance.ItemsSource = context.Orders.Include("Customer").Include("Positions").ToList();
            }
        }

        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
