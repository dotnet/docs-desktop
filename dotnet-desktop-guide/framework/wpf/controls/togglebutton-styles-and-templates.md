---
title: "ToggleButton Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "states [WPF], ToggleButton"
  - "ToggleButton [WPF], styles and templates"
  - "ControlTemplate [WPF], ToggleButton"
  - "styles [WPF], ToggleButton"
  - "templates [WPF], ToggleButton"
  - "parts [WPF], ToggleButton"
ms.assetid: 54f23f30-4bcb-4f09-8ce4-376a13a255a1
---

# ToggleButton Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.Primitives.ToggleButton> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](/dotnet/desktop-wpf/themes/how-to-create-apply-template).

## ToggleButton Parts

The <xref:System.Windows.Controls.Primitives.ToggleButton> control does not have any named parts.

## ToggleButton States

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.ToggleButton> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Pressed|CommonStates|The control is pressed.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has focus.|
|Unfocused|FocusStates|The control does not have focus.|
|Checked|CheckStates|<xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `true`.|
|Unchecked|CheckStates|<xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `false`.|
|Indeterminate|CheckStates|<xref:System.Windows.Controls.Primitives.ToggleButton.IsThreeState%2A> is `true`, and <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `null`.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control does not have focus.|

> [!NOTE]
> If the Indeterminate visual state does not exist in your control template, then the Unchecked visual state will be used as default visual state.

## ToggleButton ControlTemplate Example

The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Primitives.ToggleButton> control.

[!code-xaml[ControlTemplateExamples#ToggleButton](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/combobox.xaml#togglebutton)]

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
