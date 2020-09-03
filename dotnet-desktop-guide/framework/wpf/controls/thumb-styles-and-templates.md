---
title: "Thumb Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "states [WPF], Thumb"
  - "styles [WPF], Thumb"
  - "templates [WPF], Thumb"
  - "Thumb [WPF], styles and templates"
  - "ControlTemplate [WPF], Thumb"
  - "parts [WPF], Thumb"
ms.assetid: 86a49235-62d9-414e-923e-53126e3f930a
---

# Thumb Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.Primitives.Thumb> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](/dotnet/desktop-wpf/themes/how-to-create-apply-template).

## Thumb Parts

The <xref:System.Windows.Controls.Primitives.Thumb> control does not have any named parts.

## Thumb States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.Thumb> control.

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

## Thumb ControlTemplate Example

The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Primitives.Thumb> control.

[!code-xaml[ControlTemplateExamples#Thumb](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/slider.xaml#thumb)]

The preceding example uses one or more of the following resources.

[!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]

For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).

## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](/dotnet/desktop-wpf/fundamentals/styles-templates-overview)
- [Create a template for a control](/dotnet/desktop-wpf/themes/how-to-create-apply-template)
