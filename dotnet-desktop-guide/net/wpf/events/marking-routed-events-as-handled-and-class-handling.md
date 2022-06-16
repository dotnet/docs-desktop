---
title: "Marking routed events as handled, and class handling"
description: Learn about class handling of routed events in Windows Presentation Foundation (WPF) and when to mark a routed event as handled.
ms.date: "03/21/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "tunneling events [WPF]"
  - "class listeners [WPF]"
  - "listeners [WPF]"
  - "Preview routed events [WPF]"
  - "instance listeners [WPF]"
  - "events [WPF], bubbling"
  - "suppressing events [WPF]"
  - "routed events [WPF], preview"
  - "composited controls [WPF]"
  - "events [WPF], tunneling"
  - "routed events [WPF], marking as handled"
  - "controls [WPF], compositing"
  - "events [WPF], suppressing"
  - "bubbling events [WPF]"
---
<!--The acrolinx score was 95 on 03/21/2022-->

# Marking routed events as handled, and class handling (WPF .NET)

Although there's no absolute rule for when to mark a routed event as handled, consider marking an event as handled if your code responds to the event in a significant way. A routed event that's marked as handled will continue along its route, but only handlers that are configured to respond to handled events are invoked. Basically, marking a routed event as handled limits its visibility to listeners along the event route.

Routed event handlers can be either instance handlers or class handlers. Instance handlers handle routed events on objects or XAML elements. Class handlers handle a routed event at a class level, and are invoked before any instance handler responding to the same event on any instance of the class. When routed events are marked as handled, they're often marked as such within class handlers. This article discusses the benefits and potential pitfalls of marking routed events as handled, the different types of routed events and routed event handlers, and event suppression in composite controls.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of routed events, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write Windows Presentation Foundation (WPF) applications.

## When to mark routed events as handled

Typically, only one handler should provide a significant response for each routed event. Avoid using the routed event system to provide a significant response across multiple handlers. The definition of what constitutes a significant response is subjective and depends on your application. As general guidance:

- Significant responses include setting focus, modifying public state, setting properties that affect visual representation, raising new events, and completely handling an event.
- Insignificant responses include modifying private state without visual or programmatic impact, event logging, and examining event data without responding to the event.

Some WPF controls suppress component-level events that don't need further handling by marking them as handled. If you want to handle an event that was marked as handled by a control, see [Working around event suppression by controls](#working-around-input-event-suppression).

To mark an event as _handled_, set the <xref:System.Windows.RoutedEventArgs.Handled%2A> property value in its event data to `true`. Although it's possible to revert that value to `false`, the need to do so should be rare.

## Preview and bubbling routed event pairs

[Preview](preview-events.md) and bubbling routed event pairs are specific to [input events](/dotnet/desktop/wpf/advanced/input-overview). Several input events implement a [tunneling](<xref:System.Windows.RoutingStrategy.Tunnel>) and [bubbling](<xref:System.Windows.RoutingStrategy.Bubble>) routed event pair, such as <xref:System.Windows.UIElement.PreviewKeyDown> and <xref:System.Windows.UIElement.KeyDown>. The `Preview` prefix signifies that the bubbling event starts once the preview event completes. Each preview and bubbling event pair shares the same instance of event data.

Routed event handlers are invoked in an order that corresponds to an event's routing strategy:

1. The preview event travels from the application root element down to the element that raised the routed event. Preview event handlers attached to the application root element get invoked first, followed by handlers attached to successive nested elements.
1. After the preview event completes, the paired bubbling event travels from the element that raised the routed event to the application root element. Bubbling event handlers attached to the same element that raised the routed event get invoked first, followed by handlers attached to successive parent elements.

Paired preview and bubbling events are part of the internal implementation of several WPF classes that declare and raise their own routed events. Without that class-level internal implementation, preview and bubbling routed events are entirely separate and won't share event data&mdash;regardless of event naming. For information about how to implement bubbling or tunneling input routed events in a custom class, see [Create a custom routed event](how-to-create-a-custom-routed-event.md).

Because each preview and bubbling event pair shares the same instance of event data, if a preview routed event is marked as handled then its paired bubbling event will also be handled. If a bubbling routed event is marked as handled, it won't affect the paired preview event because the preview event completed. Be careful when marking preview and bubbling input event pairs as handled. A handled preview input event won't invoke any normally registered event handlers for the remainder of the tunneling route, and the paired bubbling event won't be raised. A handled bubbling input event won't invoke any normally registered event handlers for the remainder of the bubbling route.

## Instance and class routed event handlers

Routed event handlers can be either _instance_ handlers or _class_ handlers. Class handlers for a given class are invoked before any instance handler responding to the same event on any instance of that class. Due to this behavior, when routed events are marked as handled, they're often marked as such within class handlers. There are two types of class handlers:

- [Static class event handlers](#static-class-event-handlers), which are registered by calling the <xref:System.Windows.EventManager.RegisterClassHandler%2A> method within a static class constructor.
- [Override class event handlers](#override-class-event-handlers), which are registered by overriding base class virtual event methods. Base class virtual event methods primarily exist for input events, and have names that start with **On\<event name\>** and **OnPreview\<event name\>**.

### Instance event handlers

You can attach instance handlers to objects or XAML elements by directly calling the <xref:System.Windows.UIElement.AddHandler%2A> method. WPF routed events implement a common language runtime (CLR) event wrapper that uses the `AddHandler` method to attach event handlers. Since XAML attribute syntax for attaching event handlers results in a call to the CLR event wrapper, even attaching handlers in XAML resolves to an `AddHandler` call. For handled events:

- Handlers that are attached using XAML attribute syntax or the common signature of `AddHandler` aren't invoked.
- Handlers that are attached using the <xref:System.Windows.UIElement.AddHandler%28System.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29> overload with the `handledEventsToo` parameter set to `true` are invoked. This overload is available for the rare cases when it's necessary to respond to handled events. For example, some element in an element tree has marked an event as handled, but other elements further along the event route need to respond to the handled event.

The following XAML sample adds a custom control named `componentWrapper`, which wraps a <xref:System.Windows.Controls.TextBox> named `componentTextBox`, to a <xref:System.Windows.Controls.StackPanel> named `outerStackPanel`. An instance event handler for the <xref:System.Windows.UIElement.PreviewKeyDown> event is attached to the `componentWrapper` using XAML attribute syntax. As a result, the instance handler will only respond to unhandled `PreviewKeyDown` tunneling events raised by the `componentTextBox`.

:::code language="xaml" source="./snippets/marking-routed-events-as-handled-and-class-handling/csharp/MainWindow.xaml" id="InstanceEventHandling":::

The `MainWindow` constructor attaches an instance handler for the `KeyDown` bubbling event to the `componentWrapper` using the <xref:System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)?displayProperty=nameWithType> overload, with the `handledEventsToo` parameter set to `true`. As a result, the instance event handler will respond to both unhandled and handled events.

:::code language="csharp" source="./snippets/marking-routed-events-as-handled-and-class-handling/csharp/MainWindow.xaml.cs" id="InstanceEventHandling":::
:::code language="vb" source="./snippets/marking-routed-events-as-handled-and-class-handling/vb/MainWindow.xaml.vb" id="InstanceEventHandling":::

The code-behind implementation of `ComponentWrapper` is shown in the next section.

### Static class event handlers

You can attach static class event handlers by calling the <xref:System.Windows.EventManager.RegisterClassHandler%2A> method in the static constructor of a class. Each class in a class hierarchy can register its own static class handler for each routed event. As a result, there can be multiple static class handlers invoked for the same event on any given node in the event route. When the event route for the event is constructed, all static class handlers for each node are added to the event route. The order of invocation of static class handlers on a node starts with the most-derived static class handler, followed by static class handlers from each successive base class.

Static class event handlers registered using the <xref:System.Windows.EventManager.RegisterClassHandler%28System.Type%2CSystem.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29> overload with the `handledEventsToo` parameter set to `true` will respond to both unhandled and handled routed events.

Static class handlers are typically registered to respond to unhandled events only. In which case, if a derived class handler on a node marks an event as handled, base class handlers for that event won't be invoked. In that scenario, the base class handler is effectively replaced by the derived class handler. Base class handlers often contribute to control design in areas such as visual appearance, state logic, input handling, and command handling, so be cautious about replacing them. Derived class handlers that don't mark an event as handled end up supplementing the base class handlers instead of replacing them.

The following code sample shows the class hierarchy for the `ComponentWrapper` custom control that was referenced in the preceding XAML. The `ComponentWrapper` class derives from the `ComponentWrapperBase` class, which in turn derives from the <xref:System.Windows.Controls.StackPanel> class. The `RegisterClassHandler` method, used in the static constructor of the `ComponentWrapper` and `ComponentWrapperBase` classes, registers a static class event handler for each of those classes. The WPF event system invokes the `ComponentWrapper` static class handler ahead of the `ComponentWrapperBase` static class handler.

:::code language="csharp" source="./snippets/marking-routed-events-as-handled-and-class-handling/csharp/MainWindow.xaml.cs" id="ClassEventHandling":::
:::code language="vb" source="./snippets/marking-routed-events-as-handled-and-class-handling/vb/MainWindow.xaml.vb" id="ClassEventHandling":::

The code-behind implementation of the override class event handlers in this code sample is discussed in the next section.

### Override class event handlers

Some visual element base classes expose empty **On\<event name\>** and **OnPreview\<event name\>** virtual methods for each of their public routed input events. For example, <xref:System.Windows.UIElement> implements the <xref:System.Windows.UIElement.OnKeyDown%2A> and <xref:System.Windows.UIElement.OnPreviewKeyDown%2A> virtual event handlers, and many others. You can override base class virtual event handlers to implement override class event handlers for your derived classes. For example, you can add an override class handler for the <xref:System.Windows.UIElement.DragEnter> event in any `UIElement` derived class by overriding the <xref:System.Windows.UIElement.OnDragEnter%2A> virtual method. Overriding base class virtual methods is a simpler way to implement class handlers than registering class handlers in a static constructor. Within the override, you can raise events, initiate class-specific logic to change element properties on instances, mark the event as handled, or perform other event handling logic.

Unlike static class event handlers, the WPF event system only invokes override class event handlers for the most derived class in a class hierarchy. The most derived class in a class hierarchy, can then use the [base](/dotnet/csharp/language-reference/keywords/base) keyword to call the base implementation of the virtual method. In most cases, you should call the base implementation, regardless of whether you mark an event as handled. You should only omit calling the base implementation if your class has a requirement to replace the base implementation logic, if any. Whether you call the base implementation before or after your overriding code depends on the nature of your implementation.

In the preceding code sample, the base class `OnKeyDown` virtual method is overridden in both the `ComponentWrapper` and `ComponentWrapperBase` classes. Since the WPF event system only invokes the `ComponentWrapper.OnKeyDown` override class event handler, that handler uses `base.OnKeyDown(e)` to call the `ComponentWrapperBase.OnKeyDown` override class event handler, which in turn uses `base.OnKeyDown(e)` to call the `StackPanel.OnKeyDown` virtual method. The order of events in the preceding code sample is:

1. The instance handler attached to `componentWrapper` is triggered by the `PreviewKeyDown` routed event.
1. The static class handler attached to `componentWrapper` is triggered by the `KeyDown` routed event.
1. The static class handler attached to `componentWrapperBase` is triggered by the `KeyDown` routed event.
1. The override class handler attached to `componentWrapper` is triggered by the `KeyDown` routed event.
1. The override class handler attached to `componentWrapperBase` is triggered by the `KeyDown` routed event.
1. The `KeyDown` routed event is marked as handled.
1. The instance handler attached to `componentWrapper` is triggered by the `KeyDown` routed event. The handler was registered with the `handledEventsToo` parameter set to `true`.

## Input event suppression in composite controls

Some composite controls suppress [input events](/dotnet/desktop/wpf/advanced/input-overview) at the component-level in order to replace them with a customized high-level event that carries more information or implies a more specific behavior. A composite control is by definition composed of multiple practical controls or control base classes. A classic example is the <xref:System.Windows.Controls.Button> control, which transforms various mouse events into a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> routed event. The `Button` base class is <xref:System.Windows.Controls.Primitives.ButtonBase>, which indirectly derives from <xref:System.Windows.UIElement>. Much of the event infrastructure needed for control input processing is available at the `UIElement` level. `UIElement` exposes several <xref:System.Windows.Input.Mouse> events such as <xref:System.Windows.UIElement.MouseLeftButtonDown> and <xref:System.Windows.UIElement.MouseRightButtonDown>. `UIElement` also implements the empty virtual methods <xref:System.Windows.UIElement.OnMouseLeftButtonDown%2A> and <xref:System.Windows.UIElement.OnMouseRightButtonDown%2A> as preregistered class handlers. `ButtonBase` overrides these class handlers, and within the override handler sets the <xref:System.Windows.RoutedEventArgs.Handled%2A> property to `true` and raises a `Click` event. The end result for most listeners is that the `MouseLeftButtonDown` and `MouseRightButtonDown` events are hidden, and the high-level `Click` event is visible.

### Working around input event suppression

Sometimes event suppression within individual controls can interfere with the event handling logic in your application. For example, if your application used XAML attribute syntax to attach a handler for the <xref:System.Windows.UIElement.MouseLeftButtonDown> event on the XAML root element, that handler won't be invoked because the <xref:System.Windows.Controls.Button> control marks the `MouseLeftButtonDown` event as handled. If you want elements toward the root of your application to be invoked for a handled routed event, you can either:

- Attach handlers by calling the <xref:System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)?displayProperty=nameWithType> method with the `handledEventsToo` parameter set to `true`. This approach requires attaching the event handler in code-behind, after obtaining an object reference for the element that it will attach to.

- If the event marked as handled is a bubbling input event, attach handlers for the paired preview event, if available. For example, if a control suppresses the `MouseLeftButtonDown` event, you can attach a handler for the <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> event instead. This approach only works for preview and bubbling input event pairs, which share event data. Be careful not to mark the `PreviewMouseLeftButtonDown` as handled since that would completely suppress the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event.

For an example of how to work around input event suppression, see [Working around event suppression by controls](preview-events.md#working-around-event-suppression-by-controls).

## See also

- <xref:System.Windows.EventManager>
- [Preview events](preview-events.md)
- [Create a custom routed event](how-to-create-a-custom-routed-event.md)
- [Routed events overview](routed-events-overview.md)
