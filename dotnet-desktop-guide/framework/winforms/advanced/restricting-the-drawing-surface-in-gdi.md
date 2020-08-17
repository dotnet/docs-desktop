---
title: "Restricting the Drawing Surface in GDI+"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "GDI+, clipping"
  - "clipping [Windows Forms], using GDI+"
  - "GDI+, restricting drawing surface"
ms.assetid: 8b5f71d9-d2f0-4540-9c41-740f90fd4c26
---
# Restricting the Drawing Surface in GDI+
Clipping involves restricting drawing to a certain rectangle or region. The following illustration shows the string "Hello" clipped to a heart-shaped region.  
  
 ![Restricted Drawing Surface](./media/aboutgdip02-art30.gif "AboutGdip02_Art30")  
  
## Clipping with Regions  
 Regions can be constructed from paths, and paths can contain the outlines of strings, so you can use outlined text for clipping. The following illustration shows a set of concentric ellipses clipped to the interior of a string of text.  
  
 ![Restricted Drawing Surface](./media/aboutgdip02-art31.gif "AboutGdip02_Art31")  
  
 To draw with clipping, create a <xref:System.Drawing.Graphics> object, set its <xref:System.Drawing.Graphics.Clip%2A> property, and then call the drawing methods of that same <xref:System.Drawing.Graphics> object:  
  
 [!code-csharp[LinesCurvesAndShapes#91](~/samples/snippets/csharp/VS_Snippets_Winforms/LinesCurvesAndShapes/CS/Class1.cs#91)]
 [!code-vb[LinesCurvesAndShapes#91](~/samples/snippets/visualbasic/VS_Snippets_Winforms/LinesCurvesAndShapes/VB/Class1.vb#91)]  
  
## See also

- <xref:System.Drawing.Graphics?displayProperty=nameWithType>
- <xref:System.Drawing.Region?displayProperty=nameWithType>
- [Lines, Curves, and Shapes](lines-curves-and-shapes.md)
- [Using Regions](using-regions.md)
