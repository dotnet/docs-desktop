---
title: "RepeatButton Styles and Templates"
description: Learn how the the styles and templates for the RepeatButton control allow you to modify the default ControlTemplate to give the control a unique appearance.
ms.date: "03/30/2017"
ms.service: dotnet-framework
helpviewer_keywords:
  - "RepeatButton [WPF], styles and templates"
  - "styles [WPF], RepeatButton"
  - "templates [WPF], RepeatButton"
  - "parts [WPF], RepeatButton"
  - "ControlTemplate [WPF], RepeatButton"
  - "states [WPF], RepeatButton"
ms.assetid: fd340743-f44f-4990-9077-085301469670
---

# RepeatButton Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.Primitives.RepeatButton> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](how-to-create-apply-template.md).

## RepeatButton Parts

The <xref:System.Windows.Controls.Primitives.RepeatButton> control does not have any named parts.

## RepeatButton States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.RepeatButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has focus.|
|Unfocused|FocusStates|The control does not have focus.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|

## RepeatButton ControlTemplate Example

The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Primitives.RepeatButton> control.

[!code-xaml[ControlTemplateExamples#RepeatButton](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/scrollbar.xaml#repeatbutton)]

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
