Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub
    End Class

    Public Class Aquarium
        Inherits DependencyObject

        '<RegisterDependencyPropertyWithWrapper>
        '<RegisterDependencyProperty>
        ' Register a dependency property with the specified property name,
        ' property type, owner type, and property metadata.
        Private Shared ReadOnly s_aquariumGraphicProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="AquariumGraphic",
                propertyType:=GetType(Uri),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=New Uri("http://www.contoso.com/aquarium-graphic.jpg"),
                    flags:=FrameworkPropertyMetadataOptions.AffectsRender,
                    propertyChangedCallback:=New PropertyChangedCallback(AddressOf OnUriChanged)))

        ' Store the dependency property identifier as a static member of the class.
        Public Shared ReadOnly AquariumGraphicProperty As DependencyProperty =
            s_aquariumGraphicProperty
        '</RegisterDependencyProperty>

        ' Declare a read-write property.
        Public Property AquariumGraphic As Uri
            Get
                Return CType(GetValue(AquariumGraphicProperty), Uri)
            End Get
            Set
                SetValue(AquariumGraphicProperty, Value)
            End Set
        End Property
        '</RegisterDependencyPropertyWithWrapper>

        Private Shared Sub OnUriChanged(dependencyObject As DependencyObject, e As DependencyPropertyChangedEventArgs)
            Dim shape As Shape = CType(dependencyObject, Shape)
            shape.Fill = New ImageBrush(New BitmapImage(CType(e.NewValue, Uri)))
        End Sub

    End Class

End Namespace
