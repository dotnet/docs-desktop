---
title: "Slider"
description: Learn how the Slider allows you select from a range of values by moving a Thumb along a Track.
ms.date: 01/28/2026
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "controls [WPF], Slider"
  - "Slider control [WPF]"
ai-usage: ai-assisted
---
# Slider

The <xref:System.Windows.Controls.Slider> allows you to select from a range of values by moving a <xref:System.Windows.Controls.Primitives.Thumb> along a <xref:System.Windows.Controls.Primitives.Track>. You can configure the slider to display tick marks and customize its appearance through styling.

:::image type="content" source="./media/ss-ctl-hslider-ticks.png" alt-text="A horizontal slider control with tick marks showing the thumb position along the track":::

| Title | Description |
|-------|-------------|
| [Customize the Ticks on a Slider](how-to-customize-the-ticks-on-a-slider.md) | Shows how to customize tick marks on a slider control. |

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.Slider> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control doesn't define a content property.

:::image type="content" source="./media/shared/slider.png" alt-text="A screenshot of WPF slider controls in horizontal and vertical alignment.":::

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Slider> control.

| Part | Type | Description |
|------|------|-------------|
| PART_SelectionRange | <xref:System.Windows.FrameworkElement> | The element that displays a selection range along the slider. The selection range is visible only if the <xref:System.Windows.Controls.Slider.IsSelectionRangeEnabled%2A> property is `true`. |
| PART_Track | <xref:System.Windows.Controls.Primitives.Track> | The track element that contains the thumb and provides the slider's range visualization. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Slider> control.

| VisualState Name | VisualStateGroup Name | Description |
|------------------|----------------------|-------------|
| Disabled | CommonStates | The control is disabled. |
| Focused | FocusStates | The control has keyboard focus. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |
| MouseOver | CommonStates | The mouse is over the control. |
| Normal | CommonStates | The control is in its normal state. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| Valid | ValidationStates | The control is valid and has no validation errors. |

## See also

- <xref:System.Windows.Controls.Primitives.Thumb>
- <xref:System.Windows.Controls.Primitives.Track>
- <xref:System.Windows.Controls.Slider>
