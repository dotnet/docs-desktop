---
title: "How to: Bind a ListBox to Data"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ListBox controls [WPF], binding data to"
  - "data binding [WPF], ListBox control"
  - "binding data [WPF], to ListBox control"
ms.assetid: de93a907-709a-44a7-84bf-578b846a3d8b
---
# How to: Bind a ListBox to Data
An application developer can create <xref:System.Windows.Controls.ListBox> controls without specifying the contents of each <xref:System.Windows.Controls.ListBoxItem> separately. You can use data binding to bind data to the individual items.  
  
 The following example shows how to create a <xref:System.Windows.Controls.ListBox> that populates the <xref:System.Windows.Controls.ListBoxItem> elements by data binding to a data source called *Colors*. In this case it is not necessary to use <xref:System.Windows.Controls.ListBoxItem> tags to specify the content of each item.  
  
## Example  
 [!code-xaml[ListBoxEvent#7](~/samples/snippets/csharp/VS_Snippets_Wpf/ListBoxEvent/CSharp/Pane1.xaml#7)]  
[!code-xaml[ListBoxEvent#3](~/samples/snippets/csharp/VS_Snippets_Wpf/ListBoxEvent/CSharp/Pane1.xaml#3)]  
  
## See also

- <xref:System.Windows.Controls.ListBox>
- <xref:System.Windows.Controls.ListBoxItem>
- [Controls](../advanced/optimizing-performance-controls.md)
