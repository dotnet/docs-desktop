---
title: "Handle keyboard input at the Form level"
description: Learn how to handle keyboard input for your Windows Forms at the form level, before messages reach a control.
ms.date: 07/01/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "keyboard input [Windows Forms], at form level"
  - "Windows Forms, handling keyboard input"
  - "keyboards [Windows Forms], form-level input"
---

# How to handle keyboard input messages in the form

Windows Forms provides the ability to handle keyboard messages at the form level, before the messages reach a control. This article shows how to accomplish this task.

## Handle a keyboard message

Handle the <xref:System.Windows.Forms.Control.KeyPress> or <xref:System.Windows.Forms.Control.KeyDown> event of the active form and set the <xref:System.Windows.Forms.Form.KeyPreview*> property of the form to `true`. This property causes keyboard input to reach the form before it reaches any controls on the form. The following code example handles the <xref:System.Windows.Forms.Control.KeyPress> event by detecting all of the number keys and consuming <kbd>1</kbd>, <kbd>4</kbd>, and <kbd>7</kbd>.

:::code language="csharp" source="snippets/how-to-handle-forms/csharp/Form1.cs" id="HandleKey":::
:::code language="vb" source="snippets/how-to-handle-forms/vb/Form1.vb" id="HandleKey":::

## When `KeyPreview` is not enough

Setting `Form.KeyPreview = true` doesn't guarantee that every key reaches form-level event handlers. Certain keys go through preprocessing before standard form events run. Understanding these exceptions is important for handling command keys, dialog keys, and control-specific input correctly.

### Command and dialog key preprocessing

Before form-level keyboard events fire, Windows preprocesses certain keys through these methods (in order):

1. <xref:System.Windows.Forms.Control.ProcessCmdKey*>: Intercepts command keys such as menu shortcuts and accelerators. If this method returns `true`, the key is consumed and no event fires.
1. <xref:System.Windows.Forms.Control.IsInputKey*>: Determines whether a key should raise a <xref:System.Windows.Forms.Control.KeyDown> event or go to <xref:System.Windows.Forms.Control.ProcessDialogKey*>.
1. <xref:System.Windows.Forms.Control.ProcessDialogKey*>: Handles navigation keys (Escape, Tab, Return, and arrow keys). If processed, no event fires.

If a focused control consumes a key during preprocessing, the form never receives it, regardless of `KeyPreview`.

### Special cases that bypass form-level handlers

- **<kbd>Enter</kbd> and <kbd>Escape</kbd>**: These keys might be handled by <xref:System.Windows.Forms.Form.AcceptButton*> and <xref:System.Windows.Forms.Form.CancelButton*> before reaching form events.
- **<kbd>Tab</kbd>**: Often consumed by control focus management and won't reach form handlers.
- **Menu shortcuts**: Alt key combinations are handled by menu preprocessing.

### Intercept command keys at the form level

To handle command keys (including menu shortcuts and dialog keys) at the form level, override <xref:System.Windows.Forms.Control.ProcessCmdKey*> on your form. This runs during preprocessing, before standard form events.

:::code language="csharp" source="snippets/how-to-handle-forms/csharp/Form1.cs" id="ProcessCmdKey":::

:::code language="vb" source="snippets/how-to-handle-forms/vb/Form1.vb" id="ProcessCmdKey":::

For keys that should raise standard events in a specific control, use <xref:System.Windows.Forms.Control.PreviewKeyDown> with <xref:System.Windows.Forms.PreviewKeyDownEventArgs.IsInputKey*> set to `true` on that control.

## See also

- [Overview of using the keyboard](overview.md)
- [Using keyboard events](events.md)
- <xref:System.Windows.Forms.Keys>
- <xref:System.Windows.Forms.Control.ModifierKeys>
- <xref:System.Windows.Forms.Control.KeyDown>
- <xref:System.Windows.Forms.Control.KeyPress>
