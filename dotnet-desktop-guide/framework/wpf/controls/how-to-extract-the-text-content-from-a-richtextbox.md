---
title: "How to: Extract the Text Content from a RichTextBox"
description: Learn how to extract the Text Content from a RichTextBox.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "text content [WPF], extracting"
  - "RichTextBox control [WPF], extracting text content"
  - "content [WPF], extracting"
  - "extracting text content [WPF]"
ms.assetid: f13c093f-1a05-45b3-ac8f-c9ea5e4a11c5
---
# How to: Extract the Text Content from a RichTextBox

This example shows how to extract the contents of a <xref:System.Windows.Controls.RichTextBox> as plain text.  
  
## Describe a RichTextBox control

 The following Extensible Application Markup Language (XAML) code describes a named <xref:System.Windows.Controls.RichTextBox> control with simple content.  
  
 [!code-xaml[RichTextBoxSnippets#_RTB_XAML](~/samples/snippets/csharp/VS_Snippets_Wpf/RichTextBoxSnippets/CSharp/Window1.xaml#_rtb_xaml)]  
  
## Code example with RichTextBox as an argument

 The following code implements a method that takes a <xref:System.Windows.Controls.RichTextBox> as an argument, and returns a string representing the plain text contents of the <xref:System.Windows.Controls.RichTextBox>.  
  
 The method creates a new <xref:System.Windows.Documents.TextRange> from the contents of the <xref:System.Windows.Controls.RichTextBox>, using the <xref:System.Windows.Documents.FlowDocument.ContentStart%2A> and <xref:System.Windows.Documents.FlowDocument.ContentEnd%2A> to indicate the range of the contents to extract.  <xref:System.Windows.Documents.FlowDocument.ContentStart%2A> and <xref:System.Windows.Documents.FlowDocument.ContentEnd%2A> properties each return a <xref:System.Windows.Documents.TextPointer>, and are accessible on the underlying FlowDocument that represents the contents of the <xref:System.Windows.Controls.RichTextBox>.  <xref:System.Windows.Documents.TextRange> provides a Text property, which returns the plain text portions of the <xref:System.Windows.Documents.TextRange> as a string.  
  
 [!code-csharp[RichTextBoxSnippets#_RTB_StringFrom](~/samples/snippets/csharp/VS_Snippets_Wpf/RichTextBoxSnippets/CSharp/Window1.xaml.cs#_rtb_stringfrom)]
 [!code-vb[RichTextBoxSnippets#_RTB_StringFrom](~/samples/snippets/visualbasic/VS_Snippets_Wpf/RichTextBoxSnippets/visualbasic/window1.xaml.vb#_rtb_stringfrom)]  
  
## See also

- [RichTextBox Overview](richtextbox-overview.md)
- [TextBox Overview](textbox-overview.md)
