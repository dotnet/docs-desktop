---
title: "How to: Invoke a Print Dialog"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "invoking print dialogs [WPF]"
  - "print dialogs [WPF], invoking"
ms.assetid: e3a2c84c-74fe-45a4-8501-5813f9dbfed2
description: Learn how to provide the ability to print from an application by simply creating and opening a PrintDialog object.
---
# How to: Invoke a Print Dialog

To provide the ability to print from you application, you can simply create and open a <xref:System.Windows.Controls.PrintDialog> object.  
  
## Example  

 The <xref:System.Windows.Controls.PrintDialog> control provides a single entry point for UI, configuration, and XPS job submission. The control is easy to use and can be instantiated by using Extensible Application Markup Language (XAML) markup or code. The following example demonstrates how to instantiate and open the control in code and how to print from it. It also shows how to ensure that the dialog will give the user the option of setting a specific range of pages. The example code assumes that there is a file FixedDocumentSequence.xps in the root of the C: drive.  
  
 [!code-csharp[printdialog#1](~/samples/snippets/csharp/VS_Snippets_Wpf/PrintDialog/CSharp/Window1.xaml.cs#1)]
 [!code-vb[printdialog#1](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PrintDialog/visualbasic/window1.xaml.vb#1)]  
  
 Once the dialog is open, users will be able to select from the printers installed on their computer. They will also have the option of selecting the [Microsoft XPS Document Writer](/windows/win32/printdocs/microsoft-xps-document-writer) to create an XML Paper Specification (XPS) file instead of printing.  
  
> [!NOTE]
> The <xref:System.Windows.Controls.PrintDialog?displayProperty=nameWithType> control of WPF, which is discussed in this topic, should not be confused with the <xref:System.Windows.Forms.PrintDialog?displayProperty=nameWithType> component of Windows Forms.  
  
 Strictly speaking, you can use the <xref:System.Windows.Controls.PrintDialog.PrintDocument%2A> method without ever opening the dialog. In that sense, the control can be used as an unseen printing component. But for performance reasons, it would be better to use either the <xref:System.Printing.PrintQueue.AddJob%2A> method or one of the many <xref:System.Windows.Xps.XpsDocumentWriter.Write%2A> and <xref:System.Windows.Xps.XpsDocumentWriter.WriteAsync%2A> methods of the <xref:System.Windows.Xps.XpsDocumentWriter>. For more about this, see [Programmatically Print XPS Files](how-to-programmatically-print-xps-files.md).  
  
## See also

- <xref:System.Windows.Controls.PrintDialog>
- [Documents in WPF](documents-in-wpf.md)
- [Printing Overview](printing-overview.md)
- [Microsoft XPS Document Writer](/windows/win32/printdocs/microsoft-xps-document-writer)
