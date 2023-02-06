---
title: "StatusBar Styles and Templates"
description: Learn about the StatusBar Styles and Templates.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
helpviewer_keywords: 
  - "ControlTemplate [WPF], StatusBar"
  - "styles [WPF], StatusBar"
  - "templates [WPF], StatusBar"
  - "states [WPF], StatusBar"
  - "parts [WPF], StatusBar"
  - "StatusBar [WPF], styles and templates"
ms.assetid: 9f5e1c25-81eb-4756-a0ac-d9e1fbe33ee2
---
# StatusBar Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.Primitives.StatusBar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).  
  
## StatusBar Parts  

 The <xref:System.Windows.Controls.Primitives.StatusBar> control does not have any named parts.  
  
## StatusBar States  

 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.StatusBar> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## StatusBarItem Parts  

 The <xref:System.Windows.Controls.Primitives.StatusBarItem> control does not have any named parts.  
  
## StatusBarItem States

 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.StatusBarItem> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## StatusBar ControlTemplate Example  

 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Primitives.StatusBar> control.  
  
 [!code-xaml[ControlTemplateExamples#StatusBar](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/statusbar.xaml#statusbar)]  
  
 The <xref:System.Windows.Controls.ControlTemplate> uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
