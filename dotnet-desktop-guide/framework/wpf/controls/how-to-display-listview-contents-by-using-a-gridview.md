---
title: "How to: Display ListView Contents by Using a GridView"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ListView controls [WPF], displaying contents with GridView"
  - "GridView [WPF], displaying ListView contents"
ms.assetid: 5bc1e767-ab46-4f14-bd41-3d5d39e1d000
---
# How to: Display ListView Contents by Using a GridView
This example shows how to define a <xref:System.Windows.Controls.GridView> view mode for a <xref:System.Windows.Controls.ListView> control.  
  
## Example  
 You can define the view mode of a <xref:System.Windows.Controls.GridView> by specifying <xref:System.Windows.Controls.GridViewColumn> objects. The following example shows how to define <xref:System.Windows.Controls.GridViewColumn> objects that bind to the data content that is specified for the <xref:System.Windows.Controls.ListView> control. This <xref:System.Windows.Controls.GridView> example specifies three <xref:System.Windows.Controls.GridViewColumn> objects that map to the `FirstName`, `LastName`, and `EmployeeNumber` fields of the `EmployeeInfoDataSource` that is set as the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> of the <xref:System.Windows.Controls.ListView> control.  
  
 [!code-xaml[ListViewCode#ListViewEmployee](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#listviewemployee)]  
  
 The following illustration shows how this example appears.  
  
 ![Screenshot that shows a ListView with GridView output.](./media/gridview-overview/listview-gridview-output.jpg)  
  
## See also

- <xref:System.Windows.Controls.ListView>
- <xref:System.Windows.Controls.GridView>
- [ListView Overview](listview-overview.md)
- [GridView Overview](gridview-overview.md)
- [How-to Topics](listview-how-to-topics.md)
