---
title: "Three Categories of Graphics Services"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "imaging"
  - "graphics [Windows Forms], categories"
  - "2D vector graphics"
  - "vector graphics"
  - "typography"
ms.assetid: 068c0ef3-f6ee-4d58-a7b6-eb2531ead408
---
# Three Categories of Graphics Services
The graphics offerings in Windows Forms fall into the following three broad categories:  
  
- Two-dimensional (2-D) vector graphics  
  
- Imaging  
  
- Typography  
  
## 2D Vector Graphics  
 Two-dimensional vector graphics, such as lines, curves, and figures, are primitives that are specified by sets of points on a coordinate system. For example, a straight line is specified by its two endpoints, and a rectangle is specified by a point giving the location of its upper-left corner and a pair of numbers giving its width and height. A simple path is specified by an array of points that are connected by straight lines. A Bézier spline is a sophisticated curve specified by four control points.  
  
 GDI+ provides classes and structures that store information about the primitives themselves, classes that store information about how the primitives will be drawn, and classes that actually do the drawing. For example, the <xref:System.Drawing.Rectangle> structure stores the location and size of a rectangle; the <xref:System.Drawing.Pen> class stores information about line color, line width, and line style; and the <xref:System.Drawing.Graphics> class has methods for drawing lines, rectangles, paths, and other figures. There are also several <xref:System.Drawing.Brush> classes that store information about how closed figures and paths will be filled with colors or patterns.  
  
 You can record a vector image, which is a sequence of graphics commands, in a metafile. GDI+ provides the <xref:System.Drawing.Imaging.Metafile> class for recording, displaying, and saving metafiles. With the <xref:System.Drawing.Imaging.MetafileHeader> and <xref:System.Drawing.Imaging.MetaHeader> classes, you can inspect the data stored in a metafile header.  
  
## Imaging  
 Certain kinds of pictures are difficult or impossible to display with the techniques of vector graphics. For example, the pictures on toolbar buttons and the pictures that appear as icons are difficult to specify as collections of lines and curves. A high-resolution digital photograph of a crowded baseball stadium is even more difficult to create with vector techniques. Images of this type are stored as bitmaps, which are arrays of numbers that represent the colors of individual dots on the screen. GDI+ provides the <xref:System.Drawing.Bitmap> class for displaying, manipulating, and saving bitmaps.  
  
## Typography  
 Typography is the display of text in a variety of fonts, sizes, and styles. GDI+ provides extensive support for this complex task. One of the new features in GDI+ is subpixel antialiasing, which gives text rendered on an LCD screen a smoother appearance.  
  
 In addition, Windows Forms offers the option to draw text with GDI capabilities in its <xref:System.Windows.Forms.TextRenderer> class.  
  
## See also

- [Graphics Overview](graphics-overview-windows-forms.md)
- [About GDI+ Managed Code](about-gdi-managed-code.md)
- [Using Managed Graphics Classes](using-managed-graphics-classes.md)
