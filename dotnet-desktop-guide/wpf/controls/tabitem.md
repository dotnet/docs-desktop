---
title: "TabItem"
description: Learn how to use TabItem elements to represent individual tabs within a TabControl, containing both the tab header and its associated content.
ms.date: "01/26/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "TabItem control [WPF]"
  - "controls [WPF], TabItem"
ai-usage: ai-assisted
---
# TabItem

The <xref:System.Windows.Controls.TabItem> represents an individual tab within a <xref:System.Windows.Controls.TabControl>. Each TabItem contains both the tab header and its associated content that displays when you select the tab.

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.TabItem> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Styles and templates overview](styles-templates-overview.md) and [Create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.TabItem> uses the <xref:System.Windows.Controls.ContentControl.Content> property as its content property. This property contains the content that displays when you select the tab.

### Parts

The <xref:System.Windows.Controls.TabItem> control doesn't have any named parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.TabItem> control.

|VisualState Name|VisualStateGroup Name|Description|
|----------------------|---------------------------|-----------------|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has focus.|
|Unfocused|FocusStates|The control does not have focus.|
|Selected|SelectionStates|The control is selected.|
|Unselected|SelectionStates|The control is not selected.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|

## See also

- <xref:System.Windows.Controls.TabItem>
- <xref:System.Windows.Controls.TabControl>
- [Styles and templates overview](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
