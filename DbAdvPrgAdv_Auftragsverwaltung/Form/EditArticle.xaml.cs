using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for EditArticle.xaml
    /// </summary>
    public partial class EditArticle : Window {
        public EditArticle(MainWindow mainWindow, Article selected) {
            InitializeComponent();
            Main = mainWindow;
            SelectedArticle = selected;
            this.DataContext = this;
            using (var context = new OrderContext())
            {
                Groups = context.Groups.ToList();
            }

            // CmbBox füllen
            foreach (var item in Groups) {
                CmbGroup.Items.Add((item.Name));
                if (item.Name == SelectedArticle.Group.Name)
                {
                    CmbGroup.SelectedItem = item.Name;
                }
            }
        }
        public MainWindow Main { get; set; }
        private List<Group> Groups { get; set; }
        public Article SelectedArticle { get; set; }

        private void CmdAbortArticle_OnClick(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }

        private void CmdSaveArticle_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                double Price;
                var PriceParsed = double.TryParse(TxtPrice.Text, out Price);
                if (CmbGroup.Text != "" && PriceParsed ) {
                    var groupID = Groups
                        .FirstOrDefault(x => x.Name.Equals(CmbGroup.Text))
                        .GroupID;
                    using (var context = new OrderContext())
                    {
                        SelectedArticle.Group = context.Groups
                            .FirstOrDefault(x => x.Name.Equals(CmbGroup.Text));
                        if (SelectedArticle.ArticleID == 0)
                        {
                            context.Articles.Add(SelectedArticle);
                        }
                        else
                        {
                            SelectedArticle = context.Articles.Find(SelectedArticle.ArticleID);
                            SelectedArticle.GroupID = groupID;
                            SelectedArticle.Name = TxtName.Text;
                            SelectedArticle.Price = Convert.ToDouble(TxtPrice.Text);
                            context.Articles.Update(SelectedArticle);
                        }
                        context.SaveChanges();
                    }
                    Main.UpdateGrid();
                    Close();
                }
                else
                {
                    if (!PriceParsed)
                    {
                        throw new ArgumentException("Bitte Preis als Zahl eingeben");
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
