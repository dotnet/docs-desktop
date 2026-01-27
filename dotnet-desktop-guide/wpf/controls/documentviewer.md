---
title: "DocumentViewer"
description: Learn about the DocumentViewer control, which is used to view FixedDocument content in a paginated format.
ms.date: "10/30/2025"
ms.service: dotnet-desktop
ms.update-cycle: 365-days
helpviewer_keywords:
  - "controls [WPF], DocumentViewer"
  - "DocumentViewer control [WPF]"
ai-usage: ai-assisted
---
# DocumentViewer

The <xref:System.Windows.Controls.DocumentViewer> control is used to view <xref:System.Windows.Documents.FixedDocument> content (such as XML Paper Specification (XPS) documents) in a paginated format.

:::image type="content" source="./media/shared/documentviewer.png" alt-text="Screenshot of the DocumentViewer control with a sample document open.":::

## Styles and templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.DocumentViewer> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [What are styles and templates?](styles-templates-overview.md) and [How to create a template for a control](how-to-create-apply-template.md).

### Content property

The <xref:System.Windows.Controls.DocumentViewer> control uses the <xref:System.Windows.Controls.Primitives.DocumentViewerBase.Document> property as its content property, which specifies the <xref:System.Windows.Documents.FixedDocument> content to display.

### Parts

The following table lists the named parts for the <xref:System.Windows.Controls.DocumentViewer> control.

|Part|Type|Description|
|-|-|-|
|PART_ContentHost|<xref:System.Windows.Controls.ScrollViewer>|The content and scrolling area.|
|PART_FindToolBarHost|<xref:System.Windows.Controls.ContentControl>|The search box, at the bottom by default.|

### Visual states

This control doesn't define any visual states.

## See also

- <xref:System.Windows.Controls.DocumentViewer>
- <xref:System.Windows.Documents.FixedDocument>
- [Documents](../advanced/documents.md)
- [Document Serialization and Storage](../advanced/document-serialization-and-storage.md)
- [Printing Overview](../documents/printing-overview.md)
