---
title: "How to: Programmatically Print XPS Files"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "printing XPS files programmatically [WPF]"
  - "XPS files [WPF], printing programmatically"
ms.assetid: 0b1c0a3f-b19e-43d6-bcc9-eb3ec4e555ad
---
# How to: Programmatically Print XPS Files

You can use one overload of the <xref:System.Printing.PrintQueue.AddJob%2A> method to print XML Paper Specification (XPS) files without opening a <xref:System.Windows.Controls.PrintDialog> or, in principle, any [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)] at all.

You can also print XPS files using the many <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A?displayProperty=nameWithType> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A?displayProperty=nameWithType> methods. For more information, see [Printing an XPS Document](/previous-versions/dotnet/netframework-3.5/ms771525(v=vs.90)).

Another way of printing XPS is to use the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A?displayProperty=nameWithType> or <xref:System.Windows.Controls.PrintDialog.PrintVisual%2A?displayProperty=nameWithType> methods. See [Invoke a Print Dialog](how-to-invoke-a-print-dialog.md).

## Example

The main steps to using the three-parameter <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> method are as follows. The example below gives details.

1. Determine if the printer is an XPSDrv printer. See [Printing Overview](printing-overview.md) for more about XPSDrv.

2. If the printer is not an XPSDrv printer, set the thread's apartment to single thread.

3. Instantiate a print server and print queue object.

4. Call the method, specifying a job name, the file to be printed, and a <xref:System.Boolean> flag indicating whether or not the printer is an XPSDrv printer.

The example below shows how to batch print all XPS files in a directory. Although the application prompts the user to specify the directory, the three-parameter <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> method does not require a [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)]. It can be used in any code path where you have an XPS file name and path that you can pass to it.

The three-parameter <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> overload of <xref:System.Printing.PrintQueue.AddJob%2A> must run in a single thread apartment whenever the <xref:System.Boolean> parameter is `false`, which it must be when a non-XPSDrv printer is being used. However, the default apartment state for .NET is multiple thread. This default must be reversed since the example assumes a non-XPSDrv printer.

There are two ways to change the default. One way is to simply add the <xref:System.STAThreadAttribute> (that is, "`[System.STAThreadAttribute()]`") just above the first line of the application's `Main` method (usually "`static void Main(string[] args)`"). However, many applications require that the `Main` method have a multi-threaded apartment state, so there is a second method: put the call to <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> in a separate thread whose apartment state is set to <xref:System.Threading.ApartmentState.STA> with <xref:System.Threading.Thread.SetApartmentState%2A>. The example below uses this second technique.

Accordingly, the example begins by instantiating a <xref:System.Threading.Thread> object and passing it a **PrintXPS** method as the <xref:System.Threading.ThreadStart> parameter. (The **PrintXPS** method is defined later in the example.) Next the thread is set to a single thread apartment. The only remaining code of the `Main` method starts the new thread.

The meat of the example is in the `static`**BatchXPSPrinter.PrintXPS** method. After creating a print server and queue, the method prompts the user for a directory containing XPS files. After validating the existence of the directory and the presence of \*.xps files in it, the method adds each such file to the print queue. The example assumes that the printer is non-XPSDrv, so we are passing `false` to the last parameter of <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> method. For this reason, the method will validate the XPS markup in the file before it attempts to convert it to the printer's page description language. If the validation fails, an exception is thrown. The example code will catch the exception, notify the user about it, and then go on to process the next XPS file.

[!code-csharp[BatchPrintXPSFiles#BatchPrintXPSFiles](~/samples/snippets/csharp/VS_Snippets_Wpf/BatchPrintXPSFiles/CSharp/Program.cs#batchprintxpsfiles)]
[!code-vb[BatchPrintXPSFiles#BatchPrintXPSFiles](~/samples/snippets/visualbasic/VS_Snippets_Wpf/BatchPrintXPSFiles/visualbasic/program.vb#batchprintxpsfiles)]

If you are using an XPSDrv printer, then you can set the final parameter to `true`. In that case, since XPS is the printer's page description language, the method will send the file to the printer without validating it or converting it to another page description language. If you are uncertain at design time whether the application will be using an XPSDrv printer, you can modify the application to have it read the <xref:System.Printing.PrintQueue.IsXpsDevice%2A> property and branch according to what it finds.

Since there will initially be few XPSDrv printers available immediately after the release of Windows Vista and Microsoft .NET Framework, you may need to disguise a non-XPSDrv printer as an XPSDrv printer. To do so, add Pipelineconfig.xml to the list of files in the following registry key of the computer running your application:

HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Print\Environments\Windows NT x86\Drivers\Version-3\\*\<PseudoXPSPrinter>*\DependentFiles

where *\<PseudoXPSPrinter>* is any print queue. The machine must then be rebooted.

This disguise will enable you to pass `true` as the final parameter of <xref:System.Printing.PrintQueue.AddJob%28System.String%2CSystem.String%2CSystem.Boolean%29> without causing an exception, but since *\<PseudoXPSPrinter>* is not really an XPSDrv printer, only garbage will print.

> [!NOTE]
> For simplicity, the example above uses the presence of an \*.xps extension as its test that a file is XPS. However, XPS files do not have to have this extension. The [isXPS.exe (isXPS Conformance Tool)](/previous-versions/dotnet/netframework-4.0/aa348104(v=vs.100)) is one way of testing a file for XPS validity.

## See also

- <xref:System.Printing.PrintQueue>
- <xref:System.Printing.PrintQueue.AddJob%2A>
- <xref:System.Threading.ApartmentState>
- <xref:System.STAThreadAttribute>
- [XPS Documents](/windows/desktop/printdocs/documents)
- [Printing an XPS Document](/previous-versions/dotnet/netframework-3.5/ms771525(v=vs.90))
- [Managed and Unmanaged Threading](/previous-versions/dotnet/netframework-4.0/5s8ee185(v=vs.100))
- [isXPS.exe (isXPS Conformance Tool)](/previous-versions/dotnet/netframework-4.0/aa348104(v=vs.100))
- [Documents in WPF](documents-in-wpf.md)
- [Printing Overview](printing-overview.md)
