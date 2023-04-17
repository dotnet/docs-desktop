---
title: "Window Styles and Templates"
description: Learn about the styles and templates for the Window control allowing you to modify the default ControlTemplate to give the control a unique appearance. 
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "parts [WPF], Window"
  - "templates [WPF], Window"
  - "styles [WPF], Window"
  - "ControlTemplate [WPF], Window"
  - "Window [WPF], styles and templates"
  - "states [WPF], Window"
ms.assetid: 2dfdf025-347b-4342-bf28-95206c273f35
---
# Window Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Window> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).  
  
## Window Parts  

 The <xref:System.Windows.Window> control does not have any named parts.  
  
## Window States  

 The following table lists the visual states for the <xref:System.Windows.Window> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Window ControlTemplate

The following example is a slightly modified copy of the default template for a <xref:System.Windows.Window> control:

:::code language="xaml" source="./snippets/shared/templates/WindowTemplate.xaml":::
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](styles-templates-overview.md)
- [Create a template for a control](how-to-create-apply-template.md)
