---
title: "How to: Bind to an ADO.NET Data Source"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "data binding [WPF], binding to ADO.NET data sources"
  - "ADO.NET data sources [WPF], binding to"
  - "binding [WPF], to ADO.NET data sources"
ms.assetid: a70c6d7b-7b38-4fdf-b655-4804db7c8315
---

# How to: Bind to an ADO.NET Data Source

This example shows how to bind a [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] <xref:System.Windows.Controls.ListBox> control to an ADO.NET `DataSet`.

## Example

In this example, an `OleDbConnection` object is used to connect to the data source which is an `Access MDB` file that is specified in the connection string. After the connection is established, an `OleDbDataAdapter` object is created. The `OleDbDataAdapter` object executes a select Structured Query Language (SQL) statement to retrieve the recordset from the database. The results from the SQL command are stored in a `DataTable` of the `DataSet` by calling the `Fill` method of the `OleDbDataAdapter`. The `DataTable` in this example is named `BookTable`. The example then sets the <xref:System.Windows.FrameworkElement.DataContext%2A> property of the <xref:System.Windows.Controls.ListBox> to the `DataSet` object.

[!code-csharp[ADODataSet#1](~/samples/snippets/csharp/VS_Snippets_Wpf/ADODataSet/CSharp/Window1.xaml.cs#1)]
[!code-vb[ADODataSet#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/ADODataSet/VisualBasic/Window1.xaml.vb#1)]

We can then bind the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property of the <xref:System.Windows.Controls.ListBox> to `BookTable` of the `DataSet`:

[!code-xaml[ADODataSet#2](~/samples/snippets/csharp/VS_Snippets_Wpf/ADODataSet/CSharp/Window1.xaml#2)]

`BookItemTemplate` is the <xref:System.Windows.DataTemplate> that defines how the data appears:

[!code-xaml[ADODataSet#3](~/samples/snippets/csharp/VS_Snippets_Wpf/ADODataSet/CSharp/Window1.xaml#3)]

The `IntColorConverter` converts an `int` to a color. With the use of this converter, the <xref:System.Windows.Controls.TextBlock.Background%2A> color of the third <xref:System.Windows.Controls.TextBlock> appears green if the value of `NumPages` is less than 350 and red otherwise. The implementation of the converter is not shown here.

## See also

- <xref:System.Windows.Data.BindingListCollectionView>
- [Data Binding Overview](/dotnet/desktop-wpf/data/data-binding-overview)
- [How-to Topics](data-binding-how-to-topics.md)
