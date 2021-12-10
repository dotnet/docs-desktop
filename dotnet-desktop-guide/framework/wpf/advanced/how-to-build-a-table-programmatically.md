---
title: How to Build a Table Programmatically
description: This topic provides examples on how to create a table and populate it with content 
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tables [WPF], creating programmatically"
ms.assetid: e3ca88f3-6e94-4b61-82fc-42104c10b761
---
# How to: Build a Table Programmatically

The following examples show how to programmatically create a <xref:System.Windows.Documents.Table> and populate it with content. The contents of the table are apportioned into five rows (represented by <xref:System.Windows.Documents.TableRow> objects contained in a <xref:System.Windows.Documents.Table.RowGroups%2A> object) and six columns (represented by <xref:System.Windows.Documents.TableColumn> objects). The rows are used for different presentation purposes, including a title row intended to title the entire table, a header row to describe the columns of data in the table, and a footer row with summary information. Note that the notion of "title", "header", and "footer" rows are not inherent to the table; these are simply rows with different characteristics. Table cells contain the actual content, which can be comprised of text, images, or nearly any other [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] element.  
  
## Example to create a Flow Document to host a table
  
 First, you can create a <xref:System.Windows.Documents.FlowDocument> Flow Document to host the <xref:System.Windows.Documents.Table>, and then create a new <xref:System.Windows.Documents.Table> and add to the contents of the <xref:System.Windows.Documents.FlowDocument>.  
  
 [!code-csharp[TableSnippets#_TableCreate](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets/CSharp/Table.cs#_tablecreate)]
 [!code-vb[TableSnippets#_TableCreate](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets/VisualBasic/Table.vb#_tablecreate)]  
  
## Example to create objects and add to the collection of tables
  
 Next, create six <xref:System.Windows.Documents.TableColumn> objects and add to the table's <xref:System.Windows.Documents.Table.Columns%2A> collection, with some formatting applied.  
  
> [!NOTE]
> Note that the table's <xref:System.Windows.Documents.Table.Columns%2A> collection uses standard zero-based indexing.  
  
 [!code-csharp[TableSnippets#_TableCreateColumns](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets/CSharp/Table.cs#_tablecreatecolumns)]
 [!code-vb[TableSnippets#_TableCreateColumns](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets/VisualBasic/Table.vb#_tablecreatecolumns)]  
  
## Example to create a title row and add to the table
  
 Next, create a title row and add to the table with some formatting applied. The title row happens to contain a single cell that spans all six columns in the table.  
  
 [!code-csharp[TableSnippets#_TableAddTitleRow](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets/CSharp/Table.cs#_tableaddtitlerow)]
 [!code-vb[TableSnippets#_TableAddTitleRow](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets/VisualBasic/Table.vb#_tableaddtitlerow)]  
  
## Example to create a header row and add to the table
  
 Next, create a header row and add to the table that'll create the cells in the header row and populate with content.  
  
 [!code-csharp[TableSnippets#_TableAddHeaderRow](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets/CSharp/Table.cs#_tableaddheaderrow)]
 [!code-vb[TableSnippets#_TableAddHeaderRow](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets/VisualBasic/Table.vb#_tableaddheaderrow)]  
  
## Example to create a row for data and add to the table
  
 Next, create a row for data and add to the table that'll create the cells in this row and populate with content. Building this row is similar to building the header row, with slightly different formatting applied.  
  
 [!code-csharp[TableSnippets#_TableAddDataRow](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets/CSharp/Table.cs#_tableadddatarow)]
 [!code-vb[TableSnippets#_TableAddDataRow](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets/VisualBasic/Table.vb#_tableadddatarow)]  
  
## Example to create a single cell footer row that spans all columns in the table
  
 Finally, create a footer row, add, and format. Like the title row, the footer contains a single cell that spans all six columns in the table.  
  
 [!code-csharp[TableSnippets#_TableAddFooterRow](~/samples/snippets/csharp/VS_Snippets_Wpf/TableSnippets/CSharp/Table.cs#_tableaddfooterrow)]
 [!code-vb[TableSnippets#_TableAddFooterRow](~/samples/snippets/visualbasic/VS_Snippets_Wpf/TableSnippets/VisualBasic/Table.vb#_tableaddfooterrow)]  
  
## See also

- [Table Overview](table-overview.md)
