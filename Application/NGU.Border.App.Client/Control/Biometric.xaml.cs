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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NGU.App.Client.Control
{
    /// <summary>
    /// Interaction logic for Biometric.xaml
    /// </summary>
    public partial class Biometric : UserControl
    {
        public Biometric()
        {
            DataContext = this;
            InitializeComponent();
        }

        //public HandsViewModel MyProperty { get; set; }
    }
}
