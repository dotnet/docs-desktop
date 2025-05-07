using System.Diagnostics;
using System.Windows;

namespace CodeSampleCsharp
{
    internal static class Handler
    {
        public static void InstanceEventInfo(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"The instance handler attached to {senderName} " +
                $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}");
        }

        public static void ClassEventInfo_Static(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"The static class handler attached to {senderName} " +
                $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}");
        }

        public static void ClassEventInfo_Override(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name;
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"The override class handler attached to {senderName} " +
                $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}");
        }

        public static void ClassEventInfoBase_Static(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name + "Base";
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"The static class handler attached to {senderName} " +
                $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}");
        }

        public static void ClassEventInfoBase_Override(object sender, RoutedEventArgs e)
        {
            string senderName = ((FrameworkElement)sender).Name + "Base";
            string sourceName = ((FrameworkElement)e.Source).Name;
            string eventName = e.RoutedEvent.Name;
            string handledEventsToo = e.Handled ? " Parameter handledEventsToo set to true." : "";

            Debug.WriteLine($"The override class handler attached to {senderName} " +
                $"was triggered by the {eventName} routed event raised on {sourceName}.{handledEventsToo}");
        }
    }
}
