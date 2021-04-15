using System;
using System.Windows;

namespace WindowsOverview
{
    public partial class CustomMediaPlayerWindow : Window
    {
        public CustomMediaPlayerWindow() =>
            InitializeComponent();

        private void Window_Activated(object sender, EventArgs e)
        {
            // Continue playing media if window is activated
            mediaElement.Play();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            // Pause playing if media is being played and window is deactivated
            mediaElement.Pause();
        }
    }
}
