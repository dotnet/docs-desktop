---
title: "How to: Use XML Namespaces in Data Binding"
description: Learn how to use XML namespaces in data binding including related tutorials and several provided code examples. 
ms.date: "03/30/2017"
helpviewer_keywords:
  - "XML [WPF], namespaces"
  - "data binding [WPF], XML namespaces"
  - "namespaces [WPF], XML"
ms.assetid: a47c832f-dc84-48f2-96d5-cde18fc4284b
---
# How to: Use XML Namespaces in Data Binding

## Example

 This example shows how to handle namespaces specified in your XML binding source.

 If your XML data has the following XML namespace definition:

 `<rss version="2.0" xmlns:dc="http://purl.org/dc/elements/1.1/">`

 You can use the <xref:System.Windows.Data.XmlNamespaceMapping> element to map the namespace to a <xref:System.Windows.Data.XmlNamespaceMapping.Prefix%2A>, as in the following example. You can then use the <xref:System.Windows.Data.XmlNamespaceMapping.Prefix%2A> to refer to the XML namespace. The <xref:System.Windows.Controls.ListBox> in this example displays the *title* and *dc:date* of each *item*.

 [!code-xaml[XmlnsBindSnippet#XmlNamespaceMapping](~/samples/snippets/csharp/VS_Snippets_Wpf/XmlnsBindSnippet/CS/Window1.xaml#xmlnamespacemapping)]

 Note that the <xref:System.Windows.Data.XmlNamespaceMapping.Prefix%2A> you specify does not have to match the one used in the XML source; if the prefix changes in the XML source your mapping still works.

 In this particular example, the XML data comes from a web service, but the <xref:System.Windows.Data.XmlNamespaceMapping> element also works with inline XML or XML data in an embedded file.

## See also

- [Bind to XML Data Using an XMLDataProvider and XPath Queries](how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries.md)
- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
