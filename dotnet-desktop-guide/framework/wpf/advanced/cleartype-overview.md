---
title: "ClearType Overview"
description: Learn about Microsoft ClearType technology in Windows Presentation Foundation (WPF).
ms.date: "03/30/2017"
helpviewer_keywords:
  - "typography [WPF], ClearType technology"
  - "ClearType [WPF], technology"
ms.assetid: 7e2392e0-75dc-463d-a716-908772782431
---
# ClearType overview

This article provides an overview of the Microsoft ClearType technology found in Windows Presentation Foundation (WPF).

## Technology Overview

 [ClearType](/typography/cleartype/) is a software technology developed by Microsoft that improves the readability of text on existing LCDs (Liquid Crystal Displays), such as laptop screens, Pocket PC screens, and flat panel monitors. ClearType works by accessing the individual vertical color stripe elements in every pixel of an LCD screen. Before ClearType, the smallest level of detail that a computer could display was a single pixel, but with ClearType running on an LCD monitor, it can display features of text as small as a fraction of a pixel in width. The extra resolution increases the sharpness of the tiny details in text display, making it much easier to read over long durations.

 The ClearType available in Windows Presentation Foundation (WPF) is the latest generation of ClearType, which has several improvements over the version found in Microsoft Windows Graphics Device Interface (GDI).

## Sub-pixel Positioning

 A significant improvement over the previous version of ClearType is the use of sub-pixel positioning. Unlike the ClearType implementation found in GDI, the ClearType found in Windows Presentation Foundation (WPF) allows glyphs to start within the pixel and not just the beginning boundary of the pixel. Because of this extra resolution in positioning glyphs, the spacing and proportions of the glyphs is more precise and consistent.

 The following two examples show how glyphs may begin on any sub-pixel boundary when sub-pixel positioning is used. The example on the left is rendered using the earlier version of the ClearType renderer, which did not employ sub-pixel positioning. The example on the right is rendered using the new version of the ClearType renderer, using sub-pixel positioning. Note how each **e** and **l** in the right-hand image is rendered slightly differently because each starts on a different sub-pixel. When viewing the text at its normal size on the screen, this difference is not noticeable because of the high contrast of the glyph image. This is only possible because of sophisticated color filtering that is incorporated in ClearType.

 ![Text displayed with two versions of ClearType](./media/wcpsdk-mmgraphics-text-cleartype-overview-01.png "wcpsdk_mmgraphics_text_cleartype_overview_01")
Text displayed with earlier and later versions of ClearType

 The following two examples compare output from the earlier ClearType renderer with the new version of the ClearType renderer. The subpixel positioning, shown on the right, greatly improves the spacing of type on screen, especially at small sizes where the difference between a sub-pixel and a whole pixel represents a significant proportion of glyph width. Note that spacing between the letters is more even in the second image. The cumulative benefit of sub-pixel positioning to the overall appearance of a screen of text is greatly increased, and represents a significant evolution in ClearType technology.

 ![Text displayed with earlier version of ClearType](./media/wcpsdk-mmgraphics-text-cleartype-overview-02.png "wcpsdk_mmgraphics_text_cleartype_overview_02")
Text with earlier and later versions of ClearType

<a name="y-direction_antialiasing"></a>

## Y-Direction Antialiasing

 Another improvement of ClearType in Windows Presentation Foundation (WPF) is y-direction anti-aliasing. The ClearType in GDI without y-direction anti-aliasing provides better resolution on the x-axis but not the y-axis. On the tops and bottoms of shallow curves, the jagged edges detract from its readability.

 The following example shows the effect of having no y-direction antialiasing. In this case, the jagged edges on the top and bottom of the letter are apparent.

 ![Text with jagged edges on shallow curves](./media/wcpsdk-mmgraphics-text-cleartype-overview-03.png "wcpsdk_mmgraphics_text_cleartype_overview_03")
Text with jagged edges on shallow curves

 ClearType in Windows Presentation Foundation (WPF) provides antialiasing on the y-direction level to smooth out any jagged edges. This is particularly important for improving the readability of East Asian languages where ideographs have an almost equal amount of horizontal and vertical shallow curves.

 The following example shows the effect of y-direction antialiasing. In this case, the top and bottom of the letter show a smooth curve.

 ![Text with ClearType y-direction anti-aliasing](./media/wcpsdk-mmgraphics-text-cleartype-overview-04.png "wcpsdk_mmgraphics_text_cleartype_overview_04")
Text with ClearType y-direction antialiasing

## Hardware Acceleration

 ClearType in Windows Presentation Foundation (WPF) can take advantage of hardware acceleration for better performance and to reduce CPU load and system memory requirements. By using the pixel shaders and video memory of a graphics card, ClearType provides faster rendering of text, particularly when animation is used.

 ClearType in Windows Presentation Foundation (WPF) does not modify the system-wide ClearType settings. Disabling ClearType in Windows sets Windows Presentation Foundation (WPF) antialiasing to grayscale mode.

 One of the Windows Presentation Foundation (WPF) architectural design decisions is to have resolution-independent layout better support higher resolution DPI monitors. This has the consequence of Windows Presentation Foundation (WPF) not supporting aliased text rendering or the bitmaps in some East Asian fonts, because they're both resolution dependent.

## See also

- [ClearType Registry Settings](cleartype-registry-settings.md)
