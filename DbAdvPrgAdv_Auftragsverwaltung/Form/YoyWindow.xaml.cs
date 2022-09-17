using Autofac;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for YoyWindow.xaml
    /// </summary>
    public partial class YoyWindow : Window
    {
        public YoyWindow()
        {
            var container = BuildAutofacContainer();
            DataContext = container.Resolve<YoyViewModel>();
            InitializeComponent();
        }
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<YoyRepository>().As<IYoyRepository>();
            builder.RegisterType<YoyViewModel>();
            return builder.Build();
        }
    }
}
