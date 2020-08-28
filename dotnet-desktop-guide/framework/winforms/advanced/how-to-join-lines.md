---
title: "How to: Join Lines"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "miter line join style"
  - "bevel line join style"
  - "line join"
  - "drawing [Windows Forms], joining lines"
  - "GraphicsPath object"
  - "round line join style"
  - "lines [Windows Forms], joining"
  - "graphics [Windows Forms], joining lines"
ms.assetid: 9fc480c2-3c75-4fd1-8ab5-296a99e820e2
---
# How to: Join Lines
A line join is the common area that is formed by two lines whose ends meet or overlap. GDI+ provides three line join styles: miter, bevel, and round. Line join style is a property of the <xref:System.Drawing.Pen> class. When you specify a line join style for a <xref:System.Drawing.Pen> object, that join style will be applied to all the connected lines in any <xref:System.Drawing.Drawing2D.GraphicsPath> object drawn using that pen.  
  
 The following illustration shows the results of the beveled line join example.  
  
 ![Illustration that shows joined lines.](./media/how-to-join-lines/joined-beveled-lines.gif)  
  
## Example  
 You can specify the line join style by using the <xref:System.Drawing.Pen.LineJoin%2A> property of the <xref:System.Drawing.Pen> class. The example demonstrates a beveled line join between a horizontal line and a vertical line. In the following code, the value <xref:System.Drawing.Drawing2D.LineJoin.Bevel> assigned to the <xref:System.Drawing.Pen.LineJoin%2A> property is a member of the <xref:System.Drawing.Drawing2D.LineJoin> enumeration. The other members of the <xref:System.Drawing.Drawing2D.LineJoin> enumeration are <xref:System.Drawing.Drawing2D.LineJoin.Miter> and <xref:System.Drawing.Drawing2D.LineJoin.Round>.  
  
 [!code-csharp[System.Drawing.UsingAPen#31](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingAPen/CS/Class1.cs#31)]
 [!code-vb[System.Drawing.UsingAPen#31](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingAPen/VB/Class1.vb#31)]  
  
## Compiling the Code  
 The preceding example is designed for use with Windows Forms, and it requires <xref:System.Windows.Forms.PaintEventArgs> `e`, which is a parameter of the <xref:System.Windows.Forms.Control.Paint> event handler.  
  
## See also

- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
