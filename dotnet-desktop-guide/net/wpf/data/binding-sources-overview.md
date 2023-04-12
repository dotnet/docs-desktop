---
title: Binding sources overview
description: Discover the types of objects you can use as the binding source for your applications in Windows Presentation Foundation (WPF).
ms.date: 02/15/2023
author: adegeo
ms.author: adegeo
helpviewer_keywords:
  - "binding data [WPF], binding sources"
  - "data binding [WPF], binding source"
  - "binding sources [WPF]"
---

# Binding sources overview (WPF .NET)

In data binding, the binding source object refers to the object you obtain data from. This article discusses the types of objects you can use as the binding source, like .NET CLR objects, XML, and <xref:System.Windows.DependencyObject> objects.

## Binding source types

Windows Presentation Foundation (WPF) data binding supports the following binding source types:

- **.NET common language runtime (CLR) objects**

  You can bind to public properties, sub-properties, and indexers of any common language runtime (CLR) object. The binding engine uses CLR reflection to get the values of the properties. Objects that implement <xref:System.ComponentModel.ICustomTypeDescriptor> or have a registered <xref:System.ComponentModel.TypeDescriptionProvider> also work with the binding engine.

  For more information about how to implement a class that can serve as a binding source, see [Implementing a binding source on your objects](#implement-a-binding-source-on-your-objects) later in this article.

- **Dynamic objects**

  You can bind to available properties and indexers of an object that implements the <xref:System.Dynamic.IDynamicMetaObjectProvider> interface. If you can access the member in code, you can bind to it. For example, if a dynamic object enables you to access a member in code via `SomeObject.AProperty`, you can bind to it by setting the binding path to `AProperty`.

- **ADO.NET objects**

  You can bind to ADO.NET objects, such as <xref:System.Data.DataTable>. The ADO.NET <xref:System.Data.DataView> implements the <xref:System.ComponentModel.IBindingList> interface, which provides change notifications that the binding engine listens for.

- **XML objects**

  You can bind to and run `XPath` queries on an <xref:System.Xml.XmlNode>, <xref:System.Xml.XmlDocument>, or <xref:System.Xml.XmlElement>. A convenient way to access XML data that is the binding source in markup is to use an <xref:System.Windows.Data.XmlDataProvider> object. For more information, see [Bind to XML Data Using an XMLDataProvider and XPath Queries (.NET Framework)](../../../framework/wpf/data/how-to-bind-to-xml-data-using-an-xmldataprovider-and-xpath-queries.md).

  You can also bind to an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument>, or bind to the results of queries run on objects of these types by using LINQ to XML. A convenient way to use LINQ to XML to access XML data that is the binding source in markup is to use an <xref:System.Windows.Data.ObjectDataProvider> object. For more information, see [Bind to XDocument, XElement, or LINQ for XML Query Results (.NET Framework)](../../../framework/wpf/data/how-to-bind-to-xdocument-xelement-or-linq-for-xml-query-results.md).

- **<xref:System.Windows.DependencyObject> objects**

  You can bind to dependency properties of any <xref:System.Windows.DependencyObject>. For an example, see [Bind the Properties of Two Controls (.NET Framework)](../../../framework/wpf/data/how-to-bind-the-properties-of-two-controls.md).

## Implement a binding source on your objects

Your CLR objects can become binding sources. There are a few things to be aware of when implementing a class to serve as a binding source.

### Provide change notifications

If you're using either <xref:System.Windows.Data.BindingMode.OneWay> or <xref:System.Windows.Data.BindingMode.TwoWay> binding, implement a suitable "property changed" notification mechanism. The recommended mechanism is for the CLR or dynamic class to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. For more information, see [How to: Implement Property Change Notification (.NET Framework)](../../../framework/wpf/data/how-to-implement-property-change-notification.md).

There are two ways to notify a subscriber of a property change:

01. Implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface.

    This is the recommended mechanism for notifications. The <xref:System.ComponentModel.INotifyPropertyChanged> supplies the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event, which the binding system respects. By raising this event, and providing the name of the property that changed, you'll notify a binding target of the change.

01. Implement the `PropertyChanged` pattern.

    Each property that needs to notify a binding target that it's changed, has a corresponding `PropertyNameChanged` event, where `PropertyName` is the name of the property. You raise the event every time the property changes.

If your binding source implements one of these notification mechanisms, target updates happen automatically. If for any reason your binding source doesn't provide the proper property changed notifications, you can use the <xref:System.Windows.Data.BindingExpression.UpdateTarget%2A> method to update the target property explicitly.

### Other characteristics

The following list provides other important points to note:

- Data objects that serve as binding sources can be declared in XAML as resources, provided they have a **parameterless constructor**. Otherwise, you must create the data object in code and directly assign it to either the data context of your XAML object tree, or as the binding source of binding.

- The properties you use as binding source properties must be public properties of your class. Explicitly defined interface properties can't be accessed for binding purposes, nor can protected, private, internal, or virtual properties that have no base implementation.

- You can't bind to public fields.

- The type of the property declared in your class is the type that is passed to the binding. However, the type ultimately used by the binding depends on the type of the binding target property, not of the binding source property. If there's a difference in type, you might want to write a converter to handle how your custom property is initially passed to the binding. For more information, see <xref:System.Windows.Data.IValueConverter>.

## Entire objects as a binding source

You can use an entire object as a binding source. Specify a binding source by using the <xref:System.Windows.Data.Binding.Source%2A> or the <xref:System.Windows.FrameworkElement.DataContext%2A> property, and then provide a blank binding declaration: `{Binding}`. Scenarios in which this is useful include binding to objects that are of type string, binding to objects with multiple properties you're interested in, or binding to collection objects. For an example of binding to an entire collection object, see [How to Use the Master-Detail Pattern with Hierarchical Data (.NET Framework)](../../../framework/wpf/data/how-to-use-the-master-detail-pattern-with-hierarchical-data.md).

You may need to apply custom logic so that the data is meaningful to your bound target property. The custom logic may be in the form of a custom converter or a <xref:System.Windows.DataTemplate>. For more information about converters, see [Data conversion](index.md#data-conversion). For more information about data templates, see [Data Templating Overview (.NET Framework)](../../../framework/wpf/data/data-templating-overview.md).

## Collection objects as a binding source

Often, the object you want to use as the binding source is a collection of custom objects. Each object serves as the source for one instance of a repeated binding. For example, you might have a `CustomerOrders` collection that consists of `CustomerOrder` objects, where your application iterates over the collection to determine how many orders exist and the data contained in each order.

You can enumerate over any collection that implements the <xref:System.Collections.IEnumerable> interface. However, to set up dynamic bindings so that insertions or deletions in the collection update the UI automatically, the collection must implement the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface. This interface exposes an event that must be raised whenever the underlying collection changes.

The <xref:System.Collections.ObjectModel.ObservableCollection%601> class is a built-in implementation of a data collection that exposes the <xref:System.Collections.Specialized.INotifyCollectionChanged> interface. The individual data objects within the collection must satisfy the requirements described in the preceding sections. For an example, see [How to Create and Bind to an ObservableCollection (.NET Framework)](../../../framework/wpf/data/how-to-create-and-bind-to-an-observablecollection.md). Before you implement your own collection, consider using <xref:System.Collections.ObjectModel.ObservableCollection%601> or one of the existing collection classes, such as <xref:System.Collections.Generic.List%601>, <xref:System.Collections.ObjectModel.Collection%601>, and <xref:System.ComponentModel.BindingList%601>, among many others.

When you specify a collection as a binding source, WPF doesn't bind directly to the collection. Instead, WPF actually binds to the collection's default view. For information about default views, see [Using a default view](index.md#using-a-default-view).

If you have an advanced scenario and you want to implement your own collection, consider using the <xref:System.Collections.IList> interface. This interface provides a non-generic collection of objects that can be individually accessed by index, which can improve performance.

## Permission requirements in data binding

Unlike .NET Framework, .NET runs with full-trust security. All data binding runs with the same access as the user running the application.

## See also

- <xref:System.Windows.Data.ObjectDataProvider>
- <xref:System.Windows.Data.XmlDataProvider>
- [Data binding overview](index.md)
- [Binding sources overview](binding-sources-overview.md)
- [Overview of WPF data binding with LINQ to XML (.NET Framework)](../../../framework/wpf/data/wpf-data-binding-with-linq-to-xml-overview.md)
- [Optimizing Performance: Data Binding (.NET Framework)](../../../framework/wpf/advanced/optimizing-performance-data-binding.md)
