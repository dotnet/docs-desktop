---
title: "How to: Get the Default View of a Data Collection"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data collections [WPF], creating views of"
  - "data binding [WPF], creating views of data collections"
ms.assetid: b641e96c-c2f6-42ea-9c5d-bac81176ad65
---
# How to: Get the Default View of a Data Collection
Views allow the same data collection to be viewed in different ways, depending on sorting, filtering, or grouping criteria. Every collection has one shared default view, which is used as the actual binding source when a binding specifies a collection as its source. This example shows how to get the default view of a collection.  
  
## Example  
 To create the view, you need an object reference to the collection. This data object can be obtained by referencing your own code-behind object, by getting the data context, by getting a property of the data source, or by getting a property of the binding. This example shows how to get the <xref:System.Windows.FrameworkElement.DataContext%2A> of a data object and use it to directly obtain the default collection view for this collection.  
  
 [!code-csharp[CollectionView#2](~/samples/snippets/csharp/VS_Snippets_Wpf/CollectionView/CSharp/Page1.xaml.cs#2)]
 [!code-vb[CollectionView#2](~/samples/snippets/visualbasic/VS_Snippets_Wpf/CollectionView/VisualBasic/Page1.xaml.vb#2)]  
  
 In this example, the root element is a <xref:System.Windows.Controls.StackPanel>. The <xref:System.Windows.FrameworkElement.DataContext%2A> is set to *myDataSource*, which refers to a data provider that is an <xref:System.Collections.ObjectModel.ObservableCollection%601> of *Order* objects.  
  
 [!code-xaml[CollectionView#CollectionViewDataContext](~/samples/snippets/csharp/VS_Snippets_Wpf/CollectionView/CSharp/Page1.xaml#collectionviewdatacontext)]  
  
 Alternatively, you can instantiate and bind to your own collection view using the <xref:System.Windows.Data.CollectionViewSource> class. This collection view is only shared by controls that bind to it directly. For an example, see the How to Create a View section in the [Data Binding Overview](data-binding-overview.md).  
  
 For examples of the functionality provided by a collection view, see [Sort Data in a View](how-to-sort-data-in-a-view.md), [Filter Data in a View](how-to-filter-data-in-a-view.md), and [Navigate Through the Objects in a Data CollectionView](how-to-navigate-through-the-objects-in-a-data-collectionview.md).  
  
## See also

- [Sort and Group Data Using a View in XAML](how-to-sort-and-group-data-using-a-view-in-xaml.md)
- [How-to Topics](data-binding-how-to-topics.md)
