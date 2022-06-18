---
title: "How to navigate data"
description: Learn how to navigate data in a Windows Forms application with a BindingSource component.
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

# Navigate data (Windows Forms .NET)

The easiest way to navigate through records in a data source is to bind a <xref:System.Windows.Forms.BindingSource> component to the data source and then bind controls to the `BindingSource`. You can then use the built-in navigation method of the `BindingSource`, such as <xref:System.Windows.Forms.BindingSource.MoveNext%2A>, <xref:System.Windows.Forms.BindingSource.MoveLast%2A>, <xref:System.Windows.Forms.BindingSource.MovePrevious%2A>, and <xref:System.Windows.Forms.BindingSource.MoveFirst%2A>. Using these methods will adjust the <xref:System.Windows.Forms.BindingSource.Position%2A> and <xref:System.Windows.Forms.BindingSource.Current%2A> properties of the `BindingSource` appropriately. You can also find a record and set it as the current record by setting the `Position` property.

## To increment the record position in a data source

Set the <xref:System.Windows.Forms.BindingSource.Position%2A> property of the <xref:System.Windows.Forms.BindingSource> for your bound data to the record position to go to the required record position. The following example illustrates using the <xref:System.Windows.Forms.BindingSource.MoveNext%2A> method of the `BindingSource` to increment the `Position` property when you select the `nextButton`. The `BindingSource` is associated with the `Customers` table of a dataset `Northwind`.

:::code language="csharp" source="snippets/work-with-data-grid/csharp/form1.cs" id="increment_position_on_next_button_click":::
:::code language="vb" source="snippets/work-with-data-grid/vb/form1.vb" id="increment_position_on_next_button_click":::

> [!NOTE]
> Setting the <xref:System.Windows.Forms.BindingSource.Position%2A> property to a value beyond the first or last record does not result in an error, as Windows Forms won't set the position to a value outside the bounds of the list. If it's important to know whether you have gone past the first or last record, include logic to test whether you'll exceed the data element count.

## To check whether you've exceeded the first or last record

Create an event handler for the <xref:System.Windows.Forms.BindingSource.PositionChanged> event. In the handler, you can test whether the proposed position value has exceeded the actual data element count.

The following example illustrates how you can test whether you've reached the last data element. In the example, if you are at the last element, the **Next** button on the form is disabled.

:::code language="csharp" source="snippets/work-with-data-grid/csharp/form1.cs" id="check_for_last_element":::
:::code language="vb" source="snippets/work-with-data-grid/vb/form1.vb" id="check_for_last_element":::

> [!NOTE]
> Be aware that, if you change the list you are navigating in code, you should re-enable the **Next** button so that users might browse the entire length of the new list. Additionally, be aware that the above <xref:System.Windows.Forms.BindingSource.PositionChanged> event for the specific <xref:System.Windows.Forms.BindingSource> you are working with needs to be associated with its event-handling method.

## To find a record and set it as the current item

Find the record you wish to set as the current item. Use the <xref:System.Windows.Forms.BindingSource.Find%2A> method of the <xref:System.Windows.Forms.BindingSource> as shown in the example, if your data source implements <xref:System.ComponentModel.IBindingList>. Some examples of data sources that implement `IBindingList` are <xref:System.ComponentModel.BindingList%601> and <xref:System.Data.DataView>.

:::code language="csharp" source="snippets/work-with-data-grid/csharp/form1.cs" id="find_the_record":::
:::code language="vb" source="snippets/work-with-data-grid/vb/form1.vb" id="find_the_record":::

## To ensure the selected row in a child table remains at the correct position

When you work with data binding in Windows Forms, you'll display data in a parent/child or master/detail view. It's a data-binding scenario where data from the same source is displayed in two controls. Changing the selection in one control causes the data displayed in the second control to change. For example, the first control might contain a list of customers and the second a list of orders related to the selected customer in the first control.

When you display data in a parent/child view, you might have to take extra steps to ensure that the currently selected row in the child table isn't reset to the first row of the table. In order to do this, you'll have to cache the child table position and reset it after the parent table changes. Typically, the child table reset occurs the first time a field in a row of the parent table changes.

### To cache the current child table position

01. Declare an integer variable to store the child table position and a Boolean variable to store whether to cache the child table position.

    :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="store_the_child_list_pos":::
    :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="store_the_child_list_pos":::

01. Handle the <xref:System.Windows.Forms.CurrencyManager.ListChanged> event for the binding's <xref:System.Windows.Forms.CurrencyManager> and check for a <xref:System.ComponentModel.ListChangedType> of <xref:System.ComponentModel.ListChangedType.Reset>.

01. Check the current position of the <xref:System.Windows.Forms.CurrencyManager>. If it's greater than the first entry in the list (typically 0), save it to a variable.

    :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="check_current_pos_of_currency_manager":::
    :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="check_current_pos_of_currency_manager":::

01. Handle the parent list's <xref:System.Windows.Forms.BindingManagerBase.CurrentChanged> event for the parent currency manager. In the handler, set the Boolean value to indicate it isn't a caching scenario. If the `CurrentChanged` occurs, the change to the parent is a list position change and not an item value change.

    :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="handle_current_change_event":::
    :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="handle_current_change_event":::

### To reset the child table position

01. Handle the <xref:System.Windows.Forms.BindingManagerBase.PositionChanged> event for the child table binding's <xref:System.Windows.Forms.CurrencyManager>.

01. Reset the child table position to the cached position saved in the previous procedure.

    :::code language="csharp" source="snippets/work-with-data-grid/csharp/form2.cs" id="reset_child_tab_pos":::
    :::code language="vb" source="snippets/work-with-data-grid/vb/form2.vb" id="reset_child_tab_pos":::

To test the code example, perform the following steps:

01. Run the example.

01. Ensure the **Cache and reset position** checkbox is selected.

01. Select the **Clear parent field** button to cause a change in a field of the parent table. Notice that the selected row in the child table doesn't change.

01. Close and rerun the example. You need to run it again because the reset behavior occurs only on the first change in the parent row.

01. Clear the **Cache and reset position** checkbox.

01. Select the **Clear parent field** button. Notice that the selected row in the child table changes to the first row.

## See also

- [Data binding overview](overview.md)
- [Data sources supported by Windows Forms](overview.md#data-sources-supported-by-windows-forms)
- [Change Notification in Windows Forms Data Binding](design-great-data-sources.md)
- [How to synchronize multiple controls to the same data source](how-to-synchronize-multiple-controls.md)
- [BindingSource Component](/dotnet/desktop/winforms/controls/bindingsource-component?view=netframeworkdesktop-4.8&preserve-view=true)
