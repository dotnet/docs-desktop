---
title: "How to synchronize multiple controls bound to the same data source"
description: Learn how to ensure multiple controls bound to the same data source remain synchronized.
ms.date: "06/06/2022"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], binding multiple"
  - "controls [Windows Forms], synchronizing with data source"
ms.custom: devdivchpfy22
---

# Synchronize multiple controls to the same data source (Windows Forms .NET)

During the implementation of data binding in Windows Forms, multiple controls are bound to the same data source. In the following situations, it's necessary to ensure that the bound properties of the control remain synchronized with each other and the data source:

- If the data source doesn't implement <xref:System.ComponentModel.IBindingList>, and therefore generates <xref:System.ComponentModel.IBindingList.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged>.

- If the data source implements <xref:System.ComponentModel.IEditableObject>.

In the former case, you can use a <xref:System.Windows.Forms.BindingSource> to bind the data source to the controls. In the latter case, you use a `BindingSource` and handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event and call <xref:System.Windows.Forms.BindingManagerBase.EndCurrentEdit%2A> on the associated <xref:System.Windows.Forms.BindingManagerBase>.

## Example of bind controls using BindingSource

The following code example demonstrates how to bind three controls, two textbox controls, and a <xref:System.Windows.Forms.DataGridView> control to the same column in a <xref:System.Data.DataSet> using a <xref:System.Windows.Forms.BindingSource> component. The example demonstrates how to handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event. It ensures that when the text value of one textbox is changed, the other textbox and the `DataGridView` control are updated with the correct value.

The example uses a <xref:System.Windows.Forms.BindingSource> to bind the data source and the controls. Alternatively, you can bind the controls directly to the data source and retrieve the <xref:System.Windows.Forms.BindingManagerBase> for the binding from the form's <xref:System.Windows.Forms.Control.BindingContext%2A> and then handle the <xref:System.Windows.Forms.BindingManagerBase.BindingComplete> event for the `BindingManagerBase`. For more information on binding the data source and the controls, see the help page about the `BindingComplete` event of `BindingManagerBase`.

:::code language="csharp" source="snippets/how-to-synchronize-multiple-controls/csharp/form1.cs" id="bind_controls_using_BindingSource":::

:::code language="vb" source="snippets/how-to-synchronize-multiple-controls/vb/form1.vb" id="bind_controls_using_BindingSource":::

## See also

- [Design great data sources with change notification](design-great-data-sources.md)
- [Data Binding](overview.md)
- [How to: Share Bound Data Across Forms Using the BindingSource Component](/dotnet/desktop/winforms/controls/how-to-share-bound-data-across-forms-using-the-bindingsource-component?view=netframeworkdesktop-4.8&preserve-view=true)
