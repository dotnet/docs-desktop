---
title: "How to: Give Your Control a Transparent Background"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "transparent backgrounds [Windows Forms], custom controls"
  - "custom controls [Windows Forms], transparent background"
  - "transparency [Windows Forms], Windows Forms custom controls"
ms.assetid: 32433e63-f4e9-4305-9857-6de3edeb944a
---
# How to: Give Your Control a Transparent Background
In earlier versions of the .NET Framework, controls didn't support setting transparent backcolors without first setting the <xref:System.Windows.Forms.Control.SetStyle%2A> method in the forms's constructor. In the current framework version, the backcolor for most controls can be set to <xref:System.Drawing.Color.Transparent%2A> in the **Properties** window at design time, or in code in the form's constructor.  
  
> [!NOTE]
> Windows Forms controls do not support true transparency. The background of a transparent Windows Forms control is painted by its parent.  
  
> [!NOTE]
> The <xref:System.Windows.Controls.Button> control doesn't support a transparent backcolor even when the <xref:System.Windows.Forms.ButtonBase.BackColor%2A> property is set to <xref:System.Drawing.Color.Transparent%2A>.  
  
### To give your control a transparent backcolor  
  
- In the Properties window, choose the <xref:System.Windows.Forms.ButtonBase.BackColor%2A> property and set it to <xref:System.Drawing.Color.Transparent%2A>  
  
## See also

- <xref:System.Drawing.Color.FromArgb%2A>
- [Developing Custom Windows Forms Controls with the .NET Framework](developing-custom-windows-forms-controls.md)
- [Using Managed Graphics Classes](../advanced/using-managed-graphics-classes.md)
- [How to: Draw Opaque and Semitransparent Lines](../advanced/how-to-draw-opaque-and-semitransparent-lines.md)
