---
title: "Safe Constructor Patterns for DependencyObjects"
description: "Learn about safe constructor patterns for DependencyObjects in Windows Presentation Foundation (WPF)."
ms.date: "12/15/2021"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "constructor patterns for dependency objects [WPF]"
  - "dependency objects [WPF], constructor patterns"
  - ".NET analyzers [WPF]"
---
<!-- The acrolinx score was 91 on 12/15/2021-->

# Safe constructor patterns for DependencyObjects (WPF .NET)

There's a general principle in managed code programming, often enforced by code analysis tools, that class constructors shouldn't call overridable methods. If an overridable method is called by a base class constructor, and a derived class overrides that method, then the override method in the derived class can run before the derived class constructor. If the derived class constructor performs class initialization, then the derived class method might access uninitialized class members. Dependency property classes should avoid setting dependency property values in a class constructor to avoid runtime initialization problems. This article describes how to implement <xref:System.Windows.DependencyObject> constructors in a way that avoids those problems.

[!INCLUDE [desktop guide under construction](../../includes/desktop-guide-preview-note.md)]

## Property system virtual methods and callbacks

Dependency property virtual methods and callbacks are part of the Windows Presentation Foundation (WPF) property system and expand the versatility of dependency properties.

A basic operation like setting a dependency property value using <xref:System.Windows.DependencyObject.SetValue%2A> will invoke the <xref:System.Windows.DependencyObject.OnPropertyChanged%2A> event and potentially several WPF property system callbacks.

`OnPropertyChanged` is an example of a WPF property system virtual method that can be overridden by classes that have <xref:System.Windows.DependencyObject> in their inheritance hierarchy. If you set a dependency property value in a constructor that's called during instantiation of your custom dependency property class, and a class derived from it overrides the `OnPropertyChanged` virtual method, then the derived class `OnPropertyChanged` method will run prior to any derived class constructor.

<xref:System.Windows.PropertyChangedCallback> and <xref:System.Windows.CoerceValueCallback> are examples of WPF property system callbacks that can be registered by dependency property classes, and overridden by classes that derive from them. If you set a dependency property value in the constructor of your custom dependency property class, and a class that derives from it overrides one of those callbacks in property metadata, then the derived class callback will run before any derived class constructor. This issue isn't relevant to <xref:System.Windows.ValidateValueCallback> since it isn't part of property metadata and can only be specified by the registering class.

For more information on dependency property callbacks, see [Dependency property callbacks and validation](dependency-property-callbacks-and-validation.md).

### .NET analyzers

.NET compiler platform analyzers inspect your C# or Visual Basic code for code quality and style issues. If you call overridable methods in a constructor when analyzer rule [CA2214](/dotnet/fundamentals/code-analysis/quality-rules/ca2214) is active, you'll get the warning `CA2214: Don't call overridable methods in constructors`. But, the rule won't flag virtual methods and callbacks that are invoked by the underlying WPF property system when a dependency property value is set in a constructor.

### Issues caused by derived classes

If you [seal](/dotnet/csharp/language-reference/keywords/sealed) your custom dependency property class, or otherwise know that your class won't be derived from, then derived class runtime initialization issues don't apply to that class. But, if you create a dependency property class that's inheritable, for instance if you're creating templates or an expandable control library set, avoid calling overridable methods or setting dependency property values from a constructor.

The following test code demonstrates an unsafe constructor pattern, where a base class constructor sets a dependency property value thus triggering calls to virtual methods and callbacks.

:::code language="csharp" source="./snippets/safe-constructor-patterns-for-dependencyobjects/csharp/MainWindow.xaml.cs" id="TestUnsafeConstructorPattern":::
:::code language="vb" source="./snippets/safe-constructor-patterns-for-dependencyobjects/vb/MainWindow.xaml.vb" id="TestUnsafeConstructorPattern":::

The order in which methods are called in the unsafe constructor pattern test is:

1. Derived class static constructor, which overrides the dependency property metadata of `Aquarium` to register <xref:System.Windows.PropertyChangedCallback> and <xref:System.Windows.CoerceValueCallback>.

1. Base class constructor, which sets a new dependency property value resulting in a call to the <xref:System.Windows.DependencyObject.SetValue%2A> method. The `SetValue` call triggers callbacks and events in the following order:

    1. <xref:System.Windows.ValidateValueCallback>, which is implemented in the base class. This callback isn't part of dependency property metadata and can't be implemented in the derived class by overriding metadata.

    1. `PropertyChangedCallback`, which is implemented in the derived class by overriding dependency property metadata. This callback causes a null reference exception when it calls a method on the uninitialized class field `s_temperatureLog`.

    1. `CoerceValueCallback`, which is implemented in the derived class by overriding dependency property metadata. This callback causes a null reference exception when it calls a method on the uninitialized class field `s_temperatureLog`.
  
    1. <xref:System.Windows.DependencyObject.OnPropertyChanged%2A> event, which is implemented in the derived class by overriding the virtual method. This event causes a null reference exception when it calls a method on the uninitialized class field `s_temperatureLog`.

1. Derived class parameterless constructor, which initializes `s_temperatureLog`.

1. Derived class parameter constructor, which sets a new dependency property value resulting in another call to the `SetValue` method. Since `s_temperatureLog` is now initialized, callbacks and events will run without causing null reference exceptions.

These initialization issues are avoidable through use of safe constructor patterns.

## Safe constructor patterns

The derived class initialization issues demonstrated in the test code can be resolved in different ways, including:

- Avoid setting a dependency property value in a constructor of your custom dependency property class if your class might be used as a base class. If you need to initialize a dependency property value, consider setting the required value as the default value in property metadata during dependency property registration or when overriding metadata.

- Initialize derived class fields before their use. For example, using any of these approaches:

  - Instantiate and assign instance fields in a single statement. In the previous example, the statement `List<int> s_temperatureLog = new();` would avoid late assignment.

  - Perform assignment in the derived class static constructor, which runs ahead of any base class constructor. In the previous example, putting the assignment statement `s_temperatureLog = new List<int>();` in the derived class static constructor would avoid late assignment.

  - Use lazy initialization and instantiation, which initializes objects as and when they're needed. In the previous example, instantiating and assigning `s_temperatureLog` by using lazy initialization and instantiation would avoid late assignment. For more information, see [Lazy initialization](/dotnet/framework/performance/lazy-initialization).

- Avoid using uninitialized class variables in WPF property system callbacks and events.

## See also

- <xref:System.Windows.DependencyObject.OnPropertyChanged%2A>
- <xref:System.Windows.PropertyChangedCallback>
- <xref:System.Windows.CoerceValueCallback>
- <xref:System.Windows.ValidateValueCallback>
- [Dependency property callbacks and validation](dependency-property-callbacks-and-validation.md)
- [Custom Dependency Properties](custom-dependency-properties.md)
- [Dependency Properties Overview](dependency-properties-overview.md)
- [Dependency Property Security](dependency-property-security.md)
