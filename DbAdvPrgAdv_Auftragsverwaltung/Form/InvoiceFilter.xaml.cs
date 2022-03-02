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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for InvoiceFilter.xaml
    /// </summary>
    public partial class InvoiceFilter : Window
    {
        public InvoiceFilter(Invoice invoiceWindow)
        {
            InvoiceWindow = invoiceWindow;
            InitializeComponent();

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

        public Invoice InvoiceWindow { get; set; }
        public List<Group> Groups { get; set; }
        public List<Article> Articles { get; set; }

        private void CmdSetFilter_OnClick(object sender, RoutedEventArgs e)
        {
            InvoiceWindow.UpdateGrid();
            Close();
        }

        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
