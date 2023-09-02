Public Class Metadata

    '<print_metadata>
    Public Shared Sub PrintMetadata()

        Dim metadata As PropertyMetadata = TextBox.TextProperty.GetMetadata(GetType(TextBox))
        Dim frameworkMetadata As FrameworkPropertyMetadata = TryCast(metadata, FrameworkPropertyMetadata)

        If frameworkMetadata IsNot Nothing Then

            System.Diagnostics.Debug.WriteLine($"TextBox.Text property metadata:")
            System.Diagnostics.Debug.WriteLine($"  BindsTwoWayByDefault: {frameworkMetadata.BindsTwoWayByDefault}")
            System.Diagnostics.Debug.WriteLine($"  IsDataBindingAllowed: {frameworkMetadata.IsDataBindingAllowed}")
            System.Diagnostics.Debug.WriteLine($"        AffectsArrange: {frameworkMetadata.AffectsArrange}")
            System.Diagnostics.Debug.WriteLine($"        AffectsMeasure: {frameworkMetadata.AffectsMeasure}")
            System.Diagnostics.Debug.WriteLine($"         AffectsRender: {frameworkMetadata.AffectsRender}")
            System.Diagnostics.Debug.WriteLine($"              Inherits: {frameworkMetadata.Inherits}")

            '  Displays:
            '
            '  TextBox.Text property metadata:
            '    BindsTwoWayByDefault: True
            '    IsDataBindingAllowed: True
            '          AffectsArrange: False
            '          AffectsMeasure: False
            '           AffectsRender: False
            '                Inherits: False
        End If


    End Sub
    '</print_metadata>

End Class
