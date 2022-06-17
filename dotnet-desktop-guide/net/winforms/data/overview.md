---
title: "Overview of Data Binding and Windows Forms"
description: "Learn about interfaces related to Data Binding, data sources supported by Windows Forms, and types of Data Binding."
ms.date: "05/05/2022"
ms.topic: overview
helpviewer_keywords:
  - "data [Windows Forms], data-binding interfaces"
  - "INotifyPropertyChanged interface"
  - "IBindingListView interface"
  - "IList interface [Windows Forms], Windows Forms data binding"
  - "IBindingList interface [Windows Forms], Windows Forms data binding"
  - "interfaces [Windows Forms], Windows Forms data binding"
  - "IEditableObject interface [Windows Forms], Windows Forms data binding"
  - "data binding [Windows Forms], interfaces"
  - "IDataErrorInfo interface [Windows Forms], Windows Forms data binding"
ms.custom: devdivchpfy22
---

# Data binding overview (Windows Forms .NET)

In Windows Forms, you can bind to not just traditional data sources, but also to almost any structure that contains data. You can bind to an array of values that you calculate at run time, read from a file, or derive from the values of other controls.

 In addition, you can bind any property of any control to the data source. In traditional data binding, you typically bind the display property—for example, the <xref:System.Windows.Forms.Control.Text%2A> property of a <xref:System.Windows.Forms.TextBox> control—to the data source. With .NET, you also have the option of setting other properties through binding. You might use binding to perform the following tasks:

- Setting the graphic of an image control.

- Setting the background color of one or more controls.

- Setting the size of controls.

 Essentially, data binding is an automatic way of setting any run-time accessible property of any control on a form.

## Interfaces related to data binding

ADO.NET lets you create many different data structures to suit the binding needs of your application and the data you're working with. You might want to create your own classes that provide or consume data in Windows Forms. These objects can offer varying levels of functionality and complexity. From basic data binding, to providing design-time support, error checking, change notification, or even support for a structured rollback of the changes made to the data itself.

### Consumers of data binding interfaces

The following sections describe two groups of interface objects. The first group of interface is implemented on data sources by data source authors. The data source consumers such as the Windows Forms controls or components implement these interfaces. The second group of interface is designed to use by component authors. Component authors use these interfaces when they're creating a component that supports data binding to be consumed by the Windows Forms data binding engine. You can implement these interfaces within classes associated with your form to enable data binding. Each case presents a class that implements an interface that enables interaction with data. Visual Studio rapid application development (RAD) data design experience tools already take advantage of this functionality.

#### Interfaces for implementation by data source authors

The Windows Forms controls implement following interfaces:

- <xref:System.Collections.IList> interface

  A class that implements the <xref:System.Collections.IList> interface could be an <xref:System.Array>, <xref:System.Collections.ArrayList>, or <xref:System.Collections.CollectionBase>. These are indexed lists of items of type <xref:System.Object> and the lists must contain homogenous types, because the first item of the index determines the type. `IList` would be available for binding only at run time.

  > [!NOTE]
  > If you want to create a list of business objects for binding with Windows Forms, you should consider using the <xref:System.ComponentModel.BindingList%601>. The `BindingList` is an extensible class that implements the primary interfaces required for two-way Windows Forms data binding.

- <xref:System.ComponentModel.IBindingList> interface

  A class that implements the <xref:System.ComponentModel.IBindingList> interface provides a much higher level of data-binding functionality. This implementation offers you basic sorting capabilities and change notification. Both are useful when the list items change, and when the list itself changes. Change notification is important if you plan to have multiple controls bound to the same data. It helps you to make data changes made in one of the controls to propagate to the other bound controls.

  > [!NOTE]
  > Change notification is enabled for the <xref:System.ComponentModel.IBindingList> interface through the <xref:System.ComponentModel.IBindingList.SupportsChangeNotification%2A> property which, when `true`, raises a <xref:System.ComponentModel.IBindingList.ListChanged> event, indicating the list changed or an item in the list changed.

  The type of change is described by the <xref:System.ComponentModel.ListChangedType> property of the <xref:System.ComponentModel.ListChangedEventArgs> parameter. Hence, whenever the data model is updated, any dependent views, such as other controls bound to the same data source, will also be updated. However, objects contained within the list will have to notify the list when they change so that the list can raise the <xref:System.ComponentModel.IBindingList.ListChanged> event.

  > [!NOTE]
  > The <xref:System.ComponentModel.BindingList%601> provides a generic implementation of the <xref:System.ComponentModel.IBindingList> interface.

- <xref:System.ComponentModel.IBindingListView> interface

  A class that implements the <xref:System.ComponentModel.IBindingListView> interface provides all the functionality of an implementation of <xref:System.ComponentModel.IBindingList>, along with filtering and advanced sorting functionality. This implementation offers string-based filtering, and multi-column sorting with property descriptor-direction pairs.

- <xref:System.ComponentModel.IEditableObject> interface

  A class that implements the <xref:System.ComponentModel.IEditableObject> interface allows an object to control when changes to that object are made permanent. This implementation supports the <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>, and <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> methods, which enable you to roll back changes made to the object. Following is a brief explanation of the functioning of the `BeginEdit`, `EndEdit`, and `CancelEdit` methods and how they work with one another to enable a possible rollback of changes made to the data:

  - The <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> method signals the start of an edit on an object. An object that implements this interface will need to store any updates after the `BeginEdit` method call in such a way that the updates can be discarded if the <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> method is called. In data binding Windows Forms, you can call `BeginEdit` multiple times within the scope of a single edit transaction (for example, `BeginEdit`, `BeginEdit`, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>). Implementations of <xref:System.ComponentModel.IEditableObject> should keep track of whether `BeginEdit` has already been called and ignore subsequent calls to `BeginEdit`. Because this method can be called multiple times, it's important that subsequent calls to it are nondestructive. Subsequent `BeginEdit` calls can't destroy the updates that have been made or change the data that was saved on the first `BeginEdit` call.

  - The <xref:System.ComponentModel.IEditableObject.EndEdit%2A> method pushes any changes since <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> was called into the underlying object, if the object is currently in edit mode.

  - The <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> method discards any changes made to the object.

  For more information about how the <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>, and <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> methods work, see [Save data back to the database](/visualstudio/data-tools/save-data-back-to-the-database).

  This transactional notion of data functionality is used by the <xref:System.Windows.Forms.DataGridView> control.

- <xref:System.ComponentModel.ICancelAddNew> interface

  A class that implements the <xref:System.ComponentModel.ICancelAddNew> interface usually implements the <xref:System.ComponentModel.IBindingList> interface and allows you to roll back an addition made to the data source with the <xref:System.ComponentModel.IBindingList.AddNew%2A> method. If your data source implements the `IBindingList` interface, you should also have it implement the `ICancelAddNew` interface.

- <xref:System.ComponentModel.IDataErrorInfo> interface

  A class that implements the <xref:System.ComponentModel.IDataErrorInfo> interface allows objects to offer custom error information to bound controls:

  - The <xref:System.ComponentModel.IDataErrorInfo.Error%2A> property returns general error message text (for example, "An error has occurred").

  - The <xref:System.ComponentModel.IDataErrorInfo.Item%2A> property returns a string with the specific error message from the column (for example, "The value in the `State` column is invalid").

- <xref:System.Collections.IEnumerable> interface

  A class that implements the <xref:System.Collections.IEnumerable> interface is typically consumed by ASP.NET. Windows Forms support for this interface is only available through the <xref:System.Windows.Forms.BindingSource> component.

  > [!NOTE]
  > The <xref:System.Windows.Forms.BindingSource> component copies all <xref:System.Collections.IEnumerable> items into a separate list for binding purposes.

- <xref:System.ComponentModel.ITypedList> interface

  A collections class that implements the <xref:System.ComponentModel.ITypedList> interface provides the feature to control the order and the set of properties exposed to the bound control.

  > [!NOTE]
  > When you implement the <xref:System.ComponentModel.ITypedList.GetItemProperties%2A> method, and the <xref:System.ComponentModel.PropertyDescriptor> array is not null, the last entry in the array will be the property descriptor that describes the list property that is another list of items.

- <xref:System.ComponentModel.ICustomTypeDescriptor> interface

  A class that implements the <xref:System.ComponentModel.ICustomTypeDescriptor> interface provides dynamic information about itself. This interface is similar to <xref:System.ComponentModel.ITypedList> but is used for objects rather than lists. This interface is used by <xref:System.Data.DataRowView> to project the schema of the underlying rows. A simple implementation of `ICustomTypeDescriptor` is provided by the <xref:System.ComponentModel.CustomTypeDescriptor> class.

  > [!NOTE]
  > To support design-time binding to types that implement <xref:System.ComponentModel.ICustomTypeDescriptor>, the type must also implement <xref:System.ComponentModel.IComponent> and exist as an instance on the Form.

- <xref:System.ComponentModel.IListSource> interface

  A class that implements the <xref:System.ComponentModel.IListSource> interface enables list-based binding on non-list objects. The <xref:System.ComponentModel.IListSource.GetList%2A> method of `IListSource` is used to return a bindable list from an object that doesn't inherit from <xref:System.Collections.IList>.`IListSource` is used by the <xref:System.Data.DataSet> class.

- <xref:System.ComponentModel.IRaiseItemChangedEvents> interface

  A class that implements the <xref:System.ComponentModel.IRaiseItemChangedEvents> interface is a bindable list that also implements the <xref:System.ComponentModel.IBindingList> interface. This interface is used to indicate if your type raises <xref:System.ComponentModel.IBindingList.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged> through its <xref:System.ComponentModel.IRaiseItemChangedEvents.RaisesItemChangedEvents%2A> property.

  > [!NOTE]
  > You should implement the <xref:System.ComponentModel.IRaiseItemChangedEvents> if your data source provides the property to list event conversion described previously and is interacting with the <xref:System.Windows.Forms.BindingSource> component. Otherwise, the `BindingSource` will also perform property to list event conversion resulting in slower performance.

- <xref:System.ComponentModel.ISupportInitialize> interface

  A component that implements the <xref:System.ComponentModel.ISupportInitialize> interface takes advantages of batch optimizations for setting properties and initializing co-dependent properties. The `ISupportInitialize` contains two methods:

  - <xref:System.ComponentModel.ISupportInitialize.BeginInit%2A> signals that object initialization is starting.

  - <xref:System.ComponentModel.ISupportInitialize.EndInit%2A> signals that object initialization is finishing.

- <xref:System.ComponentModel.ISupportInitializeNotification> interface

  A component that implements the <xref:System.ComponentModel.ISupportInitializeNotification> interface also implements the <xref:System.ComponentModel.ISupportInitialize> interface. This interface allows you to notify other `ISupportInitialize` components that initialization is complete. The `ISupportInitializeNotification` interface contains two members:

  - <xref:System.ComponentModel.ISupportInitializeNotification.IsInitialized%2A> returns a `boolean` value indicating whether the component is initialized.

  - <xref:System.ComponentModel.ISupportInitializeNotification.Initialized> occurs when <xref:System.ComponentModel.ISupportInitialize.EndInit%2A> is called.

- <xref:System.ComponentModel.INotifyPropertyChanged> interface

  A class that implements this interface is a type that raises an event when any of its property values change. This interface is designed to replace the pattern of having a change event for each property of a control. When used in a <xref:System.ComponentModel.BindingList%601>, a business object should implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface and the BindingList\`1 will convert <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> events to <xref:System.ComponentModel.BindingList%601.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged>.

  > [!NOTE]
  > For change notification to occur in a binding between a bound client and a data source, your bound data-source type should either implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface (preferred) or you can provide *propertyName*`Changed` events for the bound type, but you shouldn't do both.

#### Interfaces for implementation by component authors

The following interfaces are designed for consumption by the Windows Forms data-binding engine:

- <xref:System.Windows.Forms.IBindableComponent> interface

  A class that implements this interface is a non-control component that supports data binding. This class returns the data bindings and binding context of the component through the <xref:System.Windows.Forms.IBindableComponent.DataBindings%2A> and <xref:System.Windows.Forms.IBindableComponent.BindingContext%2A> properties of this interface.

  > [!NOTE]
  > If your component inherits from <xref:System.Windows.Forms.Control>, you don't need to implement the <xref:System.Windows.Forms.IBindableComponent> interface.

- <xref:System.Windows.Forms.ICurrencyManagerProvider> interface

  A class that implements the <xref:System.Windows.Forms.ICurrencyManagerProvider> interface is a component that provides its own <xref:System.Windows.Forms.CurrencyManager> to manage the bindings associated with this particular component. Access to the custom `CurrencyManager` is provided by the <xref:System.Windows.Forms.ICurrencyManagerProvider.CurrencyManager%2A> property.

  > [!NOTE]
  > A class that inherits from <xref:System.Windows.Forms.Control> manages bindings automatically through its <xref:System.Windows.Forms.Control.BindingContext%2A> property, so cases in which you need to implement the <xref:System.Windows.Forms.ICurrencyManagerProvider> are fairly rare.

## Data sources supported by Windows Forms

Traditionally, data binding has been used within applications to take advantage of data stored in databases. With Windows Forms data binding, you can access data from databases and data in other structures, such as arrays and collections, so long as certain minimum requirements have been met.

### Structures to bind To

 In Windows Forms, you can bind to a wide variety of structures, from simple objects (simple binding) to complex lists such as ADO.NET data tables (complex binding). For simple binding, Windows Forms support binding to the public properties on the simple object. Windows Forms list-based binding generally requires that the object supports the <xref:System.Collections.IList> interface or the <xref:System.ComponentModel.IListSource> interface. Additionally, if you're binding with through a <xref:System.Windows.Forms.BindingSource> component, you can bind to an object that supports the <xref:System.Collections.IEnumerable> interface.

The following list shows the structures you can bind to in Windows Forms.

- <xref:System.Windows.Forms.BindingSource>

  A <xref:System.Windows.Forms.BindingSource> is the most common Windows Forms data source and acts a proxy between a data source and Windows Forms controls. The general `BindingSource` usage pattern is to bind your controls to the `BindingSource` and bind the `BindingSource` to the data source (for example, an ADO.NET data table or a business object). The `BindingSource` provides services that enable and improve the level of data binding support. For example, Windows Forms list based controls such as the <xref:System.Windows.Forms.DataGridView> and <xref:System.Windows.Forms.ComboBox> don't directly support binding to <xref:System.Collections.IEnumerable> data sources however, you can enable this scenario by binding through a `BindingSource`. In this case, the `BindingSource` will convert the data source to an <xref:System.Collections.IList>.

- Simple objects

  Windows Forms support data binding control properties to public properties on the instance of an object using the <xref:System.Windows.Forms.Binding> type. Windows Forms also support binding list based controls, such as a <xref:System.Windows.Forms.ListControl> to an object instance when a <xref:System.Windows.Forms.BindingSource> is used.

- Array or Collection

  To act as a data source, a list must implement the <xref:System.Collections.IList> interface; one example would be an array that is an instance of the <xref:System.Array> class. For more information on arrays, see [How to: Create an Array of Objects (Visual Basic)](/previous-versions/visualstudio/visual-studio-2010/487y7874(v=vs.100)).

  In general, you should use <xref:System.ComponentModel.BindingList%601> when you create lists of objects for data binding. `BindingList` is a generic version of the <xref:System.ComponentModel.IBindingList> interface. The `IBindingList` interface extends the <xref:System.Collections.IList> interface by adding properties, methods and events necessary for two-way data binding.

- <xref:System.Collections.IEnumerable>

  Windows Forms controls can be bound to data sources that only support the <xref:System.Collections.IEnumerable> interface if they're bound through a <xref:System.Windows.Forms.BindingSource> component.

- ADO.NET data objects

  ADO.NET provides many data structures suitable for binding to. Each varies in its sophistication and complexity.

  - <xref:System.Data.DataColumn>

    A <xref:System.Data.DataColumn> is the essential building block of a <xref:System.Data.DataTable>, in that multiple columns comprise a table. Each `DataColumn` has a <xref:System.Data.DataColumn.DataType%2A> property that determines the kind of data the column holds (for example, the make of an automobile in a table describing cars). You can simple-bind a control (such as a <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.Control.Text%2A> property) to a column within a data table.

  - <xref:System.Data.DataTable>

    A <xref:System.Data.DataTable> is the representation of a table, with rows and columns, in ADO.NET. A data table contains two collections: <xref:System.Data.DataColumn>, representing the columns of data in a given table (which ultimately determine the kinds of data that can be entered into that table), and <xref:System.Data.DataRow>, representing the rows of data in a given table. You can complex-bind a control to the information contained in a data table (such as binding the <xref:System.Windows.Forms.DataGridView> control to a data table). However, when you bind to a `DataTable`, you're a binding to the table's default view.

  - <xref:System.Data.DataView>

    A <xref:System.Data.DataView> is a customized view of a single data table that may be filtered or sorted. A data view is the data "snapshot" used by complex-bound controls. You can simple-bind or complex-bind to the data within a data view, but note that you're binding to a fixed "picture" of the data rather than a clean, updating data source.

  - <xref:System.Data.DataSet>

    A <xref:System.Data.DataSet> is a collection of tables, relationships, and constraints of the data in a database. You can simple-bind or complex-bind to the data within a dataset, but note that you're binding to the default <xref:System.Data.DataViewManager> for the `DataSet` (see the next bullet point).

  - <xref:System.Data.DataViewManager>
  
    A <xref:System.Data.DataViewManager> is a customized view of the entire <xref:System.Data.DataSet>, analogous to a <xref:System.Data.DataView>, but with relations included. With a <xref:System.Data.DataViewManager.DataViewSettings%2A> collection, you can set default filters and sort options for any views that the `DataViewManager` has for a given table.

## Types of data binding

 Windows Forms can take advantage of two types of data binding: simple binding and complex binding. Each offers different advantages.

|Type of data binding|Description|
|--------------------------|-----------------|
|Simple data binding|The ability of a control to bind to a single data element, such as a value in a column in a dataset table. Simple data binding is the type of binding typical for controls such as a <xref:System.Windows.Forms.TextBox> control or <xref:System.Windows.Forms.Label> control, which are controls that typically only display a single value. In fact, any property on a control can be bound to a field in a database. There's extensive support for this feature in Visual Studio.<br /><br /> For more information, see [Navigate data](how-to-work-with-data-grid.md) and [Create a simple-bound control (Windows Forms .NET)](how-to-create-control-binding.md).|
|Complex data binding|The ability of a control to bind to more than one data element, typically more than one record in a database. Complex binding is also called list-based binding. Examples of controls that support complex binding are the <xref:System.Windows.Forms.DataGridView>, <xref:System.Windows.Forms.ListBox>, and <xref:System.Windows.Forms.ComboBox> controls. For an example of complex data binding, see [How to: Bind a Windows Forms ComboBox or ListBox Control to Data](/dotnet/desktop/winforms/controls/how-to-bind-a-windows-forms-combobox-or-listbox-control-to-data?view=netframeworkdesktop-4.8&preserve-view=true).|

### Binding source component

 To simplify data binding, Windows Forms enables you to bind a data source to the <xref:System.Windows.Forms.BindingSource> component and then bind controls to the `BindingSource`. You can use the `BindingSource` in simple or complex binding scenarios. In either case, the `BindingSource` acts as an intermediary between the data source and bound controls providing change notification currency management and other services.

### Common scenarios that employ data binding

 Nearly every commercial application uses information read from data sources of one type or another, usually through data binding. The following list shows a few of the most common scenarios that utilize data binding as the method of data presentation and manipulation.

|Scenario|Description|
|--------------|-----------------|
|Reporting|Reports provide a flexible way for you to display and summarize your data in a printed document. It's common to create a report that prints selected contents of a data source either to the screen or to a printer. Common reports include lists, invoices, and summaries. Items are formatted into columns of lists, with subitems organized under each list item, but you should choose the layout that best suits the data.|
|Data entry|A common way to enter large amounts of related data or to prompt users for information is through a data entry form. Users can enter information or select choices using text boxes, option buttons, drop-down lists, and check boxes. Information is then submitted and stored in a database, whose structure is based on the information entered.|
|Master/detail relationship|A master/detail application is one format for looking at related data. Specifically, there are two tables of data with a relation connecting in the classic business example, a "Customers" table and an "Orders" table with a relationship between them linking customers and their respective orders. For more information about creating a master/detail application with two Windows Forms <xref:System.Windows.Forms.DataGridView> controls, see [How to: Create a Master/Detail Form Using Two Windows Forms DataGridView Controls](/dotnet/desktop/winforms/controls/create-a-master-detail-form-using-two-datagridviews?view=netframeworkdesktop-4.8&preserve-view=true)|
|Lookup Table|Another common data presentation/manipulation scenario is the table lookup. Often, as part of a larger data display, a <xref:System.Windows.Forms.ComboBox> control is used to display and manipulate data. The key is that the data displayed in the `ComboBox` control is different than the data written to the database. For example, if you have a `ComboBox` control displaying the items available from a grocery store, you would probably like to see the names of the products (bread, milk, eggs). However, to ease information retrieval within the database and for database normalization, you would probably store the information for the specific items of a given order as item numbers (#501, #603, and so on). Thus, there's an implicit connection between the "friendly name" of the grocery item in the `ComboBox` control on your form and the related item number that is present in an order. It's the essence of a table lookup. For more information, see [How to: Create a Lookup Table with the Windows Forms BindingSource Component](/dotnet/desktop/winforms/controls/how-to-create-a-lookup-table-with-the-windows-forms-bindingsource-component?view=netframeworkdesktop-4.8&preserve-view=true).|

## See also

- <xref:System.Windows.Forms.Binding>
- [Data binding overview](overview.md)
- [Design great data sources with change notification](design-great-data-sources.md)
- [Create a simple-bound control (Windows Forms .NET)](how-to-create-control-binding.md)
- [BindingSource Component](/dotnet/desktop/winforms/controls/bindingsource-component?view=netframeworkdesktop-4.8&preserve-view=true)
- [How to: Bind the Windows Forms DataGrid Control to a Data Source](/dotnet/desktop/winforms/controls/how-to-bind-the-windows-forms-datagrid-control-to-a-data-source?view=netframeworkdesktop-4.8&preserve-view=true)
