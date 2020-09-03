---
title: "How to: Specify the Direction of the Binding"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "direction of binding [WPF]"
  - "binding direction [WPF]"
  - "data binding [WPF], direction of binding"
ms.assetid: 37334478-028b-4514-86c9-1420709f4818
---
# How to: Specify the direction of the binding

This example shows how to specify whether the binding updates only the binding target (target) property, the binding source (source) property, or both the target property and the source property.  
  
## Example  
 You use the <xref:System.Windows.Data.Binding.Mode%2A?displayProperty=nameWithType> property to specify the direction of the binding. The following are the available options for binding updates:  
  
- <xref:System.Windows.Data.BindingMode.TwoWay?displayProperty=nameWithType> updates the target property or the property whenever either the target property or the source property changes.  
  
- <xref:System.Windows.Data.BindingMode.OneWay?displayProperty=nameWithType> updates the target property only when the source property changes.  
  
- <xref:System.Windows.Data.BindingMode.OneTime?displayProperty=nameWithType> updates the target property only when the application starts or when the <xref:System.Windows.FrameworkElement.DataContext%2A> undergoes a change.  
  
- <xref:System.Windows.Data.BindingMode.OneWayToSource?displayProperty=nameWithType> updates the source property when the target property changes.  
  
- <xref:System.Windows.Data.BindingMode.Default?displayProperty=nameWithType> causes the default <xref:System.Windows.Data.Binding.Mode%2A> value of target property to be used.  
  
 For more information, see the <xref:System.Windows.Data.BindingMode> enumeration.  
  
 The following example shows how to set the <xref:System.Windows.Data.Binding.Mode%2A> property.  
  
 [!code-xaml[DirectionalBinding#4](~/samples/snippets/csharp/VS_Snippets_Wpf/DirectionalBinding/CSharp/Page1.xaml#4)]  
  
 To detect source changes (applicable to <xref:System.Windows.Data.BindingMode.OneWay> and <xref:System.Windows.Data.BindingMode.TwoWay> bindings), the source must implement a suitable property change notification mechanism such as <xref:System.ComponentModel.INotifyPropertyChanged>. See [Implement Property Change Notification](how-to-implement-property-change-notification.md) for an example of an <xref:System.ComponentModel.INotifyPropertyChanged> implementation.  
  
 For <xref:System.Windows.Data.BindingMode.TwoWay> or <xref:System.Windows.Data.BindingMode.OneWayToSource> bindings, you can control the timing of the source updates by setting the <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> property. See <xref:System.Windows.Data.Binding.UpdateSourceTrigger%2A> for more information.  
  
## See also

- <xref:System.Windows.Data.Binding>
- [Data Binding Overview](/dotnet/desktop-wpf/data/data-binding-overview)
- [How-to Topics](data-binding-how-to-topics.md)
