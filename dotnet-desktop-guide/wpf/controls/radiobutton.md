---
title: "RadioButton"
description: Learn how RadioButton controls are usually grouped together to offer users a single choice among several options.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "RadioButton control [WPF]"
  - "controls [WPF], RadioButton"
ai-usage: ai-assisted
---
# RadioButton

<xref:System.Windows.Controls.RadioButton> controls are usually grouped together to offer users a single choice among several options. Only one button at a time can be selected.

The following illustration shows an example of a <xref:System.Windows.Controls.RadioButton> control.

:::image type="content" source="./media/shared/radiobutton.png" alt-text="Example of RadioButton controls showing typical radio button states":::

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.RadioButton> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.RadioButton> uses the <xref:System.Windows.Controls.ContentControl.Content?displayProperty=nameWithType> property to define what is displayed within the control.

### Parts

The <xref:System.Windows.Controls.RadioButton> control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.RadioButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|----------------------|---------------------------|-----------------|
|Checked|CheckStates|The control is checked (selected). <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `true`.|
|Disabled|CommonStates|The control is disabled and can't respond to user input.|
|Focused|FocusStates|The control has keyboard focus and can receive input.|
|Indeterminate|CheckStates|The control is in an indeterminate state. <xref:System.Windows.Controls.Primitives.ToggleButton.IsThreeState%2A> is `true`, and <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `null`.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus. <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> is `true`.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus. <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> is `true`.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Normal|CommonStates|The control is in its default, normal state.|
|Pressed|CommonStates|The control is pressed by user interaction.|
|Unchecked|CheckStates|The control is unchecked (not selected). <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `false`.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors. <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> is `false`.|

## See also

<xref:System.Windows.Controls.Primitives.ToggleButton>
