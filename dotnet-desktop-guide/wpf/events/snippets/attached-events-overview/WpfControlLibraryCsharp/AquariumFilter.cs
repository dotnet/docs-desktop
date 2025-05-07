using System.Windows;

namespace WpfControlCsharp
{
    //<AddRemoveHandlersForAttachedEvent>
    public class AquariumFilter
    {
        // Register a custom routed event using the bubble routing strategy.
        public static readonly RoutedEvent CleanEvent = EventManager.RegisterRoutedEvent(
            "Clean", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(AquariumFilter));

        // Provide an add handler accessor method for the Clean event.
        public static void AddCleanHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            if (dependencyObject is not UIElement uiElement)
                return;

            uiElement.AddHandler(CleanEvent, handler);
        }

        // Provide a remove handler accessor method for the Clean event.
        public static void RemoveCleanHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
        {
            if (dependencyObject is not UIElement uiElement)
                return;

            uiElement.RemoveHandler(CleanEvent, handler);
        }
    }
    //</AddRemoveHandlersForAttachedEvent>
}
