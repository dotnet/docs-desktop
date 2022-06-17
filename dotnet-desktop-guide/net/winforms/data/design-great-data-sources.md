---
title: "Design great data sources"
description: Learn how to design great data sources in Windows Forms .NET.
ms.date: "05/31/2022"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], binding multiple"
  - "controls [Windows Forms], synchronizing with data source"
ms.custom: devdivchpfy22
---

# Design great data sources with change notification (Windows Forms .NET)

One of the most important concepts of Windows Forms data binding is the *change notification*. To ensure that your data source and bound controls always have the most recent data, you must add change notification for data binding. Specifically, you want to ensure that bound controls are notified of changes that were made to their data source. The data source is notified of changes that were made to the bound properties of a control.

There are different kinds of change notifications, depending on the kind of data binding:

- Simple binding, in which a single control property is bound to a single instance of an object.

- List-based binding, which can include a single control property bound to the property of an item in a list or a control property bound to a list of objects.

Additionally, if you're creating Windows Forms controls that you want to use for data binding, you must apply the *PropertyName*Changed pattern to the controls. Applying pattern to the controls results in changes to the bound property of a control are propagated to the data source.

## Change notification for simple binding

For simple binding, business objects must provide change notification when the value of a bound property changes. You can provide change notification by exposing a PropertyNameChanged event for each property of your business object. It also requires binding the business object to controls with the <xref:System.Windows.Forms.BindingSource> or the preferred method in which your business object implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface and raises a <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event when the value of a property changes. When you use objects that implement the `INotifyPropertyChanged` interface, you don't have to use the `BindingSource` to bind the object to a control. But using the `BindingSource` is recommended.

## Change notification for list-based binding

Windows Forms depends on a bound list to provide *property change* and *list change* information to bound controls. The *property change* is a list item property value change and *list change* is an item deleted or added to the list. Therefore, lists used for data binding must implement the <xref:System.ComponentModel.IBindingList>, which provides both types of change notification. The <xref:System.ComponentModel.BindingList%601> is a generic implementation of `IBindingList` and is designed for use with Windows Forms data binding. You can create a `BindingList` that contains a business object type that implements <xref:System.ComponentModel.INotifyPropertyChanged> and the list will automatically convert the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> events to <xref:System.ComponentModel.IBindingList.ListChanged> events. If the bound list isn't an `IBindingList`, you must bind the list of objects to Windows Forms controls by using the <xref:System.Windows.Forms.BindingSource> component. The `BindingSource` component will provide property-to-list conversion similar to that of the `BindingList`. For more information, see [How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface](/dotnet/desktop/winforms/controls/raise-change-notifications--bindingsource?view=netframeworkdesktop-4.8&preserve-view=true).

## Change notification for custom controls

Finally, from the control side you must expose a *PropertyName*Changed event for each property designed to be bound to data. The changes to the control property are then propagated to the bound data source. For more information, see [Apply the PropertyNameChanged pattern](design-great-data-sources.md#apply-the-propertynamechanged-pattern).

## Apply the PropertyNameChanged pattern

The following code example demonstrates how to apply the *PropertyName*Changed pattern to a custom control. Apply the pattern when you implement custom controls that are used with the Windows Forms data binding engine.

:::code language="csharp" source="snippets/design-great-data-sources/csharp/form2.cs" id="apply_propertyNameChanged_pattern":::

:::code language="vb" source="snippets/design-great-data-sources/vb/form2.vb" id="apply_propertyNameChanged_pattern":::

## Implement the INotifyPropertyChanged interface

The following code example demonstrates how to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. Implement the interface on business objects that are used in Windows Forms data binding. When implemented, the interface  communicates to a bound control the property changes on a business object.

:::code language="csharp" source="snippets/design-great-data-sources/csharp/form3.cs" id="implement_INotifyPropertyChanged_interface":::

:::code language="vb" source="snippets/design-great-data-sources/vb/form3.vb" id="implement_INotifyPropertyChanged_interface":::

## Synchronize bindings

During implementation of data binding in Windows Forms, multiple controls are bound to the same data source. In some cases, it may be necessary to take extra steps to ensure that the bound properties of the controls remain synchronized with each other and the data source. These steps are necessary in two situations:

- If the data source doesn't implement <xref:System.ComponentModel.IBindingList>, and therefore generate <xref:System.ComponentModel.IBindingList.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged>.

- If the data source implements <xref:System.ComponentModel.IEditableObject>.

In the former case, you can use a <xref:System.Windows.Forms.BindingSource> to bind the data source to the controls. In the latter case, you use a `BindingSource` and handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event and call <xref:System.Windows.Forms.BindingManagerBase.EndCurrentEdit%2A> on the associated <xref:System.Windows.Forms.BindingManagerBase>.

For more information on implementing this concept, see the [BindingComplete API reference page](xref:System.Windows.Forms.BindingManagerBase.BindingComplete).

## See also

- [Data Binding](overview.md)
- <xref:System.Windows.Forms.BindingSource>
- <xref:System.ComponentModel.INotifyPropertyChanged>
- <xref:System.ComponentModel.BindingList%601>
