---
title: "Dependency property security"
description: Learn about the dependency property accessibility and security in Windows Presentation Foundation (WPF).
ms.date: "12/03/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "wrappers [WPF], access"
  - "wrappers [WPF], security"
  - "dependency properties [WPF], security"
  - "security [WPF], wrappers"
  - "validation [WPF], dependency properties"
  - "dependency properties [WPF], access"
  - "security [WPF], dependency properties"
---
<!-- The acrolinx score was 92 on 12/03/2021-->

# Dependency property security (WPF .NET)

The accessibility of read-write dependency properties through the Windows Presentation Foundation (WPF) property system effectively makes them public properties. As a result, it's not possible to make security guarantees about read-write dependency property values. The WPF property system provides more security for read-only dependency properties so that you can restrict write access.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Access and security of property wrappers

A common language runtime (CLR) property wrapper is usually included in read-write dependency property implementations to simplify getting or setting property values. If included, the CLR property wrapper is a convenience method that implements the <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> static calls that interact with the underlying dependency property. Essentially, a CLR property wrapper exposes a dependency property as a CLR property backed by a dependency property rather than a private field.

Applying security mechanisms and restricting access to the CLR property wrapper might prevent usage of the convenience method, but those techniques won't prevent direct calls to `GetValue` or `SetValue`. In other words, a read-write dependency property is always accessible through the WPF property system. If you're implementing a read-write dependency property, avoid restricting access to the CLR property wrapper. Instead, declare the CLR property wrapper as a public member so callers are aware of the true access level of the dependency property.

## Property system exposure of dependency properties

The WPF property system provides access to a read-write dependency property through its <xref:System.Windows.DependencyProperty> identifier. The identifier is usable in <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> calls. Even if the static identifier field is non-public, several aspects of the property system will return a `DependencyProperty` as it exists on an instance of a class or derived class. For example, the <xref:System.Windows.DependencyObject.GetLocalValueEnumerator%2A> method returns identifiers for dependency property instances with a locally set value. Also, you can override the <xref:System.Windows.DependencyObject.OnPropertyChanged%2A> virtual method to receive event data that will report the `DependencyProperty` identifier for dependency properties that have changed value. To make callers aware of the true access level of a read-write dependency property, declare its identifier field as a public member.

> [!NOTE]
> Although declaring a dependency property identifier field as `private` reduces the number of ways that a read-write dependency property is accessible, the property won't be [private](/dotnet/csharp/language-reference/keywords/private) according to the CLR language definition.

### Validation security

Applying a <xref:System.Security.IStackWalk.Demand%2A> to a <xref:System.Windows.DependencyProperty.ValidateValueCallback%2A> and expecting validation to fail on `Demand` failure, isn't an adequate security mechanism for restricting property value changes. Also, new value invalidation enforced through `ValidateValueCallback` can be suppressed by malicious callers, if those callers are operating within the application domain.

## Access to read-only dependency properties

To restrict access, register your property as a read-only dependency property by calling the <xref:System.Windows.DependencyProperty.RegisterReadOnly%2A> method. The `RegisterReadOnly` method returns a <xref:System.Windows.DependencyPropertyKey>, which you can assign to a non-public class field. For read-only dependency properties, the WPF property system will only provide write access to those who have a reference to the `DependencyPropertyKey`. To illustrate this behavior, the following test code:

- Instantiates a class that implements both read-write and read-only dependency properties.
- Assigns a `private` access modifier to each identifier.
- Only implements `get` accessors.
- Uses the <xref:System.Windows.DependencyObject.GetLocalValueEnumerator%2A> method to access the underlying dependency properties through the WPF property system.
- Calls <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> to test access to each dependency property value.

:::code language="csharp" source="./snippets/dependency-property-security/csharp/MainWindow.xaml.cs" id="DependencyPropertyAccessTests":::
:::code language="vb" source="./snippets/dependency-property-security/vb/MainWindow.xaml.vb" id="DependencyPropertyAccessTests":::

## See also

- <xref:System.Windows.DependencyProperty>
- <xref:System.Windows.DependencyObject.GetLocalValueEnumerator%2A>
- <xref:System.Windows.DependencyObject.OnPropertyChanged%2A>
- [Custom dependency properties](custom-dependency-properties.md)
- [Implement a Dependency property](how-to-implement-a-dependency-property.md)
