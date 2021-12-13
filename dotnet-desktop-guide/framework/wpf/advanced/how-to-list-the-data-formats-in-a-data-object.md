---
title: How to List the Data Formats in a Data Object
description: Shows how to list the Data Formats in a Data Object
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "drag-and-drop [WPF], listing data formats"
  - "DataFormats class [WPF]"
  - "data formats [WPF], listing"
ms.assetid: 18e7ba4b-ccef-4815-ae2d-3a32891010c0
---
# How to: List the Data Formats in a Data Object

The following examples show how to use the <xref:System.Windows.DataObject.GetFormats%2A> method overloads get an array of strings denoting each data format that is available in a data object.  
  
## Example to use GetFormat%2A overload to get both native and auto-convertible data formats  
  
### Description about using GetFormat%2A overload to get both native and auto-convertible data formats
  
 The following example code uses the <xref:System.Windows.DataObject.GetFormats%2A> overload to get an array of strings denoting all data formats available in a data object (both native and auto-convertible).  
  
### Code for getting both native and auto-convertible data formats
  
 [!code-csharp[DragDrop_DragDropMiscCode#_DragDrop_GetAllDataFormats](~/samples/snippets/csharp/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/CSharp/Window1.xaml.cs#_dragdrop_getalldataformats)]
 [!code-vb[DragDrop_DragDropMiscCode#_DragDrop_GetAllDataFormats](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/visualbasic/window1.xaml.vb#_dragdrop_getalldataformats)]  
  
## Example to use GetFormat%2A overload to get only native data formats after filtering auto-convertible data formats
  
### Description about using GetFormat%2A overload to get only native data formats after filtering auto-convertible data formats
  
 The following example code uses the <xref:System.Windows.DataObject.GetFormats%2A> overload to get an array of strings denoting only data formats available in a data object (filters auto-convertible data formats).  
  
### Code for getting only native data formats after filtering auto-convertible data formats

 [!code-csharp[DragDrop_DragDropMiscCode#_DragDrop_GetAllDataFormats_NativeOnly](~/samples/snippets/csharp/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/CSharp/Window1.xaml.cs#_dragdrop_getalldataformats_nativeonly)]
 [!code-vb[DragDrop_DragDropMiscCode#_DragDrop_GetAllDataFormats_NativeOnly](~/samples/snippets/visualbasic/VS_Snippets_Wpf/DragDrop_DragDropMiscCode/visualbasic/window1.xaml.vb#_dragdrop_getalldataformats_nativeonly)]  
  
## See also

- <xref:System.Windows.IDataObject>
- [Drag and Drop Overview](drag-and-drop-overview.md)
