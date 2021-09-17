---
title: How to print an XML Paper Specification (XPS) file
description: Learn how to print an XPS file from your application by using the System.Printing.PrintQueue.AddJob method.
ms.date: 09/16/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "programmatically print xps files [WPF]"
---

# How to print an XPS file (WPF .NET)

Sometimes you'll want to add a new print job to the print queue without opening a print dialog box. You can use one of the <xref:System.Printing.PrintQueue.AddJob%2A?displayProperty=nameWithType> methods to do that. Here's how.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

In the following example, we use the <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> method, one of the several overloads of `AddJob`, to:

- Add a new print job for an XML Paper Specification (XPS) document into the default print queue.
- Name the new job.
- Specify whether the XPS document should be validated (by using the `fastCopy` parameter).

When using the `AddJob(String, String, Boolean)` method, the value of the `fastCopy` parameter is a key consideration:

- If you set the `fastCopy` parameter to `true`, then XPS validation is skipped and the print job will spool quickly without page-by-page progress feedback.
- If you set the `fastCopy` parameter to `false`, then the thread that calls the `AddJob` method must have a [single-threaded apartment state](xref:System.Threading.ApartmentState), otherwise an exception will be thrown. For more information, see the **Remarks** section for <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29>.

## Add new print jobs to the queue

This example adds one or more XPS documents to the default queue. The code will:

1. Use <xref:System.Threading.Tasks.Task.Run%2A?displayProperty=nameWithType> to avoid blocking the UI thread&mdash;since there's no async version of `AddJob`.
1. If the `fastCopy` parameter value is `false`, run <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> on a thread with [single-threaded apartment state](xref:System.Threading.ApartmentState).
1. Get a reference to the default <xref:System.Printing.PrintQueue> of the <xref:System.Printing.LocalPrintServer>.
1. Call `AddJob(String, String, Boolean)` on the print queue reference, passing in a job name, an XPS document path, and the `fastCopy` parameter.

If the queue isn't paused and the printer is working, then a print job will automatically begin printing when it reaches the top of the print queue.

> [!TIP]
> To avoid the **Save Output File As** dialog when adding a print job to the default queue, ensure that your default printer isn't **Microsoft XPS Document Writer**, **Microsoft Print to PDF**, or other print-to-file options.

:::code language="csharp" source="./snippets/how-to-print-xps-files/csharp/MainWindow.xaml.cs" id="SampleCode1":::
:::code language="vb" source="./snippets/how-to-print-xps-files/vb/MainWindow.xaml.vb" id="SampleCode1":::

> [!TIP]
> You can also print XPS files by using:
>
> - <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A?displayProperty=nameWithType> or <xref:System.Windows.Controls.PrintDialog.PrintVisual%2A?displayProperty=nameWithType> methods.
> - <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A?displayProperty=nameWithType> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A?displayProperty=nameWithType> methods.
>
> For more information, see [How to display a print dialog box](how-to-display-print-dialog.md) and [Printing documents overview](printing-overview.md).

## See also

- <xref:System.Printing.PrintQueue.AddJob%2A?displayProperty=nameWithType>
- [Documents in WPF](/dotnet/desktop/wpf/advanced/documents-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
- [How to display a print dialog box](how-to-display-print-dialog.md)
- [Printing documents overview](printing-overview.md)
