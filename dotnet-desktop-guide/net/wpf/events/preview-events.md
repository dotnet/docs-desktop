---
title: "Preview events"
description: Learn about preview events in Windows Presentation Foundation (WPF) and how to use preview events for composite control event handling.
ms.date: "03/09/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Preview events [WPF]"
  - "suppressing events [WPF]"
  - "events [WPF], Preview"
  - "events [WPF], suppressing"
---
<!-- The acrolinx score was 96 on 03/09/2021-->

# Preview events (WPF .NET)

Preview events, also known as tunneling events, are routed events that traverse downward through the element tree from the application root element to the element that raised the event. The element that raises an event is reported as the <xref:System.Windows.RoutedEventArgs.Source> in the event data. Not all event scenarios support or require preview events. This article describes where preview events exist and how applications or components can interact with them. For information on how to create a preview event, see [How to create a custom routed event](how-to-create-a-custom-routed-event.md).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of routed events, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write Windows Presentation Foundation (WPF) applications.

## Preview events marked as handled

Be cautious when marking preview events as handled in event data. Marking a preview event as handled on an element other than the element that raised it can prevent the element that raised it from handling the event. Sometimes marking preview events as handled is intentional. For example, a composite control might suppress events raised by individual components and replace them with events raised by the complete control. Custom events for a control can provide customized event data and trigger based on component state relationships.

For [input events](/dotnet/desktop/wpf/advanced/input-overview), event data is shared by both the preview and non-preview (bubbling) equivalents of each event. If you use a preview event class-handler to mark an input event as handled, class-handlers for the bubbling input event typically won't be invoked. Or, if you use a preview event instance-handler to mark an event as handled, instance-handlers for the bubbling input event typically won't be invoked. Although you can configure class and instance handlers to be invoked even if an event is marked as handled, that handler configuration isn't common. For more information about class handling and how it relates to preview events, see [Marking routed events as handled and class handling](marking-routed-events-as-handled-and-class-handling.md).

> [!NOTE]
> Not all preview events are [tunneling](<xref:System.Windows.RoutingStrategy.Tunnel>) events. For example, the <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> input event follows a downward route through the element tree, but is a [direct](<xref:System.Windows.RoutingStrategy.Direct>) routed event that's raised and reraised by each <xref:System.Windows.UIElement> in the route.

## Working around event suppression by controls

Some composite controls suppress input events at the component-level in order to replace them with a customized high-level event. For example, the WPF <xref:System.Windows.Controls.Primitives.ButtonBase> marks the <xref:System.Windows.UIElement.MouseLeftButtonDown> bubbling input event as handled in its <xref:System.Windows.UIElement.OnMouseLeftButtonDown%2A> method and raises the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event. The `MouseLeftButtonDown` event and its event data still continue along the element tree route, but because the event is marked as <xref:System.Windows.RoutedEventArgs.Handled%2A> in event data, only handlers that are configured to respond to handled events are invoked.

If you want other elements toward the root of your application to handle a routed event that's marked as handled, you can either:

- Attach handlers by calling the <xref:System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)?displayProperty=nameWithType> method and setting the parameter `handledEventsToo` to `true`. This approach requires attaching the event handler in code-behind, after obtaining an object reference to the element that it will attach to.

- If the event marked as handled is a bubbling event, attach handlers for the equivalent preview event if available. For instance, if a control suppresses the <xref:System.Windows.UIElement.MouseLeftButtonDown> event, you can attach a handler for the <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> event instead. This approach only works for base element input events that implement both [tunneling](<xref:System.Windows.RoutingStrategy.Tunnel>) and [bubbling](<xref:System.Windows.RoutingStrategy.Bubble>) routing strategies and share event data.

The following example implements a rudimentary custom control named `componentWrapper` that contains a <xref:System.Windows.Controls.TextBox>. The control is added to a <xref:System.Windows.Controls.StackPanel> named `outerStackPanel`.

:::code language="xaml" source="./snippets/preview-events/csharp/MainWindow.xaml" id="CustomControlEventSuppression":::

The `componentWrapper` control listens for the <xref:System.Windows.UIElement.KeyDown> bubbling event raised by its `TextBox` component whenever a keystroke occurs. On that occurrence, the `componentWrapper` control:

1. Marks the `KeyDown` bubbling routed event as handled to suppress it. As a result, only the `outerStackPanel` handler that's configured in code-behind to respond to _handled_ `KeyDown` events is triggered. The `outerStackPanel` handler attached in XAML for `KeyDown` events isn't invoked.

1. Raises a custom bubbling routed event named `CustomKey`, which triggers the `outerStackPanel` handler for the `CustomKey` event.

:::code language="csharp" source="./snippets/preview-events/csharp/MainWindow.xaml.cs" id="EventSuppressionWorkarounds":::
:::code language="vb" source="./snippets/preview-events/vb/MainWindow.xaml.vb" id="EventSuppressionWorkarounds":::

The example demonstrates two workarounds for getting the suppressed `KeyDown` routed event to invoke an event handler attached to the `outerStackPanel`:

- Attach a <xref:System.Windows.UIElement.PreviewKeyDown> event handler to the `outerStackPanel`. Since a preview input routed event precedes the equivalent bubbling routed event, the `PreviewKeyDown` handler in the example runs ahead of the `KeyDown` handler that suppresses both preview and bubbling events through their shared event data.

- Attach a `KeyDown` event handler to the `outerStackPanel` by using the <xref:System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)?displayProperty=nameWithType> method in code-behind, with the `handledEventsToo` parameter set to `true`.

> [!NOTE]
> Marking preview or non-preview equivalents of input events as handled are both strategies for suppressing events raised by the components of a control. The approach you use depends on your application requirements.

## See also

- [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md)
- [Routed events overview](routed-events-overview.md)
- [How to create a custom routed event](how-to-create-a-custom-routed-event.md)
