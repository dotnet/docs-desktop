Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            DependencyPropertyAccessTests()
        End Sub

        '<DependencyPropertyAccessTests>
        ''' <summary>
        ''' ' Test get/set access to dependency properties exposed through the WPF property system.
        ''' </summary>
        Public Shared Sub DependencyPropertyAccessTests()
            ' Instantiate a class that implements read-write and read-only dependency properties.
            Dim _aquarium As New Aquarium()
            ' Access each dependency property using the LocalValueEnumerator method.
            Dim localValueEnumerator As LocalValueEnumerator = _aquarium.GetLocalValueEnumerator()
            While localValueEnumerator.MoveNext()
                Dim dp As DependencyProperty = localValueEnumerator.Current.[Property]
                Dim dpType As String = If(dp.[ReadOnly], "read-only", "read-write")
                ' Test read access.
                Debug.WriteLine($"Attempting to get a {dpType} dependency property value...")
                Debug.WriteLine($"Value ({dpType}): {CInt(_aquarium.GetValue(dp))}")
                ' Test write access.
                Try
                    Debug.WriteLine($"Attempting to set a {dpType} dependency property value to 2...")
                    _aquarium.SetValue(dp, 2)
                Catch e As InvalidOperationException
                    Debug.WriteLine(e.Message)
                Finally
                    Debug.WriteLine($"Value ({dpType}): {CInt(_aquarium.GetValue(dp))}")
                End Try
            End While

            ' Test output

            ' Attempting to get a read-write dependency property value...
            ' Value (read-write): 1
            ' Attempting to set a read-write dependency property value to 2...
            ' Value (read-write): 2

            ' Attempting to get a read-only dependency property value...
            ' Value (read-only): 1
            ' Attempting to set a read-only dependency property value to 2...
            ' 'FishCountReadOnly' property was registered as read-only
            ' and cannot be modified without an authorization key.
            ' Value (read-only): 1
        End Sub

    End Class

    Public Class Aquarium
        Inherits DependencyObject

        Public Sub New()
            ' Assign locally-set values.
            SetValue(FishCountProperty, 1)
            SetValue(FishCountReadOnlyPropertyKey, 1)
        End Sub

        ' Failed attempt to restrict write-access by assigning the
        ' DependencyProperty identifier to a non-public field.
        Private Shared ReadOnly FishCountProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="FishCount",
                propertyType:=GetType(Integer),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New PropertyMetadata())

        ' Successful attempt to restrict write-access by assigning the
        ' DependencyPropertyKey to a non-public field.
        Private Shared ReadOnly FishCountReadOnlyPropertyKey As DependencyPropertyKey =
            DependencyProperty.RegisterReadOnly(
                name:="FishCountReadOnly",
                propertyType:=GetType(Integer),
                ownerType:=GetType(Aquarium),
                typeMetadata:=New PropertyMetadata())

        ' Declare public get accessors.
        Public ReadOnly Property FishCount As Integer
            Get
                Return GetValue(FishCountProperty)
            End Get
        End Property

        Public ReadOnly Property FishCountReadOnly As Integer
            Get
                Return GetValue(FishCountReadOnlyPropertyKey.DependencyProperty)
            End Get
        End Property

    End Class
    '</DependencyPropertyAccessTests>

End Namespace
