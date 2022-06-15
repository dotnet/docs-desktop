---
title: "How to implement the INotifyPropertyChanged interface"
description: Learn how to implement the INotifyPropertyChanged interface on business objects that are used in Windows Forms .NET data binding. 
ms.date: 06/15/2022
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "INotifyPropertyChanged interface [Windows Forms .NET], implementing"
ms.assetid: eac428af-b43b-46ac-80d9-1a5f88658725
ms.custom: devdivchpfy22
---

# How to implement the INotifyPropertyChanged interface in Windows Forms .NET

The following code example demonstrates how to implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface. Implement the interface on business objects that are used in Windows Forms data binding. When implemented, the interface  communicates to a bound control the property changes on a business object.

:::code language="csharp" source="snippets/how-to-implement-INotifyPropertyChanged-interface/csharp/form3.cs" id="implement_INotifyPropertyChanged_interface":::

:::code language="vb" source="snippets/how-to-implement-INotifyPropertyChanged-interface/vb/form3.vb" id="implement_INotifyPropertyChanged_interface":::
