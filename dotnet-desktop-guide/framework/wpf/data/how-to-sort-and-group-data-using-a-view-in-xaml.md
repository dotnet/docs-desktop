---
title: "How to: Sort and Group Data Using a View in XAML"
description: Learn how to create a view of a data collection for grouping, sorting, and filtering in the Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data binding [WPF], grouping data in views in XAML"
  - "XAML [WPF], sorting data in views"
  - "grouping data in views in XAML [WPF]"
  - "data binding [WPF], sorting data in views in XAML"
  - "sorting data in views in XAML [WPF]"
  - "XAML [WPF], grouping data in views"
  - "views [WPF], sorting data"
  - "views [WPF], grouping data"
ms.assetid: 145c8c3f-dbdd-4d0d-816f-90b35eba7eda
---
# How to: Sort and Group Data Using a View in XAML

This example shows how to create a view of a data collection in Extensible Application Markup Language (XAML). Views allow for the functionalities of grouping, sorting, filtering, and the notion of a current item.  
  
## Example  

 In the following example, the static resource named *places* is defined as a collection of *Place* objects, in which each *Place* object is consisted of a city name and the state. The prefix *src* is mapped to the namespace where the data source *Places* is defined. The prefix *scm* maps to `"clr-namespace:System.ComponentModel;assembly=WindowsBase"` and *dat* maps to `"clr-namespace:System.Windows.Data;assembly=PresentationFramework"`.  
  
 The following example creates a view of the data collection that is sorted by the city name and grouped by the state.  
  
 [!code-xaml[CollectionViewSource#1](~/samples/snippets/csharp/VS_Snippets_Wpf/CollectionViewSource/CS/window1.xaml#1)]  
  
 The view can then be a binding source, as in the following example:  
  
 [!code-xaml[CollectionViewSource#2](~/samples/snippets/csharp/VS_Snippets_Wpf/CollectionViewSource/CS/window1.xaml#2)]  
  
 For bindings to XML data defined in an <xref:System.Windows.Data.XmlDataProvider> resource, precede the XML name with an @ symbol.  
  
 [!code-xaml[CollectionViewSource#XDPChunk](~/samples/snippets/csharp/VS_Snippets_Wpf/CollectionViewSource/CS/window1.xaml#xdpchunk)]  
  
 [!code-xaml[CollectionViewSource#Attribute](~/samples/snippets/csharp/VS_Snippets_Wpf/CollectionViewSource/CS/window1.xaml#attribute)]  
  
## See also

- <xref:System.Windows.Data.CollectionViewSource>
- [Get the Default View of a Data Collection](how-to-get-the-default-view-of-a-data-collection.md)
- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
