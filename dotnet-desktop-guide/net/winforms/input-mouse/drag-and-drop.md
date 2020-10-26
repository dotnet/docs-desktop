---
title: "Drag-and-drop mouse behaviors"
description: Learn about how drag-and-drop works on Windows Forms, including how to perform drag-and-drop with the mouse.
ms.date: 10/26/2020
ms.topic: conceptual
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords:
- "drag and drop [Windows Forms], Windows Forms"
- "Windows Forms, drag and drop"
---

# Drag-and-drop mouse behavior overview (Windows Forms .NET)

Windows Forms includes a set of methods, events, and classes that implement drag-and-drop behavior. This topic provides an overview of the drag-and-drop support in Windows Forms.<!-- TODO Also see [Drag-and-Drop Operations and Clipboard Support](./advanced/drag-and-drop-operations-and-clipboard-support.md).-->

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Drag-and-drop events

There are two categories of events in a drag and drop operation: events that occur on the current target of the drag-and-drop operation, and events that occur on the source of the drag and drop operation. To perform drag-and-drop operations, you must handle these events. By working with the information available in the event arguments of these events, you can easily facilitate drag-and-drop operations.

## Events on the current drop target

The following table shows the events that occur on the current target of a drag-and-drop operation.

| Mouse Event                                   | Description                                                                                                                                                                                            |
|-----------------------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <xref:System.Windows.Forms.Control.DragEnter> | This event occurs when an object is dragged into the control's bounds. The handler for this event receives an argument of type <xref:System.Windows.Forms.DragEventArgs>.                              |
| <xref:System.Windows.Forms.Control.DragOver>  | This event occurs when an object is dragged while the mouse pointer is within the control's bounds. The handler for this event receives an argument of type <xref:System.Windows.Forms.DragEventArgs>. |
| <xref:System.Windows.Forms.Control.DragDrop>  | This event occurs when a drag-and-drop operation is completed. The handler for this event receives an argument of type <xref:System.Windows.Forms.DragEventArgs>.                                      |
| <xref:System.Windows.Forms.Control.DragLeave> | This event occurs when an object is dragged out of the control's bounds. The handler for this event receives an argument of type <xref:System.EventArgs>.                                              |

The <xref:System.Windows.Forms.DragEventArgs> class provides the location of the mouse pointer, the current state of the mouse buttons and modifier keys of the keyboard, the data being dragged, and <xref:System.Windows.Forms.DragDropEffects> values that specify the operations allowed by the source of the drag event and the target drop effect for the operation.

## Events on the drop source

The following table shows the events that occur on the source of the drag-and-drop operation.

|Mouse Event|Description|
|-----------------|-----------------|
|<xref:System.Windows.Forms.Control.GiveFeedback>|This event occurs during a drag operation. It provides an opportunity to give a visual cue to the user that the drag-and-drop operation is occurring, such as changing the mouse pointer. The handler for this event receives an argument of type <xref:System.Windows.Forms.GiveFeedbackEventArgs>.|
|<xref:System.Windows.Forms.Control.QueryContinueDrag>|This event is raised during a drag-and-drop operation and enables the drag source to determine whether the drag-and-drop operation should be canceled. The handler for this event receives an argument of type <xref:System.Windows.Forms.QueryContinueDragEventArgs>.|

The <xref:System.Windows.Forms.QueryContinueDragEventArgs> class provides the current state of the mouse buttons and modifier keys of the keyboard, a value specifying whether the ESC key was pressed, and a <xref:System.Windows.Forms.DragAction> value that can be set to specify whether the drag-and-drop operation should continue.

## Performing drag-and-drop

Drag-and-drop operations always involve two components, the **drag source** and the **drop target**. To start a drag-and-drop operation, designate a control as the source and handle the <xref:System.Windows.Forms.Control.MouseDown> event. In the event handler, call the <xref:System.Windows.DragDrop.DoDragDrop%2A> method providing the data associated with the drop and the a <xref:System.Windows.DragDropEffects> value.

Set the target control's <xref:System.Windows.Forms.Control.AllowDrop> property set to `true` to allow that control to accept a drag-and-drop operation. The target handles two events, first an event in response to the drag being over the control, such as <xref:System.Windows.Forms.Control.DragOver>. And a second event which is the drop action itself, <xref:System.Windows.Forms.Control.DragDrop>.

The following example demonstrates a drag from a <xref:System.Windows.Forms.Label> control to a <xref:System.Windows.Forms.TextBox>. When the drag is completed, the `TextBox` responds by assigning the label's text to itself.

```csharp
// Initiate the drag
private void label1_MouseDown(object sender, MouseEventArgs e) =>
    DoDragDrop(((Label)sender).Text, DragDropEffects.All);

// Set the effect filter and allow the drop on this control
private void textBox1_DragOver(object sender, DragEventArgs e) =>
    e.Effect = DragDropEffects.All;

// React to the drop on this control
private void textBox1_DragDrop(object sender, DragEventArgs e) =>
    textBox1.Text = (string)e.Data.GetData(typeof(string));
```

```vb
' Initiate the drag
Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs)
    DoDragDrop(DirectCast(sender, Label).Text, DragDropEffects.All)
End Sub

' Set the effect filter and allow the drop on this control
Private Sub TextBox1_DragOver(sender As Object, e As DragEventArgs)
    e.Effect = DragDropEffects.All
End Sub

' React to the drop on this control
Private Sub TextBox1_DragDrop(sender As Object, e As DragEventArgs)
    TextBox1.Text = e.Data.GetData(GetType(String))
End Sub
```

For more information about the drag effects, see <xref:System.Windows.Forms.DragEventArgs.Data%2A> and <xref:System.Windows.Forms.DragEventArgs.AllowedEffect%2A>.

## See also

- [Overview of using the mouse (Windows Forms .NET)](overview.md)
- <xref:System.Windows.Forms.Control.DragDrop?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.DragEnter?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.DragLeave?displayProperty=nameWithType>
- <xref:System.Windows.Forms.Control.DragOver?displayProperty=nameWithType>
