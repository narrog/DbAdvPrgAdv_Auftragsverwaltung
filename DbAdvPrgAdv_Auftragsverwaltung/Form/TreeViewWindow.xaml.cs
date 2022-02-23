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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for TreeViewWindow.xaml
    /// </summary>
    public partial class TreeViewWindow : Window {
        public TreeViewWindow() {
            InitializeComponent();

            var context = new OrderContext();
            var org = context.GroupTree();
            //MessageBox.Show(org.Result.ToString());
            
        }
    }
}
