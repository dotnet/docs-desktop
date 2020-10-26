---
title: "How to simulate mouse events"
description: Learn how to simulate mouse events in Windows Forms for .NET.
ms.date: 10/26/2020
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "mouse [Windows Forms], event simulation"
  - "user input [Windows Forms], simulating"
  - "SendKeys [Windows Forms], using"
---
# How to simulate mouse events (Windows Forms .NET)

Simulating mouse events in Windows Forms isn't as straight forward as simulating keyboard events. Windows Forms doesn't provide a helper class to move the mouse and invoke mouse-click actions. The only option for controlling the mouse is to use native Windows methods. If you're working with a custom control or a form, you can simulate a mouse event, but you can't directly control the mouse.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Events

Most events have a corresponding method that invokes them, named in the pattern of `On` followed by `EventName`, such as `OnMouseMove`. This option is only possible within custom controls or forms, because these methods are protected and can't be accessed from outside the context of the control or form. The disadvantage to using a method such as `OnMouseMove` is that it doesn't actually control the mouse or interact with the control, it simply raises the associated event. For example, if you wanted to simulate hovering over an item in a <xref:System.Windows.Forms.ListBox>, `OnMouseMove` and the `ListBox` doesn't visually react with a highlighted item under the cursor.

These protected methods are available to simulate mouse events.

- `OnMouseDown`
- `OnMouseEnter`
- `OnMouseHover`
- `OnMouseLeave`
- `OnMouseMove`
- `OnMouseUp`
- `OnMouseWheel`
- `OnMouseClick`
- `OnMouseDoubleClick`

For more information about these events, see [Using mouse events (Windows Forms .NET)](events.md)

## Invoke a click

Considering most controls do something when clicked, like a button calling user code, or checkbox change its checked state, Windows Forms provides an easy way to trigger the click. Some controls, such as a combobox, don't do anything special when clicked and simulating a click has no effect on the control.

### PerformClick

The <xref:System.Windows.Forms.IButtonControl?displayProperty=nameWithType> interface provides the <xref:System.Windows.Forms.IButtonControl.PerformClick%2A> method which simulates a click on the control. Both the <xref:System.Windows.Forms.Button?displayProperty=nameWithType> and <xref:System.Windows.Forms.LinkLabel?displayProperty=nameWithType> controls implement this interface.

:::code language="csharp" source="snippets/how-to-simulate-events/csharp/Form1.cs" id="PerformClick":::
:::code language="vb" source="snippets/how-to-simulate-events/vb/Form1.vb" id="PerformClick":::

### InvokeClick

With a form a custom control, use the <xref:System.Windows.Forms.Control.InvokeOnClick%2A> method to simulate a mouse click. This is a protected method that can only be called from within the form or a derived custom control.

For example, the following code clicks a checkbox from `button1`.

:::code language="csharp" source="snippets/how-to-simulate-events/csharp/Form1.cs" id="ClickCheckbox":::
:::code language="vb" source="snippets/how-to-simulate-events/vb/Form1.vb" id="ClickCheckbox":::

## Use native Windows methods

Windows provides methods you can call to simulate mouse movements and clicks such as [`User32.dll SendInput`](/windows/win32/api/winuser/nf-winuser-sendinput) and [`User32.dll SetCursorPos`](/windows/win32/api/winuser/nf-winuser-setcursorpos). The following example moves the mouse cursor to the center of a control:

:::code language="csharp" source="snippets/how-to-simulate-events/csharp/Form2.cs" id="MoveCursor":::
:::code language="vb" source="snippets/how-to-simulate-events/vb/Form2.vb" id="MoveCursor":::

## See also

- [Overview of using the mouse (Windows Forms .NET)](overview.md)
- [Using mouse events (Windows Forms .NET)](events.md)
- [How to distinguish between clicks and double-clicks (Windows Forms .NET)](how-to-distinguish-between-clicks-and-double-clicks.md)
- [Manage mouse pointers (Windows Forms .NET)](how-to-manage-cursor-pointer.md)
