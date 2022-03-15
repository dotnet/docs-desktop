using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CodeSampleCsharp
{
    //<EventSuppressionWorkarounds>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Attach a handler on outerStackPanel that will be invoked by handled KeyDown events.
            outerStackPanel.AddHandler(KeyDownEvent, new RoutedEventHandler(Handler_PrintEventInfo), 
                handledEventsToo: true);
        }

        private void ComponentWrapper_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Handler_PrintEventInfo(sender, e);

            Debug.WriteLine("KeyDown event marked as handled on componentWrapper.\r\n" +
                "CustomKey event raised on componentWrapper.");

            // Mark the event as handled.
            e.Handled = true;

            // Raise the custom click event.
            componentWrapper.RaiseCustomRoutedEvent();
        }

        private void Handler_PrintEventInfo(object sender, System.Windows.Input.KeyEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"Handler attached to {senderName} " +
                $"triggered by {eventName} event raised on {sourceName}.{handledEventsToo}");
        }

        private void Handler_PrintEventInfo(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"Handler attached to {senderName} " +
                $"triggered by {eventName} event raised on {sourceName}.{handledEventsToo}");
        }

        // Debug output:
        //
        // Handler attached to outerStackPanel triggered by PreviewKeyDown event raised on componentTextBox.
        // Handler attached to componentTextBox triggered by KeyDown event raised on componentTextBox.
        // Handler attached to componentWrapper triggered by KeyDown event raised on componentTextBox.
        // KeyDown event marked as handled on componentWrapper.
        // CustomKey event raised on componentWrapper.
        // Handler attached to componentWrapper triggered by CustomKey event raised on componentWrapper.
        // Handler attached to outerStackPanel triggered by CustomKey event raised on componentWrapper.
        // Handler attached to outerStackPanel triggered by KeyDown event raised on componentTextBox. Parameter handledEventsToo set to true.
    }

    public class ComponentWrapper : StackPanel
    {
        // Register a custom routed event using the Bubble routing strategy.
        public static readonly RoutedEvent CustomKeyEvent = 
            EventManager.RegisterRoutedEvent(
                name: "CustomKey",
                routingStrategy: RoutingStrategy.Bubble,
                handlerType: typeof(RoutedEventHandler),
                ownerType: typeof(ComponentWrapper));

        // Provide CLR accessors for assigning an event handler.
        public event RoutedEventHandler CustomKey
        {
            add { AddHandler(CustomKeyEvent, value); }
            remove { RemoveHandler(CustomKeyEvent, value); }
        }

        public void RaiseCustomRoutedEvent()
        {
            // Create a RoutedEventArgs instance.
            RoutedEventArgs routedEventArgs = new(routedEvent: CustomKeyEvent);

            // Raise the event, which will bubble up through the element tree.
            RaiseEvent(routedEventArgs);
        }
    }
    //</EventSuppressionWorkarounds>
}
