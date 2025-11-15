' <LoadDataFromDatabase>
Imports System.Linq

Class MainWindow
    Dim dataEntities As AdventureWorksLT2008Entities = New AdventureWorksLT2008Entities

    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        Dim query = _
            From product In dataEntities.Products _
            Where product.Color = "Red" _
            Order By product.ListPrice _
            Select product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice

        dataGrid1.ItemsSource = query.ToList()
    End Sub
End Class
' </LoadDataFromDatabase>
