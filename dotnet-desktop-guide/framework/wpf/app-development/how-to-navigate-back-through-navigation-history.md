---
title: "How to: Navigate Back Through Navigation History"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "history [WPF], navigating back"
  - "navigation [WPF], through navigation history (back)"
ms.assetid: 9343234b-d864-441d-b8a7-d895cba80a87
---
# How to: Navigate Back Through Navigation History
This example illustrates how to navigate to entries in back navigation history.  
  
## Example  
 Code that is running from content that is hosted in a <xref:System.Windows.Navigation.NavigationWindow>, <xref:System.Windows.Controls.Frame> using <xref:System.Windows.Navigation.NavigationService>, or Internet Explorer can navigate back through navigation history, one entry at a time.  
  
 Navigating back one entry requires first checking that there are entries in back navigation history, by inspecting the **CanGoBack** property, before navigating back one entry, by calling the **GoBack** method. This is illustrated in the following example:  
  
 [!code-csharp[HOWTONavigationSnippets#NavigateBackCODE](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTONavigationSnippets/CSharp/HomePage.xaml.cs#navigatebackcode)]
 [!code-vb[HOWTONavigationSnippets#NavigateBackCODE](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTONavigationSnippets/visualbasic/homepage.xaml.vb#navigatebackcode)]  
  
 **CanGoBack** and **GoBack** are implemented by <xref:System.Windows.Navigation.NavigationWindow>, <xref:System.Windows.Controls.Frame>, and <xref:System.Windows.Navigation.NavigationService>.  
  
> [!NOTE]
> If you call **GoBack**, and there are no entries in back navigation history, an <xref:System.InvalidOperationException> is raised.
