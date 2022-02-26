using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for TreeViewWindow.xaml
    /// </summary>
    public partial class TreeViewWindow : Window
    {
        public TreeViewWindow() 
        {
            this.DataContext = this;
            InitializeComponent();

            var context = new OrderContext();
            var groups = context.GroupTree();

            
            List<TreeNodes> groupList = new List<TreeNodes>();

            var parents = groups.Where(x => x.ParentID == 0);

            foreach (var item in parents) {
                var childs = groups.Where(x => x.ParentID == item.GroupID);

                TreeNodes temp = new TreeNodes() { Name = item.Name };
                foreach (var childItem in childs) {
                    temp.Child.Add(new TreeChildNodes() { Name = childItem.Name });
                }
                groupList.Add(temp);
            }
            trvMenu.ItemsSource = groupList;

        }
    }

    public class TreeNodes {
        public TreeNodes() {
            this.Child = new ObservableCollection<TreeChildNodes>();
        }

        public string Name { get; set; }
        public int ID { get; set; }

        public ObservableCollection<TreeChildNodes> Child { get; set; }
    }

    public class TreeChildNodes {
        public string Name { get; set; }
        public int ID { get; set; }
    }
}
