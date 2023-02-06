---
title: "How to: Implement Property Change Notification"
description: Enable your properties to automatically notify a binding source when the property value changes in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "notifications of change [WPF]"
  - "data binding [WPF], property change notifications"
  - "change notifications [WPF]"
  - "properties [WPF], change notifications"
ms.assetid: 30b59d9e-8c3a-4349-aa82-4be837e841cf
---
# How to: Implement Property Change Notification

To support <xref:System.Windows.Data.BindingMode.OneWay> or <xref:System.Windows.Data.BindingMode.TwoWay> binding to enable your binding target properties to automatically reflect the dynamic changes of the binding source (for example, to have the preview pane updated automatically when the user edits a form), your class needs to provide the proper property changed notifications. This example shows how to create a class that implements <xref:System.ComponentModel.INotifyPropertyChanged>.  
  
## Example  

 To implement <xref:System.ComponentModel.INotifyPropertyChanged> you need to declare the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event and create the `OnPropertyChanged` method. Then for each property you want change notifications for, you call `OnPropertyChanged` whenever the property is updated.  
  
 [!code-csharp[SimpleBinding#PersonClass](~/samples/snippets/csharp/VS_Snippets_Wpf/SimpleBinding/CSharp/Person.cs#personclass)]
 [!code-vb[SimpleBinding#PersonClass](~/samples/snippets/visualbasic/VS_Snippets_Wpf/SimpleBinding/VisualBasic/Person.vb#personclass)]  
  
 To see an example of how the `Person` class can be used to support <xref:System.Windows.Data.BindingMode.TwoWay> binding, see [Control When the TextBox Text Updates the Source](how-to-control-when-the-textbox-text-updates-the-source.md).  
  
## See also

- [Binding Sources Overview](binding-sources-overview.md)
- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
