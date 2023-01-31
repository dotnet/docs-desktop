---
title: "How to: Convert Bound Data"
description: Learn how to use the IValueConverter interface and the Convert and ConvertBack methods to convert bound data.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "converting [WPF], bound data"
  - "data binding [WPF], converting bound data"
  - "binding data [WPF], converting bound data"
ms.assetid: b00aaa19-c6df-4c3b-a9fd-88a0b488df2b
---
# How to: Convert Bound Data

This example shows how to apply conversion to data that is used in bindings.  
  
 To convert data during binding, you must create a class that implements the <xref:System.Windows.Data.IValueConverter> interface, which includes the <xref:System.Windows.Data.IValueConverter.Convert%2A> and <xref:System.Windows.Data.IValueConverter.ConvertBack%2A> methods.  
  
## Example  

 The following example shows the implementation of a date converter that converts the date value passed in so that it only shows the year, the month, and the day. When implementing the <xref:System.Windows.Data.IValueConverter> interface, it is a good practice to decorate the implementation with a <xref:System.Windows.Data.ValueConversionAttribute> attribute to indicate to development tools the data types involved in the conversion, as in the following example:  
  
 [!code-csharp[DataBindingLab#18](~/samples/snippets/csharp/VS_Snippets_Wpf/DataBindingLab/CSharp/DateConverter.cs#18)]
 [!code-vb[DataBindingLab#18](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DataBindingLab/VisualBasic/DateConverter.vb#18)]  
  
 Once you have created a converter, you can add it as a resource in your Extensible Application Markup Language (XAML) file. In the following example, *src* maps to the namespace in which *DateConverter* is defined.  
  
 [!code-xaml[DataBindingLab#15](~/samples/snippets/csharp/VS_Snippets_Wpf/DataBindingLab/CSharp/DataBindingLabApp.xaml#15)]  
  
 Finally, you can use the converter in your binding using the following syntax. In the following example, the text content of the <xref:System.Windows.Controls.TextBlock> is bound to *StartDate*, which is a property of an external data source.  
  
 [!code-xaml[DataBindingLab#17](~/samples/snippets/csharp/VS_Snippets_Wpf/DataBindingLab/CSharp/DataBindingLabApp.xaml#17)]  
  
 The style resources referenced in the above example are defined in a resource section not shown in this topic.  
  
## See also

- [Implement Binding Validation](how-to-implement-binding-validation.md)
- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
