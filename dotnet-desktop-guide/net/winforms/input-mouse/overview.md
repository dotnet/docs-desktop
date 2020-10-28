---
title: "Overview of mouse input"
description: Learn about how mouse input works in Windows Forms for .NET. Mouse events are raised by forms and controls and represent the position and button state of the mouse.
ms.date: 10/26/2020
ms.topic: overview
helpviewer_keywords:
  - "Windows Forms, mouse input"
  - "mouse [Windows Forms], input"
---

# Overview of using the mouse (Windows Forms .NET)

Receiving and handling mouse input is an important part of every Windows application. You can handle mouse events to carry out an action in your application, or use mouse location information to perform hit testing or other actions. Also, you can change the way the controls in your application handle mouse input. This article describes these mouse events in detail, and how to obtain and change system settings for the mouse.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

In Windows Forms, user input is sent to applications in the form of [Windows messages](/windows/win32/winmsg/about-messages-and-message-queues). A series of overridable methods process these messages at the application, form, and control level. When these methods receive mouse messages, they raise events that can be handled to get information about the mouse input. In many cases, Windows Forms applications can process all user input simply by handling these events. In other cases, an application may override one of the methods that process messages to intercept a particular message before it's received by the application, form, or control.

## Mouse Events

All Windows Forms controls inherit a set of events related to mouse and keyboard input. For example, a control can handle the <xref:System.Windows.Forms.Control.MouseClick> event to determine the location of a mouse click. For more information on the mouse events, see [Using mouse events](events.md).

## Mouse location and hit-testing

When the user moves the mouse, the operating system moves the mouse pointer. The mouse pointer contains a single pixel, called the hot spot, which the operating system tracks and recognizes as the position of the pointer. When the user moves the mouse or presses a mouse button, the <xref:System.Windows.Forms.Control> that contains the <xref:System.Windows.Forms.Cursor.HotSpot%2A> raises the appropriate mouse event.

You can obtain the current mouse position with the <xref:System.Windows.Forms.MouseEventArgs.Location%2A> property of the <xref:System.Windows.Forms.MouseEventArgs> when handling a mouse event or by using the <xref:System.Windows.Forms.Cursor.Position%2A> property of the <xref:System.Windows.Forms.Cursor> class. You can then use mouse location information to carry out hit-testing, and then perform an action based on the location of the mouse. Hit-testing capability is built in to several controls in Windows Forms such as the <xref:System.Windows.Forms.ListView>, <xref:System.Windows.Forms.TreeView>, <xref:System.Windows.Forms.MonthCalendar> and <xref:System.Windows.Forms.DataGridView> controls.

Used with the appropriate mouse event, <xref:System.Windows.Forms.Control.MouseHover> for example, hit-testing is very useful for determining when your application should do a specific action.

## Changing mouse input settings

You can detect and change the way a control handles mouse input by deriving from the control and using the <xref:System.Windows.Forms.Control.GetStyle%2A> and <xref:System.Windows.Forms.Control.SetStyle%2A> methods. The <xref:System.Windows.Forms.Control.SetStyle%2A> method takes a bitwise combination of <xref:System.Windows.Forms.ControlStyles> values to determine whether the control will have standard click, double-click behavior, or if the control will handle its own mouse processing. Also, the <xref:System.Windows.Forms.SystemInformation> class includes properties that describe the capabilities of the mouse and specify how the mouse interacts with the operating system. The following table summarizes these properties.

| Property                                                               | Description                                                                                                                                                            |
|------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <xref:System.Windows.Forms.SystemInformation.DoubleClickSize%2A>       | Gets the dimensions, in pixels, of the area in which the user must click twice for the operating system to consider the two clicks a double-click.                     |
| <xref:System.Windows.Forms.SystemInformation.DoubleClickTime%2A>       | Gets the maximum number of milliseconds that can elapse between a first click and a second click for the mouse action to be considered a double-click. |
| <xref:System.Windows.Forms.SystemInformation.MouseButtons%2A>          | Gets the number of buttons on the mouse.                                                                                                                               |
| <xref:System.Windows.Forms.SystemInformation.MouseButtonsSwapped%2A>   | Gets a value indicating whether the functions of the left and right mouse buttons have been swapped.                                                                   |
| <xref:System.Windows.Forms.SystemInformation.MouseHoverSize%2A>        | Gets the dimensions, in pixels, of the rectangle within which the mouse pointer has to stay for the mouse hover time before a mouse hover message is generated.        |
| <xref:System.Windows.Forms.SystemInformation.MouseHoverTime%2A>        | Gets the time, in milliseconds, that the mouse pointer has to stay in the hover rectangle before a mouse hover message is generated.                                   |
| <xref:System.Windows.Forms.SystemInformation.MousePresent%2A>          | Gets a value indicating whether a mouse is installed.                                                                                                                  |
| <xref:System.Windows.Forms.SystemInformation.MouseSpeed%2A>            | Gets a value indicating the current mouse speed, from 1 to 20.                                                                                                         |
| <xref:System.Windows.Forms.SystemInformation.MouseWheelPresent%2A>     | Gets a value indicating whether a mouse with a mouse wheel is installed.                                                                                               |
| <xref:System.Windows.Forms.SystemInformation.MouseWheelScrollDelta%2A> | Gets the amount of the delta value of the increment of a single mouse wheel rotation.                                                                                  |
| <xref:System.Windows.Forms.SystemInformation.MouseWheelScrollLines%2A> | Gets the number of lines to scroll when the mouse wheel is rotated.                                                                                                    |

## Methods that process user input messages

Forms and controls have access to the <xref:System.Windows.Forms.IMessageFilter> interface and a set of overridable methods that process Windows messages at different points in the message queue. These methods all have a <xref:System.Windows.Forms.Message> parameter, which encapsulates the low-level details of Windows messages. You can implement or override these methods to examine the message and then either consume the message or pass it on to the next consumer in the message queue. The following table presents the methods that process all Windows messages in Windows Forms.

| Method     | Notes |
|------------|-----------|
| <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A> | This method intercepts queued (also known as posted) Windows messages at the application level.|
| <xref:System.Windows.Forms.Control.PreProcessMessage%2A>       | This method intercepts Windows messages at the form and control level before they have been processed.|
| <xref:System.Windows.Forms.Control.WndProc%2A>                 | This method processes Windows messages at the form and control level.|
| <xref:System.Windows.Forms.Control.DefWndProc%2A>              | This method performs the default processing of Windows messages at the form and control level. This provides the minimal functionality of a window.|
| <xref:System.Windows.Forms.Control.OnNotifyMessage%2A>         | This method intercepts messages at the form and control level, after they've been processed. The <xref:System.Windows.Forms.ControlStyles.EnableNotifyMessage> style bit must be set for this method to be called.|

## See also

- [Using mouse events (Windows Forms .NET)](events.md)
- [Drag-and-drop mouse behavior overview (Windows Forms .NET)](drag-and-drop.md)
- [Manage mouse pointers (Windows Forms .NET)](how-to-manage-cursor-pointer.md)
