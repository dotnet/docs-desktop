Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<InitializeAquariums>
        Private Sub InitializeAquariums(sender As Object, e As RoutedEventArgs)
            Dim aquarium1 As New Aquarium()
            Dim aquarium2 As New Aquarium()
            aquarium1.AquariumContents.Add(New Fish())
            aquarium2.AquariumContents.Add(New Fish())
            MessageBox.Show($"aquarium1 contains {aquarium1.AquariumContents.Count} fish{Environment.NewLine}" +
                            $"aquarium2 contains {aquarium2.AquariumContents.Count} fish")
        End Sub
        '</InitializeAquariums>

        Private Sub InitializeFreezableAquariums(sender As Object, e As RoutedEventArgs)
            FreezableCollectionAquarium.InitializeAquariums()
        End Sub

    End Class

    '<SetCollectionDefaultValueInConstructor>
    Public Class Aquarium
        Inherits DependencyObject

        ' Register a dependency property with the specified property name,
        ' property type, owner type, and property metadata.
        Private Shared ReadOnly s_aquariumContentsPropertyKey As DependencyPropertyKey =
            DependencyProperty.RegisterReadOnly(
                name:="AquariumContents",
                propertyType:=GetType(List(Of FrameworkElement)),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New FrameworkPropertyMetadata())
                'typeMetadata:=New FrameworkPropertyMetadata(New List(Of FrameworkElement)))

        ' Set the default collection value in a class constructor.
        Public Sub New()
            SetValue(s_aquariumContentsPropertyKey, New List(Of FrameworkElement)())
        End Sub

        ' Declare a public get accessor.
        Public ReadOnly Property AquariumContents As List(Of FrameworkElement)
            Get
                Return CType(GetValue(s_aquariumContentsPropertyKey.DependencyProperty), List(Of FrameworkElement))
            End Get
        End Property
    End Class

    Public Class Fish
        Inherits FrameworkElement
    End Class
    '</SetCollectionDefaultValueInConstructor>

    Public Class ReadWriteAquariumContents

        Public Shared Sub InitializeAquariums()
            Dim aquarium1 As New Aquarium()
            Dim aquarium2 As New Aquarium()
            aquarium1.AquariumContents.Add(New Fish())
            aquarium2.AquariumContents.Add(New Fish())
            aquarium2.AquariumContents = New List(Of FrameworkElement)()
            MessageBox.Show($"aquarium1 contains {aquarium1.AquariumContents.Count} fish{Environment.NewLine}" +
                            $"aquarium2 contains {aquarium2.AquariumContents.Count} fish")
        End Sub

        '<ReadWriteDependencyProperty>
        Public Class Aquarium
            Inherits DependencyObject

            ' Register a dependency property with the specified property name,
            ' property type, and owner type. Store the dependency property
            ' identifier as a static member of the class.
            Public Shared ReadOnly AquariumContentsProperty As DependencyProperty =
                DependencyProperty.Register(
                    name:="AquariumContents",
                    propertyType:=GetType(List(Of FrameworkElement)),
                    ownerType:=GetType(Aquarium))

            ' Set the default collection value in a class constructor.
            Public Sub New()
                SetValue(AquariumContentsProperty, New List(Of FrameworkElement)())
            End Sub

            ' Declare public get and set accessors.
            Public Property AquariumContents As List(Of FrameworkElement)
                Get
                    Return CType(GetValue(AquariumContentsProperty), List(Of FrameworkElement))
                End Get
                Set
                    SetValue(AquariumContentsProperty, Value)
                End Set
            End Property
        End Class
        '</ReadWriteDependencyProperty>

        Public Class Fish
            Inherits FrameworkElement
        End Class

    End Class

    Public Class FreezableCollectionAquarium

        Public Shared Sub InitializeAquariums()
            Dim aquarium1 As New Aquarium()
            Dim aquarium2 As New Aquarium()
            aquarium1.AquariumContents.Add(New Fish())
            aquarium2.AquariumContents.Add(New Fish())
            MessageBox.Show($"FreezableCollection aquarium1 contains {aquarium1.AquariumContents.Count} fish{Environment.NewLine}" +
                            $"FreezableCollection aquarium2 contains {aquarium2.AquariumContents.Count} fish")
        End Sub

        '<FreezableCollectionAquarium>
        Public Class Aquarium
            Inherits DependencyObject

            ' Register a dependency property with the specified property name,
            ' property type, and owner type.
            Private Shared ReadOnly s_aquariumContentsPropertyKey As DependencyPropertyKey =
                DependencyProperty.RegisterReadOnly(
                    name:="AquariumContents",
                    propertyType:=GetType(FreezableCollection(Of FrameworkElement)),
                    ownerType:=GetType(Aquarium),
                    typeMetadata:=New FrameworkPropertyMetadata())

            ' Set the default collection value in a class constructor.
            Public Sub New()
                SetValue(s_aquariumContentsPropertyKey, New FreezableCollection(Of FrameworkElement)())
            End Sub

            ' Declare a public get accessor.
            Public ReadOnly Property AquariumContents As FreezableCollection(Of FrameworkElement)
                Get
                    Return CType(GetValue(s_aquariumContentsPropertyKey.DependencyProperty), FreezableCollection(Of FrameworkElement))
                End Get
            End Property
        End Class
        '</FreezableCollectionAquarium>

        Public Class Fish
            Inherits FrameworkElement
        End Class

    End Class

End Namespace
