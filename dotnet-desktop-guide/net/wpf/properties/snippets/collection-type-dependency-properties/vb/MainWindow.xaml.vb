Namespace CodeSampleVb
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<AddToCollectionTest>
        Private Sub BtnInitializeAquariumA(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim aquarium1 As New AquariumA()
            Dim aquarium2 As New AquariumA()
            Dim fish1 As New Fish()
            Dim fish2 As New Fish()
            aquarium1.AquariumContents.Add(fish1)
            aquarium2.AquariumContents.Add(fish2)
            MessageBox.Show($"Aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" & $"Aquarium2 contains {aquarium2.AquariumContents.Count} fish")
        End Sub
        '</AddToCollectionTest>

        Private Sub BtnInitializeAquariumB(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim aquarium1 As New AquariumB()
            Dim aquarium2 As New AquariumB()
            Dim fish1 As New Fish()
            Dim fish2 As New Fish()
            aquarium1.AquariumContents.Add(fish1)
            aquarium2.AquariumContents.Add(fish2)
            MessageBox.Show($"Aquarium1 contains {aquarium1.AquariumContents.Count} fish\r\n" & $"Aquarium2 contains {aquarium2.AquariumContents.Count} fish")
        End Sub

    End Class

    '<SetCollectionDefaultValueInMetadata>
    Public Class AquariumA
        Inherits DependencyObject

        Private Shared ReadOnly s_aquariumContentsPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly("AquariumContents", GetType(List(Of FrameworkElement)), GetType(AquariumA), New FrameworkPropertyMetadata(New List(Of FrameworkElement)()))

        Public Shared ReadOnly AquariumContentsProperty As DependencyProperty = s_aquariumContentsPropertyKey.DependencyProperty

        Public ReadOnly Property AquariumContents As List(Of FrameworkElement)
            Get
                Return CType(GetValue(AquariumContentsProperty), List(Of FrameworkElement))
            End Get
        End Property
    End Class

    Public Class Fish
        Inherits FrameworkElement
    End Class
    '</SetCollectionDefaultValueInMetadata>

    Public Class AquariumB
        Inherits DependencyObject

        Private Shared ReadOnly s_aquariumContentsPropertyKey As DependencyPropertyKey = DependencyProperty.RegisterReadOnly("AquariumContents", GetType(List(Of FrameworkElement)), GetType(AquariumB), Nothing)

        Public Shared ReadOnly AquariumContentsProperty As DependencyProperty = s_aquariumContentsPropertyKey.DependencyProperty

        '<SetCollectionDefaultValueInConstructor>
        Public Sub New()
            SetValue(s_aquariumContentsPropertyKey, New List(Of FrameworkElement)())
        End Sub
        '</SetCollectionDefaultValueInConstructor>

        Public ReadOnly Property AquariumContents As List(Of FrameworkElement)
            Get
                Return CType(GetValue(AquariumContentsProperty), List(Of FrameworkElement))
            End Get
        End Property
    End Class

End Namespace
