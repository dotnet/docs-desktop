Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            SetAttachedPropertyInCode()
        End Sub

        Public Shared Sub SetAttachedPropertyInCode()
            '<SetAttachedPropertyInCode>
            Dim myDockPanel As DockPanel = New DockPanel()
            Dim myTextBox As TextBox = New TextBox()
            myTextBox.Text = "Enter text"

            ' Add child element to the DockPanel.
            myDockPanel.Children.Add(myTextBox)

            ' Set the attached property value.
            DockPanel.SetDock(myTextBox, Dock.Top)
            '</SetAttachedPropertyInCode>
        End Sub

    End Class

    '<RegisterAttachedProperty>
    Public Class Aquarium
        Inherits DependencyObject

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
