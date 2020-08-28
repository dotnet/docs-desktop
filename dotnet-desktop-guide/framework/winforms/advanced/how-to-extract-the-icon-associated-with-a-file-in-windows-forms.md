---
title: "How to: Extract the Icon Associated with a File"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "displaying a file name and its file type icon in a ListView control [Windows Forms]"
  - "file name extension icons [Windows Forms], displaying in a ListView"
  - "extracting icons associated with a file type [Windows Forms]"
ms.assetid: 88e2ad8b-c34f-415a-84f2-dad756b5c928
---
# How to: Extract the Icon Associated with a File in Windows Forms
Many files have embedded icons that provide a visual representation of the associated file type. For example, Microsoft Word documents contain an icon that identifies them as Word documents. When displaying files in a list control or table control, you may want to display the icon representing the file type next to each file name. You can do this easily by using the <xref:System.Drawing.Icon.ExtractAssociatedIcon%2A> method.  
  
## Example  
 The following code example demonstrates how to extract the icon associated with a file and display the file name and its associated icon in a <xref:System.Windows.Forms.ListView> control.  
  
 [!code-csharp[System.Drawing.Icon.ExtractAssociatedIconEx#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.Icon.ExtractAssociatedIconEx/CS/Form1.cs#1)]
 [!code-vb[System.Drawing.Icon.ExtractAssociatedIconEx#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.Icon.ExtractAssociatedIconEx/VB/Form1.vb#1)]  
  
## Compiling the Code  
 To compile the example:  
  
- Paste the preceding code into a Windows Form, and call the `ExtractAssociatedIconExample` method from the form's constructor or <xref:System.Windows.Forms.Form.Load> event-handling method.  
  
     You will need to make sure that your form imports the <xref:System.IO> namespace.  
  
## See also

- [Images, Bitmaps, and Metafiles](images-bitmaps-and-metafiles.md)
- [ListView Control](../controls/listview-control-windows-forms.md)
