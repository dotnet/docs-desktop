---
title: "How to create a simple-bound control on a Form"
description: "Learn about how to create a simple-bound control on a Form in Windows Forms .NET."
ms.date: "06/06/2022"
helpviewer_keywords:
  - "data binding [Windows Forms], simple data binding"
  - "Windows Forms controls, data binding"
ms.custom: devdivchpfy22
---

# Create a simple-bound control (Windows Forms .NET)

With simple data binding, you can display a single data element, such as a column value from a dataset table to a control on a form. You can simple-bind any property of a control to a data value.

## To simple-bind a control

01. [Connect to a data source](/dotnet/framework/data/adonet/connecting-to-a-data-source).

01. In Visual Studio, select the control on the form and display the **Properties** window.

01. Expand the **DataBindings** property.

    The properties that are bound are displayed under the **DataBindings** property. For example, in most controls, the **Text** property is frequently bound.

01. If the property you want to bind isn't one of the commonly bound properties, select the **Ellipsis** button (:::image type="content" source="../media/shared/visual-studio-ellipsis-button.png" alt-text="Screenshot of the Ellipsis button in the Properties window of Visual Studio.":::) in the **Advanced** box to display the **Formatting and Advanced Binding** dialog with a complete list of properties for that control.

01. Select the property you want to bind and select the drop-down arrow under **Binding**. A list of available data sources is displayed.

01. Expand the data source you want to bind to until you find the single data element you want. For example, if you're binding to a column value in a dataset table, expand the name of the dataset, and then expand the table name to display column names.

01. Select the name of an element to bind to.

01. If you're working in the **Formatting and Advanced Binding** dialog, select **OK** to return to the **Properties** window.

01. If you want to bind more properties of the control, repeat steps 3 to 7.

    > [!NOTE]
    > As simple-bound controls show only a single data element, it's typical to include navigation logic in a Windows Form with simple-bound controls.

## To create a bound control and format the displayed data

With Windows Forms data binding, you can format the data displayed in a data-bound control by using the **Formatting and Advanced Binding** dialog.

01. [Connect to a data source](/dotnet/framework/data/adonet/connecting-to-a-data-source).

01. In Visual Studio, select the control on the form and then open the **Properties** window.

01. Expand the **DataBindings** property, and then in the **Advanced** box, select the ellipsis button (:::image type="content" source="../media/shared/visual-studio-ellipsis-button.png" alt-text="The Ellipsis button in the Properties window of Visual Studio.":::) to display the **Formatting and Advanced Binding** dialog, which has a complete list of properties for that control.

01. Select the property you want to bind, and then select the **Binding** arrow.

    A list of available data sources is displayed.

01. Expand the data source you want to bind the property to until you find the single data element you want.

    For example, if you're binding to a column value in a dataset's table, expand the name of the dataset, and then expand the table name to display column names.

01. Select the name of an element to bind to.

01. In the **Format type** box, select the format you want to apply to the data displayed in the control.

    In every case, you can specify the value displayed in the control if the data source contains <xref:System.DBNull>. Otherwise, the options vary slightly, depending on the format type you select. The following table shows the format types and options.

    |Format type|Formatting option|
    |-----------------|-----------------------|
    |No Formatting|No options.|
    |Numeric|Specify number of decimal places by using **Decimal places** up-down control.|
    |Currency|Specify the number of decimal places by using **Decimal places** up-down control.|
    |Date Time|Choose how the date and time should be displayed by selecting one of the items in the **Type** selection box.|
    |Scientific|Specify the number of decimal places by using **Decimal places** up-down control.|
    |Custom|Specify a custom format string.<br /><br /> For more information, see [Formatting Types](/dotnet/standard/base-types/formatting-types). **Note:**  Custom format strings aren't guaranteed to successfully round trip between the data source and bound control. Instead, handle the <xref:System.Windows.Forms.Binding.Parse> or <xref:System.Windows.Forms.Binding.Format> event for the binding and apply custom formatting in the event-handling code.|

01. Select **OK** to close the **Formatting and Advanced Binding** dialog and return to the **Properties** window.

## See also

- <xref:System.Windows.Forms.Binding>
- [Data Binding](overview.md)
- [User Input Validation in Windows Forms](../input-keyboard/validation.md)
