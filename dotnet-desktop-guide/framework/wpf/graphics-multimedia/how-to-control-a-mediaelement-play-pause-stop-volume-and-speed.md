---
title: "How to: Control a MediaElement (Play, Pause, Stop, Volume, and Speed)"
description: Control playback of media in Windows Presentation foundation (WPF). Start, stop, pause, skip back and forth, and adjust volume and speed.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "playback of media [WPF], controlling"
  - "controlling playback of media [WPF]"
  - "multimedia [WPF], controlling playback of media"
  - "media [WPF], controlling playback of"
ms.assetid: 6885a730-e054-4c16-8c1e-ffe17b1f7c32
---
# How to: Control a MediaElement (Play, Pause, Stop, Volume, and Speed)
The following example shows how to control playback of media using a <xref:System.Windows.Controls.MediaElement>. The example creates a simple media player that allows you to play, pause, stop, and skip back and forth in the media as well as adjust the volume and speed ratio.  
  
## Example  
 The code below creates the UI.  
  
> [!NOTE]
> The <xref:System.Windows.Controls.MediaElement.LoadedBehavior%2A> property of <xref:System.Windows.Controls.MediaElement> must be set to `Manual` in order to be able to interactively stop, pause, and play the media.  
  
 [!code-xaml[MediaGallery_snip#MediaElementExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/MediaGallery_snip/VB/MediaElementExample.xaml#mediaelementexamplewholepage)]  
  
## Example  
 The code below implements the functionality of the sample UI controls. The <xref:System.Windows.Controls.MediaElement.Play%2A>, <xref:System.Windows.Controls.MediaElement.Pause%2A>, and <xref:System.Windows.Controls.MediaElement.Stop%2A> methods are used to respectively play, pause and stop the media. Changing the <xref:System.Windows.Controls.MediaElement.Position%2A> property of the <xref:System.Windows.Controls.MediaElement> allows you to skip around in the media. Finally, the <xref:System.Windows.Controls.MediaElement.Volume%2A> and <xref:System.Windows.Controls.MediaElement.SpeedRatio%2A> properties are used to adjust the volume and playback speed of the media.  
  
 [!code-csharp[MediaGallery_snip#CodeBehindMediaElementExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/MediaGallery_snip/CSharp/MediaElementExample.xaml.cs#codebehindmediaelementexamplewholepage)]
 [!code-vb[MediaGallery_snip#CodeBehindMediaElementExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/MediaGallery_snip/VB/MediaElementExample.xaml.vb#codebehindmediaelementexamplewholepage)]  
  
## See also

- [Control a MediaElement by Using a Storyboard](how-to-control-a-mediaelement-by-using-a-storyboard.md)
