---
title: "How to: Draw a Line with Line Caps"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "drawing [Windows Forms], lines"
  - "lines [Windows Forms], drawing"
  - "pens [Windows Forms], drawing lines"
  - "drawing lines [Windows Forms], line caps"
ms.assetid: eb68c3e1-c400-4886-8a04-76978a429cb6
---
# How to: Draw a Line with Line Caps
You can draw the start or end of a line in one of several shapes called line caps. GDI+ supports several line caps, such as round, square, diamond, and arrowhead.  
  
## Example  
 You can specify line caps for the start of a line (start cap), the end of a line (end cap), or the dashes of a dashed line (dash cap).  
  
 The following example draws a line with an arrowhead at one end and a round cap at the other end. The illustration shows the resulting line:  
  
 ![Illustration that shows a line with a round cap.](./media/how-to-draw-a-line-with-line-caps/line-cap-arrowhead-example.gif)  
  
 [!code-csharp[System.Drawing.UsingAPen#71](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#71)]
 [!code-vb[System.Drawing.UsingAPen#71](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#71)]  
  
## Compiling the Code  
  
- Create a Windows Form and handle the form's <xref:System.Windows.Forms.Control.Paint> event. Paste the example code into the <xref:System.Windows.Forms.Control.Paint> event handler passing `e` as <xref:System.Windows.Forms.PaintEventArgs>.  
  
## See also

- <xref:System.Drawing.Pen?displayProperty=nameWithType>
- <xref:System.Drawing.Drawing2D.LineCap?displayProperty=nameWithType>
- [Graphics and Drawing in Windows Forms](graphics-and-drawing-in-windows-forms.md)
- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
