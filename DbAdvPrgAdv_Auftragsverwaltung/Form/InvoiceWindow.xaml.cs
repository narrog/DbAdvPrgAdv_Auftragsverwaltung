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
using Autofac;
using Castle.Core.Internal;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for InvoiceWindow.xaml
    /// </summary>
    public partial class InvoiceWindow : Window
    {
        private readonly InvoiceVM _invoiceVM;
        public InvoiceWindow()
        {
            
            InitializeComponent();
            this.DataContext = this;
            var container = BuildAutofacContainer();
            _invoiceVM = container.Resolve<InvoiceVM>();
            Invoices = _invoiceVM.GetInvoices();
            Groups = _invoiceVM.GetGroups();
            Articles = _invoiceVM.GetArticles();

            DatePickerFrom.DisplayDateEnd = DateTime.Now;
            DatePickerTo.SelectedDate = DateTime.Now;
            DatePickerTo.DisplayDateEnd = DateTime.Now;

        }
        public List<Group> Groups { get; set; }
        public List<Article> Articles { get; set; }
        public List<Invoice> Invoices { get; set; }

        
        // wird für Filter benötigt
        private string CustomerName { get; set; }
        private string Group { get; set; }
        private string Article { get; set; }
        private DateTime DateFrom { get; set; }
        private DateTime DateTo { get; set; }
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<InvoiceRepository>().As<IInvoiceRepository>();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<InvoiceVM>();
            return builder.Build();
        }

        private void CmdFilter_OnClick(object sender, RoutedEventArgs e)
        {
            DateTo = Convert.ToDateTime(DatePickerTo.Text);

            
            if (DatePickerFrom.Text.IsNullOrEmpty())
            {
                DateFrom = DateTime.MinValue;
            }
            else
            {
                if (DateTo > Convert.ToDateTime(DatePickerFrom.Text))
                {
                    DateFrom = Convert.ToDateTime(DatePickerFrom.Text);
                }
                else
                {
                    MessageBox.Show($"*Datum von* darf nicht grösser sein als *Datum bis* \r\n" +
                                    $"Bitte korrigieren, ansonsten wird 01.01.0001 verwendet!");
                }
            }
            //Invoices.Clear();
            Invoices = _invoiceVM.GetInvoicesByDates(dateFrom: DateFrom, dateTo: DateTo);
            GrdInvoice.ItemsSource = Invoices;

        }
        private void CmdClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
