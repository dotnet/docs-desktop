---
title: "How to Navigate Data"
description: Learn how to navigate data.
ms.date: "05/20/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "cursors [Windows Forms], data sources"
  - "data sources [Windows Forms], Windows Forms"
  - "Windows Forms, navigating"
  - "CurrencyManager class [Windows Forms], navigating Windows Forms data"
  - "data [Windows Forms], navigating"
ms.custom: devdivchpfy22
---

# How to navigate data in Windows Forms .NET

In a Windows application, the easiest way to navigate through records in a data source is to bind a <xref:System.Windows.Forms.BindingSource> component to the data source and then bind controls to the `BindingSource`. You can then use the built-in navigation method on the `BindingSource` such a <xref:System.Windows.Forms.BindingSource.MoveNext%2A>, <xref:System.Windows.Forms.BindingSource.MoveLast%2A>, <xref:System.Windows.Forms.BindingSource.MovePrevious%2A> and <xref:System.Windows.Forms.BindingSource.MoveFirst%2A>. Using these methods will adjust the <xref:System.Windows.Forms.BindingSource.Position%2A> and <xref:System.Windows.Forms.BindingSource.Current%2A> properties of the `BindingSource` appropriately. You can also find an item and set it as the current item by setting the `Position` property.

## To increment the position in a data source

01. Set the <xref:System.Windows.Forms.BindingSource.Position%2A> property of the `BindingSource` for your bound data to the record position to go to. The following example illustrates using the <xref:System.Windows.Forms.BindingSource.MoveNext%2A> method of the `BindingSource` to increment the `Position` property when the `nextButton` is clicked. The `BindingSource` is associated with the `Customers` table of a dataset `Northwind`.

    > [!NOTE]
    > Setting the <xref:System.Windows.Forms.BindingSource.Position%2A> property to a value beyond the first or last record does not result in an error, as the .NET will not allow you to set the position to a value outside the bounds of the list. If it's important in your application to know whether you have gone past the first or last record, include logic to test whether you will exceed the data element count.

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form1.cs" id="increment_position_on_next_button_click":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form1.vb" id="increment_position_on_next_button_click":::

## To check whether you've passed the end or beginning

01. Create an event handler for the <xref:System.Windows.Forms.BindingSource.PositionChanged> event. In the handler, you can test whether the proposed position value has exceeded the actual data element count.

     The following example illustrates how you can test whether you've reached the last data element. In the example, if you are at the last element, the **Next** button on the form is disabled.

    > [!NOTE]
    > Be aware that, should you change the list you are navigating in code, you should re-enable the **Next** button, so that users might browse the entire length of the new list. Additionally, be aware that the above <xref:System.Windows.Forms.BindingSource.PositionChanged> event for the specific <xref:System.Windows.Forms.BindingSource> you are working with needs to be associated with its event-handling method. The following is an example of a method for handling the <xref:System.Windows.Forms.BindingSource.PositionChanged> event:

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form1.cs" id="check_for_last_element":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form1.vb" id="check_for_last_element":::

## To find an item and set it as the current item

01. Find the record you wish to set as the current item. Use the <xref:System.Windows.Forms.BindingSource.Find%2A> method of the <xref:System.Windows.Forms.BindingSource>, if your data source implements <xref:System.ComponentModel.IBindingList>. Some examples of data sources that implement `IBindingList` are <xref:System.ComponentModel.BindingList%601> and <xref:System.Data.DataView>.

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form1.cs" id="find_the_record":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form1.vb" id="find_the_record":::

## How to ensure the selected row in a child table remains at the correct position

When you work with data binding in Windows Forms, you'll display data in a parent/child or master/details view. It's a data-binding scenario where data from the same source is displayed in two controls. Changing the selection in one control causes the data displayed in the second control to change. For example, the first control might contain a list of customers and the second a list of orders related to the selected customer in the first control.

When you display data in a parent/child view, you might have to take extra steps to ensure that the currently selected row in the child table isn't reset to the first row of the table. In order to do this, you'll have to cache the child table position and reset it after the parent table changes. Typically the child reset occurs the first time a field in a row of the parent table changes.

### To cache the current child position

01. Declare an integer variable to store the child list position and a Boolean variable to store whether to cache the child position.

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="store_the_child_list_pos":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="store_the_child_list_pos":::

01. Handle the <xref:System.Windows.Forms.CurrencyManager.ListChanged> event for the binding's <xref:System.Windows.Forms.CurrencyManager> and check for a <xref:System.ComponentModel.ListChangedType> of <xref:System.ComponentModel.ListChangedType.Reset>.

01. Check the current position of the <xref:System.Windows.Forms.CurrencyManager>. If it's greater than first entry in the list (typically 0), save it to a variable.

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="check_current_pos_of_currency_manager":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="check_current_pos_of_currency_manager":::

01. Handle the parent list's <xref:System.Windows.Forms.BindingManagerBase.CurrentChanged> event for the parent currency manager. In the handler, set the Boolean value to indicate it isn't a caching scenario. If the `CurrentChanged` occurs, the change to the parent is a list position change and not an item value change.

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="handle_current_change_event":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="handle_current_change_event":::

### To reset the child position

01. Handle the <xref:System.Windows.Forms.BindingManagerBase.PositionChanged> event for the child binding's <xref:System.Windows.Forms.CurrencyManager>.

01. Reset the child table position to the cached position saved in the previous procedure.

     :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="reset_child_tab_pos":::
     :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="reset_child_tab_pos":::

To test the code example, perform the following steps:

01. Run the example.

01. Ensure the **Cache and reset position** check box is selected.

01. Select the **Clear parent field** button to cause a change in a field of the parent table. Notice that the selected row in the child table doesn't change.

01. Close and run the example again. You need to run it again because the reset behavior occurs only on the first change in the parent row.

01. Clear the **Cache and reset position** check box.

01. Select the **Clear parent field** button. Notice that the selected row in the child table changes to the first row.

## See also

- [Data Sources Supported by Windows Forms](/dotnet/desktop/winforms/data-sources-supported-by-windows-forms?view=netframeworkdesktop-4.8&preserve-view=true)
- [Change Notification in Windows Forms Data Binding](/dotnet/desktop/winforms/change-notification-in-windows-forms-data-binding?view=netframeworkdesktop-4.8&preserve-view=true)
- [Windows Forms Data Binding](/dotnet/desktop/winforms/windows-forms-data-binding?view=netframeworkdesktop-4.8&preserve-view=true)
- [How to Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized](/dotnet/desktop/winforms/multiple-controls-bound-to-data-source-synchronized?view=netframeworkdesktop-4.8&preserve-view=true)
- [BindingSource Component](/dotnet/desktop/winforms//controls/bindingsource-component?view=netframeworkdesktop-4.8&preserve-view=true)
- [Data Binding and Windows Forms](/dotnet/desktop/winforms/data-binding-and-windows-forms?view=netframeworkdesktop-4.8&preserve-view=true)
