---
title: "How to: Enumerate System Fonts"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "typography [WPF], enumerating system fonts"
  - "fonts [WPF], enumerating"
  - "system fonts [WPF], enumerating"
  - "enumerating [WPF], system fonts"
ms.assetid: 36e37791-55b9-4f01-a496-5cc10335e6a6
description: Learn how to enumerate the fonts in the system font collection and have each font family name within SystemFontFamilies added as an item to a combo box.
---
# How to: Enumerate System Fonts

## Example  

 The following example shows how to enumerate the fonts in the system font collection. The font family name of each <xref:System.Windows.Media.FontFamily> within <xref:System.Windows.Media.Fonts.SystemFontFamilies%2A> is added as an item to a combo box.  
  
 [!code-csharp[TextOverview#100](~/samples/snippets/csharp/VS_Snippets_Wpf/TextOverview/CSharp/Window1.xaml.cs#100)]
 [!code-vb[TextOverview#100](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextOverview/visualbasic/window1.xaml.vb#100)]  
  
 If multiple versions of the same font family reside in the same directory, the Windows Presentation Foundation (WPF) font enumeration returns the most recent version of the font. If the version information does not provide resolution, the font with latest timestamp is returned. If the timestamp information is equivalent, the font file that is first in alphabetical order is returned.
