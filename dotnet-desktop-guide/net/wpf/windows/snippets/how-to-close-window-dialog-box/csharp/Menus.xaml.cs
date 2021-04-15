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
    /// Interaction logic for Menus.xaml
    /// </summary>
    public partial class Menus : Window
    {
        public Menus()
        {
            InitializeComponent();
        }

        // <CloseDialog>
        private void okButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = true;

        private void cancelButton_Click(object sender, RoutedEventArgs e) =>
            DialogResult = false;
        // </CloseDialog>

        // <CloseNormal>
        private void closeButton_Click(object sender, RoutedEventArgs e) =>
            Close();
        // </CloseNormal>

        // <Hide>
        private void saveButton_Click(object sender, RoutedEventArgs e) =>
            Hide();
        // </Hide>
    }
}
