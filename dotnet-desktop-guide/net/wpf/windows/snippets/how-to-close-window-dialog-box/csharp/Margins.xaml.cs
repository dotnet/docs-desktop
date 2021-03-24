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

namespace CloseWindows
{
    /// <summary>
    /// Interaction logic for Margins.xaml
    /// </summary>
    public partial class Margins : Window
    {
        public Margins()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        // <CancelAndHide>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Cancel the closure
            e.Cancel = true;

            // Hide the window
            Hide();
        }
        // </CancelAndHide>
    }
}
