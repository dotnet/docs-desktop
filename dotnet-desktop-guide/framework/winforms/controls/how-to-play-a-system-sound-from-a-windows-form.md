---
title: "How to: Play a System Sound from a Windows Form"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "sounds [Windows Forms], playing for system events"
  - "playing sounds [Windows Forms], Windows Forms"
  - "system sounds [Windows Forms], playing from Windows Forms"
  - "playing sounds [Windows Forms], system"
  - "SoundPlayer class [Windows Forms], system sounds"
  - "sounds [Windows Forms], playing"
  - "examples [Windows Forms], sounds"
ms.assetid: afb206ff-4824-4804-a8d4-185bf5ad8e7c
---
# How to: Play a System Sound from a Windows Form
The following code example plays the `Exclamation` system sound at run time. For more information about system sounds, see <xref:System.Media.SystemSounds>.  
  
## Example  
  
```vb  
Public Sub PlayExclamation()  
    SystemSounds.Exclamation.Play()  
End Sub  
```  
  
```csharp  
public void playExclamation()  
{  
    SystemSounds.Exclamation.Play();  
}  
```  
  
## Compiling the Code  
 This example requires:  
  
- A reference to the <xref:System.Media?displayProperty=nameWithType> namespace.  
  
## See also

- <xref:System.Media.SoundPlayer>
- <xref:System.Media.SystemSounds>
- [How to: Play a Beep from a Windows Form](how-to-play-a-beep-from-a-windows-form.md)
- [How to: Play a Sound from a Windows Form](how-to-play-a-sound-from-a-windows-form.md)
