---
title: "How to: Set the Text Content of a TextBox Control"
description: Learn how to use the Text property to set the initial text contents of a Windows Presentation Foundation TextBox control.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "text content [WPF], setting"
  - "TextBox control [WPF], setting text content"
ms.assetid: bcd25fc7-a52f-4453-b802-2c8d2b335ab8
---
# How to: Set the Text Content of a TextBox Control

This example shows how to use the <xref:System.Windows.Controls.TextBox.Text%2A> property to set the initial text contents of a <xref:System.Windows.Controls.TextBox> control.

> [!NOTE]
> Although the Extensible Application Markup Language (XAML) version of the example could use the `<TextBox.Text>` tags around the text of each button's <xref:System.Windows.Controls.TextBox> content, it is not necessary because the <xref:System.Windows.Controls.TextBox> applies the <xref:System.Windows.Markup.ContentPropertyAttribute> attribute to the <xref:System.Windows.Controls.TextBox.Text%2A> property. For more information, see [XAML in WPF](../advanced/xaml-in-wpf.md).

## Use the Text property to set the text contents

[!code-xaml[TextBox_MiscCode#_TextBoxSetTextXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml#_textboxsettextxaml)]

## Set the Text Content of a TextBox Control

[!code-csharp[TextBox_MiscCode#_TextBoxSetText](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml.cs#_textboxsettext)]
[!code-vb[TextBox_MiscCode#_TextBoxSetText](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBox_MiscCode/VisualBasic/Window1.xaml.vb#_textboxsettext)]

## See also

- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
