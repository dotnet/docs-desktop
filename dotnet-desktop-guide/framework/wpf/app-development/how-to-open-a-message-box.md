---
title: "How to: Open a Message Box"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "message boxes [WPF], opening"
  - "opening message boxes [WPF]"
ms.assetid: acaad17f-af43-4eca-a004-f1c9e7c6f292
---
# How to: Open a Message Box
This example shows how to open a message box.  
  
## Example  
 A message box is a prefabricated modal dialog box for displaying information to users. A message box is opened by calling the static <xref:System.Windows.MessageBox.Show%2A> method of the <xref:System.Windows.MessageBox> class. When <xref:System.Windows.MessageBox.Show%2A> is called, the message is passed using a string parameter. Several overloads of <xref:System.Windows.MessageBox.Show%2A> allow you to configure how a message box will appear (see <xref:System.Windows.MessageBox>).  
  
 [!code-csharp[MessageBoxSnippets#MessageBoxShow1CODE](~/samples/snippets/csharp/VS_Snippets_Wpf/MessageBoxSnippets/CSharp/Show1Window.xaml.cs#messageboxshow1code)]
 [!code-vb[MessageBoxSnippets#MessageBoxShow1CODE](~/samples/snippets/visualbasic/VS_Snippets_Wpf/MessageBoxSnippets/visualbasic/show1window.xaml.vb#messageboxshow1code)]  
  
## See also

- [MessageBox Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Windows/MessageBox)
