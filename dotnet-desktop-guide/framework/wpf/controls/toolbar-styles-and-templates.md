---
title: "ToolBar Styles and Templates"
description: Learn about the styles and templates for the ToolBar control allowing you to modify the default ControlTemplate to give the control a unique appearance.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "states [WPF], ToolBar"
  - "styles [WPF], ToolBar"
  - "ControlTemplate [WPF], ToolBar"
  - "parts [WPF], ToolBar"
  - "ToolBar [WPF], styles and templates"
  - "templates [WPF], ToolBar"
ms.assetid: bd875f46-4690-46f5-81e0-f11a9822484f
---
# ToolBar Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.ToolBar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).  
  
## ToolBar Parts  

 The following table lists the named parts for the <xref:System.Windows.Controls.ToolBar> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_ToolBarPanel|<xref:System.Windows.Controls.Primitives.ToolBarPanel>|The object that contains the controls on the <xref:System.Windows.Controls.ToolBar>.|  
|PART_ToolBarOverflowPanel|<xref:System.Windows.Controls.Primitives.ToolBarOverflowPanel>|The object that contains the controls that are in the overflow area of the <xref:System.Windows.Controls.ToolBar>.|  
  
 When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ToolBar>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ToolBar>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.  
  
## ToolBar States  

 The following table lists the visual states for the <xref:System.Windows.Controls.ToolBar> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## ToolBar ControlTemplate Example  

 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.ToolBar> control.  
  
 [!code-xaml[ControlTemplateExamples#ToolBar](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/toolbar.xaml#toolbar)]  
  
 The preceding example uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
