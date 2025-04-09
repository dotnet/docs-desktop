Namespace CodeSampleVb
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        ' <DefineDependencyProperty>
        Public Class Aquarium
            Inherits DependencyObject

            Public Shared ReadOnly HasFishProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="HasFish",
                propertyType:=GetType(Boolean),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New FrameworkPropertyMetadata(defaultValue:=False))

            Public Property HasFish As Boolean
                Get
                    Return GetValue(HasFishProperty)
                End Get
                Set(value As Boolean)
                    SetValue(HasFishProperty, value)
                End Set
            End Property

        End Class
        ' </DefineDependencyProperty>
    End Class
End Namespace
