---
title: "How to: Call a Page Function"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "calling page functions [WPF]"
  - "page functions [WPF], calling"
  - "functions [WPF], calling"
ms.assetid: a4808397-c6d5-406a-83e0-0091f0c15ae4
description: Learn how to call a page function from an Extensible Application Markup Language page and navigate to that page function using a uniform resource identifier.
---
# How to: Call a Page Function

This example shows how to call a page function from a Extensible Application Markup Language (XAML) page.  
  
## Example  

 You can navigate to a page function using a uniform resource identifier (URI), just as you can when you navigate to a page. This is shown in the following example.  
  
 [!code-csharp[HOWTOPageFunctionSnippets#NavigateToAPageFunctionLikeAPageCODEBEHIND](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOPageFunctionSnippets/CSharp/CallingPage.xaml.cs#navigatetoapagefunctionlikeapagecodebehind)]
 [!code-vb[HOWTOPageFunctionSnippets#NavigateToAPageFunctionLikeAPageCODEBEHIND](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOPageFunctionSnippets/VisualBasic/CallingPage.xaml.vb#navigatetoapagefunctionlikeapagecodebehind)]  
  
 If you need to pass data to the page function, you can create an instance of it and pass the data by setting a property. Or, as the following example shows, you can pass the data using a non-parameterless constructor.  
  
 [!code-xaml[HOWTOPageFunctionSnippets#CallAPageFunctionXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOPageFunctionSnippets/CSharp/CallingPage.xaml#callapagefunctionxaml)]  
  
 [!code-csharp[HOWTOPageFunctionSnippets#CallAPageFunctionCODEBEHIND](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOPageFunctionSnippets/CSharp/CallingPage.xaml.cs#callapagefunctioncodebehind)]
 [!code-vb[HOWTOPageFunctionSnippets#CallAPageFunctionCODEBEHIND](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOPageFunctionSnippets/VisualBasic/CallingPage.xaml.vb#callapagefunctioncodebehind)]  
  
## See also

- <xref:System.Windows.Navigation.PageFunction%601>
