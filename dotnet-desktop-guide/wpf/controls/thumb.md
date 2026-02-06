---
title: "Thumb"
description: Learn about the Thumb control, which provides a dragging functionality for scroll bars, sliders, and other controls.
ms.date: "01/28/2025"
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "states [WPF], Thumb"
  - "styles [WPF], Thumb"
  - "templates [WPF], Thumb"
  - "Thumb [WPF], styles and templates"
  - "ControlTemplate [WPF], Thumb"
  - "parts [WPF], Thumb"
ai-usage: ai-assisted
---

# Thumb

The <xref:System.Windows.Controls.Primitives.Thumb> control is a small control that can be dragged by the user. It's typically used as part of other controls such as scroll bars and sliders to provide dragging functionality. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance.

:::image type="content" source="./media/shared/thumb.png" alt-text="A screenshot of vertical and horizontal scroll bars in WPF.":::

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.Primitives.Thumb> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Styles and templates overview](styles-templates-overview.md) and [Create a template for a control](how-to-create-apply-template.md).

### Content property

This control doesn't define a content property.

### Parts

This control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.Thumb> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The control is in its normal state.|
|MouseOver|CommonStates|The mouse is over the control.|
|Pressed|CommonStates|The control is pressed (IsDragging is true).|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has keyboard focus.|
|Unfocused|FocusStates|The control doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- [Control Customization](control-customization.md)
- [Create a template for a control](how-to-create-apply-template.md)
- [Styling and Templating](styles-templates-overview.md)
- <xref:System.Windows.Controls.ControlTemplate>
- <xref:System.Windows.FrameworkElement.Style%2A>
