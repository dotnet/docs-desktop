Namespace CodeSampleVb
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()

            ' <ProceduralPropertySet>
            Dim myButton As New Button With {
                .Width = 200.0
            }
            ' </ProceduralPropertySet>

            ' <ProceduralPropertyGet>
            Dim whatWidth As Double = myButton.Width
            ' </ProceduralPropertyGet>

        End Sub

        ' <DefineDependencyProperty>
        Public Shared ReadOnly IsSpinningProperty As DependencyProperty =
            DependencyProperty.Register("IsSpinning", GetType(Boolean), GetType(MainWindow))

        Public Property IsSpinning As Boolean
            Get
                Return GetValue(IsSpinningProperty)
            End Get
            Set(value As Boolean)
                SetValue(IsSpinningProperty, value)
            End Set
        End Property
        ' </DefineDependencyProperty>

    End Class

    ' <OverrideMetadata>
    Public Class SpinnerControl
        Inherits ItemsControl
        Shared Sub New()
            DefaultStyleKeyProperty.OverrideMetadata(GetType(SpinnerControl), New FrameworkPropertyMetadata(GetType(SpinnerControl)))
        End Sub
    End Class
    ' </OverrideMetadata>

End Namespace
