---
title: "PrintDocument Component Overview"
ms.date: "03/30/2017"
f1_keywords:
  - "PrintDocument"
helpviewer_keywords:
  - "PrintDocument component [Windows Forms], about PrintDocument component"
  - "printing [Windows Forms], PrintDocument component"
ms.assetid: b59b4b60-dce5-42ca-8421-3a54a2f7bab0
---
# PrintDocument Component Overview (Windows Forms)

The Windows Forms [PrintDocument](printdocument-component-windows-forms.md) component is used to set the properties that describe what to print and the ability to print the document within Windows-based applications. It can be used in conjunction with the [PrintDialog](printdialog-component-windows-forms.md) component to be in control of all aspects of document printing.

## Working with the PrintDocument Component

Two of the main scenarios that involve the <xref:System.Drawing.Printing.PrintDocument> component are:

- Simple print jobs, such as printing an individual text file. In such a case you would add the <xref:System.Drawing.Printing.PrintDocument> component to a Windows Form, then add programming logic that prints a file in the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event handler. The programming logic should culminate with the <xref:System.Drawing.Printing.PrintDocument.Print%2A> method to print the document. This method sends a <xref:System.Drawing.Graphics> object, contained in the <xref:System.Drawing.Printing.PrintPageEventArgs.Graphics%2A> property of the <xref:System.Drawing.Printing.PrintPageEventArgs> class, to the printer. For an example that shows how to print a text document using the <xref:System.Drawing.Printing.PrintDocument> component, see [How to: Print a Multi-Page Text File in Windows Forms](../advanced/how-to-print-a-multi-page-text-file-in-windows-forms.md).

- More complex print jobs, such as a situation where you will want to reuse printing logic you have written. In such a case you would derive a new component from the <xref:System.Drawing.Printing.PrintDocument> component and override (see [Overrides](../../../visual-basic/language-reference/modifiers/overrides.md) for Visual Basic or [override](../../../csharp/language-reference/keywords/override.md) for C#) the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event.

When it is added to a form, the <xref:System.Drawing.Printing.PrintDocument> component appears in the tray at the bottom of the Windows Forms Designer in Visual Studio.

## See also

- <xref:System.Drawing.Graphics>
- <xref:System.Drawing.Printing.PrintDocument>
- [Windows Forms Print Support](../advanced/windows-forms-print-support.md)
- [PrintDocument Component](printdocument-component-windows-forms.md)
