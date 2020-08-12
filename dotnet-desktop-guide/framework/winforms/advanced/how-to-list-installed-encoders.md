---
title: "How to: List Installed Encoders"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "image codecs [Windows Forms], listing"
  - "image encoders [Windows Forms], listing"
ms.assetid: 49e8e4e9-7a67-42d9-86bf-08821cdc282e
---
# How to: List Installed Encoders
You may want to list the image encoders available on a computer, to determine whether your application can save to a particular image file format. The <xref:System.Drawing.Imaging.ImageCodecInfo> class provides the <xref:System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders%2A> static methods so that you can determine which image encoders are available. <xref:System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders%2A> returns an array of <xref:System.Drawing.Imaging.ImageCodecInfo> objects.  
  
## Example  
 The following code example outputs the list of installed encoders and their property values.  
  
 [!code-csharp[UsingImageEncodersDecoders#1](~/samples/snippets/csharp/VS_Snippets_Winforms/UsingImageEncodersDecoders/CS/Form1.cs#1)]
 [!code-vb[UsingImageEncodersDecoders#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/UsingImageEncodersDecoders/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
- A Windows Forms application.  
  
- A <xref:System.Windows.Forms.PaintEventArgs>, which is a parameter of <xref:System.Windows.Forms.PaintEventHandler>.  
  
## See also

- [How to: List Installed Decoders](how-to-list-installed-decoders.md)
- [Using Image Encoders and Decoders in Managed GDI+](using-image-encoders-and-decoders-in-managed-gdi.md)
