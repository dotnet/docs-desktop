---
title: "Attached events overview"
description: Learn about attached events in Windows Presentation Foundation (WPF) and how to add a handler to an arbitrary element.
ms.date: "04/19/2022"
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "handling attached events [WPF]"
  - "defining attached events as routed events [WPF]"
  - "attached events [WPF], scenarios for"
  - "attached events vs. routed events [WPF]"
  - "backing attached events with routed events [WPF]"
  - "attached events [WPF], definition"
---
<!-- The acrolinx score was 99 on 04/19/2022-->

# Attached events overview (WPF .NET)

Extensible Application Markup Language (XAML) defines a language component and event type called an _attached event_. Attached events can be used to define a new [routed event](<xref:System.Windows.RoutedEvent>) in a non-element class and raise that event on any element in your tree. To do so, you must register the attached event as a routed event and provide specific [backing code](#define-a-custom-attached-event) that supports attached event functionality. Since attached events are registered as routed events, when raised on an element they propagate through the element tree.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of Windows Presentation Foundation (WPF) routed events, and that you've read [Routed events overview](routed-events-overview.md) and [XAML in WPF](../xaml/index.md). To follow the examples in this article, it helps if you're familiar with XAML and know how to write WPF applications.

## Attached event syntax

In XAML syntax, an attached event is specified by its event name _and_ its owner type, in the form of `<owner type>.<event name>`. Because the event name is qualified with the name of its owner type, the syntax allows the event to be attached to any element that can be instantiated. This syntax is also applicable to handlers for regular routed events that attach to an arbitrary element along the event route.

The following XAML attribute syntax attaches the `AquariumFilter_Clean` handler for the `AquariumFilter.Clean` attached event to the `aquarium1` element:

:::code language="xaml" source="./snippets/attached-events-overview/csharp/MainWindow.xaml" id="AttachEventHandlerInXaml":::

In this example, the `aqua:` prefix is necessary because the `AquariumFilter` and `Aquarium` classes exist in a different common language runtime (CLR) namespace and assembly.

You can also attach handlers for attached events in code behind. To do so, call the <xref:System.Windows.UIElement.AddHandler%2A> method on the object that the handler should attach to and pass the event identifier and handler as parameters to the method.

## How WPF implements attached events

WPF attached events are implemented as routed events backed by a <xref:System.Windows.RoutedEvent> field. As a result, attached events propagate through the element tree after they're raised. Generally, the object that raises the attached event, known as the event source, is a system or service source. System or service sources aren't a direct part of the element tree. For other attached events, the event source might be an element in the tree, such as a component within a composite control.

## Attached event scenarios

In WPF, attached events are used in certain feature areas where there's a service-level abstraction. For example, WPF makes uses of attached events enabled by the static <xref:System.Windows.Input.Mouse> or <xref:System.Windows.Controls.Validation> classes. Classes that interact with or use a service can either interact with an event using attached event syntax, or surface the attached event as a routed event. The latter option is part of how a class might integrate the capabilities of the service.

The WPF input system uses attached events extensively. However, nearly all of those attached events are surfaced as equivalent non-attached routed events through base elements. Each routed input event is a member of the base element class and is backed with a CLR event "wrapper". You'll rarely use or handle attached events directly. For instance, it's easier to handle the underlying attached <xref:System.Windows.Input.Mouse.MouseDown?displayProperty=nameWithType> event on a <xref:System.Windows.UIElement> through the equivalent <xref:System.Windows.UIElement.MouseDown?displayProperty=nameWithType> routed event than by using attached event syntax in XAML or code-behind.

Attached events serve an architecture purpose by enabling future expansion of input devices. For example, a new input device would only need to raise `Mouse.MouseDown` to simulate mouse input, and it wouldn't need to derive from `Mouse` to do so. That scenario involves code handling of the event, since XAML handling of the attached event wouldn't be relevant.

## Handle an attached event

The process for coding and handling an attached event is basically the same as for a non-attached routed event.

As noted [previously](#attached-event-scenarios), existing WPF attached events typically aren't intended to be directly handled in WPF. More often, the purpose of an attached event is to enable an element within a composite control to report its state to a parent element within the control. In that scenario, the event is raised in code and relies on class handling in the relevant parent class. For instance, items within a <xref:System.Windows.Controls.Primitives.Selector> are expected to raise the <xref:System.Windows.Controls.Primitives.Selector.Selected> attached event, which is then class handled by the `Selector` class. The `Selector` class potentially converts the `Selected` event into the <xref:System.Windows.Controls.Primitives.Selector.SelectionChanged> routed event. For more information about routed events and class handling, see [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md).

## Define a custom attached event

If you're deriving from common WPF base classes, you can implement your custom attached event by including two accessor methods in your class. Those methods are:

- An **Add\<event name\>Handler** method, with a first parameter that's the element on which the event handler is attached, and a second parameter that's the event handler to add. The method must be `public` and `static`, with no return value. The method calls the <xref:System.Windows.UIElement.AddHandler%2A> base class method, passing in the routed event and handler as arguments. This method supports the XAML attribute syntax for attaching an event handler to an element. This method also enables code access to the event handler store for the attached event.

- A **Remove\<event name\>Handler** method, with a first parameter that's the element on which the event handler is attached, and a second parameter that's the event handler to remove. The method must be `public` and `static`, with no return value. The method calls the <xref:System.Windows.UIElement.RemoveHandler%2A> base class method, passing in the routed event and handler as arguments. This method enables code access to the event handler store for the attached event.

WPF implements attached events as routed events because the identifier for a <xref:System.Windows.RoutedEvent> is defined by the WPF event system. Also, routing an event is a natural extension of the XAML language-level concept of an attached event. This implementation strategy restricts handling of attached events to either <xref:System.Windows.UIElement> derived classes or <xref:System.Windows.ContentElement> derived classes, because only those classes have <xref:System.Windows.UIElement.AddHandler%2A> implementations.

For example, the following code defines the `Clean` attached event on the `AquariumFilter` owner class, which isn't an element class. The code defines the attached event as a routed event and implements the required accessor methods.

:::code language="csharp" source="./snippets/attached-events-overview/WpfControlLibraryCsharp/AquariumFilter.cs" id="AddRemoveHandlersForAttachedEvent":::

:::code language="vb" source="./snippets/attached-events-overview/WpfControlLibraryVb/AquariumFilter.vb" id="AddRemoveHandlersForAttachedEvent":::

The <xref:System.Windows.EventManager.RegisterRoutedEvent%2A> method that returns the attached event identifier is the same method used to register non-attached routed events. Both attached and non-attached routed events are registered to a centralized internal store. This event store implementation enables the "events as an interface" concept that's discussed in [Routed events overview](routed-events-overview.md).

Unlike the CLR event "wrapper" used to back non-attached routed events, the attached event accessor methods can be implemented in classes that don't derive from <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement>. This is possible because the attached event backing code calls the <xref:System.Windows.UIElement.AddHandler%2A?displayProperty=nameWithType> and <xref:System.Windows.UIElement.RemoveHandler%2A?displayProperty=nameWithType> methods on a passed in `UIElement` instance. In contrast, the CLR wrapper for non-attached routed events calls those methods directly on the owning class, so that class must derive from `UIElement`.

## Raise a WPF attached event

The process for raising an attached event is essentially the same as for a non-attached routed event.

Typically, your code won't need to raise any existing WPF-defined attached events since those events follow the general "service" conceptual model. In that model, service classes, such as <xref:System.Windows.Input.InputManager>, are responsible for raising WPF-defined attached events.

When defining a custom attached event using the WPF model of basing attached events on [routed events](<xref:System.Windows.RoutedEvent>), use the <xref:System.Windows.UIElement.RaiseEvent%2A?displayProperty=nameWithType> method to raise an attached event on any <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement>. When raising a routed event, whether it's attached or not, you're required to designate an element in your element tree as the event source. That source is then reported as the `RaiseEvent` caller. For example, to raise the `AquariumFilter.Clean` attached routed event on `aquarium1`:

:::code language="csharp" source="./snippets/attached-events-overview/csharp/MainWindow.xaml.cs" id="RaiseAttachedEvent":::

:::code language="vb" source="./snippets/attached-events-overview/vb/MainWindow.xaml.vb" id="RaiseAttachedEvent":::

In the preceding example, `aquarium1` is the event source.

## See also

- [Routed events overview](routed-events-overview.md)
- [XAML syntax in detail](/dotnet/desktop/wpf/advanced/xaml-syntax-in-detail?view=netframeworkdesktop-4.8&preserve-view=true)
- [XAML and custom classes for WPF](/dotnet/desktop/wpf/advanced/xaml-and-custom-classes-for-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
