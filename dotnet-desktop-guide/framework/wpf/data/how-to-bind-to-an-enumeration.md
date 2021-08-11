---
title: "How to: Bind to an Enumeration"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "binding data [WPF], enumeration"
  - "data binding [WPF], enumeration"
  - "enumeration [WPF]"
ms.assetid: b9091eba-1119-424e-868b-d1a4168b3732
---
# How to: Bind to an Enumeration
This example shows how to bind to an enumeration by binding to the enumeration's GetValues method.  
  
## Example  
 In the following example, the <xref:System.Windows.Controls.ListBox> displays the list of <xref:System.Windows.HorizontalAlignment> enumeration values through data binding. The <xref:System.Windows.Controls.ListBox> and the <xref:System.Windows.Controls.Button> are bound such that you can change the <xref:System.Windows.FrameworkElement.HorizontalAlignment%2A> property value of the <xref:System.Windows.Controls.Button> by selecting a value in the <xref:System.Windows.Controls.ListBox>.  
  
 [!code-xaml[BindToEnum#BindToEnum](~/samples/snippets/csharp/VS_Snippets_Wpf/BindToEnum/CS/Window1.xaml#bindtoenum)]  
  
## See also

- [Bind to a Method](how-to-bind-to-a-method.md)
- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
