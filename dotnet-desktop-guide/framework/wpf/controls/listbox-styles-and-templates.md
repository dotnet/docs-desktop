---
title: "ListBox Styles and Templates"
description: Learn about the styles and templates of the ListBox control in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "styles [WPF], ListBox"
  - "templates [WPF], ListBox"
  - "states [WPF], ListBox"
  - "ControlTemplate [WPF], ListBox"
  - "parts [WPF], ListBox"
  - "ListBox [WPF], styles and templates"
ms.assetid: fc5764cb-c27b-495b-88d4-d969a8213ccb
---
# ListBox Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.ListBox> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).  
  
## ListBox Parts  

 The <xref:System.Windows.Controls.ListBox> control does not have any named parts.  
  
 When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.ListBox>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.ListBox>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.  
  
## ListBox States  

 The following table lists the visual states for the <xref:System.Windows.Controls.ListBox> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control is valid.|  
|InvalidFocused|ValidationStates|The control is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|  
  
## ListBoxItem Parts  

 The <xref:System.Windows.Controls.ListBoxItem> control does not have any named parts.  
  
## ListBoxItem States  

 The following table lists the visual states for the <xref:System.Windows.Controls.ListBox> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|  
|Disabled|CommonStates|The item is disabled.|  
|Focused|FocusStates|The item has focus.|  
|Unfocused|FocusStates|The item does not have focus.|  
|Unselected|SelectionStates|The item is not selected.|  
|Selected|SelectionStates|The item is currentlyplate selected.|  
|SelectedUnfocused|SelectionStates|The item is selected, but does not have focus.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## ListBox ControlTemplate Example  

 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.ListBox> and <xref:System.Windows.Controls.ListBoxItem> controls.  
  
 [!code-xaml[ControlTemplateExamples#ListBox](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/listbox.xaml#listbox)]  
  
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
