---
title: "Menu Styles and Templates"
description: Learn about styles and templates for the Windows Presentation Foundation the Menu control. Modify the ControlTemplate to give the control a unique appearance.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "styles [WPF], Menu"
  - "ControlTemplate [WPF], Menu"
  - "Menu [WPF], styles and templates"
  - "states [WPF], Menu"
  - "templates [WPF], Menu"
  - "parts [WPF], Menu"
ms.assetid: b89da183-9b87-42c6-ac53-731a42c7b09e
---
# Menu Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.Menu> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](/dotnet/desktop-wpf/themes/how-to-create-apply-template).  
  
## Menu Parts  
 The <xref:System.Windows.Controls.Menu> control does not have any named parts.  
  
 When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.Menu>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.Menu>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.  
  
## Menu States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Menu> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## MenuItem Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Menu> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_Popup|<xref:System.Windows.Controls.Primitives.Popup>|The area for the submenu.|  
  
 When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.MenuItem>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.MenuItem>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.  
  
## MenuItem States  
 The following table lists the visual states for the <xref:System.Windows.Controls.MenuItem> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Menu and MenuItem ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Menu> control.  
  
 [!code-xaml[ControlTemplateExamples#Menu](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/menu.xaml#menu)]  
  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.MenuItem> control.  
  
 [!code-xaml[ControlTemplateExamples#MenuItem](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/menu.xaml#menuitem)]  
  
 The following example defines the `MenuScrollViewer`, which is used in the previous example.  
  
 [!code-xaml[ControlTemplateExamples#MenuScrollViewer](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/menu.xaml#menuscrollviewer)]  
  
 The <xref:System.Windows.Controls.ControlTemplate> examples use one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](/dotnet/desktop-wpf/fundamentals/styles-templates-overview)
- [Create a template for a control](/dotnet/desktop-wpf/themes/how-to-create-apply-template)
