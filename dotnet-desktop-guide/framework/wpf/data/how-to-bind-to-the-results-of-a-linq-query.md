---
title: "How to: Bind to the Results of a LINQ Query"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "running a LINQ query [WPF], bind to results"
  - "binding to LINQ query results [WPF]"
ms.assetid: ff2844d9-17ed-4ea6-aab1-5111af0bc684
---
# How to: Bind to the Results of a LINQ Query

This example demonstrates how to run a LINQ query and then bind to the results.

## Example

The following example creates two list boxes. The first list box contains three list items.

[!code-xaml[LinqExample#UI](~/samples/snippets/csharp/VS_Snippets_Wpf/LinqExample/CSharp/Window1.xaml#ui)]

Selecting an item from the first list box invokes the following event handler. In this example, `Tasks` is a collection of `Task` objects. The `Task` class has a property named `Priority`. This event handler runs a LINQ query that returns the collection of `Task` objects that have the selected priority value, and then sets that as the <xref:System.Windows.FrameworkElement.DataContext%2A>:

[!code-csharp[LinqExample#Using](~/samples/snippets/csharp/VS_Snippets_Wpf/LinqExample/CSharp/Window1.xaml.cs#using)]
[!code-csharp[LinqExample#Tasks](~/samples/snippets/csharp/VS_Snippets_Wpf/LinqExample/CSharp/Window1.xaml.cs#tasks)]
[!code-csharp[LinqExample#Handler](~/samples/snippets/csharp/VS_Snippets_Wpf/LinqExample/CSharp/Window1.xaml.cs#handler)]

The second list box binds to that collection because its <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> value is set to `{Binding}`. As a result, it displays the returned collection (based on the `myTaskTemplate` <xref:System.Windows.DataTemplate>).

## See also

- [Make Data Available for Binding in XAML](how-to-make-data-available-for-binding-in-xaml.md)
- [Bind to a Collection and Display Information Based on Selection](how-to-bind-to-a-collection-and-display-information-based-on-selection.md)
- [What's New in WPF Version 4.5](../getting-started/whats-new.md)
- [Data Binding Overview](data-binding-overview.md)
