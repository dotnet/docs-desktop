---
title: "Structure of the Graphics Interface"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "GDI+, using managed interface"
  - "graphics [Windows Forms], class structure"
ms.assetid: 010a1e46-656b-40a1-8d5d-87aa05ee1243
---
# Structure of the Graphics Interface
The managed class interface to GDI+ contains about 60 classes, 50 enumerations, and 8 structures. The <xref:System.Drawing.Graphics> class is at the core of GDI+ functionality; it is the class that actually draws lines, curves, figures, images, and text.  
  
## Important Classes  
 Many classes work together with the <xref:System.Drawing.Graphics> class. For example, the <xref:System.Drawing.Graphics.DrawLine%2A> method receives a <xref:System.Drawing.Pen> object, which holds attributes (color, width, dash style, and the like) of the line to be drawn. The <xref:System.Drawing.Graphics.FillRectangle%2A> method can receive a pointer to a <xref:System.Drawing.Drawing2D.LinearGradientBrush> object, which works with the <xref:System.Drawing.Graphics> object to fill a rectangle with a gradually changing color. <xref:System.Drawing.Font> and <xref:System.Drawing.StringFormat> objects influence the way a <xref:System.Drawing.Graphics> object draws text. A <xref:System.Drawing.Drawing2D.Matrix> object stores and manipulates the world transformation of a <xref:System.Drawing.Graphics> object, which is used to rotate, scale, and flip images.  
  
 GDI+ provides several structures (for example, <xref:System.Drawing.Rectangle>, <xref:System.Drawing.Point>, and <xref:System.Drawing.Size>) for organizing graphics data. Also, certain classes serve primarily as structured data types. For example, the <xref:System.Drawing.Imaging.BitmapData> class is a helper for the <xref:System.Drawing.Bitmap> class, and the <xref:System.Drawing.Drawing2D.PathData> class is a helper for the <xref:System.Drawing.Drawing2D.GraphicsPath> class.  
  
 GDI+ defines several enumerations, which are collections of related constants. For example, the <xref:System.Drawing.Drawing2D.LineJoin> enumeration contains the elements <xref:System.Drawing.Drawing2D.LineJoin.Bevel>, <xref:System.Drawing.Drawing2D.LineJoin.Miter>, and <xref:System.Drawing.Drawing2D.LineJoin.Round>, which specify styles that can be used to join two lines.  
  
## See also

- [Graphics Overview](graphics-overview-windows-forms.md)
- [About GDI+ Managed Code](about-gdi-managed-code.md)
- [Using Managed Graphics Classes](using-managed-graphics-classes.md)
