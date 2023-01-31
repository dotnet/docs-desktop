---
title: "How to: Manipulate Columns and Rows by Using ColumnDefinitionsCollections and RowDefinitionsCollections"
description: Learn how to use methods in the ColumnDefinitionCollection and RowDefinitionCollection classes to perform actions like adding, clearing, or counting contents.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [WPF], Grid class"
  - "Grid control [WPF], ColumnDefinitionCollection class"
  - "Grid control [WPF], RowDefinitionCollection class"
ms.assetid: bfc7160a-45f2-4e17-9961-df414dfb13c5
---
# How to: Manipulate Columns and Rows by Using ColumnDefinitionsCollections and RowDefinitionsCollections

This example shows how to use the methods in the <xref:System.Windows.Controls.ColumnDefinitionCollection> and <xref:System.Windows.Controls.RowDefinitionCollection> classes to perform actions like adding, clearing, or counting the contents of rows or columns. For example, you can <xref:System.Windows.Controls.ColumnDefinitionCollection.Add%2A>, <xref:System.Windows.Controls.ColumnDefinitionCollection.Clear%2A>, or <xref:System.Windows.Controls.ColumnDefinitionCollection.Count%2A> the items that are included in a <xref:System.Windows.Controls.ColumnDefinition> or <xref:System.Windows.Controls.RowDefinition>.  
  
## Example  

 The following example creates a <xref:System.Windows.Controls.Grid> element with a <xref:System.Windows.FrameworkElement.Name%2A> of `grid1`. The <xref:System.Windows.Controls.Grid> contains a <xref:System.Windows.Controls.StackPanel> that holds <xref:System.Windows.Controls.Button> elements, each controlled by a different collection method. When you click a <xref:System.Windows.Controls.Button>, it activates a method call in the code-behind file.  
  
:::code language="xaml" source="snippets/manipulate-columns-and-rows-by-using-columndefinitionscollections/csharp/Window1.xaml" id="Snippet1":::
  
 This example defines a series of custom methods, each corresponding to a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event in the Extensible Application Markup Language (XAML) file. You can change the number of columns and rows in the <xref:System.Windows.Controls.Grid> in several ways, which includes adding or removing rows and columns; and counting the total number of rows and columns. To prevent <xref:System.ArgumentOutOfRangeException> and <xref:System.ArgumentException> exceptions, you can use the error-checking functionality that the <xref:System.Windows.Controls.ColumnDefinitionCollection.RemoveRange%2A> method provides.  
  
:::code language="csharp" source="snippets/manipulate-columns-and-rows-by-using-columndefinitionscollections/csharp/Window1.xaml.cs" id="Snippet2":::
:::code language="vb" source="snippets/manipulate-columns-and-rows-by-using-columndefinitionscollections/vb/Window1.xaml.vb" id="Snippet2":::
  
## See also

- <xref:System.Windows.Controls.Grid>
- <xref:System.Windows.Controls.ColumnDefinitionCollection>
- <xref:System.Windows.Controls.RowDefinitionCollection>
