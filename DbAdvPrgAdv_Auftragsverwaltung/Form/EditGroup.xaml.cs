using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using Autofac;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditGroup.xaml
    /// </summary>
    public partial class EditGroup : Window
    {
        private readonly GroupVM _groupVM;
        public EditGroup(MainWindow mainWindow, Group selected)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedGroup = selected;
            this.DataContext = this;
            var container = BuildAutofacContainer();
            _groupVM = container.Resolve<GroupVM>();

            Groups = _groupVM.GetGroups();


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
        private static IContainer BuildAutofacContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<GroupVM>();
            return builder.Build();
        }
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

                
                // neuen Datensatz erstellen
                if (SelectedGroup.GroupID == 0)
                {
                    var newGroup = new Group() { Name = TxtNameGroup.Text, ParentID = parentID };
                    _groupVM.AddGroup(newGroup);
                }

                // bestehnden Datensatz bearbeiten
                else
                {
                    SelectedGroup = _groupVM.GetGroupByID(SelectedGroup.GroupID);

                    SelectedGroup.ParentID = parentID;
                    _groupVM.UpdateGroup(SelectedGroup);
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
