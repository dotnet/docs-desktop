using System.Windows;
using System.Windows.Controls;

namespace AllTemplatesCS.Pages
{
    public partial class PopupPage : Page
    {
        public PopupPage()
        {
            InitializeComponent();
        }

        private void ShowBasicPopup_Click(object sender, RoutedEventArgs e)
        {
            BasicPopup.IsOpen = true;
        }

        private void ShowStyledPopup_Click(object sender, RoutedEventArgs e)
        {
            StyledPopup.IsOpen = true;
        }

        private void ShowControlsPopup_Click(object sender, RoutedEventArgs e)
        {
            ControlsPopup.IsOpen = true;
        }
    }
}
