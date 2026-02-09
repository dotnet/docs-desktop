---
title: "ScrollViewer"
description: Learn how the ScrollViewer control creates a scrollable region at which point content can be scrolled horizontally or vertically.
ms.date: 01/28/2026
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "scrolling content [WPF]"
  - "ScrollViewer control [WPF]"
  - "content [WPF], ScrollViewer control"
  - "controls [WPF], ScrollViewer"
ai-usage: ai-assisted
---
# ScrollViewer

The <xref:System.Windows.Controls.ScrollViewer> control creates a scrollable region wherein content can be scrolled horizontally or vertically. Content within a user interface is often larger than a computer screen's display area, and ScrollViewer provides a convenient way to enable scrolling of content in Windows Presentation Foundation (WPF) applications.

:::image type="content" source="./media/shared/scrollviewer.png" alt-text="A screenshot of scroll viewer container, demonstrating scroll bars in WPF.":::

The <xref:System.Windows.Controls.ScrollViewer> control encapsulates horizontal and vertical <xref:System.Windows.Controls.Primitives.ScrollBar> elements and a content container (such as a <xref:System.Windows.Controls.Panel> element) to display other visible elements in a scrollable area. You can use the <xref:System.Windows.Controls.ScrollViewer> element by itself because it's a composite control that encapsulates <xref:System.Windows.Controls.Primitives.ScrollBar> functionality.

The <xref:System.Windows.Controls.ScrollViewer> control responds to both mouse and keyboard commands, and defines numerous methods with which to scroll content by predetermined increments. You can use the <xref:System.Windows.Controls.ScrollViewer.ScrollChanged> event to detect a change in a <xref:System.Windows.Controls.ScrollViewer> state.

A <xref:System.Windows.Controls.ScrollViewer> can only have one child, typically a <xref:System.Windows.Controls.Panel> element that can host a <xref:System.Windows.Controls.Panel.Children%2A> collection of elements. The <xref:System.Windows.Controls.ContentPresenter.Content%2A> property defines the sole child of the <xref:System.Windows.Controls.ScrollViewer>.

## Physical vs. logical scrolling

Physical scrolling is used to scroll content by a predetermined physical increment, typically by a value that's declared in pixels. Logical scrolling is used to scroll to the next item in the logical tree. Physical scrolling is the default scroll behavior for most <xref:System.Windows.Controls.Panel> elements. WPF supports both types of scrolling.

### The IScrollInfo interface

The <xref:System.Windows.Controls.Primitives.IScrollInfo> interface represents the main scrolling region within a <xref:System.Windows.Controls.ScrollViewer> or derived control. The interface defines scrolling properties and methods that can be implemented by <xref:System.Windows.Controls.Panel> elements that require scrolling by logical unit, rather than by a physical increment. Casting an instance of <xref:System.Windows.Controls.Primitives.IScrollInfo> to a derived <xref:System.Windows.Controls.Panel> and then using its scrolling methods provides a useful way to scroll to the next logical unit in a child collection, rather than by pixel increment. By default, the <xref:System.Windows.Controls.ScrollViewer> control supports scrolling by physical units.

<xref:System.Windows.Controls.StackPanel> and <xref:System.Windows.Controls.VirtualizingStackPanel> both implement <xref:System.Windows.Controls.Primitives.IScrollInfo> and natively support logical scrolling. For layout controls that natively support logical scrolling, you can still achieve physical scrolling by wrapping the host <xref:System.Windows.Controls.Panel> element in a <xref:System.Windows.Controls.ScrollViewer> and setting the <xref:System.Windows.Controls.ScrollViewer.CanContentScroll%2A> property to `false`.

The following code example demonstrates how to cast an instance of <xref:System.Windows.Controls.Primitives.IScrollInfo> to a <xref:System.Windows.Controls.StackPanel> and use content scrolling methods (<xref:System.Windows.Controls.Primitives.IScrollInfo.LineUp%2A> and <xref:System.Windows.Controls.Primitives.IScrollInfo.LineDown%2A>) defined by the interface.

[!code-csharp[IScrollInfoMethods#3](~/samples/snippets/csharp/VS_Snippets_Wpf/IScrollInfoMethods/CSharp/Window1.xaml.cs#3)]
[!code-vb[IScrollInfoMethods#3](~/samples/snippets/visualbasic/VS_Snippets_Wpf/IScrollInfoMethods/VisualBasic/Window1.xaml.vb#3)]

## Example

The following example creates a <xref:System.Windows.Controls.ScrollViewer> in a window that contains some text and a rectangle. <xref:System.Windows.Controls.Primitives.ScrollBar> elements appear only when they're necessary. When you resize the window, the <xref:System.Windows.Controls.Primitives.ScrollBar> elements appear and disappear, due to updated values of the <xref:System.Windows.Controls.ScrollViewer.ComputedHorizontalScrollBarVisibility%2A> and <xref:System.Windows.Controls.ScrollViewer.ComputedVerticalScrollBarVisibility%2A> properties.

[!code-cpp[ScrollViewer#1](~/samples/snippets/cpp/VS_Snippets_Wpf/ScrollViewer/CPP/ScrollViewer_wcp.cpp#1)]
[!code-csharp[ScrollViewer#1](~/samples/snippets/csharp/VS_Snippets_Wpf/ScrollViewer/CSharp/ScrollViewer_wcp.cs#1)]
[!code-vb[ScrollViewer#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ScrollViewer/VisualBasic/ScrollViewer.vb#1)]
[!code-xaml[ScrollViewer#1](~/samples/snippets/xaml/VS_Snippets_Wpf/ScrollViewer/XAML/Pane1.xaml#1)]

## How-to topics

| Title | Description |
| ----- | ----------- |
| [Handle the ScrollChanged Event](how-to-handle-the-scrollchanged-event.md) | Learn how to handle the ScrollChanged event in a ScrollViewer control. |
| [Scroll Content by Using the IScrollInfo Interface](how-to-scroll-content-by-using-the-iscrollinfo-interface.md) | Learn how to scroll content by using the IScrollInfo interface. |
| [Use the Content-Scrolling Methods of ScrollViewer](how-to-use-the-content-scrolling-methods-of-scrollviewer.md) | Learn how to use the content-scrolling methods of ScrollViewer. |

## Styles and templates

This section describes the styles and templates for the <xref:System.Windows.Controls.ScrollViewer> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.ContentPresenter.Content%2A> property defines the sole child of the <xref:System.Windows.Controls.ScrollViewer>.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.ScrollViewer> control.

| Part | Type | Description |
| ---- | ---- | ----------- |
| PART_HorizontalScrollBar | <xref:System.Windows.Controls.Primitives.ScrollBar> | The <xref:System.Windows.Controls.Primitives.ScrollBar> used to scroll the content horizontally. |
| PART_ScrollContentPresenter | <xref:System.Windows.Controls.ScrollContentPresenter> | The placeholder for content in the <xref:System.Windows.Controls.ScrollViewer>. |
| PART_VerticalScrollBar | <xref:System.Windows.Controls.Primitives.ScrollBar> | The <xref:System.Windows.Controls.Primitives.ScrollBar> used to scroll the content vertically. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.ScrollViewer> control.

| VisualState Name | VisualStateGroup Name | Description |
| ---------------- | --------------------- | ----------- |
| InvalidFocused | ValidationStates | The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control has focus. |
| InvalidUnfocused | ValidationStates | The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` and the control doesn't have focus. |
| Valid | ValidationStates | The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`. |

## Paginating documents

For document content, an alternative to scrolling is to choose a document container that supports pagination. <xref:System.Windows.Documents.FlowDocument> is for documents that are designed to be hosted within a viewing control, such as <xref:System.Windows.Controls.FlowDocumentPageViewer>, that supports paginating content across multiple pages, preventing the need for scrolling. <xref:System.Windows.Controls.DocumentViewer> provides a solution for viewing <xref:System.Windows.Documents.FixedDocument> content, which uses traditional scrolling to display content outside the realm of the display area.

For additional information about document formats and presentation options, see [Documents in WPF](../advanced/documents-in-wpf.md).

## See also

- <xref:System.Windows.Controls.DocumentViewer>
- <xref:System.Windows.Controls.FlowDocumentPageViewer>
- <xref:System.Windows.Controls.Primitives.IScrollInfo>
- <xref:System.Windows.Controls.Primitives.ScrollBar>
- <xref:System.Windows.Controls.ScrollViewer>
- <xref:System.Windows.Controls.StackPanel>
- <xref:System.Windows.Controls.VirtualizingStackPanel>
- [Documents in WPF](../advanced/documents-in-wpf.md)
- [How to: Create a Scroll Viewer](/previous-versions/dotnet/netframework-3.5/ms752352(v=vs.90))
- [Layout](../advanced/layout.md)
- [Panels Overview](panels-overview.md)
