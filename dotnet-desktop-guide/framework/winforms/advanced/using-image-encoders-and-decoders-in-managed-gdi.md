---
title: "Using Image Encoders and Decoders in Managed GDI+"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "image encoders [Windows Forms], using"
  - "image decoders [Windows Forms], using"
ms.assetid: 0e838ea1-4e7e-4334-b882-ab25df607b8b
---
# Using Image Encoders and Decoders in Managed GDI+
The <xref:System.Drawing> namespace provides the <xref:System.Drawing.Image> and <xref:System.Drawing.Bitmap> classes for storing and manipulating images. By using image encoders in GDI+, you can write images from memory to disk. By using image decoders in GDI+, you can load images from disk into memory. An encoder translates the data in an <xref:System.Drawing.Image> or <xref:System.Drawing.Bitmap> object into a designated disk file format. A decoder translates the data in a disk file to the format required by the <xref:System.Drawing.Image> and <xref:System.Drawing.Bitmap> objects.  
  
 GDI+ has built-in encoders and decoders that support the following file types:  
  
- BMP  
  
- GIF  
  
- JPEG  
  
- PNG  
  
- TIFF  
  
 GDI+ also has built-in decoders that support the following file types:  
  
- WMF  
  
- EMF  
  
- ICON  
  
 The following topics discuss encoders and decoders in more detail:  
  
## In This Section  
 [How to: List Installed Encoders](how-to-list-installed-encoders.md)  
 Describes how to list the encoders available on a computer.  
  
 [How to: List Installed Decoders](how-to-list-installed-decoders.md)  
 Describes how to list the decoders available on a computer.  
  
 [How to: Determine the Parameters Supported by an Encoder](how-to-determine-the-parameters-supported-by-an-encoder.md)  
 Describes how to list the <xref:System.Drawing.Imaging.EncoderParameters> supported by an encoder.  
  
 [How to: Convert a BMP image to a PNG image](how-to-convert-a-bmp-image-to-a-png-image.md)  
 Describes how to save a image in a different image format.  
  
 [How to: Set JPEG Compression Level](how-to-set-jpeg-compression-level.md)  
 Describes how to change the quality level of an image.  
  
## Reference  
 <xref:System.Drawing.Image>  
  
 <xref:System.Drawing.Bitmap>  
  
 <xref:System.Drawing.Imaging.ImageCodecInfo>  
  
 <xref:System.Drawing.Imaging.EncoderParameter>  
  
 <xref:System.Drawing.Imaging.Encoder>  
  
## Related Sections  
 [About GDI+ Managed Code](about-gdi-managed-code.md)  
  
 [Images, Bitmaps, and Metafiles](images-bitmaps-and-metafiles.md)
