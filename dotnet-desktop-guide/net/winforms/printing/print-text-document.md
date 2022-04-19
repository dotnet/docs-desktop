---
title: "How to: Print a Multi-Page Text File"
ms.date: "04/19/2022"
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
# How to: Print a Multi-Page Text File in Windows Forms .NET

It's common for Windows-based applications to print text. The <xref:System.Drawing.Graphics> class provides methods for drawing objects (graphics or text) to a device, such as a screen or printer. The following section describes in detail the process to print text file. This method doesn't support print of word and pdf files.
  
> [!NOTE]
> The <xref:System.Windows.Forms.TextRenderer.DrawText%2A> methods of <xref:System.Windows.Forms.TextRenderer> are not supported for printing. You should always use the <xref:System.Drawing.Graphics.DrawString%2A> methods of <xref:System.Drawing.Graphics>, as shown in the following code example, to draw text for printing purposes.  
  
### To print text  

1. Add a <xref:System.Drawing.Printing.PrintDocument> component and a string to your form.  
  
    :::code language="csharp" source="snippets/print-text-document/csharp/Form1.cs" range="14-15":::

    :::code language="vb" source="snippets/print-text-document/visualbasic/Form1.vb" range="12-13":::
  
2. To print a document, set the <xref:System.Drawing.Printing.PrintDocument.DocumentName%2A> property to the document you wish to print. Then open and read the documents contents to the string you added previously.  
  
    :::code language="csharp" source="snippets/print-text-document/csharp/Form1.cs" range="35-42":::

    :::code language="vb" source="snippets/print-text-document/visualbasic/Form1.vb" range="26-39":::

3. In the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event handler, use the <xref:System.Drawing.Printing.PrintPageEventArgs.Graphics%2A> property of the <xref:System.Drawing.Printing.PrintPageEventArgs> class and the document contents to calculate line length and lines per page. After each page is drawn, check to see if it's the last page, and set the <xref:System.Drawing.Printing.PrintPageEventArgs.HasMorePages%2A> property of the <xref:System.Drawing.Printing.PrintPageEventArgs> accordingly. The <xref:System.Drawing.Printing.PrintDocument.PrintPage> event is raised until <xref:System.Drawing.Printing.PrintPageEventArgs.HasMorePages%2A> is `false`. Also, make sure the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event is associated with its event-handling method.  
  
    In the following code example, the event handler is used to print the contents of the "testPage.txt" file in the same font as is used on the form.  

    :::code language="csharp" source="snippets/print-text-document/csharp/Form1.cs" range="47-67":::

    :::code language="vb" source="snippets/print-text-document/visualbasic/Form1.vb" range="44-65":::
  
4. Call the <xref:System.Drawing.Printing.PrintDocument.Print%2A> method to raise the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event.  
  
    :::code language="csharp" source="snippets/print-text-document/csharp/Form1.cs" range="74":::

    :::code language="vb" source="snippets/print-text-document/visualbasic/Form1.vb" range="71":::
 
## Example  

 :::code language="csharp" source="snippets/print-text-document/csharp/Form1.cs":::

 :::code language="vb" source="snippets/print-text-document/visualbasic/Form1.vb":::

## Compiling the Code  

 This example requires:  
  
- A text file named testPage.txt containing the text to print, located in the root of drive C:\\. Edit the code to print a different file.  
  
- References to the System, System.Windows.Forms, System.Drawing assemblies.  
  
- For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](/dotnet/visual-basic/reference/command-line-compiler/building-from-the-command-line) or [Command-line Building With csc.exe](/dotnet/csharp/language-reference/compiler-options/command-line-building-with-csc-exe). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## See also

- <xref:System.Drawing.Graphics>
- <xref:System.Drawing.Brush>
- [Windows Forms Print Support](../../../framework/winforms/advanced/windows-forms-print-support.md)
