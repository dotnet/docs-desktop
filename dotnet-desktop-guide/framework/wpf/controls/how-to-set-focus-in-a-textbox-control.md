---
title: "How to: Set Focus in a TextBox Control"
description: Learn how to use the Focus method to set focus on a Windows Presentation Foundation TextBox control.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "focus [WPF], setting"
  - "TextBox control [WPF], setting focus"
ms.assetid: 24b61b45-dc2d-425e-9839-b017af7ab86f
---
# How to: Set Focus in a TextBox Control

This example shows how to use the <xref:System.Windows.UIElement.Focus%2A> method to set focus on a <xref:System.Windows.Controls.TextBox> control.  
  
## Define a simple TextBox control

 The following Extensible Application Markup Language (XAML) example describes a simple <xref:System.Windows.Controls.TextBox> control named *tbFocusMe*  
  
 [!code-xaml[TextBox_MiscCode#_TextBoxFocusXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml#_textboxfocusxaml)]  
  
## Set the focus on the TextBox control

 The following example calls the <xref:System.Windows.UIElement.Focus%2A> method to set the focus on the <xref:System.Windows.Controls.TextBox> control with the Name *tbFocusMe*.  
  
 [!code-csharp[TextBox_MiscCode#_FocusTextBox](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml.cs#_focustextbox)]
 [!code-vb[TextBox_MiscCode#_FocusTextBox](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBox_MiscCode/VisualBasic/Window1.xaml.vb#_focustextbox)]  
  
## See also

- <xref:System.Windows.UIElement.Focusable%2A>
- <xref:System.Windows.UIElement.IsFocused%2A>
- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
