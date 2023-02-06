---
title: "ProgressBar Styles and Templates"
description: Learn about the styles and templates for the ProgressBar control allowing you to modify the default ControlTemplate and give it a unique appearance.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "parts [WPF], ProgressBar"
  - "ProgressBar [WPF], styles and templates"
  - "styles [WPF], ProgressBar"
  - "ControlTemplate [WPF], ProgressBar"
  - "templates [WPF], ProgressBar"
  - "states [WPF], ProgressBar"
ms.assetid: 935aa600-16e6-4947-a905-37a189a583dd
---
# ProgressBar Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.ProgressBar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).  
  
## ProgressBar Parts  

 The following table lists the named parts for the <xref:System.Windows.Controls.ProgressBar> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_Indicator|<xref:System.Windows.FrameworkElement>|The object that indicates progress.|  
|PART_Track|<xref:System.Windows.FrameworkElement>|The object that defines the path of the progress indicator.|  
|PART_GlowRect|<xref:System.Windows.FrameworkElement>|An object that embellishes the progress bar.|  
  
## ProgressBar States  

 The following table lists the visual states for the <xref:System.Windows.Controls.ProgressBar> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|----------------------|---------------------------|-----------------|  
|Determinate|CommonStates|<xref:System.Windows.Controls.ProgressBar> reports progress based on the <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> property.|  
|Indeterminate|CommonStates|<xref:System.Windows.Controls.ProgressBar> reports generic progress with a repeating pattern.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## ProgressBar ControlTemplate Example  

 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.ProgressBar> control.  
  
 [!code-xaml[ControlTemplateExamples#ProgressBar](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/progressbar.xaml#progressbar)]  
  
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
