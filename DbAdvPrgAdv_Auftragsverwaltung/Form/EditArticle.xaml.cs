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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for EditArticle.xaml
    /// </summary>
    public partial class EditArticle : Window {
        public EditArticle(MainWindow mainWindow, int selectedID) {
            InitializeComponent();
            Main = mainWindow;
            SelectedID = selectedID;

            using (var context = new OrderContext()) {
                var selected = context.Articles.Find(SelectedID);
                

                if (SelectedID != 0) {
                    TxtBezeichnung.Text = selected.Bezeichnung;
                    TxtPrice.Text = Convert.ToString(selected.Price);
                    GroupID = context.Articles.Find(SelectedID).GroupID;
                }

                // CmbBox füllen
                var kategorie = context.Groups;
                foreach (var item in kategorie) {
                    CmbGroup.Items.Add((item.Name));
                }
                if (GroupID != 0)
                {
                    // Kategorie anzeigen
                    var Group = context.Groups.Find(GroupID).Name;
                    CmbGroup.SelectedItem = Group;
                }
                
            }

        }
        public MainWindow Main { get; set; }
        private List<Group> Kategorien { get; set; }
        public int SelectedID { get; set; }
        public int GroupID { get; set; }

        private void CmdAbCityArticle_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmdSaveArticle_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double Price;
                var PriceParsed = double.TryParse(TxtPrice.Text, out Price);
                if (CmbGroup.Text != "" && PriceParsed ) {
                    using (var context = new OrderContext())
                    {
                        var kategorieID = context.Groups.Where(x => x.Name.Equals(CmbGroup.Text))
                            .FirstOrDefault()
                            .GroupID;
                        if (SelectedID == 0)
                        {

                            var Article = new Article()
                                { Bezeichnung = TxtBezeichnung.Text, Price = Price, GroupID = kategorieID };
                            context.Articles.Add(Article);
                        }
                        else
                        {
                            var Article = context.Articles.Where(x => x.ArticleID.Equals(SelectedID))
                                .FirstOrDefault();
                            Article.Bezeichnung = TxtBezeichnung.Text;
                            Article.Price = Convert.ToDouble(TxtPrice.Text);
                            Article.GroupID = kategorieID;
                        }

                        context.SaveChanges();

                        Main.UpdateGrid();
                        Close();
                    }
                }
                else
                {
                    if (!PriceParsed)
                    {
                        throw new ArgumentException("Bitte Price als Zahl eingeben");
                    }
                    else {
                        throw new ArgumentException("Bitte Kategorie auswählen.");
                    }
                }
            }

            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message);
            }
        }
    }
}
