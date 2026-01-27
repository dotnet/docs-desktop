---
title: "ProgressBar"
description: The ProgressBar control consists of a window that fills with the system highlight color as an operation progresses indicating the progress of an operation.
ms.date: "01/26/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "controls [WPF], ProgressBar"
  - "ProgressBar control [WPF]"
---
# ProgressBar

A <xref:System.Windows.Controls.ProgressBar> indicates the progress of an operation. The <xref:System.Windows.Controls.ProgressBar> control consists of a window that is filled with the system highlight color as an operation progresses.

The following illustration shows a typical <xref:System.Windows.Controls.ProgressBar>.

:::image type="content" source="./media/shared/progress-bar.png" alt-text="A typical ProgressBar control showing the blue progress indicator filling from left to right.":::

## Styles and templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.ProgressBar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control does not define a content property.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.ProgressBar> control.

|Part|Type|Description|
|-|-|-|
|PART_GlowRect|<xref:System.Windows.FrameworkElement>|The glow element used for indeterminate progress animation.|
|PART_Indicator|<xref:System.Windows.FrameworkElement>|The indicator that shows the current progress value.|
|PART_Track|<xref:System.Windows.FrameworkElement>|The track that represents the full range of the progress bar.|

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ProgressBar> control.

|VisualState Name|VisualStateGroup Name|Description|
|----------------------|---------------------------|-----------------|
|Determinate|CommonStates|The control shows determinate progress with a specific value.|
|Indeterminate|CommonStates|The control shows indeterminate progress with animated indicator.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but does not have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

## See also

- [Control Customization](control-customization.md)
- [Create a template for a control](how-to-create-apply-template.md)
- [Styling and Templating](styles-templates-overview.md)
- <xref:System.Windows.Controls.ControlTemplate>
- <xref:System.Windows.Controls.ProgressBar>
- <xref:System.Windows.Controls.Primitives.StatusBar>
- <xref:System.Windows.FrameworkElement.Style%2A>
