---
title: "How to: Set Up Notification of Binding Updates"
description: Learn how to use the INotifyPropertyChanged interface to set up notification when source or target binding properties have been updated.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "notifications [WPF], binding updates"
  - "data binding [WPF], notification of binding updates"
  - "binding [WPF], updates [WPF], notifications of"
ms.assetid: 5673073e-dbe1-49da-980a-484a88f9595a
---
# How to: Set Up Notification of Binding Updates

This example shows how to set up to be notified when the binding target (target) or the binding source (source) property of a binding has been updated.  
  
## Example  

 user interface (UI) that it should update, because the bound data has changed. Note that for these events to work, and also for one-way or two-way binding to work properly, you need to implement your data class using the <xref:System.ComponentModel.INotifyPropertyChanged> interface. For more information, see [Implement Property Change Notification](how-to-implement-property-change-notification.md).  
  
 Set the <xref:System.Windows.Data.Binding.NotifyOnTargetUpdated%2A> or <xref:System.Windows.Data.Binding.NotifyOnSourceUpdated%2A> property (or both) to `true` in the binding. The handler you provide to listen for this event must be attached directly to the element where you want to be informed of changes, or to the overall data context if you want to be aware that anything in the context has changed.  
  
 Here is an example that shows how to set up for notification when a target property has been updated.  
  
 [!code-xaml[DirectionalBinding#2](~/samples/snippets/csharp/VS_Snippets_Wpf/DirectionalBinding/CSharp/Page1.xaml#2)]  
  
 You can then assign a handler based on the EventHandler\<T> delegate, *OnTargetUpdated* in this example, to handle the event:  
  
 [!code-csharp[DirectionalBinding#3](~/samples/snippets/csharp/VS_Snippets_Wpf/DirectionalBinding/CSharp/Page1.xaml.cs#3)]  
[!code-csharp[DirectionalBinding#EndEvent](~/samples/snippets/csharp/VS_Snippets_Wpf/DirectionalBinding/CSharp/Page1.xaml.cs#endevent)]  
  
 Parameters of the event can be used to determine details about the property that changed (such as the type or the specific element if the same handler is attached to more than one element), which can be useful if there are multiple bound properties on a single element.  
  
## See also

- [Data Binding Overview](data-binding-overview.md)
- [How-to Topics](data-binding-how-to-topics.md)
