---
title: "How to: Create a Bound Control and Format the Displayed Data"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "data [Windows Forms], formatting"
  - "bound controls [Windows Forms], creating"
  - "bound controls [Windows Forms], formatting data"
ms.assetid: d5a56228-899d-41d9-8af8-87b3f4ec2f94
---
# How to: Create a Bound Control and Format the Displayed Data

With Windows Forms data binding, you can format the data displayed in a data-bound control by using the **Formatting and Advanced Binding** dialog box.

## To bind a control and format the displayed data

1. Connect to a data source. For more information, see [Connecting to a Data Source](../data/adonet/connecting-to-a-data-source.md).

2. In Visual Studio, select the control on the form, and then open the **Properties** window.

3. Expand the **(DataBindings)** property, and then in the **(Advanced)** box, click the ellipsis button (![The Ellipsis button (...) in the Properties window of Visual Studio](./media/how-to-create-a-bound-control-and-format-the-displayed-data/visual-studio-ellipsis-button.png)) to display the **Formatting and Advanced Binding** dialog box, which has a complete list of properties for that control.

4. Select the property you want to bind, and then select the **Binding** arrow.

     A list of available data sources is displayed.

5. Expand the data source you want to bind to until you find the single data element you want.

     For example, if you are binding to a column value in a dataset's table, expand the name of the dataset, and then expand the table name to display column names.

6. Select the name of an element to bind to.

7. In the **Format type** box, select the format you want to apply to the data displayed in the control.

     In every case, you can specify the value displayed in the control if the data source contains <xref:System.DBNull>. Otherwise, the options vary slightly, depending on the format type you choose. The following table shows the format types and options.

    |Format type|Formatting option|
    |-----------------|-----------------------|
    |No Formatting|No options.|
    |Numeric|Specify number of decimal places by using **Decimal places** up-down control.|
    |Currency|Specify number of decimal places by using **Decimal places** up-down control.|
    |Date Time|Select how the date and time should be displayed by selecting one of the items in the **Type** selection box.|
    |Scientific|Specify number of decimal places by using **Decimal places** up-down control.|
    |Custom|Specify a custom format string using.<br /><br /> For more information, see [Formatting Types](../../standard/base-types/formatting-types.md). **Note:**  Custom format strings are not guaranteed to successfully round trip between the data source and bound control. Instead handle the <xref:System.Windows.Forms.Binding.Parse> or <xref:System.Windows.Forms.Binding.Format> event for the binding and apply custom formatting in the event-handling code.|

8. Select **OK** to close the **Formatting and Advanced Binding** dialog box and return to the Properties window.

## See also

- [How to: Create a Simple-Bound Control on a Windows Form](how-to-create-a-simple-bound-control-on-a-windows-form.md)
- [User Input Validation in Windows Forms](user-input-validation-in-windows-forms.md)
- [Windows Forms Data Binding](windows-forms-data-binding.md)
