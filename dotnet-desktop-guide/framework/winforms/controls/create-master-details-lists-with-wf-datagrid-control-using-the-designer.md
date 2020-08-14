---
title: Create Master-Details Lists with DataGrid Control Using the Designer
ms.date: "03/30/2017"
helpviewer_keywords:
  - "master-details lists"
  - "DataGrid control [Windows Forms], master-details lists"
  - "related tables [Windows Forms], displaying in DataGrid control"
ms.assetid: 19438ba2-f687-4417-a2fb-ab1cd69d4ded
---
# How to: Create Master-Details Lists with the Windows Forms DataGrid Control Using the Designer

> [!NOTE]
> The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).

 If your <xref:System.Data.DataSet> contains a series of related tables, you can use two <xref:System.Windows.Forms.DataGrid> controls to display the data in a master-detail format. One <xref:System.Windows.Forms.DataGrid> is designated to be the master grid, and the second is designated to be the details grid. When you select an entry in the master list, all of the related child entries are shown in the details list. For example, if your <xref:System.Data.DataSet> contains a Customers table and a related Orders table, you would specify the Customers table to be the master grid and the Orders table to be the details grid. When a customer is selected from the master grid, all of the orders associated with that customer in the Orders table would be displayed in the details grid.

 The following procedure requires a **Windows Application** project (**File** > **New** > **Project** > **Visual C#** or **Visual Basic** > **Classic Desktop** > **Windows Forms Application**).

## To create a master-details list in the designer

1. Add two <xref:System.Windows.Forms.DataGrid> controls to the form. For more information, see [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md). In Visual Studio 2005, the <xref:System.Windows.Forms.DataGrid> control is not in the **Toolbox** by default. For more information, see [How to: Add Items to the Toolbox](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/ms165355(v=vs.100)).

    > [!NOTE]
    > The following steps are not applicable to Visual Studio 2005, which uses the **Data Sources** window for design-time data binding. For more information, see [Bind controls to data in Visual Studio](/visualstudio/data-tools/bind-controls-to-data-in-visual-studio) and [How to: Display Related Data in a Windows Forms Application](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/57tx3hhe(v=vs.120)).

2. Drag two or more tables from **Server Explorer** to the form.

3. From the **Data** menu, select **Generate DataSet**.

4. Set the relationships between the tables using the XML Designer. For details, see "How to: Create One-to-Many Relationships in XML Schemas and Datasets" on MSDN.

5. Save the relationships by selecting **Save All** from the **File** menu.

6. Configure the <xref:System.Windows.Forms.DataGrid> control that you want to designate the master grid, as follows:

    1. Select the <xref:System.Data.DataSet> from the drop-down list in the <xref:System.Windows.Forms.DataGrid.DataSource%2A> property.

    2. Select the master table (for example, "Customers") from the drop-down list in the <xref:System.Windows.Forms.DataGrid.DataMember%2A> property.

7. Configure the <xref:System.Windows.Forms.DataGrid> control that you want to designate the details grid, as follows:

    1. Select the <xref:System.Data.DataSet> from the drop-down list in the <xref:System.Windows.Forms.DataGrid.DataSource%2A> property.

    2. Select the relationship (for example, "Customers.CustOrd") between the master and detail tables from the drop-down list in the <xref:System.Windows.Forms.DataGrid.DataMember%2A> property. In order to see the relationship, expand the node by clicking on the plus (**+**) sign next to the master table in the drop-down list.

## See also

- [DataGrid Control](datagrid-control-windows-forms.md)
- [DataGrid Control Overview](datagrid-control-overview-windows-forms.md)
- [How to: Bind the Windows Forms DataGrid Control to a Data Source](how-to-bind-the-windows-forms-datagrid-control-to-a-data-source.md)
- [Bind controls to data in Visual Studio](/visualstudio/data-tools/bind-controls-to-data-in-visual-studio)
