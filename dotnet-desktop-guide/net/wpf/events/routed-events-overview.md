---
title: "Routed events overview"
description: Learn about routed events in Windows Presentation Foundation (WPF), including how they're routed through an element tree and how to create custom routed events.
ms.date: "04/29/2022"
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "attached events [WPF]"
  - "grouped button set [WPF]"
  - "routed events [WPF]"
  - "events [WPF], routed"
  - "tunneling [WPF]"
  - "events [WPF], attached"
  - "routing strategies for events [WPF]"
  - "button set [WPF], grouped"
  - "bubbling [WPF]"
---
<!-- The acrolinx score was 97 on 04/29/2022-->

# Routed events overview (WPF .NET)

Windows Presentation Foundation (WPF) application developers and component authors can use routed events to propagate events through an element tree, and invoke event handlers on multiple listeners in the tree. These features aren't found in common language runtime (CLR) events. Several WPF events are routed events, such as <xref:System.Windows.Controls.Primitives.ButtonBase.Click?displayProperty=nameWithType>. This article discusses basic routed event concepts and offers guidance on when and how to respond to routed events.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Prerequisites

This article assumes a basic knowledge of the common language runtime (CLR), object-oriented programming, and how [WPF element layout](../xaml/index.md) can be conceptualized as a tree. To follow the examples in this article, it helps if you're familiar with Extensible Application Markup Language (XAML) and know how to write [WPF applications](../get-started/create-app-visual-studio.md).

## What is a routed event?

You can consider routed events from a functional or implementation perspective:

- From a **functional** perspective, a routed event is a type of event that can invoke handlers on multiple listeners in an element tree, not just on the event source. An event listener is the element where an event handler is attached and invoked. An event source is the element or object that originally raised an event.

- From an **implementation** perspective, a routed event is an event registered with the WPF event system, backed by an instance of the <xref:System.Windows.RoutedEvent> class, and processed by the WPF event system. Typically, a routed event is implemented with a CLR event "wrapper" to enable attaching handlers in XAML and in code-behind as you would a CLR event.

WPF applications typically contain many elements, which were either declared in XAML or instantiated in code. An application's elements exists within its element tree. Depending on how a routed event is defined, when the event is raised on a source element it:

- Bubbles up through element tree from the source element to the root element, which is typically a page or window.
- Tunnels down through the element tree from the root element to the source element.
- Doesn't travel through the element tree, and only occurs on the source element.

Consider the following partial element tree:

:::code language="xaml" source="./snippets/routed-events-overview/csharp/MainWindow.xaml" id="YesNoCancelButtons":::

The element tree renders as shown:

:::image type="content" source="./media/routed-events-overview/yes-no-cancel.png" border="true" alt-text="Yes, No, and Cancel buttons.":::

Each of the three buttons is a potential <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event source. When one of the buttons is clicked, it raises the `Click` event that bubbles up from the button to the root element. The <xref:System.Windows.Controls.Button> and <xref:System.Windows.Controls.Border> elements don't have event handlers attached, but the <xref:System.Windows.Controls.StackPanel> does. Possibly other elements higher up in the tree that aren't shown also have `Click` event handlers attached. When the `Click` event reaches the `StackPanel` element, the WPF event system invokes the `YesNoCancelButton_Click` handler that's attached to it. The event route for the `Click` event in the example is: `Button` -> `StackPanel` -> `Border` -> successive parent elements.

> [!NOTE]
> The element that originally raised a routed event is identified as the <xref:System.Windows.RoutedEventArgs.Source?displayProperty=nameWithType> in the event handler parameters. The event listener is the element where the event handler is attached and invoked, and is identified as the [sender](xref:System.Windows.RoutedEventHandler) in the event handler parameters.

### Top-level scenarios for routed events

Here are some of the scenarios that motivated the routed event concept, and distinguish it from a typical CLR event:

- **Control composition and encapsulation**: Various controls in WPF have a rich content model. For example, you can place an image inside a <xref:System.Windows.Controls.Button>, which effectively extends the visual tree of the button. But, the added image mustn't break the hit-test behavior of the button, which needs to respond when a user clicks the image pixels.

- **Singular handler attachment points**: You could register a handler for each button's `Click` event, but with routed events you can attach a single handler as shown in the previous XAML example. This enables you to change the element tree under the singular handler, such as adding or removing more buttons, without having to register each button's `Click` event. When the `Click` event is raised, handler logic can determine where the event came from. The following handler, specified in the previously shown XAML element tree, contains that logic:

  :::code language="csharp" source="./snippets/routed-events-overview/csharp/MainWindow.xaml.cs" id="ButtonsParentHandler":::
  :::code language="vb" source="./snippets/routed-events-overview/vb/MainWindow.xaml.vb" id="ButtonsParentHandler":::

- **Class handling**: Routed events support a [class event handler](marking-routed-events-as-handled-and-class-handling.md#instance-and-class-routed-event-handlers) that you define in a class. Class handlers handle an event before any instance handlers for the same event on any instance of the class.

- **Referencing an event without reflection**: Each routed event creates a <xref:System.Windows.RoutedEvent> field identifier to provide a robust event identification technique that doesn't require static or run-time reflection to identify the event.

### How routed events are implemented

A routed event is an event registered with the WPF event system, backed by an instance of the <xref:System.Windows.RoutedEvent> class, and processed by the WPF event system. The `RoutedEvent` instance, obtained from [registration](<xref:System.Windows.EventManager.RegisterRoutedEvent%2A>), is typically stored as a `public static readonly` member of the class that registered it. That class is referred to as the event "owner" class. Typically, a routed event implements an identically named CLR event "wrapper". The CLR event wrapper contains `add` and `remove` accessors to enable attaching handlers in XAML and in code-behind through language-specific event syntax. The `add` and `remove` accessors override their CLR implementation and call the routed event <xref:System.Windows.UIElement.AddHandler%2A> and <xref:System.Windows.UIElement.RemoveHandler%2A> methods. The routed event backing and connection mechanism is conceptually similar to how a dependency property is a CLR property that's backed by the <xref:System.Windows.DependencyProperty> class and registered with the WPF property system.

The following example registers the `Tap` routed event, stores the returned `RoutedEvent` instance, and implements a CLR event wrapper.

:::code language="csharp" source="./snippets/routed-events-overview/WpfControlLibraryCsharp/CustomButton.cs" id="RegisterRouteEventAndClrAccessors":::
:::code language="vb" source="./snippets/routed-events-overview/WpfControlLibraryVb/CustomButton.vb" id="RegisterRouteEventAndClrAccessors":::

## Routing strategies

Routed events use one of three routing strategies:

- [**Bubbling**](<xref:System.Windows.RoutingStrategy.Bubble>): Initially, event handlers on the event source are invoked. The routed event then routes to successive parent elements, invoking their event handlers in turn, until it reaches the element tree root. Most routed events use the bubbling routing strategy. Bubbling routed events are generally used to report input or state changes from composite controls or other UI elements.

- [**Tunneling**](<xref:System.Windows.RoutingStrategy.Tunnel>): Initially, event handlers at the element tree root are invoked. The routed event then routes to successive child elements, invoking their event handlers in turn, until it reaches the event source. Events that follow a tunneling route are also referred to as [Preview](preview-events.md) events. WPF input events are generally implemented as a [preview and bubbling pairs](marking-routed-events-as-handled-and-class-handling.md#preview-and-bubbling-routed-event-pairs).

- [**Direct**](<xref:System.Windows.RoutingStrategy.Direct>): Only event handlers on the event source are invoked. This non-routing strategy is analogous to Windows Forms UI framework events, which are standard CLR events. Unlike CLR events, direct routed events support [class handling](#class-handlers) and can be used by [EventSetters](#eventsetters-and-eventtriggers) and [EventTriggers](#eventsetters-and-eventtriggers).

## Why use routed events?

As an application developer, you don't always need to know or care that the event you're handling is implemented as a routed event. Routed events have special behavior, but that behavior is largely invisible if you're handling an event on the element that raised it. However, routed events are relevant when you want to attach an event handler to a parent element in order to handle events raised by child elements, such as within a composite control.

Routed event listeners don't need the routed events they handle to be members of their class. Any <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement> can be an event listener for any routed event. Since visual elements derive from `UIElement` or `ContentElement`, you can use routed events as a conceptual "interface" that supports the exchange of event information between disparate elements in an application. The "interface" concept for routed events is particularly applicable to [input events](#wpf-input-events).

Routed events support the exchange of event information between elements along the event route because each listener has access to the same instance of event data. If one element changes something in the event data, that change is visible to subsequent elements in the event route.

Apart from the routing aspect, you might choose to implement a routed event instead of a standard CLR event for these reasons:

- Some WPF styling and templating features, such as [EventSetters](#eventsetters-and-eventtriggers) and [EventTriggers](#eventsetters-and-eventtriggers), require the referenced event to be a routed event.

- Routed events support [class event handlers](marking-routed-events-as-handled-and-class-handling.md) that handle an event ahead of any instance handlers for the same event on any instance of the listener class. This feature is useful in control design because your class handler can enforce event-driven class behaviors that can't be accidentally suppressed by an instance handler.

## Attach and implement a routed event handler

In XAML, you attach an event handler to an element by declaring the event name as an attribute on the event listener element. The attribute value is your handler method name. The handler method must be implemented in the code-behind partial class for the XAML page. The event listener is the element where the event handler is attached and invoked.

For an event that's a member (inherited or otherwise) of the listener class, you can attach a handler as follows:

:::code language="xaml" source="./snippets/routed-events-overview/csharp/MainWindow.xaml" id="AddHandler_UnqualifiedEventName":::

If the event isn't a member of the listener's class, you must use the qualified event name in the form of `<owner type>.<event name>`. For example, because the <xref:System.Windows.Controls.StackPanel> class doesn't implement the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event, to attach a handler to a `StackPanel` for a `Click` event that bubbles up to that element, you'll need to use the qualified event name syntax:

:::code language="xaml" source="./snippets/routed-events-overview/csharp/MainWindow.xaml" id="AddHandler_QualifiedEventName":::

The signature of the event handler method in code-behind must match the delegate type for the routed event. The `sender` parameter of the <xref:System.Windows.RoutedEventHandler> delegate for the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event specifies the element to which the event handler is attached. The `args` parameter of the `RoutedEventHandler` delegate contains the event data. A compatible code-behind implementation for the `Button_Click` event handler might be:

:::code language="csharp" source="./snippets/routed-events-overview/csharp/MainWindow.xaml.cs" id="ButtonClickHandler":::
:::code language="vb" source="./snippets/routed-events-overview/vb/MainWindow.xaml.vb" id="ButtonClickHandler":::

Although <xref:System.Windows.RoutedEventHandler> is the basic routed event handler delegate, some controls or implementation scenarios require different delegates that support more specialized event data. As an example, for the <xref:System.Windows.UIElement.DragEnter> routed event, your handler should implement the <xref:System.Windows.DragEventHandler> delegate. By doing so, your handler code can access the <xref:System.Windows.DragEventArgs.Data?displayProperty=nameWithType> property in event data, which contains the clipboard payload from the drag operation.

The XAML syntax for adding routed event handlers is the same as for standard CLR event handlers. For more information about adding event handlers in XAML, see [XAML in WPF](../xaml/index.md). For a complete example of how to attach an event handler to an element using XAML, see [How to handle a routed event](/dotnet/desktop/wpf/advanced/how-to-handle-a-routed-event?view=netframeworkdesktop-4.8&preserve-view=true).

To attach an event handler for a routed event to an element using code, you generally have two options:

- Directly call the <xref:System.Windows.UIElement.AddHandler%2A> method. Routed event handlers can always be attached this way. This example attaches a `Click` event handler to a button using the `AddHandler` method:

  :::code language="csharp" source="./snippets/routed-events-overview/csharp/MainWindow.xaml.cs" id="AddHandlerToButton":::
  :::code language="vb" source="./snippets/routed-events-overview/vb/MainWindow.xaml.vb" id="AddHandlerToButton":::

  To attach a handler for the button's `Click` event to a different element in the event's route, such as a <xref:System.Windows.Controls.StackPanel> named `StackPanel1`:

  :::code language="csharp" source="./snippets/routed-events-overview/csharp/MainWindow.xaml.cs" id="AddHandlerToStackPanel":::
  :::code language="vb" source="./snippets/routed-events-overview/vb/MainWindow.xaml.vb" id="AddHandlerToStackPanel":::

- If the routed event implements a CLR event wrapper, use language-specific event syntax to add event handlers just as you would for a standard CLR event. Most existing WPF routed events implement the CLR wrapper, thus enabling language-specific event syntax. This example attaches a `Click` event handler to a button using language specific syntax:

  :::code language="csharp" source="./snippets/routed-events-overview/csharp/MainWindow.xaml.cs" id="LanguageSpecificSyntax_ToAttachHandler":::
  :::code language="vb" source="./snippets/routed-events-overview/vb/MainWindow.xaml.vb" id="LanguageSpecificSyntax_ToAttachHandler":::

For an example of how to attach an event handler in code, see [How to add an event handler using code](how-to-add-an-event-handler-using-code.md). If you're coding in Visual Basic, you can also use the `Handles` keyword to add handlers as part of the handler declarations. For more information, see [Visual Basic and WPF event handling](visual-basic-and-wpf-event-handling.md).

### The concept of handled

All routed events share a common base class for event data, which is the <xref:System.Windows.RoutedEventArgs> class. The `RoutedEventArgs` class defines the boolean <xref:System.Windows.RoutedEventArgs.Handled%2A> property. The purpose of the `Handled` property is to let any event handler along the event route to mark the routed event as *handled*. To mark an event as handled, set the value of `Handled` to `true` in the event handler code.

The value of `Handled` affects how a routed event is processed as it travels along the event route. If `Handled` is `true` in the shared event data of a routed event, then handlers attached to other elements further along the event route typically won't be invoked for that particular event instance. For most common handler scenarios, marking an event as handled effectively stops subsequent handlers along the event route, whether instance or class handlers, from responding to that particular event instance. However, in rare cases where you need your event handler to respond to routed events that have been marked as handled, you can:

- Attach the handler in code-behind using the <xref:System.Windows.UIElement.AddHandler(System.Windows.RoutedEvent,System.Delegate,System.Boolean)> overload, with the `handledEventsToo` parameter set to `true`.

- Set the <xref:System.Windows.EventSetter.HandledEventsToo%2A> attribute in an `EventSetter` to `true`.

The concept of `Handled` might affect how you design your application and code your event handlers. You can conceptualize `Handled` as a simple protocol for processing of routed events. How you use this protocol is up to you, but the expected use of the `Handled` parameter is:

- If a routed event is marked as handled, then it doesn't need to be handled again by other elements along the route.

- If a routed event isn't marked as handled, then listeners earlier in the event route don't have a handler for the event, or none of the registered handlers responded to the event in a way that justifies marking the event as handled. Handlers on the current listener have three possible courses of action:

  - Take no action at all. The event remains unhandled and routes to the next listener in the tree.

  - Run code in response to the event, but not to an extent that justifies marking the event as handled. The event remains unhandled and routes to the next listener in the tree.

  - Run code in response to the event, to an extent that justifies marking the event as handled. Mark the event as handled in the event data. The event still routes to the next listener in the tree, but most listeners won't invoke further handlers. The exception is listeners with handlers that were specifically registered with `handledEventsToo` set to `true`.

For more information about handling routed events, see [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md).

Although developers who only handle a bubbling routed event on the object that raised it might not be concerned about other listeners, it's good practice to mark the event as handled anyway. Doing so prevents unanticipated side effects if an element further along the event route has a handler for the same routed event.

## Class handlers

Routed event handlers can be either *instance* handlers or *class* handlers. Class handlers for a given class are invoked before any instance handler responding to the same event on any instance of that class. Due to this behavior, when routed events are marked as handled, they're often marked as such within class handlers. There are two types of class handlers:

- [Static class event handlers](marking-routed-events-as-handled-and-class-handling.md#static-class-event-handlers), which are registered by calling the <xref:System.Windows.EventManager.RegisterClassHandler%2A> method within a static class constructor.
- [Override class event handlers](marking-routed-events-as-handled-and-class-handling.md#override-class-event-handlers), which are registered by overriding base class virtual event methods. Base class virtual event methods primarily exist for input events, and have names that start with **On\<event name\>** and **OnPreview\<event name\>**.

Some WPF controls have inherent class handling for certain routed events. Class handling might give the outward appearance that the routed event isn't ever raised, but in reality it's being marked as handled by a class handler. If you need your event handler to respond to the handled event, you can register your handler with `handledEventsToo` set to `true`. For more information, both on implementing your own class handlers or working around undesired class handling, see [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md).

## Attached events in WPF

The XAML language also defines a special type of event called an *attached event*. Attached events can be used to define a new [routed event](<xref:System.Windows.RoutedEvent>) in a non-element class and raise that event on any element in your tree. To do so, you must register the attached event as a routed event and provide specific [backing code](attached-events-overview.md#define-a-custom-attached-event) that supports attached event functionality. Since attached events are registered as routed events, when raised on an element they propagate through the element tree.

In XAML syntax, an attached event is specified by its event name *and* owner type, in the form of `<owner type>.<event name>`. Because the event name is [qualified](#qualified-event-names-in-xaml) with the name of its owner type, the syntax allows the event to be attached to any element that can be instantiated. This syntax is also applicable to handlers for regular routed events that attach to an arbitrary element along the event route. You can also attach handlers for attached events in code behind by calling the <xref:System.Windows.UIElement.AddHandler%2A> method on the object that the handler should attach to.

The WPF input system uses attached events extensively. However, nearly all of those attached events are surfaced as equivalent non-attached routed events through base elements. You'll rarely use or handle attached events directly. For instance, it's easier to handle the underlying attached <xref:System.Windows.Input.Mouse.MouseDown?displayProperty=nameWithType> event on a <xref:System.Windows.UIElement> through the equivalent <xref:System.Windows.UIElement.MouseDown?displayProperty=nameWithType> routed event than by using attached event syntax in XAML or code-behind.

For more information about attached events in WPF, see [Attached events overview](attached-events-overview.md).

## Qualified event names in XAML

The `<owner type>.<event name>` syntax qualifies an event name with the name of its owner type. This syntax allows an event to be attached to any element, not just elements that implement the event as a member of their class. The syntax is applicable when attaching handlers in XAML for [attached events](#attached-events-in-wpf) or routed events on arbitrary elements along the event route. Consider the scenario where you want to attach a handler to a parent element in order to handle routed events raised on child elements. If the parent element doesn't have the routed event as a member, you'll need to use the qualified event name syntax. For example:

:::code language="xaml" source="./snippets/routed-events-overview/csharp/MainWindow.xaml" id="AddHandler_QualifiedEventName":::

In the example, the parent element listener to which the event handler is added is a <xref:System.Windows.Controls.StackPanel>. However, the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> routed event is implemented and raised on the <xref:System.Windows.Controls.Primitives.ButtonBase> class, and available to the <xref:System.Windows.Controls.Button> class through inheritance. Although the <xref:System.Windows.Controls.Button> class "owns" the `Click` event, the routed event system permits handlers for any routed event to be attached to any <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement> instance listener that could otherwise have handlers for a CLR event. The default `xmlns` namespace for these qualified event attribute names is typically the default WPF `xmlns` namespace, but you can also specify prefixed namespaces for custom routed events. For more information about `xmlns`, see [XAML namespaces and namespace mapping for WPF XAML](/dotnet/desktop/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml?view=netframeworkdesktop-4.8&preserve-view=true).

## WPF input events

One frequent application of routed events within the WPF platform is for [input events](/dotnet/desktop/wpf/advanced/input-overview?view=netframeworkdesktop-4.8&preserve-view=true). By convention, WPF routed events that follow a tunneling route have a name that's prefixed with "Preview". The Preview prefix signifies that the preview event completes before the paired bubbling event starts. Input events often come in pairs, with one being a preview event and the other a bubbling routed event. For example, <xref:System.Windows.ContentElement.PreviewKeyDown> and <xref:System.Windows.ContentElement.KeyDown>. The event pairs share the same instance of event data, which for `PreviewKeyDown` and `KeyDown` is of type <xref:System.Windows.Input.KeyEventArgs>. Occasionally, input events only have a bubbling version, or only a direct routed version. In the API documentation, routed event topics cross-reference routed event pairs and clarify the routing strategy for each routed event.

WPF input events that come in pairs are implemented so that a single user action from an input device, such as a mouse button press, will raise the preview and bubbling routed events in sequence. First, the preview event is raised and completes its route. On completion of the preview event, the bubbling event is raised and completes its route. The <xref:System.Windows.UIElement.RaiseEvent%2A> method call in the implementing class that raises the bubbling event reuses the event data from the preview event for the bubbling event.

A preview input event that's marked as handled won't invoke any normally registered event handlers for the remainder of the preview route, and the paired bubbling event won't be raised. This handling behavior is useful for composite controls designers who want hit-test based input events or focus-based input events to be reported at the top-level of their control. Top-level elements of the control have the opportunity to class-handle preview events from control subcomponents in order to "replace" them with a top-level control-specific event.

To illustrate how input event processing works, consider the following input event example. In the following tree illustration, `leaf element #2` is the source of both the `PreviewMouseDown` and `MouseDown` paired events:

:::image type="content" source="./media/routed-events-overview/input-event-routing.png" border="true" alt-text="Event routing diagram.":::

The order of event processing following a mouse-down action on leaf element #2 is:

01. `PreviewMouseDown` tunneling event on the root element.
01. `PreviewMouseDown` tunneling event on intermediate element #1.
01. `PreviewMouseDown` tunneling event on leaf element #2, which is the source element.
01. `MouseDown` bubbling event on leaf element #2, which is the source element.
01. `MouseDown` bubbling event on intermediate element #1.
01. `MouseDown` bubbling event on the root element.

The routed event handler delegate provides references to both the object that raised the event and the object where the handler was invoked. The object that originally raised the event is reported by the <xref:System.Windows.RoutedEventArgs.Source%2A> property in the event data. The object where the handler was invoked is reported by the [sender](xref:System.Windows.RoutedEventHandler) parameter. For any given routed event instance, the object that raised the event doesn't change as the event travels through the element tree, but the `sender` does. In steps 3 and 4 of the preceding diagram, the `Source` and `sender` are the same object.

If your input event handler completes the application-specific logic needed to address the event, you should mark the input event as handled. Typically, once an input event is marked <xref:System.Windows.RoutedEventArgs.Handled%2A>, handlers further along the event route aren't invoked. However, input event handlers that are registered with the `handledEventsToo` parameter set to `true` will be invoked even when the event is marked as handled. For more information, see [Preview events](preview-events.md) and [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md).

The concept of preview and bubbling event pairs, with shared event data and sequential raising of the preview event then the bubbling event, applies only to some WPF input events and not to all routed events. If you implement your own input event to address an advanced scenario, consider following the WPF input event pair approach.

If you're implementing your own composite control that responds to input events, consider using preview events to suppress and replace input events raised on subcomponents with a top-level event that represents the complete control. For more information, see [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md).

For more information about the WPF input system and how inputs and events interact in typical application scenarios, see [Input overview](/dotnet/desktop/wpf/advanced/input-overview?view=netframeworkdesktop-4.8&preserve-view=true).

## EventSetters and EventTriggers

In markup styles, you can include pre-declared XAML event handling syntax by using an <xref:System.Windows.EventSetter>. When the XAML is processed, the referenced handler is added to the styled instance. You can only declare an `EventSetter` for a routed event. In the following example, the referenced `ApplyButtonStyle` event handler method is implemented in code-behind.

:::code language="xaml" source="./snippets/routed-events-overview/csharp/MainWindow.xaml" id="EventSetter":::

It's likely that the `Style` node already contains other style information that pertains to controls of the specified type, and having the <xref:System.Windows.EventSetter> be part of those styles promotes code reuse even at the markup level. Also, an `EventSetter` abstracts method names for handlers away from the general application and page markup.

Another specialized syntax that combines the routed event and animation features of WPF is an <xref:System.Windows.EventTrigger>. As with the `EventSetter`, you can only declare an `EventTrigger` for a routed event. Typically, an `EventTrigger` is declared as part of a style, but an `EventTrigger` can be declared on page-level elements as part of the <xref:System.Windows.FrameworkElement.Triggers%2A> collection, or in a <xref:System.Windows.Controls.ControlTemplate>. An `EventTrigger` enables you to specify a <xref:System.Windows.Media.Animation.Storyboard> that runs whenever a routed event reaches an element in its route that declares an `EventTrigger` for that event. The advantage of an `EventTrigger` over just handling the event and causing it to start an existing storyboard is that an `EventTrigger` provides better control over the storyboard and its run-time behavior. For more information, see [Use event triggers to control a storyboard after it starts](/dotnet/desktop/wpf/graphics-multimedia/how-to-use-event-triggers-to-control-a-storyboard-after-it-starts?view=netframeworkdesktop-4.8&preserve-view=true).

## More about routed events

You can use the concepts and guidance in this article as a starting point when creating custom routed events in your own classes. You can also support your custom events with specialized event data classes and delegates. A routed event owner can be any class, but routed events must be raised by and handled by <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement> derived classes in order to be useful. For more information about custom events, see [Create a custom routed event](how-to-create-a-custom-routed-event.md).

## See also

- <xref:System.Windows.EventManager>
- <xref:System.Windows.RoutedEvent>
- <xref:System.Windows.RoutedEventArgs>
- [Marking routed events as handled, and class handling](marking-routed-events-as-handled-and-class-handling.md)
- [Input overview](/dotnet/desktop/wpf/advanced/input-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [Commanding overview](/dotnet/desktop/wpf/advanced/commanding-overview?view=netframeworkdesktop-4.8&preserve-view=true)
- [Custom dependency properties](../properties/custom-dependency-properties.md)
- [Trees in WPF](/dotnet/desktop/wpf/advanced/trees-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
- [Weak event patterns](weak-event-patterns.md)
