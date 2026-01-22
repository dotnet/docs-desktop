---
title: "Frame"
description: Learn about the Frame control, which supports content navigation within content and can be hosted by various root elements.
ms.date: "01/22/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
ai-usage: ai-assisted
helpviewer_keywords:
  - "navigation [WPF], within content"
  - "controls [WPF], Frame"
  - "Frame control [WPF]"
  - "content [WPF], Frame control"
---
# Frame

The <xref:System.Windows.Controls.Frame> control supports content navigation within content. You can host a <xref:System.Windows.Controls.Frame> in root elements like <xref:System.Windows.Window>, <xref:System.Windows.Navigation.NavigationWindow>, <xref:System.Windows.Controls.Page>, <xref:System.Windows.Controls.UserControl>, or <xref:System.Windows.Documents.FlowDocument>. You can also place it as an island within a content tree that belongs to a root element.

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.Frame> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The Frame control uses the <xref:System.Windows.Controls.ContentControl.Content> property to display the navigated content.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Frame> control.

|Part|Type|Description|
|-|-|-|
|PART_FrameCP|<xref:System.Windows.Controls.ContentPresenter>|The content presenter that displays the navigated content in the frame.|

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Frame> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|InvalidFocused|ValidationStates|The control has a validation error and has keyboard focus.|
|InvalidUnfocused|ValidationStates|The control has a validation error but doesn't have keyboard focus.|
|Valid|ValidationStates|The control is valid and has no validation errors.|

## See also

- <xref:System.Windows.Controls.Frame>
- [Navigation Overview](../app-development/navigation-overview.md)
