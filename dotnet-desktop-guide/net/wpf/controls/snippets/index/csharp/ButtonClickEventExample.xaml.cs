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

namespace Examples
{
    /// <summary>
    /// Interaction logic for ButtonClickEventExample.xaml
    /// </summary>
    public partial class ButtonClickEventExample : Window
    {
        public ButtonClickEventExample()
        {
            InitializeComponent();
        }

        // <ClickHandler>
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Someone clicked the submit button.");
        }
        // </ClickHandler>

    }
}
