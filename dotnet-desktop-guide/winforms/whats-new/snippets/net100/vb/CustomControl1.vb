'<CreateParams>
Public Class CustomControl1

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            ' Set this style BEFORE base.CreateParams is created and returned.
            SetStyle(ControlStyles.ApplyThemingImplicitly, True)

            Dim cp As CreateParams = MyBase.CreateParams

            ' Other logic
            Return cp
        End Get
    End Property

    ' Base class constructor is going to read CreateParams property
    ' before your constructor code runs.
    Sub New()

        ' At this point, CreateParams property is already read, you
        ' can't set ApplyThemingImplicitly here.

        InitializeComponent()

    End Sub

End Class
'</CreateParams>
