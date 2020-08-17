---
title: "How to: Tile a Shape with an Image"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "texture brushes [Windows Forms], tiling images with"
  - "images [Windows Forms], filling shapes with"
  - "shapes [Windows Forms], tiling with images"
  - "bitmaps [Windows Forms], filling shapes with"
ms.assetid: 6d407891-6e5c-4495-a546-3da5604e9fb8
---
# How to: Tile a Shape with an Image
Just as tiles can be placed next to each other to cover a floor, rectangular images can be placed next to each other to fill (tile) a shape. To tile the interior of a shape, use a texture brush. When you construct a <xref:System.Drawing.TextureBrush> object, one of the arguments you pass to the constructor is an <xref:System.Drawing.Image> object. When you use the texture brush to paint the interior of a shape, the shape is filled with repeated copies of this image.  
  
 The wrap mode property of the <xref:System.Drawing.TextureBrush> object determines how the image is oriented as it is repeated in a rectangular grid. You can make all the tiles in the grid have the same orientation, or you can make the image flip from one grid position to the next. The flipping can be horizontal, vertical, or both. The following examples demonstrate tiling with different types of flipping.  
  
### To tile an image  
  
- This example uses the following 75×75 image to tile a 200×200 rectangle.  
  
 ![The tile image that shows a red house and a tree.](./media/how-to-tile-a-shape-with-an-image/rectangle-tile-200x200.gif)  
  
- The following illustration shows how the rectangle is tiled with the image. Note that all tiles have the same orientation; there is no flipping.  
  
 ![A rectangle tiled with the image using the same orientation for all tiles.](./media/how-to-tile-a-shape-with-an-image/rectangle-tiled-image-no-flip.gif)  
  
 [!code-csharp[System.Drawing.UsingABrush#31](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingABrush/CS/Class1.cs#31)]
 [!code-vb[System.Drawing.UsingABrush#31](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingABrush/VB/Class1.vb#31)]  
  
### To flip an image horizontally while tiling  
  
- This example uses the same 75×75 image to fill a 200×200 rectangle. The wrap mode is set to flip the image horizontally. The following illustration shows how the rectangle is tiled with the image. Note that as you move from one tile to the next in a given row, the image is flipped horizontally.  
  
 ![A rectangle tiled with the image flipped horizontally.](./media/how-to-tile-a-shape-with-an-image/rectangle-tiled-image-horizontal-flip.gif)  
  
 [!code-csharp[System.Drawing.UsingABrush#32](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingABrush/CS/Class1.cs#32)]
 [!code-vb[System.Drawing.UsingABrush#32](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingABrush/VB/Class1.vb#32)]  
  
### To flip an image vertically while tiling  
  
- This example uses the same 75×75 image to fill a 200×200 rectangle. The wrap mode is set to flip the image vertically.  
  
     [!code-csharp[System.Drawing.UsingABrush#33](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingABrush/CS/Class1.cs#33)]
     [!code-vb[System.Drawing.UsingABrush#33](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingABrush/VB/Class1.vb#33)]  
  
### To flip an image horizontally and vertically while tiling  
  
- This example uses the same 75×75 image to tile a 200×200 rectangle. The wrap mode is set to flip the image both horizontally and vertically. The following illustration shows how the rectangle is tiled by the image. Note that as you move from one tile to the next in a given row, the image is flipped horizontally, and as you move from one tile to the next in a given column, the image is flipped vertically.  
  
 ![A rectangle tiled with the image flipped horizontally and vertically.](./media/how-to-tile-a-shape-with-an-image/rectangle-tiled-image-horizontal-vertical-flip.gif)  
  
 [!code-csharp[System.Drawing.UsingABrush#34](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Drawing.UsingABrush/CS/Class1.cs#34)]
 [!code-vb[System.Drawing.UsingABrush#34](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Drawing.UsingABrush/VB/Class1.vb#34)]  
  
## See also

- [Using a Brush to Fill Shapes](using-a-brush-to-fill-shapes.md)
