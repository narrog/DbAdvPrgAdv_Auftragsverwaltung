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

namespace DbAdvPrgAdv_Auftragsverwaltung.Form
{
    /// <summary>
    /// Interaction logic for BearbeiteKunde.xaml
    /// </summary>
    public partial class BearbeiteKunde : Window
    {
        public BearbeiteKunde()
        {
            InitializeComponent();
        }

        private void CmdClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
