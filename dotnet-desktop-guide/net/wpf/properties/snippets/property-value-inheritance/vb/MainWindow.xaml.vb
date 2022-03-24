Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()

        ' Code tests.
        TestAllowDropInheritanceInXaml()
        TestAllowDropInheritanceInCode()
        TestIsTransparentInheritanceInCode()
        TestDependencyPropertyWrapper()
    End Sub

    Private Sub TestAllowDropInheritanceInXaml()

        ' Test enabled property value inheritance.
        Dim fpm1 As FrameworkPropertyMetadata =
            CType(AllowDropProperty.
            GetMetadata(GetType(Canvas)), FrameworkPropertyMetadata)
        Debug.Assert(fpm1.[Inherits] = True)
        Debug.Assert(canvas1.AllowDrop = True)
        Debug.Assert(stackPanel1.AllowDrop = True)
        Debug.Assert(label1.AllowDrop = True)

        ' Test disabled property value inheritance.
        Dim fpm11 As FrameworkPropertyMetadata =
            CType(AllowDropProperty.
            GetMetadata(GetType(Canvas_AllowDropInheritDisabled)), FrameworkPropertyMetadata)
        Debug.Assert(fpm11.[Inherits] = False)
        Debug.Assert(canvas11.AllowDrop = True)
        Debug.Assert(stackPanel11.AllowDrop = False)
        Debug.Assert(label11.AllowDrop = False)
    End Sub

    Private Shared Sub TestAllowDropInheritanceInCode()

        '<CodeElementTree>
        Dim canvas2 As New Canvas With {
            .AllowDrop = True
        }
        Dim stackPanel2 As New StackPanel()
        Dim label2 As New Label()
        canvas2.Children.Add(stackPanel2)
        stackPanel2.Children.Add(label2)
        '</CodeElementTree>

        ' Test enabled property value inheritance.
        Dim fpm2 As FrameworkPropertyMetadata =
            CType(AllowDropProperty.
            GetMetadata(GetType(Canvas)), FrameworkPropertyMetadata)
        Debug.Assert(fpm2.[Inherits] = True)
        Debug.Assert(canvas2.AllowDrop = True)
        Debug.Assert(stackPanel2.AllowDrop = True)
        Debug.Assert(label2.AllowDrop = True)

        ' Test disabled property value inheritance.
        Dim canvas3 As New Canvas_AllowDropInheritDisabled With {
            .AllowDrop = True
        }
        Dim stackPanel3 As New StackPanel()
        Dim label3 As New Label()
        canvas3.Children.Add(stackPanel3)
        stackPanel3.Children.Add(label3)
        Dim fpm3 As FrameworkPropertyMetadata =
            CType(AllowDropProperty.
            GetMetadata(GetType(Canvas_AllowDropInheritDisabled)), FrameworkPropertyMetadata)
        Debug.Assert(fpm3.[Inherits] = False)
        Debug.Assert(canvas3.AllowDrop = True)
        Debug.Assert(stackPanel3.AllowDrop = False)
        Debug.Assert(label3.AllowDrop = False)

    End Sub

    Private Shared Sub TestIsTransparentInheritanceInCode()

        ' Test enabled property value inheritance.
        Dim myCanvas1 As New Canvas_IsTransparentInheritEnabled With {
            .IsTransparent = True
        }
        Dim myCanvas2 As New Canvas_IsTransparentInheritEnabled2()
        Dim myCanvas3 As New Canvas_IsTransparentInheritEnabled3()
        myCanvas1.Children.Add(myCanvas2)
        myCanvas2.Children.Add(myCanvas3)
        Dim fpm1 As FrameworkPropertyMetadata =
            CType(Canvas_IsTransparentInheritEnabled.IsTransparentProperty.
            GetMetadata(GetType(Canvas_IsTransparentInheritEnabled)), FrameworkPropertyMetadata)
        Debug.Assert(fpm1.[Inherits] = True)
        Debug.Assert(myCanvas1.IsTransparent = True)
        Debug.Assert(myCanvas2.IsTransparent = True)
        Debug.Assert(myCanvas3.IsTransparent = True)

        ' Test disabled property value inheritance.
        Dim myCanvas4 As New Canvas_IsTransparentInheritDisabled With {
            .IsTransparent = True
        }
        Dim myCanvas5 As New Canvas_IsTransparentInheritDisabled2()
        Dim myCanvas6 As New Canvas_IsTransparentInheritDisabled3()
        myCanvas4.Children.Add(myCanvas5)
        myCanvas5.Children.Add(myCanvas6)
        Dim fpm2 As FrameworkPropertyMetadata =
            CType(Canvas_IsTransparentInheritDisabled.IsTransparentProperty.
            GetMetadata(GetType(Canvas_IsTransparentInheritDisabled)), FrameworkPropertyMetadata)
        Debug.Assert(fpm2.[Inherits] = False)
        Debug.Assert(myCanvas4.IsTransparent = True)
        Debug.Assert(myCanvas5.IsTransparent = False)
        Debug.Assert(myCanvas6.IsTransparent = False)

    End Sub

    Private Shared Sub TestDependencyPropertyWrapper()

        ' Test Canvas_IsTransparentInheritEnabled.
        Dim myCanvas1 As New Canvas_IsTransparentInheritEnabled()
        Dim myCanvas2 As New Canvas_IsTransparentInheritEnabled2()
        Dim myCanvas3 As New Canvas_IsTransparentInheritEnabled3()
        ' Test property wrapper.
        myCanvas1.IsTransparent = True
        myCanvas2.IsTransparent = False
        myCanvas3.IsTransparent = True
        Debug.Assert(myCanvas1.IsTransparent = True)
        Debug.Assert(myCanvas2.IsTransparent = False)
        Debug.Assert(myCanvas3.IsTransparent = True)
        ' Test individual get/set accessors.
        Canvas_IsTransparentInheritEnabled.SetIsTransparent(myCanvas1, False)
        Canvas_IsTransparentInheritEnabled.SetIsTransparent(myCanvas2, True)
        Canvas_IsTransparentInheritEnabled.SetIsTransparent(myCanvas3, False)
        Debug.Assert(Canvas_IsTransparentInheritEnabled.GetIsTransparent(myCanvas1) = False)
        Debug.Assert(Canvas_IsTransparentInheritEnabled.GetIsTransparent(myCanvas2) = True)
        Debug.Assert(Canvas_IsTransparentInheritEnabled.GetIsTransparent(myCanvas3) = False)

        ' Test Canvas_IsTransparentInheritDisabled.
        Dim myCanvas4 As New Canvas_IsTransparentInheritDisabled()
        Dim myCanvas5 As New Canvas_IsTransparentInheritDisabled2()
        Dim myCanvas6 As New Canvas_IsTransparentInheritDisabled3()
        ' Test property wrapper.
        myCanvas4.IsTransparent = True
        myCanvas5.IsTransparent = False
        myCanvas6.IsTransparent = True
        Debug.Assert(myCanvas4.IsTransparent = True)
        Debug.Assert(myCanvas5.IsTransparent = False)
        Debug.Assert(myCanvas6.IsTransparent = True)
        ' Test individual get/set accessors.
        Canvas_IsTransparentInheritDisabled.SetIsTransparent(myCanvas4, False)
        Canvas_IsTransparentInheritDisabled.SetIsTransparent(myCanvas5, True)
        Canvas_IsTransparentInheritDisabled.SetIsTransparent(myCanvas6, False)
        Debug.Assert(Canvas_IsTransparentInheritDisabled.GetIsTransparent(myCanvas4) = False)
        Debug.Assert(Canvas_IsTransparentInheritDisabled.GetIsTransparent(myCanvas5) = True)
        Debug.Assert(Canvas_IsTransparentInheritDisabled.GetIsTransparent(myCanvas6) = False)

    End Sub
End Class

Public Class Canvas_AllowDropInheritDisabled
        Inherits Canvas
        Shared Sub New()
            ' Disable property value inheritance in a new property metadata object.
            Dim frameworkPropertyMetadata As New FrameworkPropertyMetadata With {
                .Inherits = False
            }
            ' Override existing property metadata.
            AllowDropProperty.OverrideMetadata(GetType(Canvas_AllowDropInheritDisabled), frameworkPropertyMetadata)
        End Sub
    End Class

    '<RegisterAttachedPropertyWithValueInheritance>
    Public Class Canvas_IsTransparentInheritEnabled
        Inherits Canvas

        ' Register an attached dependency property with the specified
        ' property name, property type, owner type, and property metadata
        ' (default value is 'false' and property value inheritance is enabled).
        Public Shared ReadOnly IsTransparentProperty As DependencyProperty =
            DependencyProperty.RegisterAttached(
                name:="IsTransparent",
                propertyType:=GetType(Boolean),
                ownerType:=GetType(Canvas_IsTransparentInheritEnabled),
                defaultMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=False,
                    flags:=FrameworkPropertyMetadataOptions.[Inherits]))

        ' Declare a get accessor method.
        Public Shared Function GetIsTransparent(element As Canvas) As Boolean
            Return element.GetValue(IsTransparentProperty)
        End Function

        ' Declare a set accessor method.
        Public Shared Sub SetIsTransparent(element As Canvas, value As Boolean)
            element.SetValue(IsTransparentProperty, value)
        End Sub

        ' For convenience, declare a property wrapper with get/set accessors.
        Public Property IsTransparent As Boolean
            Get
                Return GetValue(IsTransparentProperty)
            End Get
            Set(value As Boolean)
                SetValue(IsTransparentProperty, value)
            End Set
        End Property
    End Class
    '</RegisterAttachedPropertyWithValueInheritance>

    Public Class Canvas_IsTransparentInheritEnabled2
        Inherits Canvas_IsTransparentInheritEnabled
    End Class

    Public Class Canvas_IsTransparentInheritEnabled3
        Inherits Canvas_IsTransparentInheritEnabled
    End Class

    Public Class Canvas_IsTransparentInheritDisabled
        Inherits Canvas

        ' Register an attached dependency property with the specified
        ' property name, property type, owner type, and property metadata
        ' (default value is 'false' and property value inheritance is disabled).
        Public Shared ReadOnly IsTransparentProperty As DependencyProperty =
            DependencyProperty.RegisterAttached(
                name:="IsTransparent",
                propertyType:=GetType(Boolean),
                ownerType:=GetType(Canvas_IsTransparentInheritDisabled),
                defaultMetadata:=New FrameworkPropertyMetadata(defaultValue:=False))

        ' Declare a get accessor method.
        Public Shared Function GetIsTransparent(element As Canvas) As Boolean
            Return element.GetValue(IsTransparentProperty)
        End Function

        ' Declare a set accessor method.
        Public Shared Sub SetIsTransparent(element As Canvas, value As Boolean)
            element.SetValue(IsTransparentProperty, value)
        End Sub

        ' For convenience, declare a property wrapper with get/set accessors.
        Public Property IsTransparent As Boolean
            Get
                Return GetValue(IsTransparentProperty)
            End Get
            Set(value As Boolean)
                SetValue(IsTransparentProperty, value)
            End Set
        End Property
    End Class

    Public Class Canvas_IsTransparentInheritDisabled2
        Inherits Canvas_IsTransparentInheritDisabled
    End Class

    Public Class Canvas_IsTransparentInheritDisabled3
        Inherits Canvas_IsTransparentInheritDisabled
    End Class
