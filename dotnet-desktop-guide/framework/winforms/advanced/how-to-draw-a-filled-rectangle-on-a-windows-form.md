---
title: "How to: Draw a Filled Rectangle on a Windows Form"
description: Learn how to programmatically draw a filled rectangle on a Windows Form. Also learn about compiling your code. 
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
f1_keywords: 
  - "Graphics.FillRectangle"
helpviewer_keywords: 
  - "drawing [Windows Forms], rectangles"
  - "rectangles [Windows Forms], drawing"
  - "drawing rectangles"
ms.assetid: d656a93c-987d-4809-aafd-493fe17450f0
---
# How to: Draw a Filled Rectangle on a Windows Form
This example draws a filled rectangle on a form.  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#2](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#2)]
 [!code-csharp[System.Drawing.ConceptualHowTos#2](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#2)]
 [!code-vb[System.Drawing.ConceptualHowTos#2](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#2)]  
  
## Compiling the Code  
 You cannot call this method in the <xref:System.Windows.Forms.Form.Load> event handler. The drawn content will not be redrawn if the form is resized or obscured by another form. To make your content automatically repaint, you should override the <xref:System.Windows.Forms.Control.OnPaint%2A> method.  
  
## Robust Programming  
 You should always call <xref:System.IDisposable.Dispose%2A> on any objects that consume system resources, such as <xref:System.Drawing.Brush> and <xref:System.Drawing.Graphics> objects.  
  
## See also

- <xref:System.Drawing.Graphics.FillRectangle%2A>
- <xref:System.Windows.Forms.Control.OnPaint%2A>
- [Getting Started with Graphics Programming](getting-started-with-graphics-programming.md)
- [Graphics and Drawing in Windows Forms](graphics-and-drawing-in-windows-forms.md)
- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
- [Brushes and Filled Shapes in GDI+](brushes-and-filled-shapes-in-gdi.md)
