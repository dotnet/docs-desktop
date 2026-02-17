---
title: "ScrollBar"
description: Learn how a ScrollBar allows you to view content that is outside of the current viewing area by sliding the Thumb to make the content visible.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "ScrollBar control [WPF]"
  - "controls [WPF], ScrollBar"
ai-usage: ai-assisted
---
# ScrollBar

A <xref:System.Windows.Controls.Primitives.ScrollBar> allows you to view content outside the current viewing area by sliding the <xref:System.Windows.Controls.Primitives.Thumb> to make the content visible. Content within a user interface is often larger than a computer screen's display area, and ScrollBar provides the fundamental scrolling mechanism used throughout Windows Presentation Foundation (WPF) applications.

:::image type="content" source="./media/shared/scrollbar.png" alt-text="A screenshot of vertical and horizontal scroll bars in WPF.":::

There are two predefined elements that enable scrolling in WPF applications: <xref:System.Windows.Controls.Primitives.ScrollBar> and <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ScrollViewer> control encapsulates horizontal and vertical <xref:System.Windows.Controls.Primitives.ScrollBar> elements and a content container (such as a <xref:System.Windows.Controls.Panel> element) to display other visible elements in a scrollable area. You must build a custom object to use the <xref:System.Windows.Controls.Primitives.ScrollBar> element for content scrolling. However, you can use the <xref:System.Windows.Controls.ScrollViewer> element by itself because it's a composite control that encapsulates <xref:System.Windows.Controls.Primitives.ScrollBar> functionality.

| Title | Description |
| ----- | ----------- |
| [Customize the Thumb Size on a ScrollBar](how-to-customize-the-thumb-size-on-a-scrollbar.md) | Learn how to customize the size of the thumb element in a ScrollBar control. |

## Key concepts

### Physical vs. logical scrolling

Physical scrolling is used to scroll content by a predetermined physical increment, typically by a value that's declared in pixels. Logical scrolling is used to scroll to the next item in the logical tree. Physical scrolling is the default scroll behavior for most <xref:System.Windows.Controls.Panel> elements. WPF supports both types of scrolling.

The <xref:System.Windows.Controls.Primitives.IScrollInfo> interface represents the main scrolling region within a <xref:System.Windows.Controls.ScrollViewer> or derived control. The interface defines scrolling properties and methods that can be implemented by <xref:System.Windows.Controls.Panel> elements that require scrolling by logical unit, rather than by a physical increment. Casting an instance of <xref:System.Windows.Controls.Primitives.IScrollInfo> to a derived <xref:System.Windows.Controls.Panel> and then using its scrolling methods provides a useful way to scroll to the next logical unit in a child collection, rather than by pixel increment.

<xref:System.Windows.Controls.StackPanel> and <xref:System.Windows.Controls.VirtualizingStackPanel> both implement <xref:System.Windows.Controls.Primitives.IScrollInfo> and natively support logical scrolling. For layout controls that natively support logical scrolling, you can still achieve physical scrolling by wrapping the host <xref:System.Windows.Controls.Panel> element in a <xref:System.Windows.Controls.ScrollViewer> and setting the <xref:System.Windows.Controls.ScrollViewer.CanContentScroll%2A> property to `false`.

## Examples

### Using IScrollInfo for content scrolling

The following code example demonstrates how to cast an instance of <xref:System.Windows.Controls.Primitives.IScrollInfo> to a <xref:System.Windows.Controls.StackPanel> and use content scrolling methods (<xref:System.Windows.Controls.Primitives.IScrollInfo.LineUp%2A> and <xref:System.Windows.Controls.Primitives.IScrollInfo.LineDown%2A>) defined by the interface.

[!code-csharp[IScrollInfoMethods#3](~/samples/snippets/csharp/VS_Snippets_Wpf/IScrollInfoMethods/CSharp/Window1.xaml.cs#3)]
[!code-vb[IScrollInfoMethods#3](~/samples/snippets/visualbasic/VS_Snippets_Wpf/IScrollInfoMethods/VisualBasic/Window1.xaml.vb#3)]

### Creating a ScrollViewer with ScrollBar elements

The following example creates a <xref:System.Windows.Controls.ScrollViewer> in a window that contains some text and a rectangle. <xref:System.Windows.Controls.Primitives.ScrollBar> elements appear only when they're necessary. When you resize the window, the <xref:System.Windows.Controls.Primitives.ScrollBar> elements appear and disappear, due to updated values of the <xref:System.Windows.Controls.ScrollViewer.ComputedHorizontalScrollBarVisibility%2A> and <xref:System.Windows.Controls.ScrollViewer.ComputedVerticalScrollBarVisibility%2A> properties.

[!code-cpp[ScrollViewer#1](~/samples/snippets/cpp/VS_Snippets_Wpf/ScrollViewer/CPP/ScrollViewer_wcp.cpp#1)]
[!code-csharp[ScrollViewer#1](~/samples/snippets/csharp/VS_Snippets_Wpf/ScrollViewer/CSharp/ScrollViewer_wcp.cs#1)]
[!code-vb[ScrollViewer#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ScrollViewer/VisualBasic/ScrollViewer.vb#1)]
[!code-xaml[ScrollViewer#1](~/samples/snippets/xaml/VS_Snippets_Wpf/ScrollViewer/XAML/Pane1.xaml#1)]

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.Primitives.ScrollBar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

This control doesn't define a content property.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.ScrollBar> control.

| Part | Type | Description |
| ---- | ---- | ----------- |
| PART_Track | <xref:System.Windows.Controls.Primitives.Track> | The container for the element that indicates the position of the <xref:System.Windows.Controls.Primitives.ScrollBar>. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.ScrollBar> control.

| VisualState Name | VisualStateGroup Name | Description |
| ---------------- | --------------------- | ----------- |
| Disabled | CommonStates | The control is disabled. |
| MouseOver | CommonStates | The mouse pointer is positioned over the control. |
| Normal | CommonStates | The default state. |
| Focused | FocusStates | The control has keyboard focus. |
| Unfocused | FocusStates | The control doesn't have keyboard focus. |
| InvalidFocused | ValidationStates | The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus. |
| InvalidUnfocused | ValidationStates | The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control doesn't have focus. |
| Valid | ValidationStates | The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`. |

## See also

- <xref:System.Windows.Controls.DocumentViewer>
- <xref:System.Windows.Controls.FlowDocumentPageViewer>
- <xref:System.Windows.Controls.Primitives.IScrollInfo>
- <xref:System.Windows.Controls.Primitives.ScrollBar>
- <xref:System.Windows.Controls.Primitives.Thumb>
- <xref:System.Windows.Controls.Primitives.Track>
- <xref:System.Windows.Controls.ScrollViewer>
- <xref:System.Windows.Controls.StackPanel>
- <xref:System.Windows.Controls.VirtualizingStackPanel>
- [Documents in WPF](../advanced/documents-in-wpf.md)
- [How to: Create a Scroll Viewer](/previous-versions/dotnet/netframework-3.5/ms752352(v=vs.90))
- [ScrollBar Styles and Templates](scrollbar.md)
