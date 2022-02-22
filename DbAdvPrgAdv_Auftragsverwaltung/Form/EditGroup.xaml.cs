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
using System.Windows.Input;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditGroup.xaml
    /// </summary>
    public partial class EditGroup : Window
    {
        public EditGroup(MainWindow mainWindow, int selectedID)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;

            using (var context = new OrderContext())
            {
                if (SelectedID != 0) {
                    var selected = context.Groups.Find(SelectedID);
                    TxtNameGroup.Text = selected.Name;
                    ParentGroupID = context.Groups.Find(SelectedID).ParentID;
                }
                // CmbBox füllen
                var kategorie = context.Groups;
                foreach (var item in kategorie) {
                    CmbGroupParent.Items.Add((item.Name));

                }
                
                // CmbBox Wert auswählen // gibt momentan aktuellen Wert aus
                if (ParentGroupID != 0)
                {
                    var parentGroup = context.Groups.Find(ParentGroupID).Name;
                    CmbGroupParent.SelectedItem = parentGroup;
                }
            }
        }

        public MainWindow Main { get; set; }
        public int SelectedID { get; set; }
        public int ParentGroupID { get; set; }

        private void CmdAbortGroup_Click(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }
        

        private void CmdSaveGroup_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                var parentID = context.Groups.Where(x => x.Name.Equals(CmbGroupParent.Text))
                    .FirstOrDefault()
                    .GroupID;
                if (SelectedID == 0)
                {
                    var newGroup = new Group() { Name = TxtNameGroup.Text, ParentID = parentID };
                    context.Groups.Add(newGroup);
                }
                else
                {
                    var newGroup = context.Groups.Where(x => x.GroupID.Equals(SelectedID)).FirstOrDefault();
                    newGroup.Name = TxtNameGroup.Text;
                    newGroup.ParentID = parentID;
                }

                context.SaveChanges();
            }
            
            Main.UpdateGrid();
            Close();
        }

    }
}
