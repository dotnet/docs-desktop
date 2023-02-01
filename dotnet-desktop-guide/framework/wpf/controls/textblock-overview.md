---
title: "TextBlock Overview"
description: Overview of how the TextBlock control provides flexible text support for UI scenarios that do not require more than one paragraph of text.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [WPF], TextBlock"
  - "TextBlock control [WPF]"
ms.assetid: 24720bca-341a-4b03-8a6b-7a678023b10a
---
# TextBlock Overview

The <xref:System.Windows.Controls.TextBlock> control provides flexible text support for UI scenarios that do not require more than one paragraph of text. It supports a number of properties that enable precise control of presentation, such as <xref:System.Windows.Controls.TextBlock.FontFamily%2A>, <xref:System.Windows.Controls.TextBlock.FontSize%2A>, <xref:System.Windows.Controls.TextBlock.FontWeight%2A>, <xref:System.Windows.Controls.TextBlock.TextEffects%2A>, and <xref:System.Windows.Controls.TextBlock.TextWrapping%2A>. Text content can be added using the <xref:System.Windows.Controls.TextBlock.Text%2A> property. When used in XAML, content between the open and closing tag is implicitly added as the text of the element.  
  
 A <xref:System.Windows.Controls.TextBlock> element can be instantiated very simply using XAML.  
  
 [!code-xaml[TextBlockSnip_XAML#2](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBlockSnip_XAML/CS/default.xaml#2)]  
  
 Similarly, usage of the <xref:System.Windows.Controls.TextBlock> element in code is relatively simple.  
  
 [!code-csharp[TextBlockSnip#1](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBlockSnip/CSharp/TextBlockSnips.cs#1)]
 [!code-vb[TextBlockSnip#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBlockSnip/VisualBasic/TextBlockSnips.vb#1)]  
  
## See also

- <xref:System.Windows.Controls.Label>
