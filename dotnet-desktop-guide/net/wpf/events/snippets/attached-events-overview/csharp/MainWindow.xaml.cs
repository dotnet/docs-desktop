using System.Windows;
using WpfControlCsharp;

namespace CodeSampleCsharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void RaiseCleanEvent_Click(object sender, RoutedEventArgs e)
        {
            // Raise the Clean routed event.
            //<RaiseAttachedEvent>
            aquarium1.RaiseEvent(new RoutedEventArgs(AquariumFilter.CleanEvent));
            //</RaiseAttachedEvent>
        }

        // The Clean attached event handler.
        void AquariumFilter_Clean(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            MessageBox.Show($"Handler attached to {senderName} " +
                $"was triggered by the {eventName} routed event raised on {sourceName}");
        }
    }
}
