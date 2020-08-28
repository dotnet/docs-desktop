---
title: "How to: Set the Color of a Pen"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "pens [Windows Forms], setting color"
  - "colored pens"
ms.assetid: a9df06f9-a6d5-4d9b-a2d1-583943540775
---
# How to: Set the Color of a Pen
This example changes the color of a pre-existing <xref:System.Drawing.Pen> object  
  
## Example  
 [!code-cpp[System.Drawing.ConceptualHowTos#9](~/samples/snippets/cpp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/cpp/form1.cpp#9)]
 [!code-csharp[System.Drawing.ConceptualHowTos#9](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/CS/form1.cs#9)]
 [!code-vb[System.Drawing.ConceptualHowTos#9](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.ConceptualHowTos/VB/form1.vb#9)]  
  
## Compiling the Code  
 This example requires:  
  
- A <xref:System.Drawing.Pen> object named `myPen`.  
  
## Robust Programming  
 You should call <xref:System.Drawing.Pen.Dispose%2A> on objects that consume system resources (such as <xref:System.Drawing.Pen> objects) after you are finished using them.  
  
## See also

- <xref:System.Drawing.Pen>
- [Getting Started with Graphics Programming](getting-started-with-graphics-programming.md)
- [How to: Create a Pen](how-to-create-a-pen.md)
- [Using a Pen to Draw Lines and Shapes](using-a-pen-to-draw-lines-and-shapes.md)
- [Pens, Lines, and Rectangles in GDI+](pens-lines-and-rectangles-in-gdi.md)
