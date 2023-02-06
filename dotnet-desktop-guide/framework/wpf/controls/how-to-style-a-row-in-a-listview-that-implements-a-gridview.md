---
title: "How to: Style a Row in a ListView That Uses a GridView"
description: Learn how to specify the style of a row in a ListView control that uses a GridView control in a Windows Presentation Foundation (WPF) application.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "GridView controls [WPF], styling rows"
  - "styling rows in ListViews implementing GridViews [WPF]"
  - "ListView controls [WPF], styling rows with GridViews"
ms.assetid: 2e406ba2-70a0-4e62-841f-0934859de76e
---
# How to: Style a Row in a ListView That Implements a GridView

This example shows how to style a row in a <xref:System.Windows.Controls.ListView> control that uses a <xref:System.Windows.Controls.GridView> <xref:System.Windows.Controls.ListView.View%2A> mode.  
  
## Example  

 You can style a row in a <xref:System.Windows.Controls.ListView> control by setting an <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> on the <xref:System.Windows.Controls.ListView> control. Set the style for its items that are represented as <xref:System.Windows.Controls.ListViewItem> objects. The <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> references the <xref:System.Windows.Controls.ControlTemplate> objects that are used to display the row content.  
  
 The complete sample, which the following examples are extracted from, displays a collection of song information that is stored in an XML database. Each song in the database has a rating field and the value of this field specifies how to display a row of song information.  
  
 The following example shows how to define <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> for the <xref:System.Windows.Controls.ListViewItem> objects that represent the songs in the song collection. The <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> references <xref:System.Windows.Controls.ControlTemplate> objects that specify how to display a row of song information.  
  
 [!code-xaml[ListViewItemStyleSnippet#ItemContainerStyle](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewItemStyleSnippet/CS/Window1.xaml#itemcontainerstyle)]  
  
 The following example shows a <xref:System.Windows.Controls.ControlTemplate> that adds the text string `"Strongly Recommended"` to the row. This template is referenced in the <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> and displays when the song's rating has a value of 5 (five). The <xref:System.Windows.Controls.ControlTemplate> includes a <xref:System.Windows.Controls.GridViewRowPresenter> object that lays out the contents of the row in columns as defined by the <xref:System.Windows.Controls.GridView> view mode.  
  
 [!code-xaml[ListViewItemStyleSnippet#ControlTemplate](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewItemStyleSnippet/CS/Window1.xaml#controltemplate)]  
  
 The following example defines <xref:System.Windows.Controls.GridView>.  
  
 [!code-xaml[ListViewItemStyleSnippet#GridView](~/samples/snippets/csharp/VS_Snippets_Wpf/ListViewItemStyleSnippet/CS/Window1.xaml#gridview)]  
  
## See also

- <xref:System.Windows.Controls.ListView>
- <xref:System.Windows.Controls.GridView>
- [How-to Topics](listview-how-to-topics.md)
- [ListView Overview](listview-overview.md)
- [Styling and Templating](styles-templates-overview.md)
