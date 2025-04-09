Imports System.ComponentModel

Public Class Employee
    Implements INotifyPropertyChanged

    Private _salary As Decimal
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Property FirstName As String
    Public Property LastName As String
    Public Property Title As String
    Public Property HireDate As DateTime

    Public Property Salary As Decimal
        Get
            Return _salary
        End Get
        Set(value As Decimal)
            _salary = value
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(NameOf(Salary)))
        End Set
    End Property

End Class
