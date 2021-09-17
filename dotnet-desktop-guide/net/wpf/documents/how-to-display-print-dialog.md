---
title: How to display a print dialog
description: Learn how to print from your application by using the System.Windows.Controls.PrintDialog class to open a standard Microsoft Windows print dialog box.
ms.date: 08/20/2021
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "invoking print dialogs [WPF]"
  - "print dialogs [WPF], invoking"
---

# How to display a print dialog box (WPF .NET)

Want to print from your application? You can use the <xref:System.Windows.Controls.PrintDialog> class to open a standard Microsoft Windows print dialog box. Here's how.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

> [!NOTE]
> The <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType> control used for WPF and discussed here, should not be confused with the <xref:System.Windows.Forms.PrintDialog?displayProperty=nameWithType> component of Windows Forms.

The <xref:System.Windows.Controls.PrintDialog> class provides a single control for print configuration and print job submission. The control is easy to use and can be instantiated by using XAML markup or code. The following examples create and display a `PrintDialog` instance using code.

You can use the print dialog to configure print options, such as:

- Print only a specific range of pages.
- Select from printers installed on your computer. You can use the **Microsoft XPS Document Writer** option to create these document types:
  - XML Paper Specification (XPS)
  - Open XML Paper Specification (OpenXPS)

## Print the whole document

This example prints all pages of an XPS document. By default, the code will:

1. Open a print dialog window that prompts the user to select a printer and start a print job.
1. Instantiate an <xref:System.Windows.Xps.Packaging.XpsDocument> object with the content of the XPS document.
1. Use the `XpsDocument` object to generate a <xref:System.Windows.Documents.DocumentPaginator> object that holds all pages of the XPS document.
1. Call the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A> method, passing in the `DocumentPaginator` object, to send all pages to the specified printer.

:::code language="csharp" source="./snippets/how-to-display-print-dialog/csharp/MainWindow.xaml.cs" id="SampleCode1":::
:::code language="vb" source="./snippets/how-to-display-print-dialog/vb/MainWindow.xaml.vb" id="SampleCode1":::

## Print a page range

Sometimes you'll only want to print a specific range of pages within an XPS document. To do this, we extend the abstract <xref:System.Windows.Documents.DocumentPaginator> class to add support for page ranges. By default, the code will:

1. Open a print dialog window that prompts the user to select a printer, specify a range of pages, and start a print job.
1. Instantiate an <xref:System.Windows.Xps.Packaging.XpsDocument> object with the content of the XPS document.
1. Use the `XpsDocument` object to generate a default <xref:System.Windows.Documents.DocumentPaginator> object that holds all pages of the XPS document.
1. Create an instance of an extended `DocumentPaginator` class that supports page ranges, passing in the default `DocumentPaginator` object and the <xref:System.Windows.Controls.PrintDialog.PageRange> struct returned by the <xref:System.Windows.Controls.PrintDialog>.
1. Call the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A> method, passing in the instance of the extended `DocumentPaginator` class, to send the specified page range to the specified printer.

:::code language="csharp" source="./snippets/how-to-display-print-dialog/csharp/MainWindow.xaml.cs" id="SampleCode2":::
:::code language="vb" source="./snippets/how-to-display-print-dialog/vb/MainWindow.xaml.vb" id="SampleCode2":::

> [!TIP]
> Although you can use the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A> method to print without opening the print dialog, for performance reasons, it's better to use the <xref:System.Printing.PrintQueue.AddJob%2A> method, or one of the many <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter>. For more about this, see [How to print an XPS file](how-to-print-xps-files.md) and [Printing documents overview](printing-overview.md).

## See also

- <xref:System.Windows.Controls.PrintDialog>
- [Documents in WPF](/dotnet/desktop/wpf/advanced/documents-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
- [How to print an XPS file](how-to-print-xps-files.md)
- [Printing documents overview](printing-overview.md)
- [Microsoft XPS Document Writer](/windows/win32/printdocs/microsoft-xps-document-writer)
