---
title: "RepeatButton"
description: Learn about how the RepeatButton elements give you control over when and how the Click event occurs.
ai-usage: ai-assisted
ms.date: "01/26/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "controls [WPF], RepeatButton"
  - "RepeatButton control [WPF]"
---
# RepeatButton

The <xref:System.Windows.Controls.Primitives.RepeatButton> is similar to a <xref:System.Windows.Controls.Button>. However, <xref:System.Windows.Controls.Primitives.RepeatButton> elements give you control over when and how the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event occurs.

The following graphic shows an example of the three states of a repeat button control, Default, PointerFocused, and Pressed. The first button shows the default state of the <xref:System.Windows.Controls.Primitives.RepeatButton>. The second shows how the appearance of the button changes when the mouse pointer hovers over the button, giving it focus. The last button shows the appearance of the <xref:System.Windows.Controls.Primitives.RepeatButton> when the user presses the mouse button over the control.

:::image type="content" source="./media/shared/repeatbutton.png" alt-text="Two RepeatButton controls demonstrating the typical placement at the end of a counter textbox.":::

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the <xref:System.Windows.Controls.Primitives.RepeatButton> control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.Primitives.RepeatButton> control uses the <xref:System.Windows.Controls.ContentControl.Content> property to define the content displayed within the button.

### Parts

This control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.RepeatButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- <xref:System.Windows.Controls.Primitives.RepeatButton>
- [How to create a template for a control](how-to-create-apply-template.md)
- [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating)
- [What are styles and templates?](styles-templates-overview.md)
