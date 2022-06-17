---
title: "PrintDialog component overview"
description: "Learn about print related settings in with Windows Forms in .NET, like displaying the PrintDialog and working with print jobs."
ms.date: "04/26/2022"
f1_keywords:
  - "PrintDialog"
helpviewer_keywords:
  - "Print dialog box [Windows Forms], displaying"
  - "PrintDialog component [Windows Forms], about PrintDialog component"
dev_langs:
  - "csharp"
  - "vb"
ms.custom: devdivchpfy22
---

# PrintDialog component overview (Windows Forms .NET)

Printing in Windows Forms consists primarily of using the <xref:System.Drawing.Printing.PrintDocument> component to enable the user to print. The <xref:System.Windows.Forms.PrintPreviewDialog> control, <xref:System.Windows.Forms.PrintDialog> and <xref:System.Windows.Forms.PageSetupDialog> components provide a familiar graphical interface to Windows operating system users.

The `PrintDialog` component is a pre-configured dialog box used to select a printer, choose the pages to print, and determine other print-related settings in Windows-based applications. It's a simple solution for printer and print-related settings instead of configuring your own dialog box. You can enable users to print many parts of their documents: print all, print a selected page range, or print a selection. By relying on standard Windows dialog boxes, you create applications whose basic functionality is immediately familiar to users. The <xref:System.Windows.Forms.PrintDialog> component inherits from the <xref:System.Windows.Forms.CommonDialog> class.

Typically, you create a new instance of the <xref:System.Drawing.Printing.PrintDocument> component and set the properties that describe what to print using the <xref:System.Drawing.Printing.PrinterSettings> and <xref:System.Drawing.Printing.PageSettings> classes. Call to the <xref:System.Drawing.Printing.PrintDocument.Print%2A> method actually prints the document.

## Working with the component

Use the [PrintDialog.ShowDialog](xref:System.Windows.Forms.CommonDialog.ShowDialog%2A) method to display the dialog at run time. This component has properties that relate to either a single print job (<xref:System.Drawing.Printing.PrintDocument> class) or the settings of an individual printer (<xref:System.Drawing.Printing.PrinterSettings> class). One of the two, in turn, may be shared by multiple printers.

The show dialog box method helps you to add print dialog box to the form. The <xref:System.Windows.Forms.PrintDialog> component appears in the tray at the bottom of the Windows Forms Designer in Visual Studio.

## How to capture user input from a PrintDialog at run time

You can set options related to printing at design time. Sometimes you may want to change these options at run time, most likely because of choices made by the user. You can capture user input for printing a document using the <xref:System.Windows.Forms.PrintDialog> and the <xref:System.Drawing.Printing.PrintDocument> components. The following steps demonstrate displaying the print dialog for a document:

01. Add a <xref:System.Windows.Forms.PrintDialog> and a <xref:System.Drawing.Printing.PrintDocument> component to your form.

01. Set the <xref:System.Windows.Forms.PrintDialog.Document%2A> property of the <xref:System.Windows.Forms.PrintDialog> to the <xref:System.Drawing.Printing.PrintDocument> added to the form.

    ```vb
    PrintDialog1.Document = PrintDocument1
    ```

    ```csharp
    printDialog1.Document = printDocument1;
    ```

01. Display the <xref:System.Windows.Forms.PrintDialog> component by using the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method.

    :::code language="vb" source="snippets/overview/vb/Form1.vb" id="show_dialog":::

    :::code language="csharp" source="snippets/overview/csharp/Form1.cs" id="show_dialog":::

01. The user's printing choices from the dialog will be copied to the <xref:System.Drawing.Printing.PrinterSettings> property of the <xref:System.Drawing.Printing.PrintDocument> component.

## How to create print jobs

The foundation of printing in Windows Forms is the <xref:System.Drawing.Printing.PrintDocument> component—more specifically, the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event. By writing code to handle the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event, you can specify what to print and how to print it. The following steps demonstrate creating print job:

01. Add a <xref:System.Drawing.Printing.PrintDocument> component to your form.

01. Write code to handle the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event.

    You'll have to code your own printing logic. Additionally, you'll have to specify the material to be printed.

    As a material to print, in the following code example, a sample graphic in the shape of a red rectangle is created in the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event handler.

    :::code language="vb" source="snippets/overview/vb/Form1.vb" id="specify_the_material_to_be_printed":::

    :::code language="csharp" source="snippets/overview/csharp/Form1.cs" id="specify_the_material_to_be_printed":::

You may also want to write code for the <xref:System.Drawing.Printing.PrintDocument.BeginPrint> and <xref:System.Drawing.Printing.PrintDocument.EndPrint> events. It will help to include an integer representing the total number of pages to print that is decremented as each page prints.

> [!NOTE]
> You can add a <xref:System.Windows.Forms.PrintDialog> component to your form to provide a clean and efficient user interface (UI) to your users. Setting the <xref:System.Windows.Forms.PrintDialog.Document%2A> property of the <xref:System.Windows.Forms.PrintDialog> component enables you to set properties related to the print document you're working with on your form.

For more information about the specifics of Windows Forms print jobs, including how to create a print job programmatically, see <xref:System.Drawing.Printing.PrintPageEventArgs>.

## How to complete print jobs

Frequently, word processors and other applications that involve printing will provide the option to display a message to users that a print job is complete. You can provide this functionality in your Windows Forms by handling the <xref:System.Drawing.Printing.PrintDocument.EndPrint> event of the <xref:System.Drawing.Printing.PrintDocument> component.

The following procedure requires that you've created a Windows-based application with a <xref:System.Drawing.Printing.PrintDocument> component on it. The procedure given below is the standard way of enabling printing from a Windows-based application. For more information about printing from Windows Forms using the <xref:System.Drawing.Printing.PrintDocument> component, see [How to create print jobs](#how-to-create-print-jobs).

01. Set the <xref:System.Drawing.Printing.PrintDocument.DocumentName%2A> property of the <xref:System.Drawing.Printing.PrintDocument> component.

    ```vb
    PrintDocument1.DocumentName = "SamplePrintApp"
    ```

    ```csharp
    printDocument1.DocumentName = "SamplePrintApp";
    ```

01. Write code to handle the <xref:System.Drawing.Printing.PrintDocument.EndPrint> event.

    In the following code example, a message box is displayed, indicating that the document has finished printing.

    :::code language="vb" source="snippets/overview/vb/Form1.vb" id="message_box_indicating_document_has_finished_printing":::
  
    :::code language="csharp" source="snippets/overview/csharp/Form1.cs" id="message_box_indicating_document_has_finished_printing":::
