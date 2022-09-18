using Autofac;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
using Microsoft.EntityFrameworkCore;
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
using System.Xml.Serialization;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for ExportCustomer.xaml
    /// </summary>
    public partial class ExportCustomer : Window
    {
        private readonly ExportCustomerVM _exportCustomerVM;
        public ExportCustomer(MainWindow main)
        {
            Main = main;
            InitializeComponent();
            TemporalDate = DateTime.Now;
            this.DataContext = this;
            var container = BuildAutofacContainer();
            _exportCustomerVM = container.Resolve<ExportCustomerVM>();
        }
        public DateTime TemporalDate { get; set; }
        public MainWindow Main { get; set; }
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CityRepository>().As<ICityRepository>();
            builder.RegisterType<ExportCustomerVM>();
            return builder.Build();
        }
        private void CmdExportXML_Click(object sender, RoutedEventArgs e)
        {
            _exportCustomerVM.ExportXML(TemporalDate);
            Close();
        }
        private void CmdExportJSON_Click(object sender, RoutedEventArgs e)
        {
            _exportCustomerVM.ExportJSON(TemporalDate);
            Close();
        }
        private void CmdImportXML_Click(object sender, RoutedEventArgs e)
        {
            _exportCustomerVM.ImportXML();
            Main.UpdateGrid();
            Close();
        }
        private void CmdImportJSON_Click(object sender, RoutedEventArgs e)
        {
            _exportCustomerVM.ImportJSON();
            Main.UpdateGrid();
            Close();
        }
    }
}
