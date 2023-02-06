---
title: "How to: Use a Custom Context Menu with a TextBox"
description: Learn how to use a Custom Context Menu with a TextBox.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "context menus [WPF], custom"
  - "menus [WPF], custom"
  - "custom context menus [WPF]"
  - "TextBox control [WPF], custom content menus"
ms.assetid: 842d3cd5-6fa0-4be4-8d90-6c7466213b1c
---
# How to: Use a Custom Context Menu with a TextBox

This example shows how to define and implement a simple custom context menu for a <xref:System.Windows.Controls.TextBox>.  
  
## Define a Custom Context Menu

 The following Extensible Application Markup Language (XAML) example defines a <xref:System.Windows.Controls.TextBox> control that includes a custom context menu.  
  
 The context menu is defined using a <xref:System.Windows.Controls.ContextMenu> element.  The context menu itself consists of a series of <xref:System.Windows.Controls.MenuItem> elements and <xref:System.Windows.Controls.Separator> elements.  Each <xref:System.Windows.Controls.MenuItem> element defines a command in the context menu; the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> attribute defines the display text for the menu command, and the <xref:System.Windows.Controls.MenuItem.Click> attribute specifies a handler method for each menu item.  The <xref:System.Windows.Controls.Separator> element simply causes a separating line to be rendered between the previous and subsequent menu items.  
  
 [!code-xaml[TextBox_ContextMenu#_TextBox_ContextMenuXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_ContextMenu/CSharp/Window1.xaml#_textbox_contextmenuxaml)]  
  
## Implement a Custom Context Menu

 The following example shows the implementation code for the preceding context menu definition, as well as the code that enables and disables the context menu.  The <xref:System.Windows.Controls.ContextMenu.Opened> event is used to dynamically enable or disable certain commands depending on the current state of the <xref:System.Windows.Controls.TextBox>.  
  
 To restore the default context menu, use the <xref:System.Windows.DependencyObject.ClearValue%2A> method to clear the value of the <xref:System.Windows.FrameworkElement.ContextMenu%2A> property.  To disable the context menu altogether, set the <xref:System.Windows.FrameworkElement.ContextMenu%2A> property to a null reference (`Nothing` in Visual Basic).  
  
 [!code-csharp[TextBox_ContextMenu#_TextBox_ContextMenu](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBox_ContextMenu/CSharp/Window1.xaml.cs#_textbox_contextmenu)]
 [!code-vb[TextBox_ContextMenu#_TextBox_ContextMenu](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBox_ContextMenu/VisualBasic/Window1.xaml.vb#_textbox_contextmenu)]  
  
## See also

- [Use Spell Checking with a Context Menu](how-to-use-spell-checking-with-a-context-menu.md)
- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
