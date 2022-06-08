---
title: "How to ensure the selected row in a child table remains at the correct position"
ms.date: "06/08/2022"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "master-details view"
  - "row position [Windows Forms .NET]"
  - "parent/child view [Windows Forms .NET]"
  - "resetting child position"
  - "data binding [.NET], row selection"
  - "caching [.NET], child position"
  - "child position"
  - "master/details view [Windows Forms .NET]"
  - "child tables row selection"
  - "current child position"
ms.custom: devdivchpfy22
---

# How to ensure the selected row in a child table remains at the correct position

Often when you work with data binding in Windows Forms, you'll display data in what is called a parent/child or master/details view. The data from the same source is displayed in two controls is referred as data-binding. Changing the selection in one control causes the data displayed in the second control to change. For example, the first control might contain a list of customers and the second a list of orders related to the selected customer in the first control.

 To display data in a parent/child view, you might have to take extra steps to ensure that the currently selected row in the child table isn't reset to the first row of the table. You'll have to cache the child table position and reset it after the parent table changes to view the currently selected row in the child table. Typically the child reset occurs the first time a field in a row of the parent table changes.

## To cache the current child position

01. Declare an integer variable to store the child list position and a Boolean variable to store whether to cache the child position.

     :::code language="csharp" source="snippets/ensure-the-selected-row-in-a-child-table-correct/csharp/form1.cs" id="store_child_list_position":::
     :::code language="vb" source="snippets/ensure-the-selected-row-in-a-child-table-correct/vb/form1.vb" id="store_child_list_position":::

01. Handle the <xref:System.Windows.Forms.CurrencyManager.ListChanged> event for the binding's <xref:System.Windows.Forms.CurrencyManager> and check for a <xref:System.ComponentModel.ListChangedType> of <xref:System.ComponentModel.ListChangedType.Reset>.

01. Check the current position of the <xref:System.Windows.Forms.CurrencyManager>. If it's greater than first entry in the list (typically 0), save it to a variable.

     :::code language="csharp" source="snippets/ensure-the-selected-row-in-a-child-table-correct/csharp/form1.cs" id="check_current_pos":::
     :::code language="vb" source="snippets/ensure-the-selected-row-in-a-child-table-correct/vb/form1.vb" id="check_current_pos":::

01. Handle the parent list's <xref:System.Windows.Forms.BindingManagerBase.CurrentChanged> event for the parent currency manager. In the handler, set the Boolean value to indicate it isn't a caching scenario. If the `CurrentChanged` occurs, the change to the parent is a list position change and not an item value change.

     :::code language="csharp" source="snippets/ensure-the-selected-row-in-a-child-table-correct/csharp/form1.cs" id="handle_parent_list":::
     :::code language="vb" source="snippets/ensure-the-selected-row-in-a-child-table-correct/vb/form1.vb" id="handle_parent_list":::

## To reset the child position

01. Handle the <xref:System.Windows.Forms.BindingManagerBase.PositionChanged> event for the child binding's <xref:System.Windows.Forms.CurrencyManager>.

01. Reset the child table position to the cached position saved in the previous procedure.

     :::code language="csharp" source="snippets/ensure-the-selected-row-in-a-child-table-correct/csharp/form1.cs" id="reset_child_tab_pos":::
     :::code language="vb" source="snippets/ensure-the-selected-row-in-a-child-table-correct/vb/form1.vb" id="reset_child_tab_pos":::

## See also

- [How to: Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized](/dotnet/desktop/winforms/multiple-controls-bound-to-data-source-synchronized?view=netframeworkdesktop-4.8&preserve-view=true)
- [BindingSource Component](/dotnet/desktop/winforms/controls/bindingsource-component?view=netframeworkdesktop-4.8&preserve-view=true)
- [Data Binding and Windows Forms](/dotnet/desktop/winforms/data-binding-and-windows-forms?view=netframeworkdesktop-4.8&preserve-view=true)
