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
    /// Interaction logic for BearbeiteGruppe.xaml
    /// </summary>
    public partial class BearbeiteGruppe : Window
    {
        public BearbeiteGruppe()
        {
            InitializeComponent();
        }

        private void CmdAbortGroup_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public MainWindow Main { get; set; }
        private void CmdSaveGroup_Click(object sender, RoutedEventArgs e)
        {
            var newGroup = new Gruppe() { Name = TxtNameGroup.Text };
            using (var context = new OrderContext())
            {
                context.Gruppen.Add(newGroup);
            }
            Main.UpdateGrid();
        }

        private void CmdDeleteGroup_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
