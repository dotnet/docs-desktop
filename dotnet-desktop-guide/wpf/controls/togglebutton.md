---
title: "ToggleButton control"
description: Learn about the ToggleButton control in WPF, a button that can be toggled between two or three states, including its styles and templates.
ms.date: "01/28/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "states [WPF], ToggleButton"
  - "ToggleButton [WPF], styles and templates"
  - "ControlTemplate [WPF], ToggleButton"
  - "styles [WPF], ToggleButton"
  - "templates [WPF], ToggleButton"
ai-usage: ai-assisted
---

# ToggleButton control

The <xref:System.Windows.Controls.Primitives.ToggleButton> control represents a button that can be toggled between two or three states. It's a base class for controls like <xref:System.Windows.Controls.CheckBox> and <xref:System.Windows.Controls.RadioButton>, providing the fundamental toggle functionality. You can set the <xref:System.Windows.Controls.Primitives.ToggleButton.IsThreeState%2A> property to `true` to enable an indeterminate state in addition to checked and unchecked states.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.Primitives.ToggleButton> defines the <xref:System.Windows.Controls.ContentControl.Content%2A> property as its content property. This means you can set any object, such as text or UI elements, as the button's content.

### Parts

The <xref:System.Windows.Controls.Primitives.ToggleButton> control doesn't define any named parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.ToggleButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Checked|CheckStates|The control is checked.|
|Unchecked|CheckStates|The control is unchecked.|
|Indeterminate|CheckStates|The control is in an indeterminate state (when <xref:System.Windows.Controls.Primitives.ToggleButton.IsThreeState%2A> is `true`).|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

> [!NOTE]
> If the Indeterminate visual state doesn't exist in your control template, the Unchecked visual state is used as the default visual state.

## See also

- <xref:System.Windows.Controls.CheckBox>
- <xref:System.Windows.Controls.ControlTemplate>
- <xref:System.Windows.Controls.Primitives.ButtonBase>
- <xref:System.Windows.Controls.Primitives.ToggleButton>
- <xref:System.Windows.Controls.RadioButton>
- <xref:System.Windows.FrameworkElement.Style%2A>
- [Control customization](control-customization.md)
- [Create a template for a control](how-to-create-apply-template.md)
- [Styling and templating](styles-templates-overview.md)
