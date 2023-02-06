---
title: "How to: Sort Data in a View"
description: Learn about various techniques to sort data in a view including related tutorials and several provided code examples.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data binding [WPF], sorting data in views"
  - "data binding [WPF], grouping data in views"
  - "grouping data in views [WPF]"
  - "views [WPF], sorting data"
  - "views [WPF], grouping data"
  - "sorting data in views [WPF]"
ms.assetid: f4c43578-01b7-4774-a953-acb95a13b94a
---
# How to: Sort Data in a View

This example describes how to sort data in a view.  
  
## Example  

 The following example creates a simple <xref:System.Windows.Controls.ListBox> and a <xref:System.Windows.Controls.Button>:  
  
 [!code-xaml[ListBoxSort_snip#HowTo](~/samples/snippets/csharp/VS_Snippets_Wpf/ListBoxSort_snip/CSharp/Window1.xaml#howto)]  
  
 The <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler of the button contains logic to sort the items in the <xref:System.Windows.Controls.ListBox> in the descending order. You can do this because adding items to a <xref:System.Windows.Controls.ListBox> this way adds them to the <xref:System.Windows.Controls.ItemCollection> of the <xref:System.Windows.Controls.ListBox>, and <xref:System.Windows.Controls.ItemCollection> derives from the <xref:System.Windows.Data.CollectionView> class. If you are binding your <xref:System.Windows.Controls.ListBox> to a collection using the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property, you can use the same technique to sort.  
  
 [!code-csharp[ListBoxSort_snip#HowToCode](~/samples/snippets/csharp/VS_Snippets_Wpf/ListBoxSort_snip/CSharp/Window1.xaml.cs#howtocode)]
 [!code-vb[ListBoxSort_snip#HowToCode](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ListBoxSort_snip/visualbasic/window1.xaml.vb#howtocode)]  
  
 As long as you have a reference to the view object, you can use the same technique to sort the content of other collection views. For an example of how to obtain a view, see [Get the Default View of a Data Collection](how-to-get-the-default-view-of-a-data-collection.md). For another example, see [Sort a GridView Column When a Header Is Clicked](../controls/how-to-sort-a-gridview-column-when-a-header-is-clicked.md). For more information about views, see Binding to Collections in [Data Binding Overview](data-binding-overview.md).  
  
 For an example of how to apply sorting logic in Extensible Application Markup Language (XAML), see [Sort and Group Data Using a View in XAML](how-to-sort-and-group-data-using-a-view-in-xaml.md).  
  
## See also

- <xref:System.Windows.Data.ListCollectionView.CustomSort%2A>
- [Sort a GridView Column When a Header Is Clicked](../controls/how-to-sort-a-gridview-column-when-a-header-is-clicked.md)
- [Data Binding Overview](data-binding-overview.md)
- [Filter Data in a View](how-to-filter-data-in-a-view.md)
- [How-to Topics](data-binding-how-to-topics.md)
