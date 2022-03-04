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
        public YoyViewModel()
        {
            using(var context = new OrderContext())
            {
                YoySales = context.Test();
                context.Test();
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
        public ICommand Close { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnProptertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
