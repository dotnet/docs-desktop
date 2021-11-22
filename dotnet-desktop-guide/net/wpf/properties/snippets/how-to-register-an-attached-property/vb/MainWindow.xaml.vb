Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' Test get/set accessors.
            Dim aquarium As New Aquarium()
            Aquarium.SetHasFish(aquarium, True)
            Dim hasFish As Boolean = Aquarium.GetHasFish(aquarium)
            Debug.WriteLine($"Has fish: {hasFish}")
        End Sub

    End Class

    '<RegisterAttachedProperty>
    Public Class Aquarium
        Inherits UIElement

        ' Register an attached dependency property with the specified
        ' property name, property type, owner type, and property metadata.
        Public Shared ReadOnly HasFishProperty As DependencyProperty =
            DependencyProperty.RegisterAttached("HasFish", GetType(Boolean), GetType(Aquarium),
                New FrameworkPropertyMetadata(defaultValue:=False,
                    flags:=FrameworkPropertyMetadataOptions.AffectsRender))

        ' Declare a get accessor method.
        Public Shared Function GetHasFish(target As UIElement) As Boolean
            Return target.GetValue(HasFishProperty)
        End Function

        ' Declare a set accessor method.
        Public Shared Sub SetHasFish(target As UIElement, value As Boolean)
            target.SetValue(HasFishProperty, value)
        End Sub

    End Class
    '</RegisterAttachedProperty>

End Namespace
