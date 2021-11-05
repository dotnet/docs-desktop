Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub ValidateSnippet(sender As Object, e As RoutedEventArgs)
            Dim tropicalAquarium As New TropicalAquarium()
            Dim aquarium As New Aquarium()

            Dim aquariumPropertyMetadata As FrameworkPropertyMetadata = CType(Aquarium.AquariumGraphicProperty.GetMetadata(aquarium), FrameworkPropertyMetadata)
            Dim tropicalAquariumPropertyMetadata As FrameworkPropertyMetadata = CType(Aquarium.AquariumGraphicProperty.GetMetadata(tropicalAquarium), FrameworkPropertyMetadata)

            lblMessage.Content = $"Tropical aquarium graphic URL: {tropicalAquarium.AquariumGraphic.OriginalString}" & Environment.NewLine
            lblMessage.Content += $"Aquarium graphic URL: {aquarium.AquariumGraphic.OriginalString}" & Environment.NewLine

            lblMessage.Content += $"Queried owner-type AquariumGraphic default value: {aquariumPropertyMetadata.DefaultValue}" & Environment.NewLine
            lblMessage.Content += $"Queried owner-type AquariumGraphic affects render: {aquariumPropertyMetadata.AffectsRender}" & Environment.NewLine

            lblMessage.Content += $"Queried derived-type TropicalAquarium default value: {tropicalAquariumPropertyMetadata.DefaultValue}" & Environment.NewLine
            lblMessage.Content += $"Queried derived-type TropicalAquarium affects render: {tropicalAquariumPropertyMetadata.AffectsRender}" & Environment.NewLine
        End Sub

    End Class

    '<BaseDependencyProperty>
    Public Class Aquarium
        Inherits DependencyObject

        ' Register a dependency property with the specified property name,
        ' property type, owner type, and property metadata.
        Public Shared ReadOnly AquariumGraphicProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="AquariumGraphic",
                propertyType:=GetType(Uri),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=New Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                    flags:=FrameworkPropertyMetadataOptions.AffectsRender))

        ' Declare a read-write CLR wrapper with get/set accessors.
        Public Property AquariumGraphic As Uri
            Get
                Return CType(GetValue(AquariumGraphicProperty), Uri)
            End Get
            Set
                SetValue(AquariumGraphicProperty, Value)
            End Set
        End Property

    End Class
    '</BaseDependencyProperty>

    '<InheritedDependencyProperty>
    Public Class TropicalAquarium
        Inherits Aquarium

        ' Static constructor.
        Shared Sub New()
            ' Create a new metadata instance with a modified default value.
            Dim newPropertyMetadata As New FrameworkPropertyMetadata(
                defaultValue:=New Uri("http://www.contoso.com/tropical-aquarium-graphic.jpg"))

            ' Call OverrideMetadata on the dependency property identifier.
            ' Pass in the type for which the new metadata will be applied
            ' and the new metadata instance.
            AquariumGraphicProperty.OverrideMetadata(
                forType:=GetType(TropicalAquarium),
                typeMetadata:=newPropertyMetadata)
        End Sub

    End Class
    '</InheritedDependencyProperty>

End Namespace
