---
title: What's new in WPF for .NET 7
description: Learn about what's new in Windows Presentation Foundation (WPF) for .NET 7.
ms.date: 02/08/2023
ms.topic: conceptual
---

# What's new for .NET 7 (WPF .NET)

This article describes some of the new Windows Presentation Foundation features and enhancements in .NET 7.

## Performance improvements

A lot of the improvements in WPF for .NET 7 were focused around performance, such as:

- Avoid boxing and unboxing where possible.
- Avoid unnecessary object allocations on the heap.
- Reuse instances of <xref:System.Text.StringBuilder> instead of creating new instances.
- Stopped using <xref:System.Text.StringBuilder> when it wasn't necessary.

For a list of notable changes, see [.NET Blog - What’s new for WPF in .NET 7](https://devblogs.microsoft.com/dotnet/wpf-on-dotnet-7).

## Accessibility improvements and fixes

Additional keyboard interactions for controls were added:

- The <xref:System.Windows.Controls.DataGrid> and <xref:System.Windows.Controls.GridView> column widths can be adjusted with <kbd>ALT</kbd> + <kbd>Left/Right Arrow</kbd>.
- When sorting is enabled for the <xref:System.Windows.Controls.DataGrid>, a column can be sorted with <kbd>F3</kbd>.
- Checkable menu items are now correctly announced with an onscreen narrator.

## Bug fixes

While WPF remains fully supported and serviced on .NET Framework, most fixes and all new features only go into .NET, where we have the opportunity to make bigger changes. The WPF community helped address some long-standing bugs in this release:

- [FocusVisualStyle can’t be overwritten globally](https://github.com/dotnet/wpf/issues/1164)
- [CommandParameter invalidates CanExecute](https://github.com/dotnet/wpf/pull/4217)
- [.NET 6 Tooltip behavior change from .NET 5 (bug?)](https://github.com/dotnet/wpf/issues/5703)
- [Comboboxitem tooltip bug](https://github.com/dotnet/wpf/issues/5716)
- [ContextMenu stops working if its owner is removed from the visual tree](https://github.com/dotnet/wpf/issues/5835)
- [Fixes rounding error while glyphrun serialization](https://github.com/dotnet/wpf/issues/6295)

There were more bug fixes provided by the community, many of which are noted on the [.NET Blog](https://devblogs.microsoft.com/dotnet/wpf-on-dotnet-7).

## See also

- [.NET Blog - What’s new for WPF in .NET 7](https://devblogs.microsoft.com/dotnet/wpf-on-dotnet-7)
- [.NET Community Toolkit](/dotnet/communitytoolkit/introduction)
