---
title: "How to: Use Spell Checking with a Context Menu"
description: Learn how to use Spell Checking with a Context Menu.
ms.date: "03/30/2017"
ms.custom: devdivchpfy22
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "enabling spell checking in a text box [WPF]"
  - "reenabling spell checking in a text box [WPF]"
  - "spell checking with a context menu [WPF]"
ms.assetid: 61f69a20-2ff3-4056-9060-e32f4483ec5e
---
# How to: Use Spell Checking with a Context Menu

By default, when you enable spell checking in an editing control like <xref:System.Windows.Controls.TextBox> or <xref:System.Windows.Controls.RichTextBox>, you get spell-checking choices in the context menu. For example, when users right-click a misspelled word, they get a set of spelling suggestions or the option to **Ignore All**. However, when you override the default context menu with your own custom context menu, this functionality is lost, and you need to write code to reenable the spell-checking feature in the context menu. The following example shows how to enable this on a <xref:System.Windows.Controls.TextBox>.  
  
## Define a Context Menu

 The following example shows the Extensible Application Markup Language (XAML) that creates a <xref:System.Windows.Controls.TextBox> with some events that are used to implement the context menu.  
  
 [!code-xaml[TextBoxMiscSnippets_snip#SpellerCustomContextMenuExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/csharp/speller_custom_context_menu.xaml#spellercustomcontextmenuexamplewholepage)]  
  
## Implement a Context Menu

 The following example shows the code that implements the context menu.  
  
 [!code-csharp[TextBoxMiscSnippets_snip#SpellerCustomContextMenuCodeExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/csharp/speller_custom_context_menu.xaml.cs#spellercustomcontextmenucodeexamplewholepage)]
 [!code-vb[TextBoxMiscSnippets_snip#SpellerCustomContextMenuCodeExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TextBoxMiscSnippets_snip/visualbasic/speller_custom_context_menu.xaml.vb#spellercustomcontextmenucodeexamplewholepage)]  
  
 The code used for doing this with a <xref:System.Windows.Controls.RichTextBox> is similar. The main difference is in the parameter passed to the `GetSpellingError` method. For a <xref:System.Windows.Controls.TextBox>, pass the integer index of the caret position:  
  
 `spellingError = myTextBox.GetSpellingError(caretIndex);`  
  
 For a <xref:System.Windows.Controls.RichTextBox>, pass the <xref:System.Windows.Documents.TextPointer> that specifies the caret position:  
  
 `spellingError = myRichTextBox.GetSpellingError(myRichTextBox.CaretPosition);`  
  
## See also

- [TextBox Overview](textbox-overview.md)
- [RichTextBox Overview](richtextbox-overview.md)
- [Enable Spell Checking in a Text Editing Control](how-to-enable-spell-checking-in-a-text-editing-control.md)
- [Use a Custom Context Menu with a TextBox](how-to-use-a-custom-context-menu-with-a-textbox.md)
