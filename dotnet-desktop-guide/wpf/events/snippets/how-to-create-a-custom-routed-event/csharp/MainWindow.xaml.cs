using System.Diagnostics;
using System.Windows;

namespace CodeSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Assign an event handler to the CustomButton using the '+=' operator.
            // customButton.ConditionalClick += Handler_ConditionalClick;

            // Assign an event handler to the CustomButton using the AddHandler method.
            // customButton.AddHandler(WpfControl.CustomButton.ConditionalClickEvent,
            //   new RoutedEventHandler(Handler_ConditionalClick));

            // Assign an event handler to the StackPanel using the AddHandler method.
            // StackPanel1.AddHandler(WpfControl.CustomButton.ConditionalClickEvent, 
            //   new RoutedEventHandler(Handler_ConditionalClick));
        }

        //<EventHandler>
        // The ConditionalClick event handler.
        private void Handler_ConditionalClick(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;

            Debug.WriteLine($"Routed event handler attached to {senderName}, " +
                $"triggered by the ConditionalClick routed event raised on {sourceName}.");
        }

        // Debug output when CustomButton is clicked:
        // Routed event handler attached to CustomButton,
        //     triggered by the ConditionalClick routed event raised on CustomButton.
        // Routed event handler attached to StackPanel1,
        //     triggered by the ConditionalClick routed event raised on CustomButton.
        //</EventHandler>
    }
}
