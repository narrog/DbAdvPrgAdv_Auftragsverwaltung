using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form {
    /// <summary>
    /// Interaction logic for EditArticle.xaml
    /// </summary>
    public partial class EditArticle : Window {
        private readonly ArticleVM _articleVM;
        public EditArticle(MainWindow mainWindow, Article selected) {
            InitializeComponent();
            Main = mainWindow;
            SelectedArticle = selected;
            this.DataContext = this;
            _articleVM = new ArticleVM();

            Groups = _articleVM.GetGroups();

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
                if (TxtName.Text != "" && CmbGroup.Text != "" && PriceParsed ) {

                    var groupID = _articleVM.GetGroupByName(CmbGroup.Text).GroupID;
                    SelectedArticle.Group = _articleVM.GetGroupByID(groupID);
                 
                    if (SelectedArticle.ArticleID == 0)
                    {
                        _articleVM.AddArticle(SelectedArticle);
                    }
                    else
                    {
                        SelectedArticle = _articleVM.GetArticleByID(SelectedArticle.ArticleID);
                        SelectedArticle.GroupID = groupID;
                        SelectedArticle.Name = TxtName.Text;
                        SelectedArticle.Price = Convert.ToDouble(TxtPrice.Text);
                        _articleVM.UpdateArticle(SelectedArticle);
                    }

                    Main.UpdateGrid();
                    Close();
                }
                else
                {
                    if (TxtName.Text == "") {
                        throw new ArgumentException("Bitte Name eingeben");
                    }
                    else if (!PriceParsed)
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
