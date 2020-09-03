---
title: "How to: Use Special Characters in XAML"
description: Learn about the syntax for encoding special characters in Unicode UTF-8 file format in Visual Studio for use in XAML files in Windows Presentation Foundation.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Unicode UTF-8 file format"
  - "UTF-8 file format"
  - "characters [WPF], special"
  - "typography [WPF], special characters"
  - "special characters [WPF]"
ms.assetid: a57776d1-f353-4794-afa0-bfa3c712ed1c
---
# How to: Use Special Characters in XAML
Markup files that are created in Visual Studio are automatically saved in the Unicode UTF-8 file format, which means that most special characters, such as accent marks, are encoded correctly. However, there is a set of commonly-used special characters that are handled differently. These special characters follow the World Wide Web Consortium (W3C) XML standard for encoding.  
  
 The following table shows the syntax for encoding this set of special characters:  
  
|Character|Syntax|Description|  
|---------------|------------|-----------------|  
|<|`&lt;`|Less than symbol.|  
|>|`&gt;`|Greater than sign.|  
|&|`&amp;`|Ampersand symbol.|  
|"|`&quot;`|Double quote symbol.|  
  
> [!NOTE]
> If you create a markup file using a text editor, such as Windows Notepad, you must save the file in the Unicode UTF-8 file format in order to preserve any encoded special characters.  
  
 The following example shows how you can use special characters in text when creating markup.  
  
## Example  
 [!code-xaml[SpecialCharsSnippets#SpecialCharsSnippet1](~/samples/snippets/csharp/VS_Snippets_Wpf/SpecialCharsSnippets/CS/Window1.xaml#specialcharssnippet1)]
