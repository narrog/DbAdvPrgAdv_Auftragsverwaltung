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
        public EditGroup(MainWindow mainWindow, Group selected)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedGroup = selected;
            this.DataContext = this;

            using (var context = new OrderContext())
            {
                Groups = context.Groups.ToList();
            }

            // CmbBox füllen & falls nötig: übergeordnete Kategorie auswählen
            CmbGroupParent.Items.Add("");
            foreach (var item in Groups) {
                CmbGroupParent.Items.Add((item.Name));
                if (item.ParentID == SelectedGroup.ParentID && item.ParentID != 0)
                {
                    ParentName = Groups.FirstOrDefault(x => x.GroupID.Equals(SelectedGroup.ParentID)).Name;
                }
            }
            // Entfernen des aktuellen Items (Verhindert, dass Gruppe 1 die ParentGruppe 1 bekommt)
            CmbGroupParent.Items.Remove(SelectedGroup.Name);
        }

        public MainWindow Main { get; set; }
        public Group SelectedGroup { get; set; }
        public List<Group> Groups { get; set; }
        public string ParentName { get; set; }

        private void CmdAbortGroup_Click(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }
        

        private void CmdSaveGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // überprüft, ob eine übergeordnete Gruppe ausgewählt wurde, falls nicht, wird ParentID = 0
                int parentID;
                if (CmbGroupParent.Text != "")
                {
                    parentID = Groups
                        .FirstOrDefault(x => x.Name.Equals(CmbGroupParent.Text))
                        .GroupID;
                    int grandParentID = Convert.ToInt32(Groups
                        .FirstOrDefault(x => x.GroupID.Equals(parentID))
                        .ParentID);
                    if (grandParentID > 0)
                    {
                         throw new ArgumentException("Bitte Gruppe aus oberster Ebene wählen");
                    }
                }
                else
                {
                    parentID = 0;
                }

                using (var context = new OrderContext())
                {
                    // neuen Datensatz erstellen
                    if (SelectedGroup.GroupID == 0)
                    {
                        var newGroup = new Group() { Name = TxtNameGroup.Text, ParentID = parentID };
                        context.Groups.Add(newGroup);
                    }

                    // bestehnden Datensatz bearbeiten
                    else
                    {
                        SelectedGroup = context.Groups.Find(SelectedGroup.GroupID);

                        SelectedGroup.ParentID = parentID;
                        context.Groups.Update(SelectedGroup);
                    }
                    // Datensatz speichern
                    context.SaveChanges();
                }

                Main.UpdateGrid();
                Close();
            }
            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message);
            }
        }
    }
}
