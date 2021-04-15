Imports System.Globalization

Public Class MarginValidationRule
    Inherits ValidationRule

    Public Property MinMargin As Double
    Public Property MaxMargin As Double

    Public Overrides Function Validate(value As Object, cultureInfo As CultureInfo) As ValidationResult
        Dim margin As Double

        ' Is it a number?
        If Not Double.TryParse(DirectCast(value, String), margin) Then
            Return New ValidationResult(False, "Not a number")
        End If

        ' Is it in range
        If margin < MinMargin Or margin > MaxMargin Then
            Return New ValidationResult(False, $"Margin must be between {MinMargin} and {MaxMargin}")
        End If

        Return New ValidationResult(True, Nothing)

    End Function

End Class
