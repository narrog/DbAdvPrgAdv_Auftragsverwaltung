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
        private List<string> windowFuncResult;
        public YoyViewModel()
        {
            var testList = new List<string>();
            testList.Add("first");
            testList.Add("Second");
            WindowFuncResult = testList;
            Close = new CommandClose();
        }
        public List<string> WindowFuncResult
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
