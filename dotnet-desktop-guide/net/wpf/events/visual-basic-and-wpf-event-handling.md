---
title: Handle events in Visual Basic
description: Learn how to attach handlers to Windows Presentation Foundation (WPF) routed events in Visual Basic.
ms.date: "02/25/2022"
helpviewer_keywords:
  - "Visual Basic [WPF], event handlers"
  - "event handlers [WPF], Visual Basic"
---
<!-- The acrolinx score was 100 on 02/25/2021-->

# Visual Basic and WPF event handling (WPF .NET)

If you're coding in Visual Basic .NET, you can use the language-specific [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword to attach an event handler to an object. The object can be defined in Extensible Application Markup Language (XAML) or code-behind. `Handles` can be used to assign event handlers for common language runtime (CLR) events or [routed events](/dotnet/desktop/wpf/advanced/routed-events-overview?view=netframeworkdesktop-4.8&preserve-view=true) in Windows Presentation Foundation (WPF). Unlike using XAML attribute syntax or the <xref:System.Windows.UIElement.AddHandler%2A> method, `Handles` has [limitations](#limitations) when used to attach handlers for routed events.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Syntax

The syntax for a `Sub` declaration that uses the [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword is: `Sub <procedure name> Handles <object name>.<event name>`. That syntax designates the procedure as the event handler that will run when an event specified by `<event name>` occurs on an object specified by `<object name>`.

For an event on an object defined in code-behind, typically you declare the object using the [WithEvents](/dotnet/visual-basic/language-reference/modifiers/withevents) keyword. For more information on `WithEvents` usage, see these [examples](/dotnet/visual-basic/language-reference/statements/handles-clause#example-1). WPF automatically declares XAML elements using `WithEvents`.

To use the same handler for multiple events, comma-separate the `<object name>.<event name>` events. For example: `Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles Button1.Click, Button2.Click`. The comma-separated events can be in any order.

You can assign different handlers for the same event with multiple `Handles` statements. The order of the `Handles` statements doesn't determine the order in which handlers are invoked when the event occurs.

To remove a handler that was added with `Handles` in the declaration, call <xref:System.Windows.UIElement.RemoveHandler%2A>. For example: `RemoveHandler Button1.Click, AddressOf Button1_Click`.

## Using 'Handles' in a WPF application

For an object defined in XAML, the [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) event syntax `<object name>.<event name>` requires the XAML element (which represents an object) to have a <xref:System.Windows.FrameworkContentElement.Name%2A> or [x:Name](/dotnet/desktop/xaml-services/xname-directive) property. However, a name property isn't required for the XAML page root element, in which case the name can be `Me`. For example, `Sub EventHandler() Handles Me.Loaded`.

When a XAML page is compiled, every XAML element with a <xref:System.Windows.FrameworkContentElement.Name%2A> or [x:Name](/dotnet/desktop/xaml-services/xname-directive) parameter is declared as `Friend WithEvents`. As a result, each element can be used by [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) without a further [WithEvents](/dotnet/visual-basic/language-reference/modifiers/withevents) declaration.

Regardless of whether an event handler is attached using `Handles`, XAML attribute syntax, the AddHandler statement, or the <xref:System.Windows.UIElement.AddHandler%2A> method, the event system behavior is the same.

> [!NOTE]
> Within Visual Studio, IntelliSense can show you which elements are available for use with `Handles`.

## Limitations

The [Handles](/dotnet/visual-basic/language-reference/statements/handles-clause) keyword has these usage [limitations](#limitations):

- You can only use `Handles` to attach an event handler to an object if the event is a member of the object's class or base class. For example, you can use `Handles` to attach a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler to a button that raises the `Click` routed event. However, one of the features of routed events is that they traverse the element tree, and sometimes it's useful to listen for and handle a `Click` event at a higher level than the element that raised it. A routed event that a parent element listens for and handles is called an _attached event_. `Handles` can't be used for attached events because its syntax doesn't support specifying a different listener in the XAML element tree than the element that raised the event. To assign event handlers for attached events, you'll need to use XAML attribute syntax or the <xref:System.Windows.UIElement.AddHandler%2A> method. For more information on attached events, see [Attached events overview](/dotnet/desktop/wpf/advanced/attached-events-overview?view=netframeworkdesktop-4.8&preserve-view=true) and [Attached events in WPF](/dotnet/desktop/wpf/advanced/routed-events-overview?view=netframeworkdesktop-4.8&preserve-view=true#attached-events-in-wpf).

- `Handles` syntax doesn't support specifying that an event handler will be invoked for events that are marked as <xref:System.Windows.RoutedEventArgs.Handled>. To enable that behavior, attach the event handler using <xref:System.Windows.UIElement.AddHandler%28System.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29> and set the `handledEventsToo` parameter to `true`.

> [!NOTE]
> Don't use both XAML attributes and `Handles` to attach the same event handler to the same event, otherwise the event handler will get called twice for each event.

## See also

- <xref:System.Windows.UIElement.AddHandler%2A>
- [Marking routed events as handled, and class handling](/dotnet/desktop/wpf/advanced/marking-routed-events-as-handled-and-class-handling?view=netframeworkdesktop-4.8&preserve-view=true)
- [Routed events overview](/dotnet/desktop/wpf/advanced/routed-events-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [Attached events overview](/dotnet/desktop/wpf/advanced/attached-events-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [XAML in WPF](/dotnet/desktop/wpf/advanced/xaml/index?view=netframeworkdesktop-4.8&preserve-view=true)
