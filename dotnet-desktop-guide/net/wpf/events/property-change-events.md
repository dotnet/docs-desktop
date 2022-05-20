---
title: "Property change events"
description: Learn about the property changed events and property triggers in Windows Presentation Foundation (WPF).
ms.date: "04/07/2022"
helpviewer_keywords:
  - "dependency properties [WPF], change events"
  - "property value changes [WPF]"
  - "change events [WPF], property"
  - "events [WPF], change in property values"
  - "creating property triggers [WPF]"
  - "property change events [WPF], types of"
  - "property change events [WPF]"
  - "property triggers [WPF]"
  - "identifying changed property events [WPF]"
  - "property triggers [WPF], definition of"
---
<!-- The acrolinx score was 95 on 04/08/2022-->

# Property change events (WPF .NET)

Windows Presentation Foundation (WPF) defines several events that are raised in response to a change in the value of a property. Often the property is a dependency property. The event itself can be a routed event or a standard common language runtime (CLR) event, depending on whether the event should be routed through an element tree, or occur only on the object where the property changed. The latter scenario applies when a property change is only relevant to the object where the property value changed.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

This article assumes a basic knowledge of dependency properties, and that you've read [Routed events overview](routed-events-overview.md).

## Identifying a property changed event

Not all events that report a property change are explicitly identified as a property changed event through their signature or naming pattern. The SDK documentation cross-references properties with events and indicates whether an event is directly tied to a property value change.

Some events use an event data type and delegate that are specific to property changed events. For example, [RoutedPropertyChanged](#routedpropertychanged-events) and [DependencyPropertyChanged](#dependencypropertychanged-events) events each have specific signatures. These event types are discussed in the following sections.

### RoutedPropertyChanged events

RoutedPropertyChanged events have <xref:System.Windows.RoutedPropertyChangedEventArgs%601> event data and a <xref:System.Windows.RoutedPropertyChangedEventHandler%601> delegate. Both the event data and the delegate have a generic type parameter `T`. You specify the actual type of the changed property when you define the handler. The event data contains the <xref:System.Windows.RoutedPropertyChangedEventArgs%601.OldValue%2A> and <xref:System.Windows.RoutedPropertyChangedEventArgs%601.NewValue%2A> properties, whose runtime type is the same as the changed property.

The "Routed" part of the name indicates that the property changed event is registered as a routed event. The advantage of a property changed _routed_ event is that parent elements are notified whenever child element properties change. This means that the top-level element of a control receives property changed events when the value of any of its composite parts changes. For example, let's say you create a control that incorporates a <xref:System.Windows.Controls.Primitives.RangeBase> control, such as a <xref:System.Windows.Controls.Slider>. If the <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> property changes on the slider part, you can handle that change on the parent control rather than on the part.

Avoid using a property changed event handler to validate the property value, since that isn't the design intention for most property changed events. Generally, the property changed event is provided so that you can respond to the value change in other logic areas of your code. Changing the property value again from within the property changed event handler isn't advisable, and can cause unintentional recursion depending on your handler implementation.

If your property is a custom dependency property, or if you're working with a derived class where you've defined the instantiation code, the WPF property system has a better way to track property changes. That way is to use the built-in <xref:System.Windows.CoerceValueCallback> and <xref:System.Windows.PropertyChangedCallback> property system callbacks. For more information about how you can use the WPF property system for validation and coercion, see [Dependency property callbacks and Validation](../properties/dependency-property-callbacks-and-validation.md) and [Custom dependency properties](../properties/custom-dependency-properties.md).

### DependencyPropertyChanged events

DependencyPropertyChanged events have <xref:System.Windows.DependencyPropertyChangedEventArgs> event data and a <xref:System.Windows.DependencyPropertyChangedEventHandler> delegate. These events are standard CLR events, not routed events. `DependencyPropertyChangedEventArgs` is an unusual event data reporting type because it doesn't derive from <xref:System.EventArgs> and is a structure, not a class.

One example of a `DependencyPropertyChanged` event is <xref:System.Windows.UIElement.IsMouseCapturedChanged>. `DependencyPropertyChanged` events are slightly more common than `RoutedPropertyChanged` events.

Similar to RoutedPropertyChanged event data, DependencyPropertyChanged event data contains the <xref:System.Windows.RoutedPropertyChangedEventArgs%601.OldValue%2A> and <xref:System.Windows.RoutedPropertyChangedEventArgs%601.NewValue%2A> properties. For the reasons [mentioned previously](#routedpropertychanged-events), avoid using a property changed event handler to change the property value again.

## Property triggers

A closely related concept to a property changed event is a property trigger. A property trigger is created within a style or template. The property trigger lets you create a conditional behavior based on the value of the property to which the trigger is assigned.

The property on which a property trigger acts must be a dependency property. It can be, and frequently is, a read-only dependency property. If a dependency property exposed by a control has a name that begins with "Is", that's a good indicator that the property was at least partially designed to be a property trigger. Properties with this naming are often read-only <xref:System.Boolean> dependency properties, where the primary scenario for the property is reporting control state. If the control state affects the real-time UI, then the dependency property is a property trigger candidate.

Some dependency properties have a dedicated property changed event. For example, <xref:System.Windows.UIElement.IsMouseCaptured%2A> has the <xref:System.Windows.UIElement.IsMouseCapturedChanged> property changed event. The `IsMouseCaptured` property is read-only and its value is modified by the input system. The input system raises the `IsMouseCapturedChanged` event on each real-time change.

### Property trigger limitations

Compared to a true property changed event, property triggers have some limitations.

Property [triggers](<xref:System.Windows.Trigger>) work through an exact match logic, where you specify a property name and a specific value that will activate the trigger. An example is `<Setter Property="IsMouseCaptured" Value="true"> ... </Setter>`. The property trigger syntax limits most property trigger usages to <xref:System.Boolean> properties, or properties that take a dedicated enumeration value. The range of possible values must be manageable, so that you're able to define a trigger for each case. Sometimes property triggers exist only for special values, such as when an item count reaches zero. A single trigger can't be set to activate when a property value changes away from a specific value, such as zero. Instead of using multiple triggers for all nonzero cases, consider implementing a code event handler, or a default behavior that toggles back from the trigger state whenever the value is nonzero.

Property trigger syntax is analogous to an "if" statement in programming. If the trigger condition is true, then the "body" of the property trigger is "run". The "body" of a property trigger isn't code, its markup. That markup is limited to using one or more <xref:System.Windows.Setter> elements to set other properties of the object where the style or template is applied.

When the "if" condition of a property trigger has a wide variety of possible values, it's advisable to set that same property value to a default by using a `Setter` outside the trigger. That way, the setter within the trigger will have precedence when the trigger condition is `true`, otherwise the `Setter` outside the trigger will have precedence.

Property triggers are useful for scenarios where one or more appearance properties should change based on the state of another property on the same element.

To learn more about property triggers, see [Styling and Templating](/dotnet/desktop/wpf/controls/styles-templates-overview?view=netframeworkdesktop-4.8&preserve-view=true).

## See also

- [Routed events overview](routed-events-overview.md)
- [Dependency properties overview](../properties/dependency-properties-overview.md)
