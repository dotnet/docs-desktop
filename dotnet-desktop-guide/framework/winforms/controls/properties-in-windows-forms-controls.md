---
title: Properties of controls
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "custom controls [Windows Forms], properties overview (using code)"
  - "controls [Windows Forms], properties"
  - "properties [Windows Forms]"
ms.assetid: 2785279b-fb57-4937-8f6b-2050e475db6f
---
# Properties in Windows Forms Controls
A Windows Forms control inherits many properties form the base class <xref:System.Windows.Forms.Control?displayProperty=nameWithType>. These include properties such as <xref:System.Windows.Forms.Control.Font%2A>, <xref:System.Windows.Forms.Control.ForeColor%2A>, <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.Bounds%2A>, <xref:System.Windows.Forms.Control.ClientRectangle%2A>, <xref:System.Windows.Forms.Control.DisplayRectangle%2A>, <xref:System.Windows.Forms.Control.Enabled%2A>, <xref:System.Windows.Forms.Control.Focused%2A>, <xref:System.Windows.Forms.Control.Height%2A>, <xref:System.Windows.Forms.Control.Width%2A>, <xref:System.Windows.Forms.Control.Visible%2A>, <xref:System.Windows.Forms.Control.AutoSize%2A>, and many others. For details about inherited properties, see <xref:System.Windows.Forms.Control?displayProperty=nameWithType>.  
  
 You can override inherited properties in your control as well as define new properties.  
  
## In This Section  
 [Defining a Property](defining-a-property-in-windows-forms-controls.md)  
 Shows how to implement a property for a custom control or component and shows how to integrate the property into the design environment.  
  
 [Defining Default Values with the ShouldSerialize and Reset Methods](defining-default-values-with-the-shouldserialize-and-reset-methods.md)  
 Shows how to define default property values for a custom control or component.  
  
 [Property-Changed Events](property-changed-events.md)  
 Describes how to enable property-change notifications when a property value changes.  
  
 [How to: Expose Properties of Constituent Controls](how-to-expose-properties-of-constituent-controls.md)  
 Shows how to expose properties of constituent controls in a custom composite control.  
  
 [Method Implementation in Custom Controls](method-implementation-in-custom-controls.md)  
 Describes how to implement methods in custom controls and components.  
  
## Reference  
 <xref:System.Windows.Forms.UserControl>  
 Documents the base class for implementing composite controls.  
  
 <xref:System.ComponentModel.TypeConverterAttribute>  
 Documents the attribute that specifies the <xref:System.ComponentModel.TypeConverter> to use for a custom property type.  
  
 <xref:System.ComponentModel.EditorAttribute>  
 Documents the attribute that specifies the <xref:System.Drawing.Design.UITypeEditor> to use for a custom property.  
  
## Related Sections  
 [Attributes in Windows Forms Controls](attributes-in-windows-forms-controls.md)  
 Describes the attributes you can apply to properties or other members of your custom controls and components.  
  
 [Design-Time Attributes for Components](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/tk67c2t8(v=vs.120))  
 Lists metadata attributes to apply to components and controls so that they are displayed correctly at design time in visual designers.  
  
 [Extending Design-Time Support](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/37899azc(v=vs.120))  
 Describes how to implement classes such as editors and designers that provide design-time support.
