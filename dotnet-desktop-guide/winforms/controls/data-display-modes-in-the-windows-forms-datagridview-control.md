---
title: Data Display Modes in DataGridView Control
description: Learn about data display modes in the Windows Forms DataGridView control, which displays data in three distinct modes.
ms.date: "03/30/2017"
ms.service: dotnet-framework
helpviewer_keywords:
  - "data [Windows Forms], display modes"
  - "data grids [Windows Forms], display modes"
  - "DataGridView control [Windows Forms], display modes"
ms.assetid: 9755a030-3f3f-4705-a661-ba5a48a81875
---
# Data Display Modes in the Windows Forms DataGridView Control

The <xref:System.Windows.Forms.DataGridView> control can display data in three distinct modes: bound, unbound, and virtual. Choose the most suitable mode based on your requirements.

## Unbound

Unbound mode is suitable for displaying relatively small amounts of data that you manage programmatically. You do not attach the <xref:System.Windows.Forms.DataGridView> control directly to a data source as in bound mode. Instead, you must populate the control yourself, typically by using the <xref:System.Windows.Forms.DataGridViewRowCollection.Add%2A?displayProperty=nameWithType> method.

Unbound mode can be particularly useful for static, read-only data, or when you want to provide your own code that interacts with an external data store. When you want your users to interact with an external data source, however, you will typically use bound mode.

For an example that uses a read-only unbound <xref:System.Windows.Forms.DataGridView>, see [How to: Create an Unbound Windows Forms DataGridView Control](how-to-create-an-unbound-windows-forms-datagridview-control.md).

## Bound

Bound mode is suitable for managing data using automatic interaction with the data store. You can attach the <xref:System.Windows.Forms.DataGridView> control directly to its data source by setting the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property. When the control is data bound, data rows are pushed and pulled without the need of explicit management on your part. When the <xref:System.Windows.Forms.DataGridView.AutoGenerateColumns%2A> property is `true`, each column in your data source will cause a corresponding column to be created in the control. If you prefer to create your own columns, you can set this property to `false` and use the <xref:System.Windows.Forms.DataGridViewColumn.DataPropertyName%2A> property to bind each column when you configure it. This is useful when you want to use a column type other than the types that are generated by default. For more information, see [Column Types in the Windows Forms DataGridView Control](column-types-in-the-windows-forms-datagridview-control.md).

For an example that uses a bound <xref:System.Windows.Forms.DataGridView> control, see [Walkthrough: Validating Data in the Windows Forms DataGridView Control](walkthrough-validating-data-in-the-windows-forms-datagridview-control.md).

You can also add unbound columns to a <xref:System.Windows.Forms.DataGridView> control in bound mode. This is useful when you want to display a column of buttons or links that enable users to perform actions on specific rows. It is also useful to display columns with values calculated from bound columns. You can populate the cell values for calculated columns in a handler for the <xref:System.Windows.Forms.DataGridView.CellFormatting> event. If you are using a <xref:System.Data.DataSet> or <xref:System.Data.DataTable> as the data source, however, you might want to use the <xref:System.Data.DataColumn.Expression%2A?displayProperty=nameWithType> property to create a calculated column instead. In this case, the <xref:System.Windows.Forms.DataGridView> control will treat calculated column just like any other column in the data source.

Sorting by unbound columns in bound mode is not supported. If you create an unbound column in bound mode that contains user-editable values, you must implement virtual mode to maintain these values when the control is sorted by a bound column.

## Virtual

With virtual mode, you can implement your own data management operations. This is necessary to maintain the values of unbound columns in bound mode when the control is sorted by bound columns. The primary use of virtual mode, however, is to optimize performance when interacting with large amounts of data.

You attach the <xref:System.Windows.Forms.DataGridView> control to a cache that you manage, and your code controls when data rows are pushed and pulled. To keep the memory footprint small, the cache should be similar in size to the number of rows currently displayed. When the user scrolls new rows into view, your code requests new data from the cache and optionally flushes old data from memory.

When you are implementing virtual mode, you will need to track when a new row is needed in the data model and when to rollback the addition of the new row. The exact implementation of this functionality will depend on the implementation of the data model and the transaction semantics of the data model; whether commit scope is at the cell or row level.

For more information about virtual mode, see [Virtual Mode in the Windows Forms DataGridView Control](virtual-mode-in-the-windows-forms-datagridview-control.md). For an example that shows how to use virtual mode events, see [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](implementing-virtual-mode-wf-datagridview-control.md).

## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.DataSource%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.DataGridView.VirtualMode%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.BindingSource>
- <xref:System.Windows.Forms.DataGridViewColumn.DataPropertyName%2A?displayProperty=nameWithType>
- [Displaying Data in the Windows Forms DataGridView Control](displaying-data-in-the-windows-forms-datagridview-control.md)
- [Column Types in the Windows Forms DataGridView Control](column-types-in-the-windows-forms-datagridview-control.md)
- [Walkthrough: Creating an Unbound Windows Forms DataGridView Control](walkthrough-creating-an-unbound-windows-forms-datagridview-control.md)
- [How to: Bind Data to the Windows Forms DataGridView Control](how-to-bind-data-to-the-windows-forms-datagridview-control.md)
- [Virtual Mode in the Windows Forms DataGridView Control](virtual-mode-in-the-windows-forms-datagridview-control.md)
- [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](implementing-virtual-mode-wf-datagridview-control.md)
