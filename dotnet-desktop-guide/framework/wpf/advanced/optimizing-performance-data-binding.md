---
title: "Optimizing Performance: Data Binding"
description: Learn how to optimize the performance of Windows Presentation Foundation (WPF) data binding, for a simple, consistent way to present and interact with data.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "binding data [WPF], performance"
  - "data binding [WPF], performance"
ms.assetid: 1506a35d-c009-43db-9f1e-4e230ad5be73
---
# Optimizing Performance: Data Binding

Windows Presentation Foundation (WPF) data binding provides a simple and consistent way for applications to present and interact with data. Elements can be bound to data from a variety of data sources in the form of CLR objects and XML.  
  
 This topic provides data binding performance recommendations.  

<a name="HowDataBindingReferencesAreResolved"></a>

## How Data Binding References are Resolved  

 Before discussing data binding performance issues, it is worthwhile to explore how the Windows Presentation Foundation (WPF) data binding engine resolves object references for binding.  
  
 The source of a Windows Presentation Foundation (WPF) data binding can be any CLR object. You can bind to properties, sub-properties, or indexers of a CLR object. The binding references are resolved by using either Microsoft .NET Framework reflection or an <xref:System.ComponentModel.ICustomTypeDescriptor>. Here are three methods for resolving object references for binding.  
  
 The first method involves using reflection. In this case, the <xref:System.Reflection.PropertyInfo> object is used to discover the attributes of the property and provides access to property metadata. When using the <xref:System.ComponentModel.ICustomTypeDescriptor> interface, the data binding engine uses this interface to access the property values. The <xref:System.ComponentModel.ICustomTypeDescriptor> interface is especially useful in cases where the object does not have a static set of properties.  
  
 Property change notifications can be provided either by implementing the <xref:System.ComponentModel.INotifyPropertyChanged> interface or by using the change notifications associated with the <xref:System.ComponentModel.TypeDescriptor>. However, the preferred strategy for implementing property change notifications is to use <xref:System.ComponentModel.INotifyPropertyChanged>.  
  
 If the source object is a CLR object and the source property is a CLR property, the Windows Presentation Foundation (WPF) data binding engine has to first use reflection on the source object to get the <xref:System.ComponentModel.TypeDescriptor>, and then query for a <xref:System.ComponentModel.PropertyDescriptor>. This sequence of reflection operations is potentially very time-consuming from a performance perspective.  
  
 The second method for resolving object references involves a CLR source object that implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface, and a source property that is a CLR property. In this case, the data binding engine uses reflection directly on the source type and gets the required property. This is still not the optimal method, but it will cost less in working set requirements than the first method.  
  
 The third method for resolving object references involves a source object that is a <xref:System.Windows.DependencyObject> and a source property that is a <xref:System.Windows.DependencyProperty>. In this case, the data binding engine does not need to use reflection. Instead, the property engine and the data binding engine together resolve the property reference independently. This is the optimal method for resolving object references used for data binding.  
  
 The table below compares the speed of data binding the <xref:System.Windows.Controls.TextBlock.Text%2A> property of one thousand <xref:System.Windows.Controls.TextBlock> elements using these three methods.  
  
|**Binding the Text property of a TextBlock**|**Binding time (ms)**|**Render time -- includes binding (ms)**|  
|--------------------------------------------------|-----------------------------|--------------------------------------------------|  
|To a property of a CLR object|115|314|  
|To a property of a CLR object which implements <xref:System.ComponentModel.INotifyPropertyChanged>|115|305|  
|To a <xref:System.Windows.DependencyProperty> of a <xref:System.Windows.DependencyObject>.|90|263|  
  
<a name="Binding_to_Large_CLR_Objects"></a>

## Binding to Large CLR Objects  

 There is a significant performance impact when you data bind to a single CLR object with thousands of properties. You can minimize this impact by dividing the single object into multiple CLR objects with fewer properties. The table shows the binding and rendering times for data binding to a single large CLR object versus multiple smaller objects.  
  
|**Data binding 1000 TextBlock objects**|**Binding time (ms)**|**Render time -- includes binding (ms)**|  
|---------------------------------------------|-----------------------------|--------------------------------------------------|  
|To a CLR object with 1000 properties|950|1200|  
|To 1000 CLR objects with one property|115|314|  
  
<a name="Binding_to_an_ItemsSource"></a>

## Binding to an ItemsSource  

 Consider a scenario in which you have a CLR <xref:System.Collections.Generic.List%601> object that holds a list of employees that you want to display in a <xref:System.Windows.Controls.ListBox>. To create a correspondence between these two objects, you would bind your employee list to the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property of the <xref:System.Windows.Controls.ListBox>. However, suppose you have a new employee joining your group. You might think that in order to insert this new person into your bound <xref:System.Windows.Controls.ListBox> values, you would simply add this person to your employee list and expect this change to be recognized by the data binding engine automatically. That assumption would prove false; in actuality, the change will not be reflected in the <xref:System.Windows.Controls.ListBox> automatically. This is because the CLR <xref:System.Collections.Generic.List%601> object does not automatically raise a collection changed event. In order to get the <xref:System.Windows.Controls.ListBox> to pick up the changes, you would have to recreate your list of employees and re-attach it to the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property of the <xref:System.Windows.Controls.ListBox>. While this solution works, it introduces a huge performance impact. Each time you reassign the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> of <xref:System.Windows.Controls.ListBox> to a new object, the <xref:System.Windows.Controls.ListBox> first throws away its previous items and regenerates its entire list. The performance impact is magnified if your <xref:System.Windows.Controls.ListBox> maps to a complex <xref:System.Windows.DataTemplate>.  
  
 A very efficient solution to this problem is to make your employee list an <xref:System.Collections.ObjectModel.ObservableCollection%601>. An <xref:System.Collections.ObjectModel.ObservableCollection%601> object raises a change notification which the data binding engine can receive. The event adds or removes an item from an <xref:System.Windows.Controls.ItemsControl> without the need to regenerate the entire list.  
  
 The table below shows the time it takes to update the <xref:System.Windows.Controls.ListBox> (with UI virtualization turned off) when one item is added. The number in the first row represents the elapsed time when the CLR <xref:System.Collections.Generic.List%601> object is bound to <xref:System.Windows.Controls.ListBox> element's <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A>. The number in the second row represents the elapsed time when an <xref:System.Collections.ObjectModel.ObservableCollection%601> is bound to the <xref:System.Windows.Controls.ListBox> element's <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A>. Note the significant time savings using the <xref:System.Collections.ObjectModel.ObservableCollection%601> data binding strategy.  
  
|**Data binding the ItemsSource**|**Update time for 1 item (ms)**|  
|--------------------------------------|---------------------------------------|  
|To a CLR <xref:System.Collections.Generic.List%601> object|1656|  
|To an <xref:System.Collections.ObjectModel.ObservableCollection%601>|20|  
  
<a name="Binding_IList_to_ItemsControl_not_IEnumerable"></a>

## Bind IList to ItemsControl not IEnumerable  

 If you have a choice between binding an <xref:System.Collections.Generic.IList%601> or an <xref:System.Collections.IEnumerable> to an <xref:System.Windows.Controls.ItemsControl> object, choose the <xref:System.Collections.Generic.IList%601> object. Binding <xref:System.Collections.IEnumerable> to an <xref:System.Windows.Controls.ItemsControl> forces WPF to create a wrapper <xref:System.Collections.Generic.IList%601> object, which means your performance is impacted by the unnecessary overhead of a second object.  
  
<a name="Do_not_Convert_CLR_objects_to_Xml_Just_For_Data_Binding"></a>

## Do not Convert CLR objects to XML Just for Data Binding.  

 WPF allows you to data bind to XML content; however, data binding to XML content is slower than data binding to CLR objects. Do not convert CLR object data to XML if the only purpose is for data binding.  
  
## See also

- [Optimizing WPF Application Performance](optimizing-wpf-application-performance.md)
- [Planning for Application Performance](planning-for-application-performance.md)
- [Taking Advantage of Hardware](optimizing-performance-taking-advantage-of-hardware.md)
- [Layout and Design](optimizing-performance-layout-and-design.md)
- [2D Graphics and Imaging](optimizing-performance-2d-graphics-and-imaging.md)
- [Object Behavior](optimizing-performance-object-behavior.md)
- [Application Resources](optimizing-performance-application-resources.md)
- [Text](optimizing-performance-text.md)
- [Other Performance Recommendations](optimizing-performance-other-recommendations.md)
- [Data Binding Overview](../data/data-binding-overview.md)
- [Walkthrough: Caching Application Data in a WPF Application](walkthrough-caching-application-data-in-a-wpf-application.md)
