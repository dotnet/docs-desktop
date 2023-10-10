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

namespace SDKSamples
{
    /// <summary>
    /// Interaction logic for NestedPumpScreenShot.xaml
    /// </summary>
    public partial class NestedPumpScreenShot : Window
    {
        public NestedPumpScreenShot()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click OK to close the window and stop blocking");
        }
    }
}
