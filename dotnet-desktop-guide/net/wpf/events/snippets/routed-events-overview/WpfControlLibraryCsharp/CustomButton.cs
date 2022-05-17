using System.Windows;
using System.Windows.Controls;

namespace WpfControl
{
    public class CustomButton : Button
    {
        //<RegisterRouteEventAndClrAccessors>
        // Register a custom routed event using the Bubble routing strategy.
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent(
            name: "Tap",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(CustomButton));

        // Provide CLR accessors for adding and removing an event handler.
        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }
        //</RegisterRouteEventAndClrAccessors>

        void RaiseCustomRoutedEvent()
        {
            // Create a RoutedEventArgs instance.
            RoutedEventArgs routedEventArgs = new(routedEvent: TapEvent);

            // Raise the event, which will bubble up through the element tree.
            RaiseEvent(routedEventArgs);
        }

        // For demo purposes, we use the Click event as a trigger.
        protected override void OnClick()
        {
            RaiseCustomRoutedEvent();

            // Call the base class OnClick() method so Click event subscribers are notified.
            base.OnClick();
        }
    }
}
