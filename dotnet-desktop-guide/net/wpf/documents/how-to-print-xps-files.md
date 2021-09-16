---
title: How to print an XPS file
description: Learn how to print an XPS file from your application by using the System.Printing.PrintQueue.AddJob method.
ms.date: 
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "programmatically print xps files [WPF]"
---

# How to print an XPS file (WPF .NET)

Sometimes you'll want to add a new print job to the print queue without opening a print dialog box. You can use the <xref:System.Printing.PrintQueue.AddJob> method to do that. Here's how.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

In the example, we use the <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> method, one of the several overloads of `AddJob`, to:

- Add a new print job for an XML Paper Specification (XPS) document into the default print queue.
- Name the new job.
- Specify whether or not the XPS document should be validated&mdash;using the `fastCopy` parameter.

When using the `AddJob(String, String, Boolean)` method, the value of `fastCopy` parameter is a key consideration:

- If the `fastCopy` parameter of the `AddJob(String, String, Boolean)` method is set to `true`, then XPS validation is skipped and the print job will spool quickly without page-by-page progress feedback.
- If the `fastCopy` parameter is false, then the thread that calls the `AddJob` method must have a [single-threaded apartment state](/dotnet/api/system.threading.apartmentstate), otherwise an exception will be thrown. For more about this, see the **Remarks** section for <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29>.

> [!TIP]
> To avoid the **Save Output File As** dialog when adding a print job to the default queue, ensure that your default printer is not **Microsoft XPS Document Writer**, **Microsoft Print to PDF**, or other print-to-file option.

## Add a new print job to the queue

This example adds one or more XPS documents to the default queue. The code will:

1. Use [Task.Run](/dotnet/api/system.threading.tasks.task.run) to avoid blocking the UI thread&mdash;since there's no async version of the `AddJob` methods.
1. If the `fastCopy` parameter is false, run `AddJob(String, String, Boolean)` on a new thread with a [single-threaded apartment state](/dotnet/api/system.threading.apartmentstate).
1. Get a reference to the default <xref:System.Printing.PrintQueue> of the <xref:System.Printing.LocalPrintServer>.
1. Call the `AddJob(String, String, Boolean)` method on the reference to the default print queue, passing a job name, the XPS document path, and the `fastCopy` parameter value.

:::code language="csharp" source="./snippets/how-to-print-xps-files/csharp/MainWindow.xaml.cs" id="SampleCode1":::
:::code language="vb" source="./snippets/how-to-print-xps-files/vb/MainWindow.xaml.vb" id="SampleCode1":::

> [!TIP]
> You can also print XPS files using:
>
> - <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A?displayProperty=nameWithType> or <xref:System.Windows.Controls.PrintDialog.PrintVisual%2A?displayProperty=nameWithType> methods.
> - <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A?displayProperty=nameWithType> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A?displayProperty=nameWithType> methods.
>
> For more information, see [How to display a print dialog box](how-to-display-print-dialog.md) and [Printing documents overview](printing-overview.md).
