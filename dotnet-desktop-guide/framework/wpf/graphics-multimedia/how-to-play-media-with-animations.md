---
title: "How to: Play Media with Animations"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "multimedia [WPF], playback with animations"
  - "playback of media [WPF], with animations"
  - "animation [WPF], media playback with"
  - "media [WPF], playback with animations"
ms.assetid: 8982b7b7-1c6c-4b24-8801-b328862975f5
---
# How to: Play Media with Animations
This example shows how to play media and animations at the same time by using the <xref:System.Windows.Media.MediaTimeline> and <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames> classes in the same <xref:System.Windows.Media.Animation.Storyboard>.  
  
## Example  
 You can use one or more <xref:System.Windows.Media.MediaTimeline> objects in a <xref:System.Windows.Media.Animation.Storyboard> together with other <xref:System.Windows.Media.Animation.Timeline> objects, such as animations.  
  
 The following example sets the <xref:System.Windows.Media.Animation.ParallelTimeline.SlipBehavior%2A> property of the <xref:System.Windows.Media.Animation.Storyboard> to a value of `Slip`, which specifies that the animation does not progress until the media (video in this example) progresses. This functionality might be needed if media playback is delayed because of loading time.  
  
 [!code-xaml[MediaGallery_snippet#MediaTimelinePlusAnimationExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/MediaGallery_snippet/CSharp/MediaTimelinePlusAnimationExample.xaml#mediatimelineplusanimationexamplewholepage)]  
  
## See also

- <xref:System.Windows.Media.MediaTimeline>
- <xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames>
- <xref:System.Windows.Media.Animation.Storyboard>
- <xref:System.Windows.Media.Animation.ParallelTimeline.SlipBehavior%2A>
- [How-to Topics](audio-and-video-how-to-topics.md)
- [Storyboards Overview](storyboards-overview.md)
- [Key-Frame Animations Overview](key-frame-animations-overview.md)
- [Animation Overview](animation-overview.md)
- [Graphics and Multimedia](index.md)
