---
title: "How to: Retrieve a Text Selection"
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
description: Learn how to retrieve a Text selection.
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "text [WPF], retrieving"
  - "TextBox control [WPF], retrieving text"
  - "retrieving text [WPF]"
ms.assetid: d5793172-1e11-4a39-9be0-73f336ed858d
---
# How to: Retrieve a Text Selection

This example shows one way to use the <xref:System.Windows.Controls.TextBox.SelectedText%2A> property to retrieve text that the user has selected in a <xref:System.Windows.Controls.TextBox> control.  
  
## Define a TextBox control

 The following Extensible Application Markup Language (XAML) example shows the definition of a <xref:System.Windows.Controls.TextBox> control that contains some text to select, and a <xref:System.Windows.Controls.Button> control with a specified <xref:System.Windows.Controls.Button.OnClick%2A> method.  
  
 In this example, a button with an associated <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler is used to retrieve the text selection. When the user clicks the button, the <xref:System.Windows.Controls.Button.OnClick%2A> method copies any selected text in the textbox into a string. The particular circumstances by which the text selection is retrieved (clicking a button), as well as the action taken with that selection (copying the text selection to a string), can easily be modified to accommodate a wide variety of scenarios.  
  
 [!code-xaml[TextBox_MiscCode#_TextBoxSelectTextXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml#_textboxselecttextxaml)]  
  
## OnClick event handler

 The following C# example shows an <xref:System.Windows.Controls.Button.OnClick%2A> event handler for the button defined in the XAML for this example.  
  
 [!code-csharp[TextBox_MiscCode#_SelectText](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml.cs#_selecttext)]
 [!code-vb[TextBox_MiscCode#_SelectText](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBox_MiscCode/VisualBasic/Window1.xaml.vb#_selecttext)]  
  
## See also

- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
