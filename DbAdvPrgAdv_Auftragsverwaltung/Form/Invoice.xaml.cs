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
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for Invoice.xaml
    /// </summary>
    public partial class Invoice : Window
    {
        public Invoice()
        {
            this.DataContext = this;
            InitializeComponent();
            OrderList = new List<List<string>>();
            UpdateGrid();

            using (var context = new OrderContext())
            {
                Groups = context.Groups.ToList();
                Articles = context.Articles.ToList();
            }

            // CmbBox füllen
            foreach (var item in Groups)
            {
                CmbGroup.Items.Add((item.Name));
            }
            foreach (var item in Articles)
            {
                CmbArticle.Items.Add((item.Name));
            }

            DatePickerFrom.DisplayDateEnd = DateTime.Now;
            DatePickerTo.SelectedDate = DateTime.Now;
            DatePickerTo.DisplayDateEnd = DateTime.Now;

        }
        public List<Group> Groups { get; set; }
        public List<Article> Articles { get; set; }
        private List<Order> Orders { get; set; }
        private List<List<string>> OrderList { get; set; }
        private List<string> OrderDetails { get; set; }
        
        // wird für Filter benötigt
        private string CustomerName { get; set; }
        private string Group { get; set; }
        private string Article { get; set; }
        private DateTime DateFrom { get; set; }
        private DateTime DateTo { get; set; }


        private void CmdFilter_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerName = TxtNameCustomer.Text;
            Group = CmbGroup.Text;
            Article = CmbArticle.Text;
            
            
            DateTo = Convert.ToDateTime(DatePickerTo.Text);
            DateFrom = Convert.ToDateTime(DatePickerFrom.Text);

            // ToDo: Überprüfung ob DateFrom < DateTo ist

            MessageBox.Show(CustomerName + " " + Group + " " + Article + " " + DateFrom + " " + DateTo + " ");
        }

        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Tabelle befüllen
        public void UpdateGrid()
        {
            using (var context = new OrderContext())
            {
                Orders = context.Orders.ToList();
            }

            for (int i = 0; i < Orders.Count-15; i++)
            {
                OrderDetails = new List<string>();
                OrderDetails.Add(Convert.ToString(Orders[i].CustomerID));
                OrderDetails.Add(Convert.ToString(Orders[i].OrderDate));
                OrderDetails.Add(Convert.ToString(Orders[i].PriceTotal));
                OrderDetails.Add(Convert.ToString(Orders[i].PriceTotal*1.08));
                OrderList.Add(OrderDetails);
            }


            GrdInvoice.ItemsSource = OrderList;

        }

    }
}
