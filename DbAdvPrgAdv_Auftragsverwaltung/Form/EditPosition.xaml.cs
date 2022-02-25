using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Castle.Core.Internal;
using DbAdvPrgAdv_Auftragsverwaltung.Model;

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for EditPosition.xaml
    /// </summary>
    public partial class EditPosition : Window
    {
        public EditPosition(EditOrder main, Position selected)
        {
            InitializeComponent();
            Main = main;
            SelectedPosition = selected;
            this.DataContext = this;
            using (var context = new OrderContext())
            {
                Articles = context.Articles.ToList();
            }

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

        private void CmdSave_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new OrderContext())
            {
                SelectedPosition.ArticleID = context.Articles
                    .FirstOrDefault(x => x.Name == CmbArticle.Text)
                    .ArticleID;
                if (IsNew)
                {
                    context.Positions.Add(SelectedPosition);
                }
                else
                {
                    context.Positions.Update(SelectedPosition);
                }
                context.SaveChanges();
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
