---
title: "Window"
description: Learn about the Window control, which represents a window in WPF applications and provides the foundation for creating standalone desktop applications.
ai-usage: ai-assisted
ms.date: "01/28/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "parts [WPF], Window"
  - "templates [WPF], Window"
  - "styles [WPF], Window"
  - "ControlTemplate [WPF], Window"
  - "Window [WPF], styles and templates"
  - "states [WPF], Window"
---
# Window

The <xref:System.Windows.Window> control represents a window in Windows Presentation Foundation (WPF) applications. It provides the foundation for creating standalone desktop applications with a title bar, borders, and standard window controls like minimize, maximize, and close buttons. Windows can host any WPF content and support features like dialog boxes, modeless windows, and application main windows.

## Styles and templates

You can customize the appearance of the <xref:System.Windows.Window> control by modifying its default <xref:System.Windows.Controls.ControlTemplate>. For more information about customizing templates, see [Create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Window> control uses the <xref:System.Windows.Window.Content%2A> property to define the main content displayed within the window.

### Parts

The <xref:System.Windows.Window> control doesn't define any named template parts.

### Visual states

The <xref:System.Windows.Window> control doesn't define any visual states.

### ControlTemplate

The following XAML shows the default template for the <xref:System.Windows.Window> control:

:::code language="xaml" source="./snippets/shared/templates/WindowTemplate.xaml":::

## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Customization](control-customization.md)
- [Styling and Templating](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
