---
title: "Overview of keyboard input"
description: Learn about how keyboard input works in Windows Forms for .NET. Keyboard events are raised by forms and controls and represent keys that are down, pressed, or up.
ms.date: 04/02/2025
ms.service: dotnet-desktop
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Windows Forms, keyboard input"
  - "keyboard [Windows Forms], input"
---

# Overview of using the keyboard

In Windows Forms, user input is sent to applications in the form of [Windows messages](/windows/win32/winmsg/about-messages-and-message-queues). A series of overridable methods process these messages at the application, form, and control level. When these methods receive keyboard messages, they raise events that can be handled to get information about the keyboard input. In many cases, Windows Forms applications are able to process all user input simply by handling these events. In other cases, an application might need to override one of the methods that process messages in order to intercept a particular message before it's received by the application, form, or control.

## Keyboard events

All Windows Forms controls inherit a set of events related to mouse and keyboard input. For example, a control can handle the <xref:System.Windows.Forms.Control.KeyPress> event to determine the character code of a key that was pressed. For more information, see [Using keyboard events](events.md).

## Methods that process user input messages

Forms and controls have access to the <xref:System.Windows.Forms.IMessageFilter> interface and a set of overridable methods that process Windows messages at different points in the message queue. These methods all have a <xref:System.Windows.Forms.Message> parameter, which encapsulates the low-level details of Windows messages. You can implement or override these methods to examine the message and then either consume the message or pass it on to the next consumer in the message queue. The following table presents the methods that process all Windows messages in Windows Forms.

| Method     | Notes |
|------------|-----------|
| <xref:System.Windows.Forms.IMessageFilter.PreFilterMessage%2A> | This method intercepts queued (also known as posted) Windows messages at the application level.|
| <xref:System.Windows.Forms.Control.PreProcessMessage%2A>       | This method intercepts Windows messages at the form and control level before they have been processed.|
| <xref:System.Windows.Forms.Control.WndProc%2A>                 | This method processes Windows messages at the form and control level.|
| <xref:System.Windows.Forms.Control.DefWndProc%2A>              | This method performs the default processing of Windows messages at the form and control level. This provides the minimal functionality of a window.|
| <xref:System.Windows.Forms.Control.OnNotifyMessage%2A>         | This method intercepts messages at the form and control level, after they have been processed. The <xref:System.Windows.Forms.ControlStyles.EnableNotifyMessage> style bit must be set for this method to be called.|

Keyboard and mouse messages are processed by an extra set of overridable methods that are specific to those types of messages. For more information, see the [Preprocessing keys](#preprocessing-keys) section.

## Types of keys

Windows Forms identifies keyboard input as virtual-key codes that are represented by the bitwise <xref:System.Windows.Forms.Keys> enumeration. With the <xref:System.Windows.Forms.Keys> enumeration, you can combine a series of pressed keys to result in a single value. These values correspond to the values that accompany the **WM_KEYDOWN** and **WM_SYSKEYDOWN** Windows messages. You can detect most physical key presses by handling the <xref:System.Windows.Forms.Control.KeyDown> or <xref:System.Windows.Forms.Control.KeyUp> events. Character keys are a subset of the <xref:System.Windows.Forms.Keys> enumeration and correspond to the values that accompany the **WM_CHAR** and **WM_SYSCHAR** Windows messages. If the combination of pressed keys results in a character, you can detect the character by handling the <xref:System.Windows.Forms.Control.KeyPress> event. Alternatively, you can use <xref:Microsoft.VisualBasic.Devices.Keyboard>, exposed by Visual Basic programming interface, to discover which keys were pressed and send keys. For more information, see [Accessing the Keyboard (Visual Basic)](/dotnet/visual-basic/developing-apps/programming/computer-resources/accessing-the-keyboard).

## Order of keyboard events

As listed previously, there are three keyboard related events that can occur on a control. The following sequence shows the general order of the events:

01. The user pushes the <kbd>A</kbd> key, the key is preprocessed, dispatched, and a <xref:System.Windows.Forms.Control.KeyDown> event occurs.
01. The user holds the <kbd>A</kbd> key, the key is preprocessed, dispatched, and a <xref:System.Windows.Forms.Control.KeyPress> event occurs.
    This event occurs multiple times as the user holds a key.
01. The user releases the <kbd>A</kbd> key, the key is preprocessed, dispatched and a <xref:System.Windows.Forms.Control.KeyUp> event occurs.

## Preprocessing keys

Like other messages, keyboard messages are processed in the <xref:System.Windows.Forms.Control.WndProc%2A> method of a form or control. However, before keyboard messages are processed, the <xref:System.Windows.Forms.Control.PreProcessMessage%2A> method calls one or more methods that can be overridden to handle special character keys and physical keys. You can override these methods to detect and filter certain keys before the control processes the messages. The following table shows the action that is being performed and the related method that occurs, in the order that the method occurs.

### Preprocessing for a KeyDown event

|Action|Related method|Notes|
|------------|--------------------|-----------|
|Check for a command key such as an accelerator or menu shortcut.|<xref:System.Windows.Forms.Control.ProcessCmdKey%2A>|This method processes a command key, which takes precedence over regular keys. If this method returns `true`, the key message isn't dispatched and a key event doesn't occur. If it returns `false`, <xref:System.Windows.Forms.Control.IsInputKey%2A> is called`.`|
|Check for a special key that requires preprocessing or a normal character key that should raise a <xref:System.Windows.Forms.Control.KeyDown> event and be dispatched to a control.|<xref:System.Windows.Forms.Control.IsInputKey%2A>|If the method returns `true`, it means the control is a regular character and a <xref:System.Windows.Forms.Control.KeyDown> event is raised. If `false`, <xref:System.Windows.Forms.Control.ProcessDialogKey%2A> is called. **Note:**  To ensure a control gets a key or combination of keys, you can handle the <xref:System.Windows.Forms.Control.PreviewKeyDown> event and set <xref:System.Windows.Forms.PreviewKeyDownEventArgs.IsInputKey%2A> of the <xref:System.Windows.Forms.PreviewKeyDownEventArgs> to `true` for the key or keys you want.|
|Check for a navigation key (ESC, TAB, Return, or arrow keys).|<xref:System.Windows.Forms.Control.ProcessDialogKey%2A>|This method processes a physical key that employs special functionality within the control, such as switching focus between the control and its parent. If the immediate control doesn't handle the key, the <xref:System.Windows.Forms.Control.ProcessDialogKey%2A> is called on the parent control, and so on, to the topmost control in the hierarchy. If this method returns `true`, preprocessing is complete and a key event isn't generated. If it returns `false`, a <xref:System.Windows.Forms.Control.KeyDown> event occurs.|

### Preprocessing for a KeyPress event

|Action|Related method|Notes|
|------------|--------------------|-----------|
|Check to see the key is a normal character that should be processed by the control|<xref:System.Windows.Forms.Control.IsInputChar%2A>|If the character is a normal character, this method returns `true`, the <xref:System.Windows.Forms.Control.KeyPress> event is raised and no further preprocessing occurs. Otherwise <xref:System.Windows.Forms.Control.ProcessDialogChar%2A> is called.|
|Check to see if the character is a mnemonic (such as &OK on a button)|<xref:System.Windows.Forms.Control.ProcessDialogChar%2A>|This method, similar to <xref:System.Windows.Forms.Control.ProcessDialogKey%2A>, is called up the control hierarchy. If the control is a container control, it checks for mnemonics by calling <xref:System.Windows.Forms.Control.ProcessMnemonic%2A> on itself and its child controls. If <xref:System.Windows.Forms.Control.ProcessDialogChar%2A> returns `true`, a <xref:System.Windows.Forms.Control.KeyPress> event doesn't occur.|

## Processing keyboard messages

After keyboard messages reach the <xref:System.Windows.Forms.Control.WndProc%2A> method of a form or control, they're processed by a set of methods that can be overridden. Each of these methods returns a <xref:System.Boolean> value specifying whether the keyboard message has been processed and consumed by the control. If one of the methods returns `true`, then the message is considered handled, and it isn't passed to the control's base or parent for further processing. Otherwise, the message stays in the message queue and might be processed in another method in the control's base or parent. The following table presents the methods that process keyboard messages.

|Method|Notes|
|------------|-----------|
|<xref:System.Windows.Forms.Control.ProcessKeyMessage%2A>|This method processes all keyboard messages that are received by the <xref:System.Windows.Forms.Control.WndProc%2A> method of the control.|
|<xref:System.Windows.Forms.Control.ProcessKeyPreview%2A>|This method sends the keyboard message to the control's parent. If <xref:System.Windows.Forms.Control.ProcessKeyPreview%2A> returns `true`, no key event is generated, otherwise <xref:System.Windows.Forms.Control.ProcessKeyEventArgs%2A> is called.|
|<xref:System.Windows.Forms.Control.ProcessKeyEventArgs%2A>|This method raises the <xref:System.Windows.Forms.Control.KeyDown>, <xref:System.Windows.Forms.Control.KeyPress>, and <xref:System.Windows.Forms.Control.KeyUp> events, as appropriate.|

## Overriding keyboard methods

There are many methods available for overriding when a keyboard message is preprocessed and processed; however, some methods are better choices than others. Following table shows tasks you might want to accomplish and the best way to override the keyboard methods. For more information on overriding methods, see [Inheritance (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/inheritance#abstract-and-virtual-methods) or [Inheritance (Visual Basic)](/dotnet/visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics#overriding-properties-and-methods-in-derived-classes)

|Task|Method|
|----------|------------|
|Intercept a navigation key and raise a <xref:System.Windows.Forms.Control.KeyDown> event. For example, you want <kbd>Tab</kbd> and <kbd>Enter</kbd> to be handled in a text box.|Override <xref:System.Windows.Forms.Control.IsInputKey%2A>. Alternatively, you can handle the <xref:System.Windows.Forms.Control.PreviewKeyDown> event and set <xref:System.Windows.Forms.PreviewKeyDownEventArgs.IsInputKey%2A> of the <xref:System.Windows.Forms.PreviewKeyDownEventArgs> to `true` for the key or keys you want.|
|Perform special input or navigation handling on a control. For example, you want the use of arrow keys in your list control to change the selected item.|Override <xref:System.Windows.Forms.Control.ProcessDialogKey%2A>|
|Intercept a navigation key and raise a <xref:System.Windows.Forms.Control.KeyPress> event. For example in a spin-box control you want multiple arrow key presses to accelerate progression through the items.|Override <xref:System.Windows.Forms.Control.IsInputChar%2A>.|
|Perform special input or navigation handling during a <xref:System.Windows.Forms.Control.KeyPress> event. For example, in a list control holding down the <kbd>R</kbd> key skips between items that begin with the letter **r**.|Override <xref:System.Windows.Forms.Control.ProcessDialogChar%2A>|
|Perform custom mnemonic handling; for example, you want to handle mnemonics on owner-drawn buttons contained in a toolbar.|Override <xref:System.Windows.Forms.Control.ProcessMnemonic%2A>.|

## See also

- <xref:System.Windows.Forms.Keys>
- <xref:System.Windows.Forms.Control.WndProc%2A>
- <xref:System.Windows.Forms.Control.PreProcessMessage%2A>
- [Using keyboard events](events.md)
- [How to modify keyboard key events](how-to-change-key-press.md)
- [How to Check for modifier key presses](how-to-check-modifier-key.md)
- [How to simulate keyboard events](how-to-simulate-events.md)
- [How to handle keyboard input messages in the form](how-to-handle-forms.md)
- [Add a control](../controls/how-to-add-to-a-form.md)
