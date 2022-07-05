---
title: Visual Basic and WPF event handling
description: Learn how to attach handlers to Windows Presentation Foundation (WPF) routed events in Visual Basic.
ms.date: "02/25/2022"
helpviewer_keywords:
  - "Visual Basic [WPF], event handlers"
  - "event handlers [WPF], Visual Basic"
---
<!-- The acrolinx score was 100 on 02/25/2021-->

# Visual Basic and WPF event handling (WPF .NET)

If you're coding in Visual Basic .NET, you can use the language-specific [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword to attach an event handler to an object. The object can be an instance in code-behind or an element in Extensible Application Markup Language (XAML). `Handles` can be used to assign event handlers for common language runtime (CLR) events or Windows Presentation Foundation (WPF) [routed events](routed-events-overview.md). However, `Handles` has some usage [limitations](#limitations) when used to attach event handlers for routed events.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

The article assumes a basic knowledge of routed events, and that you've read [Routed events overview](routed-events-overview.md). To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write Windows Presentation Foundation (WPF) applications.

## Syntax

The syntax for a `Sub` declaration that uses the [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword is: `Sub <procedure name> Handles <object name>.<event name>`. That syntax designates a procedure as the event handler that will run when an event specified by `<event name>` is raised on an object specified by `<object name>`. The event must be a member of the object's class or base class. The following example shows how to attach an event handler to a XAML element using `Handles`.

:::code language="vb" source="./snippets/visual-basic-and-wpf-event-handling/vb/MainWindow.xaml.vb" id="XamlButton_Click":::

To use `Handles` with an object defined in code-behind, typically you declare the object using the [WithEvents](/dotnet/visual-basic/language-reference/modifiers/withevents) keyword. For more information on `WithEvents` usage, see these [examples](/dotnet/visual-basic/language-reference/statements/handles-clause#example-1). WPF automatically declares all XAML elements using `Friend WithEvents`. The following example shows how to declare an object defined in code-behind using `WithEvents`.

:::code language="vb" source="./snippets/visual-basic-and-wpf-event-handling/vb/MainWindow.xaml.vb" id="CodeButton_Click":::

To use the same handler for multiple events, comma-separate the `<object name>.<event name>` events. For example, `Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles Button1.Click, Button2.Click`. The order of the comma-separated events is immaterial.

You can assign different handlers for the same event with multiple `Handles` statements. The order of the `Handles` statements doesn't determine the order in which handlers are invoked when the event occurs.

> [!TIP]
> To remove a handler that was added with `Handles`, call [RemoveHandler](/dotnet/visual-basic/language-reference/statements/removehandler-statement). For example, `RemoveHandler Button1.Click, AddressOf Button1_Click`.

## Using 'Handles' in a WPF application

For an object defined in XAML, the [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) event syntax `<object name>.<event name>` requires the XAML element that represents the object to have a <xref:System.Windows.FrameworkContentElement.Name%2A> or [x:Name](/dotnet/desktop/xaml-services/xname-directive) property. However, a name property isn't required for the XAML page root element, for which you can use the name `Me`. The following example shows how to attach an event handler to an XAML page root using `Handles`.

:::code language="vb" source="./snippets/visual-basic-and-wpf-event-handling/vb/MainWindow.xaml.vb" id="Window_Loaded":::

When a XAML page is compiled, every XAML element with a `Name` or `x:Name` parameter is declared as `Friend WithEvents`. As a result, you can use any XAML element with `Handles`.

> [!TIP]
> Visual Studio IntelliSense shows the objects that can be used with `Handles`.

Regardless whether you attach an event handler using `Handles`, XAML attribute syntax, the [AddHandler](/dotnet/visual-basic/language-reference/statements/addhandler-statement) statement, or the <xref:System.Windows.UIElement.AddHandler%2A> method, the event system behavior is the same.

> [!NOTE]
> Don't use both XAML attributes and `Handles` to attach the same event handler to the same event, otherwise the event handler will get called twice for each event.

## Limitations

The [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword has these usage limitations:

- You can only use `Handles` to attach an event handler to an object if the event is a member of the object's class or base class. For example, you can use `Handles` to attach a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler to a button whose base class <xref:System.Windows.Forms.ButtonBase> raises the `Click` routed event. However, one of the features of [routed events](routed-events-overview.md) is that they traverse the element tree, which makes it possible to listen for and handle a `Click` event at a higher level than the element that raised it. A routed event that a parent element listens for and handles is called an _attached event_. `Handles` can't be used for attached events because its syntax doesn't support specifying a different listener in the XAML element tree than the element that raised the event. To assign event handlers for attached events, you'll need to use either XAML attribute syntax or the <xref:System.Windows.UIElement.AddHandler%2A> method. For more information on attached events, see [Attached events overview](attached-events-overview.md) and [Attached events in WPF](routed-events-overview.md#attached-events-in-wpf).

- `Handles` syntax doesn't support event handler invocation for <xref:System.Windows.RoutedEventArgs.Handled> events. To enable your event handler to be invoked for `Handled` events, attach the event handler using the <xref:System.Windows.UIElement.AddHandler%28System.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29> method and set its `handledEventsToo` parameter to `true`.

## See also

- <xref:System.Windows.UIElement.AddHandler%2A>
- [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md)
- [Routed events overview](routed-events-overview.md)
- [Attached events overview](attached-events-overview.md)
- [XAML in WPF](/dotnet/desktop/wpf/xaml)
