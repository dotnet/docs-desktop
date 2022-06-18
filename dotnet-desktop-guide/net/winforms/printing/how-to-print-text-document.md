---
title: "How to print multi-page text file"
description: Learn how to print multiple page text file (Windows Forms .NET).
ms.date: "05/04/2022"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "printing [Windows Forms], printing multiple pages"
  - "text [Windows Forms], printing Windows Forms"
  - "Windows Forms, printing text"
  - "printing [Windows Forms], text"
ms.custom: devdivchpfy22
---

# Print a multi-page text file (Windows Forms .NET)

It's common for Windows-based applications to print text. The <xref:System.Drawing.Graphics> class provides methods for drawing objects (graphics or text) to a device, such as a screen or printer. The following section describes in detail the process to print text file. This method doesn't support printing non-plain text files, such as an Office Word document or a _PDF_ file.

> [!NOTE]
> The <xref:System.Windows.Forms.TextRenderer.DrawText%2A> methods of <xref:System.Windows.Forms.TextRenderer> are not supported for printing. You should always use the <xref:System.Drawing.Graphics.DrawString%2A> methods of <xref:System.Drawing.Graphics>, as shown in the following code example, to draw text for printing purposes.

## To print text

01. In Visual Studio, double-click the form you want to print from, in the **Solution Explorer** pane. This opens the Visual Designer.

01. From the **Toolbox**, double-click the <xref:System.Drawing.Printing.PrintDocument> component to add it to the form. This should create a `PrintDocument` component with the name `printDocument1`.

01. Either add a `Button` to the form, or use a button that is already on the form.

01. In the Visual Designer of the form, select the button. In the **Properties** pane, select the **Event** filter button and then double-click the `Click` event to generate an event handler.

01. The `Click` event code should be visible. Outside the scope of the event handler, add a private string variable to the class named `stringToPrint`.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id="add_string_to_your_form":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id="add_string_to_your_form":::

01. Back in the `Click` event handler code, set the <xref:System.Drawing.Printing.PrintDocument.DocumentName%2A> property to the name of the document. This information is sent to the printer. Next, read the document text content and store it in the `stringToPrint` string. Finally, call the <xref:System.Drawing.Printing.PrintDocument.Print%2A> method to raise the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event. The `Print` method is highlighted below.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id="set_DocumentName_and_string" highlight= "11":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id="set_DocumentName_and_string" highlight= "11":::

01. Go back to the Visual Designer of the form and select the `PrintDocument` component. On the **Properties** pane, select the **Event** filter and then double-click the `PrintPage` event to generate an event handler.

01. In the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event handler, use the <xref:System.Drawing.Printing.PrintPageEventArgs.Graphics%2A> property of the <xref:System.Drawing.Printing.PrintPageEventArgs> class and the document contents to calculate line length and lines per page. After each page is drawn, check if it's the last page, and set the <xref:System.Drawing.Printing.PrintPageEventArgs.HasMorePages%2A> property of the `PrintPageEventArgs` accordingly. The `PrintPage` event is raised until `HasMorePages` is `false`.

    In the following code example, the event handler is used to print the contents of the "testPage.txt" file in the same font as it's used on the form.

    :::code language="csharp" source="snippets/how-to-print-text-document/csharp/Form1.cs" id="print_contents_using_event_handler":::

    :::code language="vb" source="snippets/how-to-print-text-document/vb/Form1.vb" id="print_contents_using_event_handler":::

## See also

- <xref:System.Drawing.Graphics>
- <xref:System.Drawing.Brush>
- [PrintDialog component overview](overview.md)
