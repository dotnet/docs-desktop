---
title: "How to: Control a MediaElement by Using a Storyboard"
description: Control playback of media using a storyboard in Windows Presentation foundation (WPF). Consider this example for creating a simple media player.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "multimedia [WPF], controlling playback of media with Storyboards"
  - "controlling playback of media [WPF], with Storyboards"
  - "Storyboards [WPF], controlling playback of media with"
  - "media [WPF], controlling playback with Storyboards"
  - "playback of media [WPF], controlling with Storyboards"
ms.assetid: 6128ca77-b826-4e36-b968-6f237157c543
---
# How to: Control a MediaElement by Using a Storyboard

This example shows how to control a <xref:System.Windows.Controls.MediaElement> by using a <xref:System.Windows.Media.MediaTimeline> in a <xref:System.Windows.Media.Animation.Storyboard>.  
  
## Example  

 When you use a <xref:System.Windows.Media.MediaTimeline> in a <xref:System.Windows.Media.Animation.Storyboard> to control the timing of a <xref:System.Windows.Controls.MediaElement>, the functionality is identical to the functionality of other <xref:System.Windows.Media.Animation.Timeline> objects, such as animations. For example, a <xref:System.Windows.Media.MediaTimeline> uses <xref:System.Windows.Media.Animation.Timeline> properties like the <xref:System.Windows.Media.Animation.Timeline.BeginTime%2A> property to specify when to start a <xref:System.Windows.Controls.MediaElement> (start media playback). It also uses the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> property to specify how long the <xref:System.Windows.Controls.MediaElement> is active (duration of media playback). For more information about using <xref:System.Windows.Media.Animation.Timeline> objects with a <xref:System.Windows.Media.Animation.Storyboard>, see [Storyboards Overview](storyboards-overview.md).  
  
 This example shows how to create a simple media player that uses a <xref:System.Windows.Media.MediaTimeline> to control playback. The media player includes play, pause, resume, and stop buttons. The player also has a <xref:System.Windows.Controls.Slider> control that acts as a progress bar.  
  
 The following example creates the user interface (UI) for the media player.  
  
 [!code-xaml[MediaGallery_snip#MediaTimelineExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/MediaGallery_snip/VB/MediaTimelineExample.xaml#mediatimelineexamplewholepage)]  
  
 The following example creates the functionality for the progress bar.  
  
 [!code-csharp[MediaGallery_snip#CodeBehindMediaTimelineExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/MediaGallery_snip/CSharp/MediaTimelineExample.xaml.cs#codebehindmediatimelineexamplewholepage)]
 [!code-vb[MediaGallery_snip#CodeBehindMediaTimelineExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/MediaGallery_snip/VB/MediaTimelineExample.xaml.vb#codebehindmediatimelineexamplewholepage)]  
  
## See also

- <xref:System.Windows.Controls.MediaElement>
- <xref:System.Windows.Media.MediaTimeline>
- <xref:System.Windows.Media.Animation.Storyboard>
- [Control a MediaElement (Play, Pause, Stop, Volume, and Speed)](how-to-control-a-mediaelement-play-pause-stop-volume-and-speed.md)
- [Storyboards Overview](storyboards-overview.md)
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
- [Animation Overview](animation-overview.md)
- [How-to Topics](audio-and-video-how-to-topics.md)
- [Graphics and Multimedia](index.md)
