using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Autofac;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
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
            var container = BuildAutofacContainer();
            _articleVM = container.Resolve<ArticleVM>();

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
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>();
            builder.RegisterType<ArticleVM>();
            return builder.Build();
        }
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
                    SelectedArticle.Group = _articleVM
                        .GetGroupByID(Groups.FirstOrDefault(x => x.Name == CmbGroup.SelectedItem).GroupID);
                    SelectedArticle.GroupID = SelectedArticle.Group.GroupID;
                 
                    if (SelectedArticle.ArticleID == 0)
                    {
                        _articleVM.AddArticle(SelectedArticle);
                    }
                    else
                    {
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
