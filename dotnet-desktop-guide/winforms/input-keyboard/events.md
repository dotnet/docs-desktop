---
title: "Using keyboard events"
description: Overview of using keyboard events to handle keyboard input. This article provides a list of keyboard-related events and when to use them.
ms.date: 04/20/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
ms.topic: overview
ai-usage: ai-assisted
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "KeyPress event [Windows Forms]"
  - "keyboards [Windows Forms], keyboard events"
  - "KeyUp event"
  - "KeyDown event"
  - "keyboard events"
  - "events [Windows Forms], keyboard"
---
# Using keyboard events

Most Windows Forms programs process keyboard input by handling the keyboard events. This article provides an overview of the keyboard events, including details on when to use each event and the data that each event provides. For more information about events in general, see [Events overview](../forms/events.md).

## Keyboard events

Windows Forms raises the following events when a user presses and releases a keyboard key:

- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
- <xref:System.Windows.Forms.Control.KeyUp>

When a user presses a key, Windows Forms determines which event to raise based on whether the keyboard message specifies a character key or a physical key. For more information about character and physical keys, see [Keyboard overview, keyboard events](overview.md#keyboard-events).

## KeyDown event

The <xref:System.Windows.Forms.Control.KeyDown> event is raised when a user presses a physical key. If the key is held down, this event repeats at the OS keyboard repeat rate.

The handler for <xref:System.Windows.Forms.Control.KeyDown> receives a <xref:System.Windows.Forms.KeyEventArgs> parameter that provides:

- The <xref:System.Windows.Forms.KeyEventArgs.KeyCode> property, which specifies a physical keyboard button.
- The <xref:System.Windows.Forms.KeyEventArgs.Modifiers> property (`Shift`, `Ctrl`, or `Alt`).
- The <xref:System.Windows.Forms.KeyEventArgs.KeyData> property, which combines the key code and modifier.
- The <xref:System.Windows.Forms.KeyEventArgs.Handled> property, which prevents the underlying control from receiving the key when set.
- The <xref:System.Windows.Forms.KeyEventArgs.SuppressKeyPress> property, which suppresses the <xref:System.Windows.Forms.Control.KeyPress> and <xref:System.Windows.Forms.Control.KeyUp> events for that keystroke.

## KeyPress event

The <xref:System.Windows.Forms.Control.KeyPress> event is raised when the key or keys pressed result in a character. For example, pressing <kbd>Shift</kbd> and the lowercase "a" key produces a capital letter "A" character. <xref:System.Windows.Forms.Control.KeyPress> is raised after <xref:System.Windows.Forms.Control.KeyDown> and repeats at the OS keyboard repeat rate while the key is held.

The handler for <xref:System.Windows.Forms.Control.KeyPress> receives a <xref:System.Windows.Forms.KeyPressEventArgs> parameter that contains the character code of the key pressed. This character code is unique for every combination of a character key and a modifier key.

For example, the "A" key generates:

- The character code 65, if it's pressed with the <kbd>Shift</kbd> key.
- The character code 65, if <kbd>Caps Lock</kbd> is on.
- The character code 97, if it's pressed by itself.
- The character code 1, if it's pressed with the <kbd>Ctrl</kbd> key.

## KeyUp event

The <xref:System.Windows.Forms.Control.KeyUp> event is raised once when a user releases a physical key.

The handler for <xref:System.Windows.Forms.Control.KeyUp> receives a <xref:System.Windows.Forms.KeyEventArgs> parameter that provides:

- The <xref:System.Windows.Forms.KeyEventArgs.KeyCode> property, which specifies a physical keyboard button.
- The <xref:System.Windows.Forms.KeyEventArgs.Modifiers> property (`Shift`, `Ctrl`, or `Alt`).
- The <xref:System.Windows.Forms.KeyEventArgs.KeyData> property, which combines the key code and modifier.

## See also

- [Overview of using the keyboard](overview.md)
- [How to modify keyboard key events](how-to-change-key-press.md)
- [How to check for modifier key presses](how-to-check-modifier-key.md)
- [How to simulate keyboard events](how-to-simulate-events.md)
- [How to handle keyboard input messages in the form](how-to-handle-forms.md)
