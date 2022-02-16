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
    /// Interaction logic for BearbeiteGruppe.xaml
    /// </summary>
    public partial class BearbeiteGruppe : Window
    {
        public BearbeiteGruppe(MainWindow mainWindow, int selectedID)
        {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;

            using (var context = new OrderContext())
            {

                ParentGroupID = context.Gruppen.Find(SelectedID).ParentID;

                if (SelectedID != 0) {
                    var selected = context.Gruppen.Find(SelectedID);
                    TxtNameGroup.Text = selected.Name;
                }

                if (ParentGroupID != 0)
                {
                    // CmbBox füllen
                    var kategorie = context.Gruppen;
                    foreach (var item in kategorie) {
                        CmbGroupParent.Items.Add((item.Name));

                    }

                    // CmbBox Wert auswählen // gibt momentan aktuellen Wert aus
                    var parentGroup = context.Gruppen.Find(ParentGroupID).Name;
                    CmbGroupParent.SelectedItem = parentGroup;
                }
            }
        }

        public MainWindow Main { get; set; }
        public int SelectedID { get; set; }
        public int ParentGroupID { get; set; }

        private void CmdAbortGroup_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        

        private void CmdSaveGroup_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                var parentID = context.Gruppen.Where(x => x.Name.Equals(CmbGroupParent.Text))
                    .FirstOrDefault()
                    .GruppeID;
                if (SelectedID == 0)
                {
                    var newGroup = new Gruppe() { Name = TxtNameGroup.Text, ParentID = parentID };
                    context.Gruppen.Add(newGroup);
                }
                else
                {
                    var newGroup = context.Gruppen.Where(x => x.GruppeID.Equals(SelectedID)).FirstOrDefault();
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
