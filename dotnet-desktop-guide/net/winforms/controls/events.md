---
title: Control events overview
description: Learn about the different types of events exposed by controls in Windows Forms for .NET. Controls raise events when the user interacts with the control.
ms.date: 07/16/2021
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
f1_keywords: 
  - "OnPaint"
helpviewer_keywords: 
  - "Windows Forms, event handling"
  - "events [Windows Forms], connecting multiple to single event handler"
  - "event handlers [Windows Forms], connecting events to"
  - "menus [Windows Forms], event-handling methods for multiple menu items"
  - "Windows Forms controls, events"
  - "menu items [Windows Forms], multicasting event-handling methods"
---

# Control events (Windows Forms .NET)

Controls provide events that are raised when the user interacts with the control or when the state of the control changes. This article describes the common events shared by most controls, events raised by user interaction, and events unique to specific controls. For more information about events in Windows Forms, see [Events overview](../forms/events.md) and [Handling and raising events](/dotnet/standard/events/index).

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

For more information about how to add or remove a control event handler, see [How to handle an event](how-to-add-an-event-handler.md).

## Common events

Controls provide a set of common events through the base class: <xref:System.Windows.Forms.Control>. Not every control responds to every event. For example, the <xref:System.Windows.Forms.Label> control doesn't respond to keyboard input, so the <xref:System.Windows.Forms.Control.PreviewKeyDown?displayProperty=nameWithType> event isn't raised. Most shared events fall under these categories:

- Mouse events
- Keyboard events
- Property changed events
- Other events

## Mouse events

Considering Windows Forms is a User Interface (UI) technology, mouse input is the primary way users interact with a Windows Forms application. All controls provide basic mouse-related events:

- <xref:System.Windows.Forms.Control.MouseClick>
- <xref:System.Windows.Forms.Control.MouseDoubleClick>
- <xref:System.Windows.Forms.Control.MouseDown>
- <xref:System.Windows.Forms.Control.MouseEnter>
- <xref:System.Windows.Forms.Control.MouseHover>
- <xref:System.Windows.Forms.Control.MouseLeave>
- <xref:System.Windows.Forms.Control.MouseMove>
- <xref:System.Windows.Forms.Control.MouseUp>
- <xref:System.Windows.Forms.Control.MouseWheel>
- <xref:System.Windows.Forms.Control.Click>

For more information, see [Using mouse events](../input-mouse/events.md).

## Keyboard events

If the control responds to user input, such as a <xref:System.Windows.Forms.TextBox> or <xref:System.Windows.Forms.Button> control, the appropriate input event is raised for the control. The control must be focused to receive keyboard events. Some controls, such as the <xref:System.Windows.Forms.Label> control, can't be focused and can't receive keyboard events. The following is a list of keyboard events:

- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
- <xref:System.Windows.Forms.Control.KeyUp>

For more information, see [Using keyboard events](../input-keyboard/events.md).

## Property changed events

Windows Forms follows the _PropertyNameChanged_ pattern for properties that have change events. The data binding engine provided by Windows Forms recognizes this pattern and integrates well with it. When creating your own controls, implement this pattern.

This pattern implements the following rules, using the property `FirstName` as an example:

- Name your property: `FirstName`.
- Create an event for the property using the pattern `PropertyNameChanged`: `FirstNameChanged`.
- Create a private or protected method using the pattern `OnPropertyNameChanged`: `OnFirstNameChanged`.

If the `FirstName` property set modifies the backing value, the `OnFirstNameChanged` method is called. The `OnFirstNameChanged` method raises the `FirstNameChanged` event.

Here are some of the common property changed events for a control:

| Event                                                      | Description                                                                                     |
|------------------------------------------------------------|-------------------------------------------------------------------------------------------------|
| <xref:System.Windows.Forms.Control.BackColorChanged>       | Occurs when the value of the <xref:System.Windows.Forms.Control.BackColor%2A> property changes. |
| <xref:System.Windows.Forms.Control.BackgroundImageChanged> | Occurs when the value of the <xref:System.Windows.Forms.Control.BackgroundImage> property changes.                                  |
| <xref:System.Windows.Forms.Control.BindingContextChanged>  | Occurs when the value of the <xref:System.Windows.Forms.Control.BindingContext> property changes.                                   |
| <xref:System.Windows.Forms.Control.DockChanged>            | Occurs when the value of the <xref:System.Windows.Forms.Control.Dock> property changes.                                             |
| <xref:System.Windows.Forms.Control.EnabledChanged>         | Occurs when the <xref:System.Windows.Forms.Control.Enabled> property value has changed.                                             |
| <xref:System.Windows.Forms.Control.FontChanged>            | Occurs when the <xref:System.Windows.Forms.Control.Font> property value changes.                                                    |
| <xref:System.Windows.Forms.Control.ForeColorChanged>       | Occurs when the <xref:System.Windows.Forms.Control.ForeColor> property value changes.                                               |
| <xref:System.Windows.Forms.Control.LocationChanged>        | Occurs when the <xref:System.Windows.Forms.Control.Location> property value has changed.                                            |
| <xref:System.Windows.Forms.Control.SizeChanged>            | Occurs when the <xref:System.Windows.Forms.Control.Size> property value changes.                                                    |
| <xref:System.Windows.Forms.Control.VisibleChanged>         | Occurs when the <xref:System.Windows.Forms.Control.Visible> property value changes.                                                 |

For a full list of events, see the **Events** section of the [Control Class](xref:System.Windows.Forms.Control#events).

## Other events

Controls will also raise events based on the state of the control, or other interactions with the control. For example, the <xref:System.Windows.Forms.Control.HelpRequested> event is raised if the control has focus and the user presses the <kbd>F1</kbd> key. This event is also raised if the user presses the context-sensitive **Help** button on a form, and then presses the help cursor on the control.

Another example is when a control is changed, moved, or resized, the <xref:System.Windows.Forms.Control.Paint> event is raised. This event provides the developer with the opportunity to draw on the control and change its appearance.

For a full list of events, see the **Events** section of the [Control Class](xref:System.Windows.Forms.Control#events).

## See also

- [How to handle an event](how-to-add-an-event-handler.md)
- [Events overview](../forms/events.md)
- [Using mouse events](../input-mouse/events.md)
- [Using keyboard events](../input-keyboard/events.md)
- <xref:System.Windows.Forms.Control?displayProperty=fullName>
- <xref:System.Windows.Forms.Control.Click?displayProperty=fullName>
- <xref:System.Windows.Forms.Button?displayProperty=fullName>
