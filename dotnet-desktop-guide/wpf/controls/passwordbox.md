---
title: "PasswordBox"
description: Learn how to use PasswordBox to input sensitive or private information in Windows Presentation Foundation (WPF) applications.
ai-usage: ai-assisted
ms.date: "01/26/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "PasswordBox control [WPF]"
  - "controls [WPF], PasswordBox"
---
# PasswordBox

Use the <xref:System.Windows.Controls.PasswordBox> control to collect sensitive or private information such as passwords. When you use this control, the actual characters don't appear on screen. Instead, the control displays placeholder characters (typically asterisks) to mask the input and protect user privacy.

:::image type="content" source="./media/shared/password-box.png" alt-text="Screenshot showing multiple entry text fields with one using a password mask.":::

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.PasswordBox> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control doesn't define a content property.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.PasswordBox> control.

|Part|Type|Description|
|-|-|-|
|PART_ContentHost|<xref:System.Windows.FrameworkElement>|The host for the password box content.|

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.PasswordBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- <xref:System.Windows.Controls.TextBox>
- <xref:System.Windows.Controls.RichTextBox>
- [Control Library](control-library.md)
