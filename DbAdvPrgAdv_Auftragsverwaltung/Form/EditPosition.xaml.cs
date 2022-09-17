using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autofac;
using Castle.Core.Internal;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using DbAdvPrgAdv_Auftragsverwaltung.Repository;
using DbAdvPrgAdv_Auftragsverwaltung.ViewModel;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditPosition.xaml
    /// </summary>
    public partial class EditPosition : Window
    {
        private readonly PositionVM _positionVM;

        public EditPosition(EditOrder main, Position selected, bool isNew)
        {
            InitializeComponent();
            Main = main;
            SelectedPosition = selected;
            IsNew = isNew;
            this.DataContext = this;
            var container = BuildAutofacContainer();
            _positionVM = container.Resolve<PositionVM>();

            Articles = _positionVM.GetAllArticles();

            // CmbBox Articles füllen
            foreach (var item in Articles)
            {
                CmbArticle.Items.Add(item.Name);
                if (item.ArticleID == SelectedPosition.ArticleID)
                {
                    CmbArticle.SelectedItem = item.Name;
                }
            }
        }
        public EditOrder Main { get; set; }
        public Position SelectedPosition { get; set; }
        public List<Article> Articles { get; set; }
        public bool IsNew { get; set; }
        private static IContainer BuildAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PositionRepository>().As<IPositionRepository>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<PositionVM>();
            return builder.Build();
        }
        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            SelectedPosition.Article = _positionVM.GetArticleById(Articles.FirstOrDefault(x => x.Name == CmbArticle.Text).ArticleID);
            SelectedPosition.Order = _positionVM.GetOrderById(SelectedPosition.OrderID);
            SelectedPosition.ArticleID = SelectedPosition.Article.ArticleID;
            SelectedPosition.OrderID = SelectedPosition.Order.OrderID;
            
            if (IsNew)
            {
                _positionVM.AddPosition(SelectedPosition);
            }
            else
            {
                _positionVM.UpdatePosition(SelectedPosition);
            }

            Main.UpdateGrid();
            Close();
        }

        private void CmdAbort_Click(object sender, RoutedEventArgs e)
        {
            Main.UpdateGrid();
            Close();
        }
        private void CmbArticle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbArticle.Text != "" && !Articles.IsNullOrEmpty())
            {
                TxtPrice.Text = Convert.ToString(Articles
                    .FirstOrDefault(x => x.Name == CmbArticle.Text)
                    .Price);
            }
        }
    }
}
