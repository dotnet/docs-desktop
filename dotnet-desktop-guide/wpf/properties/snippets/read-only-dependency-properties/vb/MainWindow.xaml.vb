Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        ReadOnly _aquarium As New Aquarium()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
            ' Test setting a value.
            _aquarium.SetValue(Aquarium.FishCountPropertyKey, _aquarium.FishCount + 1)
            lblFishCount.Content = $"Aquarium fish count: {_aquarium.FishCount}"
        End Sub

    End Class

    '<RegisterReadOnlyDependencyProperty>
    Public Class Aquarium
        Inherits DependencyObject

        ' Register a dependency property with the specified property name,
        ' property type, owner type, And property metadata.
        ' Assign DependencyPropertyKey to a nonpublic field.
        Friend Shared ReadOnly FishCountPropertyKey As DependencyPropertyKey =
            DependencyProperty.RegisterReadOnly(
                name:="FishCount",
                propertyType:=GetType(Integer),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New FrameworkPropertyMetadata())

        ' Declare a public get accessor.
        Public ReadOnly Property FishCount As Integer
            Get
                Return GetValue(FishCountPropertyKey.DependencyProperty)
            End Get
        End Property

    End Class
    '</RegisterReadOnlyDependencyProperty>

End Namespace
