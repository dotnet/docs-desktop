using System.Windows;

namespace WindowsOverview
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //<YesNoCancel>
            string messageBoxText = "Do you want to save changes?";
            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            //<MessageBoxShow>
            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            //</YesNoCancel>

            switch (result)
            {
                case MessageBoxResult.Cancel:
                    // User pressed Cancel
                    break;
                case MessageBoxResult.Yes:
                    // User pressed Yes
                    break;
                case MessageBoxResult.No:
                    // User pressed No
                    break;
            }
            //</MessageBoxShow>
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Message to display to the user", "Window caption", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
        }

        private void Alert_Click(object sender, RoutedEventArgs e)
        {
            //<AlertSimple>
            MessageBox.Show("Unable to save file, try again.");
            //</AlertSimple>
            //<Alert>
            MessageBox.Show("Unable to save file, try again.", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            //</Alert>
        }

        private void Warning_Click(object sender, RoutedEventArgs e)
        {
            //<Warning>
            MessageBox.Show("If you close the next window without saving, your changes will be lost.", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            //</Warning>
        }

        private void Prompt_Click(object sender, RoutedEventArgs e)
        {
            //<Prompt>
            if (MessageBox.Show("If the file save fails, do you want to automatically try again?",
                                "Save file",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // Do something here
            }
            //</Prompt>
        }
    }
}
