---
title: "Object lifetime events"
description: Learn about the object lifetime events for framework-level elements in Windows Presentation Foundation (WPF).
ms.date: "03/31/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "events [WPF], ContentRendered"
  - "events [WPF], Deactivated"
  - "events [WPF], Unloaded"
  - "Activated events [WPF]"
  - "events [WPF], Loaded"
  - "Application objects [WPF], lifetime events"
  - "events [WPF], Activated"
  - "ContentRendered events [WPF]"
  - "Deactivated events [WPF]"
  - "events [WPF], Initialized"
  - "events [WPF], Closing"
  - "Unloaded events [WPF]"
  - "exit events [WPF]"
  - "objects' lifetime events [WPF]"
  - "Loaded events [WPF]"
  - "Closing events [WPF]"
  - "events [WPF], Closed"
  - "Initialized events [WPF]"
  - "Closed events [WPF]"
  - "startup events [WPF]"
  - "lifetime events of objects [WPF]"
---
<!-- The acrolinx score was 96 on 03/31/2022-->

# Object lifetime events (WPF .NET)

During their lifetime, all objects in Microsoft .NET managed code go through _creation_, _use_, and _destruction_ stages. Windows Presentation Foundation (WPF) provides notification of these stages, as they occur on an object, by raising lifetime events. For WPF framework-level elements (visual objects), WPF implements the <xref:System.Windows.FrameworkElement.Initialized>, <xref:System.Windows.FrameworkElement.Loaded>, and <xref:System.Windows.FrameworkElement.Unloaded> lifetime events. Developers can use these lifetime events as hooks for code-behind operations that involve elements. This article describes the lifetime events for visual objects, and then introduces other lifetime events that specifically apply to window elements, navigation hosts, or application objects.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

This article assumes a basic knowledge of how WPF element layout can be conceptualized as a tree, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write WPF applications.

## Lifetime events for visual objects

WPF framework-level elements derive from <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>. The <xref:System.Windows.FrameworkElement.Initialized>, <xref:System.Windows.FrameworkElement.Loaded>, and <xref:System.Windows.FrameworkElement.Unloaded> lifetime events are common to all WPF framework-level elements. The following example shows an element tree that's primarily implemented in XAML. The XAML defines a parent <xref:System.Windows.Controls.Canvas> element that contains nested elements, which each use XAML attribute syntax to attach `Initialized`, `Loaded`, and `Unloaded` lifetime event handlers.

:::code language="xaml" source="./snippets/object-lifetime-events/csharp/MainWindow.xaml" id="LifetimeEventsXaml":::

One of the XAML elements is a custom control, which derives from a base class that assigns lifetime event handlers in code-behind.

:::code language="csharp" source="./snippets/object-lifetime-events/csharp/MainWindow.xaml.cs" id="LifetimeEventsCodeBehind":::
:::code language="vb" source="./snippets/object-lifetime-events/vb/MainWindow.xaml.vb" id="LifetimeEventsCodeBehind":::
  
The program output shows the order of invocation of `Initialized`, `Loaded`, and `Unloaded` lifetime events on each tree object. Those events are described in the following sections, in the order that they're raised on each tree object.

### Initialized lifetime event

The WPF event system raises the <xref:System.Windows.FrameworkElement.Initialized> event on an element:

- When the properties of the element are set.
- Around the same time that the object is initialized through a call to its constructor.

Some element properties, such as <xref:System.Windows.Controls.Panel.Children%2A?displayProperty=nameWithType>, can contain child elements. Parent elements can't report initialization until their child elements are initialized. So, property values are set starting with the most deeply nested element(s) in an element tree, followed by successive parent elements up to the application root. Since the `Initialized` event occurs when an element's properties are set, that event is first invoked on the most deeply nested element(s) as defined in markup, followed by successive parent elements up to the application root. When objects are dynamically created in code-behind, their initialization may be out of sequence.

The WPF event system doesn't wait for all elements in an element tree to be initialized before raising the `Initialized` event on an element. So, when you write an `Initialized` event handler for any element, keep in mind that surrounding elements in the logical or visual tree, particularly parent elements, may not have been created. Or, their member variables and data bindings might be uninitialized.

> [!NOTE]
> When the `Initialized` event is raised on an element, the element's expression usages, such as dynamic resources or binding, will be unevaluated.

### Loaded lifetime event

The WPF event system raises the <xref:System.Windows.FrameworkElement.Loaded> event on an element:

- When the logical tree that contains the element is complete and connected to a presentation source. The presentation source provides the window handle (HWND) and rendering surface.
- When data binding to local sources, such as other properties or directly defined data sources, is complete.
- After the layout system has calculated all necessary values for rendering.
- Before final rendering.

The `Loaded` event isn't raised on any element in an element tree until _all_ elements within the [logical tree](/dotnet/desktop/wpf/advanced/trees-in-wpf#the-purpose-of-the-logical-tree) are loaded. The WPF event system first raises the `Loaded` event on the root element of an element tree, then on each successive child element down to the most deeply nested element(s). Although this event might resemble a [tunneling](<xref:System.Windows.RoutingStrategy.Tunnel>) routed event, the `Loaded` event doesn't carry event data from one element to another, so marking the event as handled has no effect.

> [!NOTE]
> The WPF event system can't guarantee that asynchronous data bindings have completed before the `Loaded` event. Asynchronous data bindings bind to external or dynamic sources.

### Unloaded lifetime event

The WPF event system raises the <xref:System.Windows.FrameworkElement.Unloaded> event on an element:

- On removal of its presentation source, or
- On removal of its visual parent.

The WPF event system first raises the `Unloaded` event on the root element of an element tree, then on each successive child element down to the most deeply nested element(s). Although this event might resemble a [tunneling](<xref:System.Windows.RoutingStrategy.Tunnel>) routed event, the `Unloaded` event doesn't propagate event data from element to element, so marking the event as handled has no effect.

When the `Unloaded` event is raised on an element, it's [parent](<xref:System.Windows.FrameworkElement.Parent%2A>) element or any element higher in the logical or visual tree may have already been _unset_. Unset means that an element's data bindings, resource references, and styles are no longer set to their normal or last known run-time value.

## Other lifetime events

From the lifetime events perspective, there are four main types of WPF objects: elements in general, window elements, navigation hosts, and application objects. The <xref:System.Windows.FrameworkElement.Initialized>, <xref:System.Windows.FrameworkElement.Loaded>, and <xref:System.Windows.FrameworkElement.Unloaded> lifetime events apply to all framework-level elements. Other lifetime events specifically apply to window elements, navigation hosts, or application objects. For information about those other lifetime events, see:

- [Application management overview](/dotnet/desktop/wpf/app-development/application-management-overview?view=netframeworkdesktop-4.8&preserve-view=true) for <xref:System.Windows.Application> objects.
- [Overview of WPF windows](../windows/index.md) for <xref:System.Windows.Window> elements.
- [Navigation overview](/dotnet/desktop/wpf/app-development/navigation-overview?view=netframeworkdesktop-4.8&preserve-view=true) for <xref:System.Windows.Controls.Page>, <xref:System.Windows.Navigation.NavigationWindow>, and <xref:System.Windows.Controls.Frame> elements.

## See also

- <xref:System.Windows.FrameworkElement.Initialized>
- <xref:System.Windows.FrameworkElement.Loaded>
- <xref:System.Windows.FrameworkElement.Unloaded>
- [Handle a Loaded Event](/dotnet/desktop/wpf/advanced/how-to-handle-a-loaded-event?view=netframeworkdesktop-4.8&preserve-view=true)
- [The Loaded event and the Initialized event](/archive/blogs/mikehillberg/the-loaded-event-and-the-initialized-event)
- [Trees in WPF](/dotnet/desktop/wpf/advanced/trees-in-wpf)
- [Routed events overview](routed-events-overview.md)
