---
title: "FlowDocument controls"
description: Learn about the FlowDocument controls in WPF, which display FlowDocument content in different viewing modes including scrolling, paged, and multi-mode readers.
ms.date: "10/30/2025"
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], FlowDocumentReader"
  - "controls [WPF], FlowDocumentPageViewer"
  - "controls [WPF], FlowDocumentScrollViewer"
  - "FlowDocumentReader control [WPF]"
  - "FlowDocumentPageViewer control [WPF]"
  - "FlowDocumentScrollViewer control [WPF]"
ai-usage: ai-assisted
---
# FlowDocument controls

WPF provides three specialized controls for viewing <xref:System.Windows.Documents.FlowDocument> content, each optimized for different presentation scenarios. These controls enable you to display rich, reflowable content in your applications while offering users different ways to interact with that content.

:::image type="content" source="./media/shared/flowdocument.png" alt-text="Screenshot of the FlowDocumentReader control with a sample document open.":::

The three FlowDocument controls are:

- <xref:System.Windows.Controls.FlowDocumentScrollViewer>: Displays content in a continuous scrolling view, ideal for reading long documents without pagination.
- <xref:System.Windows.Controls.FlowDocumentPageViewer>: Presents content page by page, similar to a book or magazine layout.
- <xref:System.Windows.Controls.FlowDocumentReader>: Offers the most flexibility by allowing users to switch between different viewing modes, including scrolling, page-by-page, and two-page spread views.

All three controls share the common purpose of displaying <xref:System.Windows.Documents.FlowDocument> content, which automatically adjusts to fit the available viewing area. Choose the control that best matches your application's needs: use <xref:System.Windows.Controls.FlowDocumentScrollViewer> for simple scrolling scenarios, <xref:System.Windows.Controls.FlowDocumentPageViewer> for fixed-page presentations, or <xref:System.Windows.Controls.FlowDocumentReader> when you want to give users control over how they view the content.

For detailed information about creating and working with flow documents, see [Flow Document Overview](../advanced/flow-document-overview.md).

## FlowDocumentScrollViewer

The <xref:System.Windows.Controls.FlowDocumentScrollViewer> control displays <xref:System.Windows.Documents.FlowDocument> content in a scrolling container. This control is ideal for continuous reading experiences where you want users to scroll through content rather than navigate between pages. Contrast with <xref:System.Windows.Controls.FlowDocumentPageViewer>, which views content on a per page basis.

### Content property

The content property for <xref:System.Windows.Controls.FlowDocumentScrollViewer> is `Document`, which specifies the <xref:System.Windows.Documents.FlowDocument> to display.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.FlowDocumentScrollViewer> control.

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_ContentHost | <xref:System.Windows.Controls.ScrollViewer> | The scrolling host for the flow document content. |
| PART_FindToolBarHost | <xref:System.Windows.Controls.Decorator> | The host for the find toolbar. |
| PART_ToolBarHost | <xref:System.Windows.Controls.Decorator> | The host for the toolbar. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.FlowDocumentScrollViewer> control.

| VisualState Name | VisualStateGroup Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## FlowDocumentPageViewer

The <xref:System.Windows.Controls.FlowDocumentPageViewer> control displays <xref:System.Windows.Documents.FlowDocument> content on a per page basis. This control provides a book-like reading experience with page navigation controls. Contrast with the <xref:System.Windows.Controls.FlowDocumentScrollViewer>, which presents <xref:System.Windows.Documents.FlowDocument> content in a scrolling viewer.

### Content property

The <xref:System.Windows.Controls.FlowDocumentPageViewer.Document> property is the content property of the <xref:System.Windows.Controls.FlowDocumentPageViewer> control and contains the flow document displayed in the viewer.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.FlowDocumentPageViewer> control.

| Part Name | Part Type | Description |
|-|-|-|
| PART_FindToolBarHost | <xref:System.Windows.Controls.Decorator> | The decorator that hosts the find toolbar. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.FlowDocumentPageViewer> control.

| Visual state | Visual state group | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## FlowDocumentReader

The <xref:System.Windows.Controls.FlowDocumentReader> control displays <xref:System.Windows.Documents.FlowDocument> content and supports multiple viewing modes. This control provides the most flexibility by allowing users to choose their preferred reading experience, switching between scrolling, single-page, and two-page spread views.

### Content property

The <xref:System.Windows.Controls.FlowDocumentReader.Document> property is the content property and defines the <xref:System.Windows.Documents.FlowDocument> content that the reader displays.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.FlowDocumentReader> control.

| Part Name | Part Type | Description |
|-----------|-----------|-------------|
| PART_ContentHost | <xref:System.Windows.Controls.Decorator> | The decorator that hosts the content viewer for different viewing modes. |
| PART_FindToolBarHost | <xref:System.Windows.Controls.Decorator> | The decorator that hosts the find toolbar when find functionality is enabled. |

### Visual states

The following table lists the visual states for the <xref:System.Windows.Controls.FlowDocumentReader> control.

| Visual State Name | Visual State Group Name | Description |
|-|-|-|
| Valid | ValidationStates | The control is valid and has no validation errors. |
| InvalidFocused | ValidationStates | The control has a validation error and has keyboard focus. |
| InvalidUnfocused | ValidationStates | The control has a validation error but doesn't have keyboard focus. |

## Styles and templates

You can modify the default <xref:System.Windows.Controls.ControlTemplate> for these controls to give them a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

## See also

- <xref:System.Windows.Controls.FlowDocumentReader>
- <xref:System.Windows.Controls.FlowDocumentPageViewer>
- <xref:System.Windows.Controls.FlowDocumentScrollViewer>
- <xref:System.Windows.Documents.FlowDocument>
- [Documents in WPF](../advanced/documents-in-wpf.md)
- [Flow Document Overview](../advanced/flow-document-overview.md)
- [Flow Document How To Topics](../advanced/flow-content-elements-how-to-topics.md)
