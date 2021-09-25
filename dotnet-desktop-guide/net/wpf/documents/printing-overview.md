---
title: Printing documents overview
description: Learn about the printing and print system management APIs available with Windows Presentation Foundation (WPF).
ms.date: 09/22/2021
ms.topic: overview
dev_langs: 
- "csharp"
- "vb"
helpviewer_keywords: 
- "print path [WPF], XPS"
- "printers [WPF], XPSDrv-based"
- "printing [WPF]"
- "PrintQueue class PrintServer class [WPF]"
- "XML Paper Specification (XPS) file format"
- "XPS (XML Paper Specification) file format"
- "XPSDrv-based printers"
- "GDI print path [WPF]"
---

# Printing documents overview (WPF .NET)

With Microsoft .NET, application developers using Windows Presentation Foundation (WPF) have a rich set of printing and print system management APIs. The core of this functionality is the XML Paper Specification (XPS) file format and the XPS print path.

## About XPS

XPS is an electronic document format, a spool file format, and a page description language. It's an open document format that uses XML, Open Packaging Conventions, and other industry standards to create cross-platform documents. XPS simplifies the process by which digital documents are created, shared, printed, viewed, and archived. For more on XPS, see [XPS Documents](/windows/desktop/printdocs/documents).

## XPS print path

The [XPS print path](/windows-hardware/drivers/print/windows-print-path-overview) is a Windows feature that redefines how printing is handled in Windows applications. XPS print path can replace:

- Document presentation languages, such as Rich Text Format or Portable Document Format.
- Print spooler formats, such as Windows Metafile or Enhanced Metafile (EMF).
- Page description languages, such as Printer Command Language or PostScript.

As a result, the XPS print path maintains the XPS format from application publication down to final processing in the printer driver or device.

The print spooler for XPS documents supports both the XPS print path and the GDI print path. The XPS print path natively consumes an XPS spool file and requires an XPS printer driver. The XPS print path is built on the [XPS printer driver](/windows-hardware/drivers/print/xpsdrv-printer-driver) (XPSDrv) model.

The benefits of the XPS print path include:

- WYSIWYG print support.
- Native support of advanced color profiles, such as 32 bits per channel, the CMYK color model, named-colors, n-inks, and transparencies and gradients.
- Improved print performance&mdash;XPS features and enhancements are only available to applications that target the XPS print path.
- Industry standard XPS format.

For basic print scenarios, a simple and intuitive API is available with a standard UI for print configuration and job submission. For advanced scenarios, the API supports UI customization or no UI at all, synchronous or asynchronous printing, and batch printing capabilities. Both simple and advanced options provide print support in full or partial trust modes.

XPS was designed with extensibility in mind, so features and capabilities can be added to XPS in a modular manner. Extensibility features include:

- A print schema that supports rapid extension of device capabilities. The public portion of the schema is regularly updated to add desired device capabilities. For more information, see [Extensible architecture](/windows-hardware/drivers/print/extensible-architecture).
- An extensible filter pipeline that XPSDrv drivers use to support both direct and scalable printing of XPS documents. For more information, see [XPSDrv printer drivers](/windows-hardware/drivers/print/xpsdrv-printer-drivers).

### Print path architecture

WPF applications natively support the XPS print path, and can use XPS print APIs to print directly to the XPSDrv driver. If the target print queue of the write operation doesn't have an XPSDrv driver, then the <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter> class will automatically convert content from XPS to GDI format, for the GDI print path.

The following illustration shows the print subsystem and defines the portions provided by Microsoft and independent software and hardware vendors.

![Screenshot showing the XPS print system.](~/framework/wpf/advanced/media/printing-overview/xml-paper-specification-print-system.png)

### Basic XPS printing

WPF has a printing API that supports both basic and advanced printing features. For those applications that don't require extensive print customization or access to the complete XPS feature set, basic print support might suffice. Basic print support is provided through a [PrintDialog](#printdialog) control that requires minimal configuration, has a familiar UI, and supports many XPS features.

#### PrintDialog

The <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType> control provides a single entry point for UI, configuration, and XPS job submission. To learn how to instantiate and use the control, see [How to display a print dialog](how-to-display-print-dialog.md).

### Advanced XPS printing

To access the complete set of XPS features, use the advanced printing API. Several relevant APIs are described in this section, including [PrintTicket](#printticket-and-printcapabilities), [PrintCapabilities](#printticket-and-printcapabilities), [PrintServer](#printserver-and-printqueue), [PrintQueue](#printserver-and-printqueue), and [XpsDocumentWriter](#xpsdocumentwriter). For a complete list of XPS print path APIs, see the <xref:System.Windows.Xps> and <xref:System.Printing> namespaces.

#### PrintTicket and PrintCapabilities

The <xref:System.Printing.PrintTicket> and <xref:System.Printing.PrintCapabilities> classes are the foundation of advanced XPS features. Both objects contain XML formatted structures of print-oriented features that are defined by the print schema. The features include duplexing, collation, two-sided printing, and stapling. A `PrintTicket` instructs a printer how to process a print job. The `PrintCapabilities` class defines the capabilities of a printer. By querying the capabilities of a printer, a `PrintTicket` can be created that takes full advantage of a printer's supported features. Similarly, unsupported features can be avoided.

The following example queries the `PrintCapabilities` of a printer and creates a `PrintTicket` using code.

:::code language="csharp" source="./snippets/printing-overview/csharp/MainWindow.xaml.cs" id="GetPrintTicket":::
:::code language="vb" source="./snippets/printing-overview/vb/MainWindow.xaml.vb" id="GetPrintTicket":::

#### PrintServer and PrintQueue

The <xref:System.Printing.PrintServer> class represents a network print server, and the <xref:System.Printing.PrintQueue> class represents a printer and the output job queue associated with it. Together, these APIs support advanced management of the print jobs for a server. A `PrintServer`, or one of its derived classes, is used to manage a `PrintQueue`.

The following example creates a <xref:System.Printing.LocalPrintServer> and accesses the local computer's <xref:System.Printing.PrintQueueCollection> using code.

:::code language="csharp" source="./snippets/printing-overview/csharp/MainWindow.xaml.cs" id="GetPrintQueues":::
:::code language="vb" source="./snippets/printing-overview/vb/MainWindow.xaml.vb" id="GetPrintQueues":::

#### XpsDocumentWriter

<xref:System.Windows.Xps.XpsDocumentWriter>, with its many <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods, is used to add XPS documents to a <xref:System.Printing.PrintQueue>. For example, the <xref:System.Windows.Xps.XpsDocumentWriter.Write%28System.Windows.Documents.FixedDocumentSequence%2CSystem.Printing.PrintTicket%29> method is used to synchronously add an XPS document with a print ticket to a queue. The <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%28System.Windows.Documents.FixedDocumentSequence%2CSystem.Printing.PrintTicket%29> method is used to asynchronously add an XPS document with a print ticket to a queue.

The following example creates an `XpsDocumentWriter` and adds XPS documents, both synchronously and asynchronously, to a `PrintQueue` using code.

:::code language="csharp" source="./snippets/printing-overview/csharp/MainWindow.xaml.cs" id="PrintXpsDocument":::
:::code language="vb" source="./snippets/printing-overview/vb/MainWindow.xaml.vb" id="PrintXpsDocument":::

## GDI print path

Although WPF applications natively support the XPS print path, they can also output to the GDI print path by calling one of the <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> or <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter> class and selecting the print queue for a non-XpsDrv printer.

For applications that don't require XPS functionality or support, the current GDI print path remains unchanged. For more about the GDI print path and the various XPS conversion options, see [Microsoft XPS document converter (MXDC)](/windows/win32/printdocs/microsoft-xps-document-converter--mxdc-) and [XPSDrv printer drivers](/windows-hardware/drivers/print/xpsdrv-printer-drivers).

## XPSDrv driver model

The XPS print path improves spooler efficiency by using XPS as the native print spool format when printing to an XPS-enabled printer or driver. Unlike EMF, which represents application output as a series of calls into GDI for rendering services, XPS spool format represents the document. So, when XPS spool files are output to an XPS-based printer driver, they don't require further interpretation as the drivers operate directly on data in that format. This capability eliminates the data and color space conversions required for EMF files and GDI-based print drivers.

The simplified spooling process eliminates the need to generate an intermediate spool file, such as an EMF data file, before the document is spooled. With smaller spool file sizes, the XPS print path can reduce network traffic and improve print performance. Compared with their EMF equivalents, XPS spool file sizes are typically reduced when using the XPS print path. Spool file size reduction is done through several mechanisms:

- **Font subsetting**, which only stores the characters used within a document in the XPS file.
- **Advanced graphics support**, which natively supports transparency and gradient primitives to avoid rasterization of XPS content.
- **Identification of common resources**, such as an image of a corporate logo that's used multiple times in a document. Common resources are treated as shared resources and are only loaded once.
- **ZIP compression**, which is used on all XPS documents.

The XPS spool file size might not be reduced if a vector graphic is highly complex, multi-layered, or inefficiently written. Unlike GDI spool files, XPS files embed device fonts and computer-based fonts for screen display purposes, though both kinds of fonts are subsetted and printer drivers can remove device fonts before transmitting the file to the printer.

> [!TIP]
> You can also print XPS files by using <xref:System.Printing.PrintQueue.AddJob%2A?displayProperty=nameWithType> methods. For more information, see [How to print XPS files](how-to-print-xps-files.md).

## See also

- <xref:System.Windows.Controls.PrintDialog>
- <xref:System.Windows.Xps.XpsDocumentWriter>
- <xref:System.Windows.Xps.Packaging.XpsDocument>
- <xref:System.Printing.PrintTicket>
- <xref:System.Printing.PrintCapabilities>
- <xref:System.Printing.PrintServer>
- <xref:System.Printing.PrintQueue>
- [How-to topics](/dotnet/desktop/wpf/advanced/printing-how-to-topics?view=netframeworkdesktop-4.8&preserve-view=true)
- [Documents in WPF](/dotnet/desktop/wpf/advanced/documents-in-wpf?view=netframeworkdesktop-4.8&preserve-view=true)
- [XPS documents](/windows/desktop/printdocs/documents)
- [Document serialization and storage](/dotnet/desktop/wpf/advanced/document-serialization-and-storage?view=netframeworkdesktop-4.8&preserve-view=true)
- [Microsoft XPS document converter (MXDC)](/windows/win32/printdocs/microsoft-xps-document-converter--mxdc-)
