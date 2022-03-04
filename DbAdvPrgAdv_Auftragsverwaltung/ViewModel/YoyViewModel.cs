using DbAdvPrgAdv_Auftragsverwaltung.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DbAdvPrgAdv_Auftragsverwaltung.ViewModel
{
    public class YoyViewModel : INotifyPropertyChanged
    {
        private List<Yoy> yoySales;
        private List<Yoy> yoyArticlePer;
        private List<Yoy> yoySum;
        private List<YoyCustomer> yoyCustomers;
        private List<Yoy> yoySumArticles;
        public YoyViewModel()
        {
            using(var context = new OrderContext())
            {
                YoySales = context.SoldArticlesYoy();
                YoyArticlePer = context.GetArticlesYoy();
                YoySum = context.GetSumYoy();
                YoyCustomers = context.GetSumCustomer();
                YoySumArticles = context.GetSumArticles();
                Close = new CommandClose();
            }
        }
        public List<Yoy> YoySales
        {
            get { return yoySales; }
            set
            {
                yoySales = value;
                OnProptertyChanged(nameof(YoySales));
            }
        }
        public List<Yoy> YoyArticlePer
        {
            get { return yoyArticlePer; }
            set
            {
                yoyArticlePer = value;
                OnProptertyChanged(nameof(YoyArticlePer));
            }
        }

        public List<Yoy> YoySum
        {
            get { return yoySum; }
            set
            {
                yoySum = value;
                OnProptertyChanged(nameof(YoySum));
            }
        }

        public List<YoyCustomer> YoyCustomers
        {
            get { return yoyCustomers; }
            set
            {
                yoyCustomers = value;
                OnProptertyChanged(nameof(YoyCustomers));
            }
        }

        public List<Yoy> YoySumArticles
        {
            get { return yoySumArticles; }
            set
            {
                yoySumArticles = value;
                OnProptertyChanged(nameof(YoySumArticles));
            }
        }
        public ICommand Close { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnProptertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
