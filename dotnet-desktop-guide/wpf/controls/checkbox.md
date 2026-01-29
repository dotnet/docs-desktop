---
title: "CheckBox"
description: Learn how to use a CheckBox in the user interface (UI) of your application to represent options that a user can select or clear.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], CheckBox"
  - "CheckBox control [WPF]"
ai-usage: ai-assisted
---
# CheckBox

You can use a <xref:System.Windows.Controls.CheckBox> in the user interface (UI) of your application to represent options that a user can select or clear. You can use a single check box or you can group two or more check boxes.

The following graphic shows the different states of a <xref:System.Windows.Controls.CheckBox>.

:::image type="content" source="./media/shared/checkbox.png" alt-text="CheckBox controls in different states.":::

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.CheckBox> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The content property for the <xref:System.Windows.Controls.CheckBox> control is <xref:System.Windows.Controls.ContentControl.Content%2A>. Use this property to specify the text or content that appears next to the checkbox.

### Parts

The <xref:System.Windows.Controls.CheckBox> control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.CheckBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|---|---|---|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Checked|CheckStates|The control is checked.|
|Unchecked|CheckStates|The control is unchecked.|
|Indeterminate|CheckStates|The control is in an indeterminate state.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- <xref:System.Windows.Controls.CheckBox>
- <xref:System.Windows.Controls.RadioButton>
- <xref:System.Windows.Controls.Primitives.ButtonBase>
- <xref:System.Windows.Controls.Primitives.RepeatButton>
