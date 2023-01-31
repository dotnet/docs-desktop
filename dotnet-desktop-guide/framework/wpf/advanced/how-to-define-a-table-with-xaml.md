---
title: "How to: Define a Table with XAML"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "XAML [WPF], defining tables"
  - "documents [WPF], defining tables with XAML"
  - "tables [WPF], defining with XAML"
ms.assetid: 83f2dc58-437e-4cdc-b5dd-0019810c7a85
description: Learn how to define a Table using Extensible Application Markup Language (XAML), with an example rendering.
---
# How to: Define a Table with XAML

The following example demonstrates how to define a <xref:System.Windows.Documents.Table> using Extensible Application Markup Language (XAML).  The example table has four columns (represented by <xref:System.Windows.Documents.TableColumn> elements) and several rows (represented by <xref:System.Windows.Documents.TableRow> elements) containing data as well as title, header, and footer information.  Rows must be contained in a <xref:System.Windows.Documents.TableRowGroup> element.  Each row in the table is comprised of one or more cells (represented by <xref:System.Windows.Documents.TableCell> elements).  Content in a table cell must be contained in a <xref:System.Windows.Documents.Block> element; in this case <xref:System.Windows.Documents.Paragraph> elements are used.  The table also hosts a hyperlink (represented by the <xref:System.Windows.Documents.Hyperlink> element) in the footer row.  
  
## Example  

 [!code-xaml[TableSnippetsXAML#_TableXAML](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippetsXAML/CS/Window1.xaml#_tablexaml)]  
  
 The following figure shows how the table defined in this example renders:  
  
 ![Screenshot of a table defined with XAML.](./media/how-to-define-a-table-with-xaml/planetary-information-xaml-table.png)
