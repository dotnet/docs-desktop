---
title: "GroupBox"
description: Learn about the GroupBox control, which is a HeaderedContentControl that provides a titled container for graphical user interface (GUI) content.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], GroupBox"
  - "GroupBox control [WPF]"
ai-usage: ai-assisted
---
# GroupBox

The <xref:System.Windows.Controls.GroupBox> control is a <xref:System.Windows.Controls.HeaderedContentControl> that provides a titled container for graphical user interface (GUI) content.

The following illustration shows a <xref:System.Windows.Controls.GroupBox> that contains a <xref:System.Windows.Controls.TabControl> and a <xref:System.Windows.Controls.Button> that are enclosed in a <xref:System.Windows.Controls.StackPanel>.

:::image type="content" source="./media/shared/groupbox.png" alt-text="Screenshot of three GroupBox controls demonstrating grouping similar controls together by function.":::

## Styles and templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.GroupBox> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.GroupBox> control uses the <xref:System.Windows.Controls.ContentControl.Content?displayProperty=nameWithType> property to define the content that appears within the group box container.

### Parts

The <xref:System.Windows.Controls.GroupBox> control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.GroupBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Valid|ValidationStates|The control is valid and has no validation errors.|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|

## See also

- <xref:System.Windows.Controls.GroupBox>
