---
title: "How to print a Windows Form"
description: Learn how to programmatically print a copy of the current Windows Form by using the CopyFromScreen method.
ms.date: "05/04/2022"
ms.service: dotnet-desktop
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Windows Forms, printing"
  - "printing [Windows Forms]"
  - "printing a form"
  - "printing [Windows Forms], printing a form"
ms.custom: devdivchpfy22
---

# How to print a Form

In the course of designing an app, you might design a form in such a way that it represents a printed page. The following code example shows how to print a copy of the current form by using the <xref:System.Drawing.Graphics.CopyFromScreen%2A> method.

## Example

To run the example code, add two components to a form with the following settings:

> [!div class="mx-tableNormal"]
>
> | Object            | Property\Event | Value            |
> |-------------------|----------------|------------------|
> | **Button**        | `Name`         | `Button1`        |
> |                   | `Click`        | `Button1_Click`  |
> | **PrintDocument** | `Name`         | `PrintDocument1` |
> |                   | `PrintPage`    | `PrintDocument1_PrintPage` |

The following code is run when the `Button1` is clicked. The code creates a `Graphics` object from the form and saves its contents to a `Bitmap` variable named `memoryImage`. The <xref:System.Drawing.Printing.PrintDocument.Print%2A?displayProperty=nameWithType> method is called, which invokes the <xref:System.Drawing.Printing.PrintDocument.PrintPage> event. The print event handler draws the `memoryImage` bitmap on the printer page's `Graphics` object. When the print event handler code returns, the page is printed.

:::code language="csharp" source="snippets/how-to-print-windows-form/csharp/Form1.cs":::

:::code language="vb" source="snippets/how-to-print-windows-form/vb/Form1.vb":::

## Robust programming

The following conditions cause an exception:

- You don't have permission to access the printer.
- There's no printer installed.

## .NET security

To run this code example, you must have permission to access the printer you use with your computer.

## See also

- <xref:System.Drawing.Printing.PrintDocument>
- [How to: Render Images with GDI+](../advanced/how-to-render-images-with-gdi.md)
- [How to: Print Graphics in Windows Forms](../advanced/how-to-print-graphics-in-windows-forms.md)
