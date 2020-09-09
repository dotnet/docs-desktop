---
title: "How to: Get all Windows in an Application"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "window objects [WPF], getting"
ms.assetid: f120f06e-993b-4a97-9657-af0d1986981f
---
# How to: Get all Windows in an Application
This example shows how to get all <xref:System.Windows.Window> objects in an application.  
  
## Example  
 Every instantiated <xref:System.Windows.Window> object, whether visible or not, is automatically added to a collection of window references that is managed by <xref:System.Windows.Application>, and exposed from <xref:System.Windows.Application.Windows%2A>.  
  
 You can enumerate <xref:System.Windows.Application.Windows%2A> to get all instantiated windows using the following code:  
  
 [!code-csharp[HOWTOWindowManagementSnippets#GetAllWindows](~/samples/snippets/csharp/VS_Snippets_Wpf/HOWTOWindowManagementSnippets/CSharp/CustomWindow.xaml.cs#getallwindows)]
 [!code-vb[HOWTOWindowManagementSnippets#GetAllWindows](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HOWTOWindowManagementSnippets/visualbasic/customwindow.xaml.vb#getallwindows)]
