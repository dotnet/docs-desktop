---
title: "Storing Ink"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ISF (Ink Serialized Format)"
  - "storing ink [WPF]"
  - "ink [WPF], storing"
  - "retrieving ink [WPF]"
  - "Ink Serialized Format (ISF)"
ms.assetid: a3f6d16b-d682-4680-9965-907332b4d2b8
description: Learn how to store and retrieve ink in the WPF platform by implementing a button-click event handler that saves the ink from an InkCanvas.
---
# Storing Ink

The <xref:System.Windows.Ink.StrokeCollection.Save%2A> methods provide support for storing ink as Ink Serialized Format (ISF). Constructors for the <xref:System.Windows.Ink.StrokeCollection> class provide support for reading ink data.  
  
## Ink Storage and Retrieval  

 This section discusses how to store and retrieve ink in the WPF platform.  
  
 The following example implements a button-click event handler that presents the user with a File Save dialog box and saves the ink from an <xref:System.Windows.Controls.InkCanvas> out to a file.  
  
 [!code-csharp[DigitalInkTopics#12](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window1.xaml.cs#12)]
 [!code-vb[DigitalInkTopics#12](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DigitalInkTopics/VisualBasic/Window1.xaml.vb#12)]  
  
 The following example implements a button-click event handler that presents the user with a File Open dialog box and reads ink from the file into an <xref:System.Windows.Controls.InkCanvas> element.  
  
 [!code-csharp[DigitalInkTopics#13](~/samples/snippets/csharp/VS_Snippets_Wpf/DigitalInkTopics/CSharp/Window1.xaml.cs#13)]
 [!code-vb[DigitalInkTopics#13](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DigitalInkTopics/VisualBasic/Window1.xaml.vb#13)]  
  
## See also

- <xref:System.Windows.Controls.InkCanvas>
- [Windows Presentation Foundation](../index.md)
