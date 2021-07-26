---
title: How to add or remove an event handler
description: Learn how to create an event handler for a control at design-time with the Windows Forms Designer in Visual Studio or at run-time.
ms.date: 07/16/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Windows Forms, event handling"
  - "event handlers [Windows Forms], creating"
  - "run time [Windows Forms], creating event handlers at"
  - "examples [Windows Forms], event handling"
  - "Button control [Windows Forms], event handlers"
  - "events [Windows Forms], connecting multiple to single event handler"
  - "event handlers [Windows Forms], connecting events to"
  - "menus [Windows Forms], event-handling methods for multiple menu items"
  - "Windows Forms controls, events"
  - "menu items [Windows Forms], multicasting event-handling methods"
---

# How to handle a control event (Windows Forms .NET)

Events for controls (and for forms) are generally set through the Visual Studio Visual Designer for Windows Forms. Setting an event through the Visual Designer is known as handling an event at design-time. You can also handle events dynamically in code, known as handling events at run-time. An event created at run-time allows you to connect event handlers dynamically based on what your app is currently doing.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Handle an event - designer

In Visual Studio, use the Visual Designer to manage handlers for control events. The Visual Designer will generate the handler code and add it to the event for you.

### Set the handler

Use the **Properties** pane to add or set the handler of an event:

01. Open the Visual Designer of the form containing the control to change.
01. Select the control.
01. Change the **Properties** pane mode to **Events** by pressing the events button (:::image type="icon" source="../media/shared/visual-studio-events-button.png" border="false":::).
01. Find the event you want to add a handler to, for example, the **Click** event:

    :::image type="content" source="media/how-to-add-an-event-handler/visual-studio-properties-events-click.png" alt-text="Visual Studio properties pane shown with the events mode enabled and the click event.":::

01. Do one of the following:

    - Double-click the event to generate a new handler, it's blank if no handler is assigned. If it's not blank, this action opens the code for the form and navigates to the existing handler.

    - Use the selection box (:::image type="icon" source="../media/shared/visual-studio-chevron-button.png" border="false":::) to choose an existing handler.
  
      The selection box will list all methods that have a compatible method signature for the event handler.

### Clear the handler

To remove an event handler, you can't just delete handler code that is in the form's code-behind file, it's still referenced by the event. Use the **Properties** pane to remove the handler of an event:

01. Open the Visual Designer of the form containing the control to change.
01. Select the control.
01. Change the **Properties** pane mode to **Events** by pressing the events button (:::image type="icon" source="../media/shared/visual-studio-events-button.png" border="false":::).
01. Find the event containing the handler you want to remove, for example, the **Click** event:

    :::image type="content" source="media/how-to-add-an-event-handler/visual-studio-properties-events-click.png" alt-text="Visual Studio properties pane shown with the events mode enabled and the click event.":::

01. Right-click on the event and choose **Reset**.

## Handle an event - code

You typically add event handlers to controls at design-time through the Visual Designer. You can, though, create controls at run-time, which requires you to add event handlers in code. Adding handlers in code also gives you the chance to add multiple handlers to the same event.

### Add a handler

The following example shows how to create a control and add an event handler. This control is created in the [`Button.Click`](xref:System.Windows.Forms.Control.Click) event handler a different button. When **Button1** is pressed. The code moves and sizes a new button. The new button's `Click` event is handled by the `MyNewButton_Click` method. To get the new button to appear, it's added to the form's `Controls` collection. There's also code to remove the `Button1.Click` event's handler, this is discussed in the [Remove the handler](#remove-the-handler) section.

:::code language="csharp" source="snippets/how-to-add-an-event-handler/cs/Form1.cs" id="HandlerViaCode" highlight="12":::
:::code language="vb" source="snippets/how-to-add-an-event-handler/vb/Form1.vb" id="HandlerViaCode" highlight="8":::

To run this code, do the following to a form with the Visual Studio Visual Designer:

01. Add a new button to the form and name it **Button1**.
01. Change the **Properties** pane mode to **Events** by pressing the event button (:::image type="icon" source="../media/shared/visual-studio-events-button.png" border="false":::).
01. Double-click the **Click** event to generate a handler. This action opens the code window and generates a blank `Button1_Click` method.
01. Replace the method code with the previous code above.

For more information about C# events, see [Events (C#)](/dotnet/csharp/programming-guide/events/)
For more information about Visual Basic events, see [Events (Visual Basic)](/dotnet/visual-basic/programming-guide/language-features/events/)

### Remove the handler

The [Add a handler](#add-a-handler) section used some code to demonstrate adding a handler. That code also contained a call to remove a handler:

:::code language="csharp" source="snippets/how-to-add-an-event-handler/cs/Form1.cs" id="RemoveHandler":::
:::code language="vb" source="snippets/how-to-add-an-event-handler/vb/Form1.vb" id="RemoveHandler":::

This syntax can be used to remove any event handler from any event.

For more information about C# events, see [Events (C#)](/dotnet/csharp/programming-guide/events/)
For more information about Visual Basic events, see [Events (Visual Basic)](/dotnet/visual-basic/programming-guide/language-features/events/)

## How to use multiple events with the same handler

With the Visual Studio Visual Designer's **Properties** pane, you can select the same handler already in use by a different event. Follow the directions in the [Set the handler](#set-the-handler) section to select an existing handler instead of creating a new one.

In C#, the handler is attached to a control's event in the form's designer code, which changed through the Visual Designer. For more information about C# events, see [Events (C#)](/dotnet/csharp/programming-guide/events/)

### Visual Basic

In Visual Basic, the handler is attached to a control's event in the form's code-behind file, where the event handler code is declared. Multiple `Handles` keywords can be added to the event handler code to use it with multiple events. The Visual Designer will generate the `Handles` keyword for you and add it to the event handler. However, you can easily do this yourself to any control's event and event handler, as long as the signature of the handler method matches the event. For more information about Visual Basic events, see [Events (Visual Basic)](/dotnet/visual-basic/programming-guide/language-features/events/)

This code demonstrates how the same method can be used as a handler for two different [`Button.Click`](xref:System.Windows.Forms.Control.Click) events:

:::code language="vb" source="snippets/how-to-add-an-event-handler/vb/Form2.vb" id="MultipleHandlers":::

## See also

- [Control events](events.md)
- [Events overview](../forms/events.md)
- [Using mouse events](../input-mouse/events.md)
- [Using keyboard events](../input-keyboard/events.md)
- <xref:System.Windows.Forms.Button?displayProperty=fullName>
