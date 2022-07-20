---
title: "Activate Function - WPF unmanaged API reference"
description: Learn about the Activate function of the Windows Presentation Foundation (WPF) unmanaged API reference.
titleSuffix: ""
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "Activate"
api_location:
  - "PresentationHost_v0400.dll"
ms.assetid: 1400329c-b598-465f-80f2-e3dabf044811
---

# Activate Function (WPF Unmanaged API Reference)

This API supports the Windows Presentation Foundation (WPF) infrastructure and is not intended to be used directly from your code.

Used by the Windows Presentation Foundation (WPF) infrastructure for windows management.

## Syntax

```cpp
void Activate(
    const ActivateParameters* pParameters,
    __deref_out_ecount(1) LPUNKNOWN* ppInner,
    );
```

## Parameters

`pParameters`\
A pointer to the window's activation parameters.

`ppInner`\
A pointer to the address of a single-element buffer that contains a pointer to an <xref:Microsoft.VisualStudio.OLE.Interop.IOleDocument> object.

## Requirements

**Platforms:** See [.NET Framework System Requirements](/dotnet/framework/get-started/system-requirements).

**DLL:**

In the .NET Framework 3.0 and 3.5: PresentationHostDLL.dll

In the .NET Framework 4 and later: PresentationHost_v0400.dll

**.NET Framework Version:** Available since 3.0

## See also

- [WPF Unmanaged API Reference](wpf-unmanaged-api-reference.md)
