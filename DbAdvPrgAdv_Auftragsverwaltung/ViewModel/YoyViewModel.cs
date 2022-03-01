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
        private List<Order> windowFuncResult;
        public YoyViewModel()
        {
            using(var context = new OrderContext())
            {
                WindowFuncResult = context.OrderYOY();
                Close = new CommandClose();
            }
        }
        public List<Order> WindowFuncResult
        { 
            get { return windowFuncResult; }
            set
            {
                windowFuncResult = value;
                OnProptertyChanged(nameof(WindowFuncResult));
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
