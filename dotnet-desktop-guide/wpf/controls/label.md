---
title: "Label"
description: Learn how to use the Label control to provide information and access key support in a Windows Presentation Foundation (WPF) application.
ms.date: 01/28/2026
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "controls [WPF], Label"
  - "Label control [WPF]"
ai-usage: ai-assisted
---
# Label

<xref:System.Windows.Controls.Label> controls usually provide information in the user interface (UI). Historically, a <xref:System.Windows.Controls.Label> has contained only text, but because the <xref:System.Windows.Controls.Label> that ships with Windows Presentation Foundation (WPF) is a <xref:System.Windows.Controls.ContentControl>, it can contain either text or a <xref:System.Windows.UIElement>.

:::image type="content" source="./media/shared/label.png" alt-text="Screenshot of Label controls displayed in different ways.":::

A <xref:System.Windows.Controls.Label> provides both functional and visual support for access keys. It's frequently used to enable quick keyboard access to controls such as a <xref:System.Windows.Controls.TextBox>. To assign a <xref:System.Windows.Controls.Label> to a <xref:System.Windows.Controls.Control>, set the <xref:System.Windows.Controls.Label.Target%2A?displayProperty=nameWithType> property to the control that should get focus when the user presses the access key.

The following image shows a <xref:System.Windows.Controls.Label> "Theme" that targets a <xref:System.Windows.Controls.ComboBox>. When the user presses <kbd>T</kbd>, the <xref:System.Windows.Controls.ComboBox> receives focus.

| Title | Description |
|-------|-------------|
| [How to: Create a Control That Has an Access Key and Text Wrapping](how-to-create-a-control-that-has-an-access-key-and-text-wrapping.md) | Learn how to create a control that has an access key and supports text wrapping. |

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.Label> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.Label> control uses the <xref:System.Windows.Controls.ContentControl.Content%2A> property to display its content. This property can contain text or any <xref:System.Windows.UIElement>.

### Parts

The <xref:System.Windows.Controls.Label> control doesn't define any template parts.

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Label> control.

| VisualState Name | VisualStateGroup Name | Description |
|------------------|----------------------|-------------|
| Valid | ValidationStates | The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`. |
| InvalidFocused | ValidationStates | The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus. |
| InvalidUnfocused | ValidationStates | The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control doesn't have focus. |

## See also

- [How to: Set the Target Property of a Label](/previous-versions/dotnet/netframework-3.5/ms752101(v=vs.90))
- <xref:System.Windows.Controls.Label>
