---
title: How to display a print dialog
description: Learn how to print from your application using the System.Windows.Controls.PrintDialog class to open a standard Microsoft Windows print dialog box.
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

## Example

The <xref:System.Windows.Controls.PrintDialog> class provides a single control for print configuration and XPS job submission. The control is easy to use and can be instantiated using XAML markup or code. This example creates and displays a `PrintDialog` instance using code.

:::code language="csharp" source="./snippets/how-to-display-print-dialog/csharp/MainWindow.xaml.cs" id="SampleCode":::
:::code language="vb" source="./snippets/how-to-display-print-dialog/vb/MainWindow.xaml.vb" id="SampleCode":::

> [!NOTE]
> The <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType> control used for WPF and discussed here, should not be confused with the <xref:System.Windows.Forms.PrintDialog?displayProperty=nameWithType> component of Windows Forms.

Users can use the print dialog to:

- Select from the printers installed on their computer. The **Microsoft XPS Document Writer** option creates an XML Paper Specification (XPS) file.
- Print only a specific range of pages.

You can even use the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A> method to print without opening the print dialog. But for performance reasons, it's better to use the <xref:System.Printing.PrintQueue.AddJob%2A> method, or one of the many <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter>. For more about this, see [Programmatically Print XPS Files](\how-to-print-xps-files.md).
  
## See also

- <xref:System.Windows.Controls.PrintDialog>
- [Documents in WPF](/dotnet/desktop/wpf/advanced/documents-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
- [Printing Overview](printing-overview.md)
- [Microsoft XPS Document Writer](/windows/win32/printdocs/microsoft-xps-document-writer)
