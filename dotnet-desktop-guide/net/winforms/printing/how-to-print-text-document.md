---
title: "How to print multi-page text file"
description: Learn how to print multiple page text file (Windows Forms .NET).
ms.date: "04/29/2022"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "printing [Windows Forms .NET], printing multiple pages"
  - "text [Windows Forms .NET], printing Windows Forms"
  - "Windows Forms .NET, printing text"
  - "printing [Windows Forms .NET], text"
ms.custom: devdivchpfy22
---

# How to print a multi-page text file (Windows Forms .NET)

It's common for Windows-based applications to print text. The <xref:System.Drawing.Graphics> class provides methods for drawing objects (graphics or text) to a device, such as a screen or printer. The following section describes in detail the process to print text file. This method doesn't support printing non-plain text files, such as an Office Word document or a _PDF_ file.

> [!NOTE]
> The <xref:System.Windows.Forms.TextRenderer.DrawText%2A> methods of <xref:System.Windows.Forms.TextRenderer> are not supported for printing. You should always use the <xref:System.Drawing.Graphics.DrawString%2A> methods of <xref:System.Drawing.Graphics>, as shown in the following code example, to draw text for printing purposes.

## To print text

01. Add a <xref:System.Drawing.Printing.PrintDocument> component and a string to your form.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id="add_string_to_your_form":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id="add_string_to_your_form":::

01. To print a document, set the <xref:System.Drawing.Printing.PrintDocument.DocumentName%2A> property to the document you wish to print. Then open and read the document content to the string you added previously.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id="set_DocumentName_and_string":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id="set_DocumentName_and_string":::

01. Select the `PrintDocument` component in the Visual Designer. On the **Properties** pane, select the **Event** filter and then double-click the `PrintPage` event to generate an event handler.

01. In the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event handler, use the <xref:System.Drawing.Printing.PrintPageEventArgs.Graphics%2A> property of the <xref:System.Drawing.Printing.PrintPageEventArgs> class and the document contents to calculate line length and lines per page. After each page is drawn, check if it's the last page, and set the <xref:System.Drawing.Printing.PrintPageEventArgs.HasMorePages%2A> property of the `PrintPageEventArgs` accordingly. The `PrintPage` event is raised until `HasMorePages` is `false`. Also, make sure the `PrintPage` event is associated with its event-handling method.

    In the following code example, the event handler is used to print the contents of the "testPage.txt" file in the same font as it's used on the form.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id="print_contents_using_event_handler":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id="print_contents_using_event_handler":::

01. Call the <xref:System.Drawing.Printing.PrintDocument.Print%2A> method to raise the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id= "call_print_method_to_print_file":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id= "call_print_method_to_print_file":::

## See also

- <xref:System.Drawing.Graphics>
- <xref:System.Drawing.Brush>
- [Windows Forms Print Support](/dotnet/desktop/winforms/advanced/windows-forms-print-support?view=netframeworkdesktop-4.8&preserve-view=true)
