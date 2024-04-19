---
title: "Automatic form scaling"
description: "A look into how Windows Forms for .NET handles scaling the UI."
ms.date: 10/26/2020
ms.topic: overview
helpviewer_keywords:
  - "scalability [Windows Forms], automatic in Windows Forms"
  - "Windows Forms, automatic scaling"
---

# Automatic scaling (Windows Forms .NET)

Automatic scaling enables a form and its controls, designed on one machine with a certain display resolution or font, to be displayed appropriately on another machine with a different display resolution or font. It assures that the form and its controls will intelligently resize to be consistent with native windows and other applications on both the users' and other developers' machines. Automatic scaling and visual styles enable Windows Forms applications to maintain a consistent look-and-feel when compared to native Windows applications on each user's machine.

For the most part, automatic scaling works as expected in Windows Forms. However, font scheme changes can be problematic.<!-- TODO For an example of how to resolve this, see [How to: Respond to Font Scheme Changes in a Windows Forms Application](how-to-respond-to-font-scheme-changes-in-a-windows-forms-application.md). -->

## Need for automatic scaling

Without automatic scaling, an application designed for one display resolution or font will either appear too small or too large when that resolution or font is changed. For example, if the application is designed using Tahoma 9 point as a baseline, without adjustment it will appear too small if run on a machine where the system font is Tahoma 12 point. Text elements, such as titles, menus, text box contents, and so on will render smaller than other applications. Furthermore, the size of user interface (UI) elements that contain text, such as the title bar, menus, and many controls are dependent on the font used. In this example, these elements will also appear relatively smaller.

An analogous situation occurs when an application is designed for a certain display resolution. The most common display resolution is 96 dots per inch (DPI), which equals 100% display scaling, but higher resolution displays supporting 125%, 150%, 200% (which respectively equal 120, 144 and 192 DPI) and above are becoming more common. Without adjustment, an application, especially a graphics-based one, designed for one resolution will appear either too large or too small when run at another resolution.

Automatic scaling seeks to address these problems by automatically resizing the form and its child controls according to the relative font size or display resolution. The Windows operating system supports automatic scaling of dialog boxes using a relative unit of measurement called dialog units. A dialog unit is based on the system font and its relationship to pixels can be determined though the Win32 SDK function `GetDialogBaseUnits`. When a user changes the theme used by Windows, all dialog boxes are automatically adjusted accordingly. In addition, Windows Forms supports automatic scaling either according to the default system font or the display resolution. Optionally, automatic scaling can be disabled in an application.

> [!CAUTION]
> Arbitrary mixtures of DPI and font scaling modes are not supported. Although you may scale a user control using one mode (for example, DPI) and place it on a form using another mode (Font) with no issues, but mixing a base form in one mode and a derived form in another can lead to unexpected results.

## Automatic scaling in action

Windows Forms uses the following logic to automatically scale forms and their contents:

01. At design time, each <xref:System.Windows.Forms.ContainerControl> records the scaling mode and it current resolution in the <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>, respectively.

01. At run time, the actual resolution is stored in the <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> property. The <xref:System.Windows.Forms.ContainerControl.AutoScaleFactor%2A> property dynamically calculates the ratio between the run-time and design-time scaling resolution.

01. When the form loads, if the values of <xref:System.Windows.Forms.ContainerControl.CurrentAutoScaleDimensions%2A> and <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> are different, then the <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> method is called to scale the control and its children. This method suspends layout and calls the <xref:System.Windows.Forms.Control.Scale%2A> method to perform the actual scaling. Afterwards, the value of <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> is updated to avoid progressive scaling.

01. <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A> is also automatically invoked in the following situations:

    - In response to the <xref:System.Windows.Forms.Control.OnFontChanged%2A> event if the scaling mode is <xref:System.Windows.Forms.AutoScaleMode.Font>.

    - When the layout of the container control resumes and a change is detected in the <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A> or <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A> properties.

    - As implied above, when a parent <xref:System.Windows.Forms.ContainerControl> is being scaled. Each container control is responsible for scaling its children using its own scaling factors and not the one from its parent container.

01. Child controls can modify their scaling behavior through several means:

    - The <xref:System.Windows.Forms.Control.ScaleChildren%2A> property can be overridden to determine if their child controls should be scaled or not.

    - The <xref:System.Windows.Forms.Control.GetScaledBounds%2A> method can be overridden to adjust the bounds that the control is scaled to, but not the scaling logic.

    - The <xref:System.Windows.Forms.Control.ScaleControl%2A> method can be overridden to change the scaling logic for the current control.

## See also

- <xref:System.Windows.Forms.ContainerControl.AutoScaleMode%2A>
- <xref:System.Windows.Forms.Control.Scale%2A>
- <xref:System.Windows.Forms.ContainerControl.PerformAutoScale%2A>
- <xref:System.Windows.Forms.ContainerControl.AutoScaleDimensions%2A>

<!-- TODO
- [Rendering Controls with Visual Styles](controls/rendering-controls-with-visual-styles.md)
- [How to: Improve Performance by Avoiding Automatic Scaling](advanced/how-to-improve-performance-by-avoiding-automatic-scaling.md)-->
