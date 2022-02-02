using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfControl
{
    //<CustomButton>
    public class CustomButton : Button
    {
        // Register a custom routed event using the Bubble routing strategy.
        public static readonly RoutedEvent ConditionalClickEvent = EventManager.RegisterRoutedEvent(
            name: "ConditionalClick",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(RoutedEventHandler),
            ownerType: typeof(CustomButton));

        // Provide CLR accessors for assigning an event handler.
        public event RoutedEventHandler ConditionalClick
        {
            add { AddHandler(ConditionalClickEvent, value); }
            remove { RemoveHandler(ConditionalClickEvent, value); }
        }

        void RaiseCustomRoutedEvent()
        {
            // Create a RoutedEventArgs instance.
            RoutedEventArgs routedEventArgs = new(routedEvent: ConditionalClickEvent);

            // Raise the event, which will bubble up through the element tree.
            RaiseEvent(routedEventArgs);
        }

        // For demo purposes, we use the Click event as a trigger.
        protected override void OnClick()
        {
            // Some condition combined with the Click event will trigger the ConditionalClick event.
            if (DateTime.Now > new DateTime())
                RaiseCustomRoutedEvent();

            // Call the base class OnClick() method so Click event subscribers are notified.
            base.OnClick();
        }
    }
    //</CustomButton>
}
