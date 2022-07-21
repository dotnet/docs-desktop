---
title: "How to: Custom Draw a ToolStrip Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "toolbars [Windows Forms], custom drawing"
  - "drawing [Windows Forms], owner"
  - "ProfessionalColorTable class [Windows Forms], overriding"
  - "examples [Windows Forms], toolbars"
  - "drawing [Windows Forms], custom"
  - "toolbars [Windows Forms], changing colors"
  - "ToolStrip control [Windows Forms], drawing"
  - "ToolStrip control [Windows Forms], changing colors"
  - "custom drawing"
  - "owner drawing"
ms.assetid: 94e7d7bd-a752-441c-b5b3-7acf98881163
description: Learn how to custom draw a ToolStrip control by overriding one of the renderer classes and changing an aspect of the rendering logic.
---
# How to: Custom Draw a ToolStrip Control
The <xref:System.Windows.Forms.ToolStrip> controls have the following associated rendering (painting) classes:  
  
- <xref:System.Windows.Forms.ToolStripSystemRenderer> provides the appearance and style of your operating system.  
  
- <xref:System.Windows.Forms.ToolStripProfessionalRenderer> provides the appearance and style of Microsoft Office.  
  
- <xref:System.Windows.Forms.ToolStripRenderer> is the abstract base class for the other two rendering classes.  
  
 To custom draw (also known as owner draw) a <xref:System.Windows.Forms.ToolStrip>, you can override one of the renderer classes and change an aspect of the rendering logic.  
  
 The following procedures describe various aspects of custom drawing.  
  
## Switch between the provided renderers
  
- Set the <xref:System.Windows.Forms.ToolStrip.RenderMode%2A> property to the <xref:System.Windows.Forms.ToolStripRenderMode> value you want.  
  
     With <xref:System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode>, the static <xref:System.Windows.Forms.ToolStrip.RenderMode%2A> determines the renderer for your application. The other values of <xref:System.Windows.Forms.ToolStripRenderMode> are <xref:System.Windows.Forms.ToolStripRenderMode.Custom>, <xref:System.Windows.Forms.ToolStripRenderMode.Professional>, and <xref:System.Windows.Forms.ToolStripRenderMode.System>.  
  
## Change the Office–style borders
  
- Override <xref:System.Windows.Forms.ToolStripProfessionalRenderer.OnRenderToolStripBorder%2A?displayProperty=nameWithType>, but do not call the base class.  
  
> [!NOTE]
> There is a version of this method for <xref:System.Windows.Forms.ToolStripRenderer>, <xref:System.Windows.Forms.ToolStripSystemRenderer>, and <xref:System.Windows.Forms.ToolStripProfessionalRenderer>.  
  
## Change the ProfessionalColorTable
  
- Override <xref:System.Windows.Forms.ProfessionalColorTable> and change the colors you want.  

  ```csharp
  public partial class Form1 : Form
  {
      public Form1()
      {
          InitializeComponent();
      }
  
      private void Form1_Load(object sender, EventArgs e)
      {
          var colorTable = new MyColorTable();
          toolStrip1.Renderer = new ToolStripProfessionalRenderer(colorTable);
      }
  
      class MyColorTable: ProfessionalColorTable
      {
          public override System.Drawing.Color ButtonPressedGradientBegin => Color.Red;
          public override System.Drawing.Color ButtonPressedGradientMiddle => Color.Blue;
          public override System.Drawing.Color ButtonPressedGradientEnd => Color.Green;
          public override System.Drawing.Color ButtonSelectedGradientBegin => Color.Yellow;
          public override System.Drawing.Color ButtonSelectedGradientMiddle => Color.Orange;
          public override System.Drawing.Color ButtonSelectedGradientEnd => Color.Violet;
      }
  }
  ```

  ```vb
  Public Class Form1
      Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
          Dim colorTable As New MyColorTable
          ToolStrip1.Renderer = New ToolStripProfessionalRenderer(colorTable)
      End Sub
  
      Class MyColorTable
          Inherits ProfessionalColorTable
  
          Public Overrides ReadOnly Property ButtonPressedGradientBegin() As System.Drawing.Color
              Get
                  Return Color.Red
              End Get
          End Property
  
          Public Overrides ReadOnly Property ButtonPressedGradientMiddle() As System.Drawing.Color
              Get
                  Return Color.Blue
              End Get
          End Property
  
          Public Overrides ReadOnly Property ButtonPressedGradientEnd() As System.Drawing.Color
              Get
                  Return Color.Green
              End Get
          End Property
  
          Public Overrides ReadOnly Property ButtonSelectedGradientBegin() As System.Drawing.Color
              Get
                  Return Color.Yellow
              End Get
          End Property
  
          Public Overrides ReadOnly Property ButtonSelectedGradientMiddle() As System.Drawing.Color
              Get
                  Return Color.Orange
              End Get
          End Property
  
          Public Overrides ReadOnly Property ButtonSelectedGradientEnd() As System.Drawing.Color
              Get
                  Return Color.Violet
              End Get
          End Property
      End Class
  End Class
  ```
  
## Change rendering for all ToolStrips
  
1. Use the <xref:System.Windows.Forms.ToolStripManager.RenderMode%2A?displayProperty=nameWithType> property to choose one of the provided renderers.  
  
2. Use <xref:System.Windows.Forms.ToolStripManager.Renderer%2A?displayProperty=nameWithType> to assign a custom renderer.  
  
3. Ensure that <xref:System.Windows.Forms.ToolStrip.RenderMode%2A?displayProperty=nameWithType> is set to the default value of <xref:System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode>.  
  
## Turn off the Office colors
  
- Set <xref:System.Windows.Forms.ToolStripManager.VisualStylesEnabled%2A?displayProperty=nameWithType> to `false`.  
  
## Turn off the Office colors for one ToolStrip
  
- Use code similar to the following code example.  

  ```csharp
  ProfessionalColorTable colorTable = new ProfessionalColorTable();
  colorTable.UseSystemColors = true;
  toolStrip1.Renderer = new ToolStripProfessionalRenderer(colorTable);
  ```
  
  ```vb
  Dim colorTable As New ProfessionalColorTable
  colorTable.UseSystemColors = True
  ToolStrip1.Renderer = new ToolStripProfessionalRenderer(colorTable)
  ```
  
## See also

- <xref:System.Windows.Forms.ToolStripSystemRenderer>
- <xref:System.Windows.Forms.ToolStripProfessionalRenderer>
- <xref:System.Windows.Forms.ToolStripRenderer>
- [Controls with Built-In Owner-Drawing Support](controls-with-built-in-owner-drawing-support.md)
- [How to: Create and Set a Custom Renderer for the ToolStrip Control in Windows Forms](create-and-set-a-custom-renderer-for-the-toolstrip-control-in-wf.md)
- [ToolStrip Control Overview](toolstrip-control-overview-windows-forms.md)
