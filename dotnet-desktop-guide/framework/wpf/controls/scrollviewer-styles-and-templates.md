---
title: "ScrollViewer Styles and Templates"
description: Learn about the styles and templates for the ScrollViewer control allowing you to modify the default ControlTemplate to give the control a unique appearance. 
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "parts [WPF], ScrollViewer"
  - "states [WPF], ScrollViewer"
  - "styles [WPF], ScrollViewer"
  - "templates [WPF], ScrollViewer"
  - "ControlTemplate [WPF], ScrollViewer"
  - "ScrollViewer [WPF], styles and templates"
ms.assetid: dffdd822-ae69-4946-abaf-710860cd65b2
---
# ScrollViewer Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.ScrollViewer> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).  
  
## ScrollViewer Parts  

 The following table lists the named parts for the <xref:System.Windows.Controls.ScrollViewer> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_ScrollContentPresenter|<xref:System.Windows.Controls.ScrollContentPresenter>|The placeholder for content in the <xref:System.Windows.Controls.ScrollViewer>.|  
|PART_HorizontalScrollBar|<xref:System.Windows.Controls.Primitives.ScrollBar>|The <xref:System.Windows.Controls.Primitives.ScrollBar> used to scroll the content horizontally.|  
|PART_VerticalScrollBar|<xref:System.Windows.Controls.Primitives.ScrollBar>|The <xref:System.Windows.Controls.Primitives.ScrollBar> used to scroll the content vertically.|  
  
## ScrollViewer States  

 The following table lists the visual states for the <xref:System.Windows.Controls.ScrollViewer> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## ScrollViewer ControlTemplate Example  

 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.ScrollViewer> control.  
  
 [!code-xaml[ControlTemplateExamples#ScrollViewer](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/scrollviewer.xaml#scrollviewer)]  
  
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
