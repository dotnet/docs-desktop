---
title: "How to: Insert an Element Into Text Programmatically"
ms.date: "03/30/2017"
ms.service: dotnet-framework
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "Text Animation sample [WPF]"
  - "elements [WPF], inserting into text"
  - "inserting elements into text [WPF]"
  - "TextPointer objects [WPF]"
  - "text [WPF], inserting elements"
ms.assetid: 97bd950a-25ac-4e42-a311-94b6420d4136
description: Learn how to use two TextPointer objects to specify a range within text to apply a Span element, with supporting examples and links.
---
# How to: Insert an Element Into Text Programmatically

The following example shows how to use two <xref:System.Windows.Documents.TextPointer> objects to specify a range within text to apply a <xref:System.Windows.Documents.Span> element to.

## Example

[!code-csharp[FlowMiscSnippets_procedural_snip#InsertInlineIntoTextExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/FlowMiscSnippets_procedural_snip/CSharp/InsertInlineIntoTextExample.cs#insertinlineintotextexamplewholepage)]
[!code-vb[FlowMiscSnippets_procedural_snip#InsertInlineIntoTextExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/FlowMiscSnippets_procedural_snip/VisualBasic/InsertInlineIntoTextExample.vb#insertinlineintotextexamplewholepage)]

The illustration below shows what this example looks like.

![A Span element applied to a range of text](./media/flow-insertelementintotextprogrammatically.png "Flow_InsertElementIntoTextProgrammatically")

## See also

- [Flow Document Overview](flow-document-overview.md)
