Imports System.Globalization

Public Class DataBindingCode

    '<Converter>
    Private Class NameConverter
        Implements IValueConverter

        Private Shared _instance As New NameConverter

        Public Shared ReadOnly Instance As NameConverter = _instance

        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Return $"[[ {value} ]]"
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return value.ToString().Trim("[", "]", " ")
        End Function
    End Class
    '</Converter>

    '<SetBinding>
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        ' Make a new data source object
        Dim personDetails As New Person() With {
            .Name = "John",
            .Birthdate = Date.Parse("2001-02-03")
        }

        ' New binding object using the path of 'Name' for whatever source object is used
        Dim nameBindingObject As New Binding("Name")

        ' Configure the binding
        nameBindingObject.Mode = BindingMode.OneWay
        nameBindingObject.Source = personDetails
        nameBindingObject.Converter = NameConverter.Instance
        nameBindingObject.ConverterCulture = New CultureInfo("en-US")

        ' Set the binding to a target object. The TextBlock.Name property on the NameBlock UI element
        BindingOperations.SetBinding(NameBlock, TextBlock.TextProperty, nameBindingObject)

    End Sub
    '</SetBinding>
End Class
