---
title: "How to: Define a GroupBox Template"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "controls [WPF], GroupBox"
  - "GroupBox control [WPF], creating templates"
ms.assetid: 85a4d1a7-4753-4f4a-b26d-14fa10c1ddb5
---
# How to: Define a GroupBox Template
This example shows how to create a template for a <xref:System.Windows.Controls.GroupBox> control.  
  
## Example  
 The following example defines a <xref:System.Windows.Controls.GroupBox> control template by using a <xref:System.Windows.Controls.Grid> control for layout. The template uses a <xref:System.Windows.Controls.BorderGapMaskConverter> to define the border of the <xref:System.Windows.Controls.GroupBox> so that the border does not obscure the <xref:System.Windows.Controls.HeaderedContentControl.Header%2A> content.  
  
 [!code-xaml[GroupBoxSnippet#GroupBoxTemplate](~/samples/snippets/csharp/VS_Snippets_Wpf/GroupBoxSnippet/CS/Window1.xaml#groupboxtemplate)]  
  
## See also

- <xref:System.Windows.Controls.GroupBox>
- [How to: Create a GroupBox](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms748321(v=vs.90))
