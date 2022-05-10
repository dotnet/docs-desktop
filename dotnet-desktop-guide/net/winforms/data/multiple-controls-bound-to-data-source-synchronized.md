---
title: "How to ensure multiple controls bound to the same data source remain synchronized"
description: Learn how to ensure multiple controls bound to the same data source remain synchronized.
ms.date: "05/10/2022"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], binding multiple"
  - "controls [Windows Forms], synchronizing with data source"
ms.custom: devdivchpfy22
---

# How to ensure multiple controls bound to the same data source remain synchronized

During implementation of data binding in Windows Forms, multiple controls are bound to the same data source. In some cases, it may be necessary to take extra steps to ensure that the bound properties of the controls remain synchronized with each other and the data source. These steps are necessary in two situations:  
  
- If the data source doesn't implement <xref:System.ComponentModel.IBindingList>, and therefore generate <xref:System.ComponentModel.IBindingList.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged>.  
  
- If the data source implements <xref:System.ComponentModel.IEditableObject>.  
  
In the former case, you can use a <xref:System.Windows.Forms.BindingSource> to bind the data source to the controls. In the latter case, you use a <xref:System.Windows.Forms.BindingSource> and handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event and call <xref:System.Windows.Forms.BindingManagerBase.EndCurrentEdit%2A> on the associated <xref:System.Windows.Forms.BindingManagerBase>.  

The following code example demonstrates how to bind three controls—two text-box controls and a <xref:System.Windows.Forms.DataGridView> control—to the same column in a <xref:System.Data.DataSet> using a <xref:System.Windows.Forms.BindingSource> component. The example demonstrates how to handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event. It ensures that when the text value of one text box is changed, the other text box and the <xref:System.Windows.Forms.DataGridView> control are updated with the correct value.  
  
The example uses a <xref:System.Windows.Forms.BindingSource> to bind the data source and the controls. Alternatively, you can bind the controls directly to the data source and retrieve the <xref:System.Windows.Forms.BindingManagerBase> for the binding from the form's <xref:System.Windows.Forms.Control.BindingContext%2A> and then handle the <xref:System.Windows.Forms.BindingManagerBase.BindingComplete> event for the <xref:System.Windows.Forms.BindingManagerBase>. For more information on bind the data source and the controls, see the help page about the <xref:System.Windows.Forms.BindingManagerBase.BindingComplete> event of <xref:System.Windows.Forms.BindingManagerBase>.  
  
 [!code-csharp[System.Windows.Forms.BindingSourceMultipleControls#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BindingSourceMultipleControls/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.BindingSourceMultipleControls#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BindingSourceMultipleControls/VB/Form1.vb#1)]  

## How to apply the PropertyNameChanged pattern

The following code example demonstrates how to apply the *PropertyName*Changed pattern to a custom control. Apply the pattern when you implement custom controls that are used with the Windows Forms data binding engine.  

 [!code-csharp[System.Windows.Forms.ChangeNotification#3](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ChangeNotification/CS/Form1.cs#3)]
 [!code-vb[System.Windows.Forms.ChangeNotification#3](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ChangeNotification/VB/Form1.vb#3)]  
  
## Change notification in Windows Forms data binding

One of the most important concepts of Windows Forms data binding is the *change notification*. To ensure that your data source and bound controls always have the most recent data, you must add change notification for data binding. Specifically, you want to ensure that bound controls are notified of changes that were made to their data source. The data source is notified of changes that were made to the bound properties of a control.  
  
There are different kinds of change notification, depending on the kind of data binding:  
  
- Simple binding, in which a single control property is bound to a single instance of an object.  
  
- List-based binding, which can include a single control property bound to the property of an item in a list or a control property bound to a list of objects.  
  
Additionally, if you're creating Windows Forms controls that you want to use for data binding, you must apply the *PropertyName*Changed pattern to the controls. Applying pattern to the controls results in changes to the bound property of a control are propagated to the data source.  
  
### Change notification for simple binding  

For simple binding, business objects must provide change notification when the value of a bound property changes. You can provide change notification by exposing a PropertyNameChanged event for each property of your business object. It also requires binding the business object to controls with the <xref:System.Windows.Forms.BindingSource> or the preferred method in which your business object implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface and raises a <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event when the value of a property changes. For more information, see [How to: Implement the INotifyPropertyChanged Interface](how-to-implement-the-inotifypropertychanged-interface.md). When you use objects that implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface, you don't have to use the <xref:System.Windows.Forms.BindingSource> to bind the object to a control. But using the <xref:System.Windows.Forms.BindingSource> is recommended.  
  
### Change notification for list-based binding  

Windows Forms depends on a bound list to provide *property change* and *list change* information to bound controls. The *property change* is a list item property value change and *list change* is an item deleted or added to the list. Therefore, lists used for data binding must implement the <xref:System.ComponentModel.IBindingList>, which provides both types of change notification. The <xref:System.ComponentModel.BindingList%601> is a generic implementation of <xref:System.ComponentModel.IBindingList> and is designed for use with Windows Forms data binding. You can create a <xref:System.ComponentModel.BindingList%601> that contains a business object type that implements <xref:System.ComponentModel.INotifyPropertyChanged> and the list will automatically convert the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> events to <xref:System.ComponentModel.IBindingList.ListChanged> events. If the bound list isn't an <xref:System.ComponentModel.IBindingList>, you must bind the list of objects to Windows Forms controls by using the <xref:System.Windows.Forms.BindingSource> component. The <xref:System.Windows.Forms.BindingSource> component will provide property-to-list conversion similar to that of the <xref:System.ComponentModel.BindingList%601>. For more information, see [How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface](./controls/raise-change-notifications--bindingsource.md).  
  
### Change notification for custom controls  

Finally, from the control side you must expose a *PropertyName*Changed event for each property designed to be bound to data. The changes to the control property are then propagated to the bound data source. For more information, see [How to: Apply the PropertyNameChanged Pattern](how-to-apply-the-propertynamechanged-pattern.md)  
  
## How to implement the INotifyPropertyChanged interface

The following code example demonstrates how to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. Implement the interface on business objects that are used in Windows Forms data binding. When implemented, the interface  communicates to a bound control the property changes on a business object.  

 [!code-csharp[System.ComponentModel.IPropertyChangeExample#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.ComponentModel.IPropertyChangeExample/CS/Form1.cs#1)]
 [!code-vb[System.ComponentModel.IPropertyChangeExample#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.ComponentModel.IPropertyChangeExample/VB/Form1.vb#1)]  

## See also

- <xref:System.Windows.Forms.BindingSource>
- <xref:System.ComponentModel.INotifyPropertyChanged>
- <xref:System.ComponentModel.BindingList%601>
- [How to: Share Bound Data Across Forms Using the BindingSource Component](./controls/how-to-share-bound-data-across-forms-using-the-bindingsource-component.md)
- [Interfaces Related to Data Binding](overview.md)
- [Data Sources Supported by Windows Forms](overview.md)
- [Data Binding and Windows Forms](overview.md)
- [Windows Forms Data Binding](windows-forms-data-binding.md)
- [How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface](./controls/raise-change-notifications--bindingsource.md)
