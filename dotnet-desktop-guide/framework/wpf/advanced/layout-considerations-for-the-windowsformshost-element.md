---
title: "Layout Considerations for the WindowsFormsHost Element"
description: Learn about the various layout considerations that should be taken into account when using the WindowsFormsHost element.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Windows Forms [WPF], interoperability with"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "WindowsFormsHost element layout considerations [WPF]"
  - "dynamic layout [WPF interoperability]"
  - "device-independent pixels"
ms.assetid: 3c574597-bbde-440f-95cc-01371f1a5d9d
---
# Layout Considerations for the WindowsFormsHost Element

This topic describes how the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element interacts with the WPF layout system.  
  
 WPF and Windows Forms support different, but similar, logic for sizing and positioning elements on a form or page. When you create a hybrid user interface (UI) that hosts Windows Forms controls in WPF, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element integrates the two layout schemes.  
  
## Differences in Layout Between WPF and Windows Forms  

 WPF uses resolution-independent layout. All WPF layout dimensions are specified using *device-independent pixels*. A device-independent pixel is one ninety-sixth of an inch in size and resolution-independent, so you get similar results regardless of whether you are rendering to a 72-dpi monitor or a 19,200-dpi printer.  
  
 WPF is also based on *dynamic layout*. This means that a UI element arranges itself on a form or page according to its content, its parent layout container, and the available screen size. Dynamic layout facilitates localization by automatically adjusting the size and position of UI elements when the strings they contain change length.  
  
 Layout in Windows Forms is device-dependent and more likely to be static. Typically, Windows Forms controls are positioned absolutely on a form using dimensions specified in hardware pixels. However, Windows Forms does support some dynamic layout features, as summarized in the following table.  
  
|Layout feature|Description|  
|--------------------|-----------------|  
|Autosizing|Some Windows Forms controls resize themselves to display their contents properly. For more information, see [AutoSize Property Overview](/dotnet/framework/winforms/controls/autosize-property-overview).|  
|Anchoring and docking|Windows Forms controls support positioning and sizing based on the parent container. For more information, see <xref:System.Windows.Forms.Control.Anchor%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.Control.Dock%2A?displayProperty=nameWithType>.|  
|Autoscaling|Container controls resize themselves and their children based on the resolution of the output device or the size, in pixels, of the default container font. For more information, see [Automatic Scaling in Windows Forms](/dotnet/framework/winforms/automatic-scaling-in-windows-forms).|  
|Layout containers|The <xref:System.Windows.Forms.FlowLayoutPanel> and <xref:System.Windows.Forms.TableLayoutPanel> controls arrange their child controls and size themselves according to their contents.|  
  
## Layout Limitations  

 In general, Windows Forms controls cannot be scaled and transformed to the extent possible in WPF. The following list describes the known limitations when the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element attempts to integrate its hosted Windows Forms control into the WPF layout system.  
  
- In some cases, Windows Forms controls cannot be resized, or can be sized only to specific dimensions. For example, a Windows Forms <xref:System.Windows.Forms.ComboBox> control supports only a single height, which is defined by the control's font size. In a WPF dynamic layout where elements can stretch vertically, a hosted <xref:System.Windows.Forms.ComboBox> control will not stretch as expected.  
  
- Windows Forms controls cannot be rotated or skewed. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element raises the <xref:System.Windows.Forms.Integration.WindowsFormsHost.LayoutError> event if you apply a skew or rotation transformation. If you do not handle the <xref:System.Windows.Forms.Integration.WindowsFormsHost.LayoutError> event, an <xref:System.InvalidOperationException> is raised.  
  
- In most cases, Windows Forms controls do not support proportional scaling. Although the overall dimensions of the control will scale, child controls and component elements of the control may not resize as expected. This limitation depends on how well each Windows Forms control supports scaling. In addition, you cannot scale Windows Forms controls down to a size of 0 pixels.  
  
- Windows Forms controls support autoscaling, in which the form will automatically resize itself and its controls based on the font size. In a WPF user interface, changing the font size does not resize the entire layout, although individual elements may dynamically resize.  
  
### Z-order  

 In a WPF user interface, you can change the z-order of elements to control overlapping behavior. A hosted Windows Forms control is drawn in a separate HWND, so it is always drawn on top of WPF elements.  
  
 A hosted Windows Forms control is also drawn on top of any <xref:System.Windows.Documents.Adorner> elements.  
  
## Layout Behavior  

 The following sections describe specific aspects of layout behavior when hosting Windows Forms controls in WPF.  
  
### Scaling, Unit Conversion, and Device Independence  

 Whenever the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element performs operations involving WPF and Windows Forms dimensions, two coordinate systems are involved: device-independent pixels for WPF and hardware pixels for Windows Forms. Therefore, you must apply proper unit and scaling conversions to achieve a consistent layout.  
  
 Conversion between the coordinate systems depends on the current device resolution and any layout or rendering transforms applied to the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element or to its ancestors.  
  
 If the output device is 96 dpi and no scaling has been applied to the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, one device-independent pixel is equal to one hardware pixel.  
  
 All other cases require coordinate system scaling. The hosted control is not resized. Instead, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element attempts to scale the hosted control and all of its child controls. Because Windows Forms does not fully support scaling, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element scales to the degree supported by particular controls.  
  
 Override the <xref:System.Windows.Forms.Integration.WindowsFormsHost.ScaleChild%2A> method to provide custom scaling behavior for the hosted Windows Forms control.  
  
 In addition to scaling, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element handles rounding and overflow cases as described in the following table.  
  
|Conversion issue|Description|  
|----------------------|-----------------|  
|Rounding|WPF device-independent pixel dimensions are specified as `double`, and Windows Forms hardware pixel dimensions are specified as `int`. In cases where `double`-based dimensions are converted to `int`-based dimensions, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element uses standard rounding, so that fractional values less than 0.5 are rounded down to 0.|  
|Overflow|When the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element converts from `double` values to `int` values, overflow is possible. Values that are larger than <xref:System.Int32.MaxValue> are set to <xref:System.Int32.MaxValue>.|  
  
### Layout-related Properties  

 Properties that control layout behavior in Windows Forms controls and WPF elements are mapped appropriately by the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element. For more information, see [Windows Forms and WPF Property Mapping](windows-forms-and-wpf-property-mapping.md).  
  
### Layout Changes in the Hosted Control  

 Layout changes in the hosted Windows Forms control are propagated to WPF to trigger layout updates. The <xref:System.Windows.UIElement.InvalidateMeasure%2A> method on <xref:System.Windows.Forms.Integration.WindowsFormsHost> ensures that layout changes in the hosted control cause the WPF layout engine to run.  
  
### Continuously Sized Windows Forms Controls  

 Windows Forms controls that support continuous scaling fully interact with the WPF layout system. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element uses the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> and <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> methods as usual to size and arrange the hosted Windows Forms control.  
  
### Sizing Algorithm  

 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element uses the following procedure to size the hosted control:  
  
1. The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element overrides the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> and <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> methods.  
  
2. To determine the size of the hosted control, the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> method calls the hosted control's <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method with a constraint translated from the constraint passed to the <xref:System.Windows.FrameworkElement.MeasureOverride%2A> method.  
  
3. The <xref:System.Windows.FrameworkElement.ArrangeOverride%2A> method attempts to set the hosted control to the given size constraint.  
  
4. If the hosted control's <xref:System.Windows.Forms.Control.Size%2A> property matches the specified constraint, the hosted control is sized to the constraint.  
  
 If the <xref:System.Windows.Forms.Control.Size%2A> property does not match the specified constraint, the hosted control does not support continuous sizing. For example, the <xref:System.Windows.Forms.MonthCalendar> control allows only discrete sizes. The permitted sizes for this control consist of integers (representing the number of months) for both height and width. In cases such as this, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element behaves as follows:  
  
- If the <xref:System.Windows.Forms.Control.Size%2A> property returns a larger size than the specified constraint, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element clips the hosted control. Height and width are handled separately, so the hosted control may be clipped in either direction.  
  
- If the <xref:System.Windows.Forms.Control.Size%2A> property returns a smaller size than the specified constraint, <xref:System.Windows.Forms.Integration.WindowsFormsHost> accepts this size value and returns the value to the WPF layout system.  
  
## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Walkthrough: Arranging Windows Forms Controls in WPF](walkthrough-arranging-windows-forms-controls-in-wpf.md)
- [Arranging Windows Forms Controls in WPF Sample](https://github.com/microsoft/WPF-Samples/tree/master/Migration%20and%20Interoperability/WpfLayoutHostingWfWithXaml)
- [Windows Forms and WPF Property Mapping](windows-forms-and-wpf-property-mapping.md)
- [Migration and Interoperability](migration-and-interoperability.md)
