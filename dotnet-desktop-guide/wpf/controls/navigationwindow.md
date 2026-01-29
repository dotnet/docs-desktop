---
title: "NavigationWindow"
description: Learn about the NavigationWindow control in WPF, including its parts, visual states, and control template.
ms.date: "01/23/2025"
ms.service: dotnet-framework
ms.update-cycle: 1825-days
helpviewer_keywords:
  - "states [WPF], NavigationWindow"
  - "NavigationWindow [WPF], styles and templates"
  - "ControlTemplate [WPF], NavigationWindow"
  - "parts [WPF], NavigationWindow"
  - "styles [WPF], NavigationWindow"
  - "templates [WPF], NavigationWindow"
ai-usage: ai-assisted
---
# NavigationWindow

The <xref:System.Windows.Navigation.NavigationWindow> control provides a specialized window that supports navigation and hosting of pages. It's designed for applications that need browser-like navigation capabilities, allowing users to navigate between different pages or content within a window.

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).

### Content property

The NavigationWindow control uses the `Content` property to display the navigated content.

### Parts

The following table lists the named parts for the <xref:System.Windows.Navigation.NavigationWindow> control.

|Part|Type|Description|
|-|-|-|
|PART_NavWinCP|<xref:System.Windows.Controls.ContentPresenter>|The content presenter that displays the navigated content.|

### Visual states

The NavigationWindow control doesn't define any visual states.

## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Customization](control-customization.md)
- [Styling and Templating](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
