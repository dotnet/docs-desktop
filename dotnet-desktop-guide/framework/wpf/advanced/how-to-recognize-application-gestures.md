---
title: "How To: Recognize Application Gestures"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application gestures [WPF], recognizing"
  - "gestures [WPF], recognizing"
ms.assetid: d58b740f-5192-4a3e-af59-7aa162e6ca15
---
# How To: Recognize Application Gestures
The following example demonstrates how to erase ink when a user makes a <xref:System.Windows.Ink.ApplicationGesture.ScratchOut> gesture on an <xref:System.Windows.Controls.InkCanvas>. This example assumes an <xref:System.Windows.Controls.InkCanvas>, called `inkCanvas1`, is declared in the XAML file.  
  
## Example  
 [!code-csharp[HowToRecognizeGestures#1](~/samples/snippets/csharp/VS_Snippets_Wpf/HowToRecognizeGestures/CSharp/Window1.xaml.cs#1)]
 [!code-vb[HowToRecognizeGestures#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HowToRecognizeGestures/VisualBasic/Window1.xaml.vb#1)]  
  
## See also

- <xref:System.Windows.Ink.ApplicationGesture>
- <xref:System.Windows.Controls.InkCanvas>
- <xref:System.Windows.Controls.InkCanvas.Gesture>
