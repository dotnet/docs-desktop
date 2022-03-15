---
title: "How to: Detect When Text in a TextBox Has Changed"
description: Learn how to use the TextChanged event to run a method whenever the text in a TextBox control changes in a Windows Presentation Foundation application.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "TextBox control [WPF], detecting text change"
  - "text change [WPF], detecting"
  - "detecting text change [WPF]"
ms.assetid: 1c39ee14-e37f-49fb-a0d1-a9824ca13584
---
# How to: Detect When Text in a TextBox Has Changed

This example shows one way to use the <xref:System.Windows.Controls.Primitives.TextBoxBase.TextChanged> event to execute a method whenever the text in a <xref:System.Windows.Controls.TextBox> control has changed.

In the code-behind class for the XAML that contains the <xref:System.Windows.Controls.TextBox> control that you want to monitor for changes, insert a method to call whenever the <xref:System.Windows.Controls.Primitives.TextBoxBase.TextChanged> event fires.  This method must have a signature that matches what is expected by the <xref:System.Windows.Controls.TextChangedEventHandler> delegate.

The event handler is called whenever the contents of the <xref:System.Windows.Controls.TextBox> control are changed, either by a user or programmatically.

> [!NOTE]
> This event fires when the <xref:System.Windows.Controls.TextBox> control is created and initially populated with text.

## Define TextBox control

In the Extensible Application Markup Language (XAML) that defines your <xref:System.Windows.Controls.TextBox> control, specify the <xref:System.Windows.Controls.Primitives.TextBoxBase.TextChanged> attribute with a value that matches the event handler method name.

[!code-xaml[TextBox_MiscCode#_TextChangedXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml#_textchangedxaml)]

## Monitor the TextBox control changes

In the code-behind class for the XAML that contains the <xref:System.Windows.Controls.TextBox> control that you want to monitor for changes, insert a method to call whenever the <xref:System.Windows.Controls.Primitives.TextBoxBase.TextChanged> event fires.  This method must have a signature that matches what is expected by the <xref:System.Windows.Controls.TextChangedEventHandler> delegate.

[!code-csharp[TextBox_MiscCode#_TextChangedEventHandler](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_MiscCode/CSharp/Window1.xaml.cs#_textchangedeventhandler)]
[!code-vb[TextBox_MiscCode#_TextChangedEventHandler](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBox_MiscCode/VisualBasic/Window1.xaml.vb#_textchangedeventhandler)]

The event handler is called whenever the contents of the <xref:System.Windows.Controls.TextBox> control are changed, either by a user or programmatically.

> [!NOTE]
> This event fires when the <xref:System.Windows.Controls.TextBox> control is created and initially populated with text.

Comments

## See also

- <xref:System.Windows.Controls.TextChangedEventArgs>
- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
