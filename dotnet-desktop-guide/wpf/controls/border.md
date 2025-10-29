---
title: "Border"
description: Learn about the Border element in this article, including how to dynamically change the properties of the Border element.
ms.date: 10/29/2025
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "borders [WPF]"
  - "controls [WPF], Border"
  - "Border control [WPF]"
ai-usage: ai-assisted
---
# Border

The <xref:System.Windows.Controls.Border> control draws a border, background, or both around another element. Use `Border` to create a visual frame around content or to add spacing between UI elements.

:::image type="content" source="./media/layout-border-around-textbox.png" alt-text="Screenshot showing a TextBox surrounded by a decorative border.":::

| Title | Description |
|-------|-------------|
| [Animate a BorderThickness Value](how-to-animate-a-borderthickness-value.md) | Shows how to animate the thickness of a border to create dynamic visual effects. |
| [Wrap a Border Around the Content of a Canvas](how-to-wrap-a-border-around-the-content-of-a-canvas.md) | Demonstrates how to use a Border control to frame Canvas content. |

## Styles and templates

The <xref:System.Windows.Controls.Border> control inherits from <xref:System.Windows.Controls.Decorator> and provides visual styling capabilities through its border and background properties.

### Content property

The content property for this control is <xref:System.Windows.Controls.Decorator.Child%2A>. This property allows you to place a single child element inside the border.

### Parts

This control doesn't define any template parts.

### Visual states

This control doesn't use visual states.

## Key concepts

Understanding how Border works within the WPF layout system helps you create effective visual designs.

### Border as a decorator

The <xref:System.Windows.Controls.Border> control is a <xref:System.Windows.Controls.Decorator>, which means it can contain only one child element. If you need to place multiple elements inside a border, wrap them in a panel such as <xref:System.Windows.Controls.StackPanel> or <xref:System.Windows.Controls.Grid>.

### Border properties

Border provides several key properties for visual customization:

- <xref:System.Windows.Controls.Border.BorderBrush%2A> - Sets the color or pattern of the border line.
- <xref:System.Windows.Controls.Border.BorderThickness%2A> - Defines how thick the border appears on each side.
- <xref:System.Windows.Controls.Border.Background%2A> - Fills the area inside the border with a color or pattern.
- <xref:System.Windows.Controls.Border.CornerRadius%2A> - Creates rounded corners for a softer appearance.
- <xref:System.Windows.Controls.Border.Padding%2A> - Adds space between the border and its child content.

### Layout considerations

Border participates in the WPF layout system by measuring and arranging its single child element. The border's thickness and padding affect the final size calculations, so consider these values when designing your layout.

## Examples

The following examples demonstrate common Border usage scenarios.

### Basic border usage

The following XAML creates a simple border around a TextBox:

:::code language="xaml" source="./snippets/border/net/csharp/BorderExamples/BasicBorder.xaml" id="BasicBorderUsage":::

### Styling with brushes

You can use gradients and other brushes to create more sophisticated border effects:

:::code language="xaml" source="./snippets/border/net/csharp/BorderExamples/StyledBorder.xaml" id="StyledBorder":::

### Containing multiple elements

Since Border can only contain one child, use a panel to group multiple elements:

:::code language="xaml" source="./snippets/border/net/csharp/BorderExamples/MultipleElements.xaml" id="MultipleElements":::

## See also

- <xref:System.Windows.Controls.Border>
- <xref:System.Windows.Controls.Decorator>
- [Alignment, Margins, and Padding Overview](../advanced/alignment-margins-and-padding-overview.md)
- [Panels Overview](panels-overview.md)
