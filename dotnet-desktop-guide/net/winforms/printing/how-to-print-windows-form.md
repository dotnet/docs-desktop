---
title: "How to print a Windows Form"
description: Learn how to programmatically print a copy of the current Windows Form by using the CopyFromScreen method.
ms.date: "05/04/2022"
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

# How to print a Form (Windows Forms .NET)

As part of the development process, you typically will want to print a copy of your Windows Form. The following code example shows how to print a copy of the current form by using the <xref:System.Drawing.Graphics.CopyFromScreen%2A> method.

In the following example, a button named **Button1** is added to the form. When the **Button1** button is clicked, it saves the form to an image in memory, and then sends it to the print object.

## Example

:::code language="csharp" source="snippets/how-to-print-windows-form/csharp/Form1.cs":::

:::code language="vb" source="snippets/how-to-print-windows-form/vb/Form1.vb":::

## Robust programming

The following conditions may cause an exception:

- You don't have permission to access the printer.

- There's no printer installed.

## .NET security

To run this code example, you must have permission to access the printer you use with your computer.

## See also

- <xref:System.Drawing.Printing.PrintDocument>
- [How to: Render Images with GDI+](/dotnet/desktop/winforms/advanced/how-to-render-images-with-gdi?view=netframeworkdesktop-4.8&preserve-view=true)
- [How to: Print Graphics in Windows Forms](/dotnet/desktop/winforms/advanced/how-to-print-graphics-in-windows-forms?view=netframeworkdesktop-4.8&preserve-view=true)
