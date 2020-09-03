---
title: "How to: Group Items in a ListView That Implements a GridView"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ListView controls [WPF], grouping items with GridViews"
  - "grouping items in ListViews implementing GridViews [WPF]"
  - "GridView controls [WPF], grouping items"
ms.assetid: eebef25b-ddc6-424e-a66d-ea228d1bf33d
---
# How to: Group Items in a ListView That Implements a GridView
This example shows how to display groups of items in the <xref:System.Windows.Controls.GridView> view mode of a <xref:System.Windows.Controls.ListView> control.  
  
## Example  
 To display groups of items in a <xref:System.Windows.Controls.ListView>, define a <xref:System.Windows.Data.CollectionViewSource>. The following example shows a <xref:System.Windows.Data.CollectionViewSource> that groups data items according to the value of the `Catalog` data field.  
  
 [!code-xaml[GridViewWithGroups#GroupingCollectionViewSource](~/samples/snippets/csharp/VS_Snippets_Wpf/GridViewWithGroups/CS/Window1.xaml#groupingcollectionviewsource)]  
  
 The following example sets the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> for the <xref:System.Windows.Controls.ListView> to the <xref:System.Windows.Data.CollectionViewSource> that the previous example defines. The example also defines a <xref:System.Windows.Controls.ItemsControl.GroupStyle%2A> that implements an <xref:System.Windows.Controls.Expander> control.  
  
 [!code-xaml[GridViewWithGroups#ListViewGroups](~/samples/snippets/csharp/VS_Snippets_Wpf/GridViewWithGroups/CS/Window1.xaml#listviewgroups)]  
[!code-xaml[GridViewWithGroups#ListViewEnd](~/samples/snippets/csharp/VS_Snippets_Wpf/GridViewWithGroups/CS/Window1.xaml#listviewend)]  
  
## See also

- <xref:System.Windows.Controls.ListView>
- <xref:System.Windows.Controls.GridView>
- [How-to Topics](listview-how-to-topics.md)
- [ListView Overview](listview-overview.md)
- [GridView Overview](gridview-overview.md)
