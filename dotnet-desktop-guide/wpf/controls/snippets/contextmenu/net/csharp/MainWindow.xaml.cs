using System.Windows;
using System.Windows.Controls;

namespace ContextMenuExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Menu_OnOpened(object sender, RoutedEventArgs e)
        {
            cmButton.Content = "The ContextMenu Opened";
        }

        private void Menu_OnClosed(object sender, RoutedEventArgs e)
        {
            cmButton.Content = "The ContextMenu Closed";
        }

        //<ProgrammaticContextMenu>
        private void CreateContextMenuProgrammatically()
        {
            Button button = new() { Content = "Created with C#" };
            ContextMenu contextMenu = new();
            button.ContextMenu = contextMenu;

            MenuItem fileMenuItem = new() { Header = "File" };
            MenuItem newMenuItem = new() { Header = "New" };
            fileMenuItem.Items.Add(newMenuItem);

            MenuItem openMenuItem = new() { Header = "Open" };
            fileMenuItem.Items.Add(openMenuItem);

            MenuItem recentlyOpenedMenuItem = new() { Header = "Recently Opened" };
            openMenuItem.Items.Add(recentlyOpenedMenuItem);

            MenuItem textFileMenuItem = new() { Header = "Text.xaml" };
            recentlyOpenedMenuItem.Items.Add(textFileMenuItem);

            contextMenu.Items.Add(fileMenuItem);

            // Add the button to your container (implementation depends on your layout)
            // containerPanel.Children.Add(button);
        }
        //</ProgrammaticContextMenu>
    }
}
