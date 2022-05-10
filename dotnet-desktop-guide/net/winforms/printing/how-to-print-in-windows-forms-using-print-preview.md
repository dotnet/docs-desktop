---
title: Print Using Print Preview
description: Learn how to add print preview services to your application by using the Windows Forms PrintPreviewDialog control.
ms.date: "05/02/2022"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "printing [Windows Forms], using print preview"
  - "printing [Windows Forms], with print preview"
  - "print preview"
ms.custom: devdivchpfy22
---

# How to print in Windows forms using print preview

It's common in Windows Forms programming to offer print preview in addition to printing services. An easy way to add print preview services to your application is to use a <xref:System.Windows.Forms.PrintPreviewDialog> control in combination with the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event-handling logic for printing a file.

## To preview a text document with a PrintPreviewDialog control

01. Add a <xref:System.Windows.Forms.PrintPreviewDialog> and <xref:System.Drawing.Printing.PrintDocument>.

01. Add two strings to your form.

     :::code language="csharp" source="snippets/how-to-print-in-windows-forms-using-print-preview/csharp/Form1.cs" id="string_declaration":::

     :::code language="vb" source="snippets/how-to-print-in-windows-forms-using-print-preview/vb/Form1.vb" id="string_declaration":::

01. Set the <xref:System.Drawing.Printing.PrintDocument.DocumentName%2A> property to the document you wish to print, and open and read the document's contents to the string you added previously.

     :::code language="csharp" source="snippets/how-to-print-in-windows-forms-using-print-preview/csharp/Form1.cs" id="open_and_read_document_contents_the_string":::

     :::code language="vb" source="snippets/how-to-print-in-windows-forms-using-print-preview/vb/Form1.vb" id="open_and_read_document_contents_the_string":::

01. As you would for printing the document, in the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event handler, use the <xref:System.Drawing.Printing.PrintPageEventArgs.Graphics%2A> property of the <xref:System.Drawing.Printing.PrintPageEventArgs> class and the file contents to calculate lines per page and render the document's contents. After each page is drawn, check to see if it's the last page, and set the <xref:System.Drawing.Printing.PrintPageEventArgs.HasMorePages%2A> property of the `PrintPageEventArgs` accordingly. The `PrintPage` event is raised until `HasMorePages` is `false`. When the document has finished rendering, reset the string to be rendered. Also, ensure that the `PrintPage` event is associated with its event-handling method.

    > [!NOTE]
    > If you have implemented printing in your application, you may have already completed step 2 and 3.

     In the following code example, the event handler is used to print the "testPage.txt" file in the same font used on the form.

     :::code language="csharp" source="snippets/how-to-print-in-windows-forms-using-print-preview/csharp/Form1.cs" id="print_file_using_event_handler":::

     :::code language="vb" source="snippets/how-to-print-in-windows-forms-using-print-preview/vb/Form1.vb" id="print_file_using_event_handler":::

01. Set the <xref:System.Windows.Forms.PrintPreviewDialog.Document%2A> property of the <xref:System.Windows.Forms.PrintPreviewDialog> control to the <xref:System.Drawing.Printing.PrintDocument> component on the form.

     :::code language="csharp" source="snippets/how-to-print-in-windows-forms-using-print-preview/csharp/Form1.cs" id="set_the_document_property":::

     :::code language="vb" source="snippets/how-to-print-in-windows-forms-using-print-preview/vb/Form1.vb" id="set_the_document_property":::

01. Call the <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> method on the <xref:System.Windows.Forms.PrintPreviewDialog> control. Note the highlighted code given below, you would typically call <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> from the <xref:System.Windows.Forms.Control.Click> event-handling method of a button. Calling <xref:System.Windows.Forms.CommonDialog.ShowDialog%2A> raises the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event and renders the output to the <xref:System.Windows.Forms.PrintPreviewDialog> control. When the user selects the print icon on the dialog, the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event is raised again, sending the output to the printer instead of the preview dialog. Hence, the string is reset at the end of the rendering process in step 4.

     The following code example shows the <xref:System.Windows.Forms.Control.Click> event-handling method for a button on the form. This event-handling method calls the methods to read the document and show the print preview dialog.

     :::code language="csharp" source="snippets/how-to-print-in-windows-forms-using-print-preview/csharp/Form1.cs" id="read_document_and_show_print_preview_dialog" highlight="15":::

     :::code language="vb" source="snippets/how-to-print-in-windows-forms-using-print-preview/vb/Form1.vb" id="read_document_and_show_print_preview_dialog" highlight="21":::

## See also

- [How to: Print a Multi-Page Text File in Windows Forms](/dotnet/dotnet/desktop/winforms/advanced/how-to-print-a-multi-page-text-file-in-windows-forms?view=netframeworkdesktop-4.8&preserve-view=true)
- [Windows Forms Print Support](/dotnet/desktop/winforms/advanced/windows-forms-print-support?view=netframeworkdesktop-4.8&preserve-view=true)
- [More Secure Printing in Windows Forms](/desktop/winforms/advanced/more-secure-printing-in-windows-forms?view=netframeworkdesktop-4.8&preserve-view=true)