---
title: "Using mouse events"
description: Overview of using mouse events to handle mouse input. Each event may provide associated data. This article provides a list of mouse-related events.
ms.date: 10/26/2020
ms.topic: conceptual
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Click event [Windows Forms]"
  - "mouse [Windows Forms], mouse events"
  - "Click event"
  - "MouseClick event"
  - "DoubleClick event"
  - "MouseDown event"
  - "MouseEnter event"
  - "MouseHover event"
  - "MouseLeave event"
  - "MouseMove event"
  - "MouseUp event"
  - "MouseWheel event"
  - "mouse events"
  - "events [Windows Forms], mouse"
---

# Using mouse events (Windows Forms .NET)

Most Windows Forms programs process mouse input by handling the mouse events. This article provides an overview of the mouse events, including details on when to use each event and the data that is supplied for each event. For more information about events in general, see [Events overview (Windows Forms .NET)](../forms/events.md).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Mouse events

The primary way to respond to mouse input is to handle mouse events. The following table shows the mouse events and describes when they're raised.

| Mouse Event                                          | Description                                             |
|------------------------------------------------------|---------------------------------------------------------|
| <xref:System.Windows.Forms.Control.Click>            | This event occurs when the mouse button is released, typically before the <xref:System.Windows.Forms.Control.MouseUp> event. The handler for this event receives an argument of type <xref:System.EventArgs>. Handle this event when you only need to determine when a click occurs.                                                                             |
| <xref:System.Windows.Forms.Control.MouseClick>       | This event occurs when the user clicks the control with the mouse. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>. Handle this event when you need to get information about the mouse when a click occurs.                                                                                                   |
| <xref:System.Windows.Forms.Control.DoubleClick>      | This event occurs when the control is double-clicked. The handler for this event receives an argument of type <xref:System.EventArgs>. Handle this event when you only need to determine when a double-click occurs.                                                                                                                                             |
| <xref:System.Windows.Forms.Control.MouseDoubleClick> | This event occurs when the user double-clicks the control with the mouse. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>. Handle this event when you need to get information about the mouse when a double-click occurs.                                                                                     |
| <xref:System.Windows.Forms.Control.MouseDown>        | This event occurs when the mouse pointer is over the control and the user presses a mouse button. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>.                                                                                                                                                            |
| <xref:System.Windows.Forms.Control.MouseEnter>       | This event occurs when the mouse pointer enters the border or client area of the control, depending on the type of control. The handler for this event receives an argument of type <xref:System.EventArgs>.                                                                                                                                                     |
| <xref:System.Windows.Forms.Control.MouseHover>       | This event occurs when the mouse pointer stops and rests over the control. The handler for this event receives an argument of type <xref:System.EventArgs>.                                                                                                                                                                                                      |
| <xref:System.Windows.Forms.Control.MouseLeave>       | This event occurs when the mouse pointer leaves the border or client area of the control, depending on the type of the control. The handler for this event receives an argument of type <xref:System.EventArgs>.                                                                                                                                                 |
| <xref:System.Windows.Forms.Control.MouseMove>        | This event occurs when the mouse pointer moves while it is over a control. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>.                                                                                                                                                                                   |
| <xref:System.Windows.Forms.Control.MouseUp>          | This event occurs when the mouse pointer is over the control and the user releases a mouse button. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>.                                                                                                                                                           |
| <xref:System.Windows.Forms.Control.MouseWheel>       | This event occurs when the user rotates the mouse wheel while the control has focus. The handler for this event receives an argument of type <xref:System.Windows.Forms.MouseEventArgs>. You can use the <xref:System.Windows.Forms.MouseEventArgs.Delta%2A> property of <xref:System.Windows.Forms.MouseEventArgs> to determine how far the mouse has scrolled. |

## Mouse information

A <xref:System.Windows.Forms.MouseEventArgs> is sent to the handlers of mouse events related to clicking a mouse button and tracking mouse movements. <xref:System.Windows.Forms.MouseEventArgs> provides information about the current state of the mouse, including the location of the mouse pointer in client coordinates, which mouse buttons are pressed, and whether the mouse wheel has scrolled. Several mouse events, such as those that are raised when the mouse pointer has entered or left the bounds of a control, send an <xref:System.EventArgs> to the event handler with no further information.

If you want to know the current state of the mouse buttons or the location of the mouse pointer, and you want to avoid handling a mouse event, you can also use the <xref:System.Windows.Forms.Control.MouseButtons%2A> and <xref:System.Windows.Forms.Control.MousePosition%2A> properties of the <xref:System.Windows.Forms.Control> class. <xref:System.Windows.Forms.Control.MouseButtons%2A> returns information about which mouse buttons are currently pressed. The <xref:System.Windows.Forms.Control.MousePosition%2A> returns the screen coordinates of the mouse pointer and is equivalent to the value returned by <xref:System.Windows.Forms.Cursor.Position%2A>.

## Converting Between Screen and Client Coordinates

Because some mouse location information is in client coordinates and some is in screen coordinates, you may need to convert a point from one coordinate system to the other. You can do this easily by using the <xref:System.Windows.Forms.Control.PointToClient%2A> and <xref:System.Windows.Forms.Control.PointToScreen%2A> methods available on the <xref:System.Windows.Forms.Control> class.

## Standard Click event behavior

If you want to handle mouse click events in the proper order, you need to know the order in which click events are raised in Windows Forms controls. All Windows Forms controls raise click events in the same order when any supported mouse button is pressed and released, except where noted in the following list for individual controls. The following list shows the order of events raised for a single mouse-button click:

01. <xref:System.Windows.Forms.Control.MouseDown> event.
01. <xref:System.Windows.Forms.Control.Click> event.
01. <xref:System.Windows.Forms.Control.MouseClick> event.
01. <xref:System.Windows.Forms.Control.MouseUp> event.

The following is the order of events raised for a double mouse-button click:

01. <xref:System.Windows.Forms.Control.MouseDown> event.
01. <xref:System.Windows.Forms.Control.Click> event.
01. <xref:System.Windows.Forms.Control.MouseClick> event.
01. <xref:System.Windows.Forms.Control.MouseUp> event.
01. <xref:System.Windows.Forms.Control.MouseDown> event.
01. <xref:System.Windows.Forms.Control.DoubleClick> event.

    This can vary, depending on whether the control in question has the <xref:System.Windows.Forms.ControlStyles.StandardDoubleClick> style bit set to `true`. For more information about how to set a <xref:System.Windows.Forms.ControlStyles> bit, see the <xref:System.Windows.Forms.Control.SetStyle%2A> method.

01. <xref:System.Windows.Forms.Control.MouseDoubleClick> event.
01. <xref:System.Windows.Forms.Control.MouseUp> event.

### Individual controls

The following controls don't conform to the standard mouse click event behavior:

- <xref:System.Windows.Forms.Button>
- <xref:System.Windows.Forms.CheckBox>
- <xref:System.Windows.Forms.ComboBox>
- <xref:System.Windows.Forms.RadioButton>

  > [!NOTE]
  > For the <xref:System.Windows.Forms.ComboBox> control, the event behavior detailed later occurs if the user clicks on the edit field, the button, or on an item within the list.

  - **Left click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Right click**: No click events raised
  - **Left double-click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Right double-click**: No click events raised

- <xref:System.Windows.Forms.TextBox>, <xref:System.Windows.Forms.RichTextBox>, <xref:System.Windows.Forms.ListBox>, <xref:System.Windows.Forms.MaskedTextBox>, and <xref:System.Windows.Forms.CheckedListBox> controls

  > [!NOTE]
  > The event behavior detailed later occurs when the user clicks anywhere within these controls.

  - **Left click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Right click**: No click events raised
  - **Left double-click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>, <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>
  - **Right double-click**: No click events raised

- <xref:System.Windows.Forms.ListView> control

  > [!NOTE]
  > The event behavior detailed later occurs only when the user clicks on the items in the <xref:System.Windows.Forms.ListView> control. No events are raised for clicks anywhere else on the control. In addition to the events described later, there are the <xref:System.Windows.Forms.ListView.BeforeLabelEdit> and <xref:System.Windows.Forms.ListView.AfterLabelEdit> events, which may be of interest to you if you want to use validation with the <xref:System.Windows.Forms.ListView> control.

  - **Left click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Right click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Left double-click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>
  - **Right double-click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>

- <xref:System.Windows.Forms.TreeView> control

  > [!NOTE]
  > The event behavior detailed later occurs only when the user clicks on the items themselves or to the right of the items in the <xref:System.Windows.Forms.TreeView> control. No events are raised for clicks anywhere else on the control. In addition to those described later, there are the <xref:System.Windows.Forms.TreeView.BeforeCheck>, <xref:System.Windows.Forms.TreeView.BeforeSelect>, <xref:System.Windows.Forms.TreeView.BeforeLabelEdit>, <xref:System.Windows.Forms.TreeView.AfterSelect>, <xref:System.Windows.Forms.TreeView.AfterCheck>, and <xref:System.Windows.Forms.TreeView.AfterLabelEdit> events, which may be of interest to you if you want to use validation with the <xref:System.Windows.Forms.TreeView> control.

  - **Left click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Right click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>
  - **Left double-click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>
  - **Right double-click**: <xref:System.Windows.Forms.Control.Click>, <xref:System.Windows.Forms.Control.MouseClick>; <xref:System.Windows.Forms.Control.DoubleClick>, <xref:System.Windows.Forms.Control.MouseDoubleClick>

## Painting behavior of toggle controls

Toggle controls, such as the controls deriving from the <xref:System.Windows.Forms.ButtonBase> class, have the following distinctive painting behavior in combination with mouse click events:

01. The user presses the mouse button.
01. The control paints in the pressed state.
01. The <xref:System.Windows.Forms.Control.MouseDown> event is raised.
01. The user releases the mouse button.
01. The control paints in the raised state.
01. The <xref:System.Windows.Forms.Control.Click> event is raised.
01. The <xref:System.Windows.Forms.Control.MouseClick> event is raised.
01. The <xref:System.Windows.Forms.Control.MouseUp> event is raised.

    > [!NOTE]
    > If the user moves the pointer out of the toggle control while the mouse button is down (such as moving the mouse off the <xref:System.Windows.Forms.Button> control while it is pressed), the toggle control will paint in the raised state and only the <xref:System.Windows.Forms.Control.MouseUp> event occurs. The <xref:System.Windows.Forms.Control.Click> or <xref:System.Windows.Forms.Control.MouseClick> events will not occur in this situation.

## See also

- [Overview of using the mouse (Windows Forms .NET)](overview.md)
- [Manage mouse pointers (Windows Forms .NET)](how-to-manage-cursor-pointer.md)
- [How to simulate mouse events (Windows Forms .NET)](how-to-simulate-events.md)
- <xref:System.Windows.Forms.Control?displayProperty=nameWithType>
