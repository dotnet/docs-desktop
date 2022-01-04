Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            TestUnsafeConstructorPattern()
        End Sub

        '<TestUnsafeConstructorPattern>
        Private Shared Sub TestUnsafeConstructorPattern()
            'Aquarium aquarium = new Aquarium();
            'Debug.WriteLine($"Aquarium temperature (C): {aquarium.TempCelcius}");

            ' Instantiate And set tropical aquarium temperature.
            Dim tropicalAquarium As New TropicalAquarium(tempCelc:=25)
            Debug.WriteLine($"Tropical aquarium temperature (C): 
                {tropicalAquarium.TempCelcius}")

            ' Test output:
            ' Derived class static constructor running.
            ' Base class ValidateValueCallback running.
            ' Base class ValidateValueCallback running.
            ' Base class ValidateValueCallback running.
            ' Base class parameterless constructor running.
            ' Base class ValidateValueCallback running.
            ' Derived class CoerceValueCallback running.
            ' Derived class CoerceValueCallback: null reference exception.
            ' Derived class OnPropertyChanged event running.
            ' Derived class OnPropertyChanged event: null reference exception.
            ' Derived class PropertyChangedCallback running.
            ' Derived class PropertyChangedCallback: null reference exception.
            ' Aquarium temperature(C):  20
            ' Derived class parameterless constructor running.
            ' Derived class parameter constructor running.
            ' Base class ValidateValueCallback running.
            ' Derived class CoerceValueCallback running.
            ' Derived class OnPropertyChanged event running.
            ' Derived class PropertyChangedCallback running.
            ' Tropical Aquarium temperature (C): 25

        End Sub
    End Class

    Public Class Aquarium
        Inherits DependencyObject

        'Register a dependency property with the specified property name,
        ' property type, owner type, property metadata with default value,
        ' and validate-value callback.
        Public Shared ReadOnly TempCelciusProperty As DependencyProperty =
            DependencyProperty.Register(
            name:="TempCelcius",
            propertyType:=GetType(Integer),
            ownerType:=GetType(Aquarium),
            typeMetadata:=New PropertyMetadata(defaultValue:=0),
            validateValueCallback:=
                New ValidateValueCallback(AddressOf ValidateValueCallback))

        ' Parameterless constructor.
        Public Sub New()
            Debug.WriteLine("Base class parameterless constructor running.")

            ' Set typical aquarium temperature.
            TempCelcius = 20

            Debug.WriteLine($"Aquarium temperature (C): {TempCelcius}")
        End Sub

        ' Declare public read-write accessors.
        Public Property TempCelcius As Integer
            Get
                Return GetValue(TempCelciusProperty)
            End Get
            Set(value As Integer)
                SetValue(TempCelciusProperty, value)
            End Set
        End Property

        ' Validate-value callback.
        Public Shared Function ValidateValueCallback(value As Object) As Boolean
            Debug.WriteLine("Base class ValidateValueCallback running.")
            Dim val As Double = CInt(value)
            Return val >= 0
        End Function

    End Class

    Public Class TropicalAquarium
        Inherits Aquarium

        ' Class field.
        Private Shared s_temperatureLog As List(Of Integer)

        ' Static constructor.
        Shared Sub New()
            Debug.WriteLine("Derived class static constructor running.")

            ' Create a new metadata instance with callbacks specified.
            Dim newPropertyMetadata As New PropertyMetadata(
                    defaultValue:=0,
                    propertyChangedCallback:=
                        New PropertyChangedCallback(AddressOf PropertyChangedCallback),
                    coerceValueCallback:=
                        New CoerceValueCallback(AddressOf CoerceValueCallback))

            ' Call OverrideMetadata on the dependency property identifier.
            TempCelciusProperty.OverrideMetadata(
                    forType:=GetType(TropicalAquarium),
                    typeMetadata:=newPropertyMetadata)
        End Sub

        ' Parameterless constructor.
        Public Sub New()
            Debug.WriteLine("Derived class parameterless constructor running.")
            s_temperatureLog = New List(Of Integer)()
        End Sub

        ' Parameter constructor.
        Public Sub New(tempCelc As Integer)
            Me.New()
            Debug.WriteLine("Derived class parameter constructor running.")
            TempCelcius = tempCelc
            s_temperatureLog.Add(TempCelcius)
        End Sub

        ' Property-changed callback.
        Private Shared Sub PropertyChangedCallback(depObj As DependencyObject,
            e As DependencyPropertyChangedEventArgs)
            Debug.WriteLine("Derived class PropertyChangedCallback running.")

            Try
                s_temperatureLog.Add(e.NewValue)
            Catch ex As NullReferenceException
                Debug.WriteLine("Derived class PropertyChangedCallback: null reference exception.")
            End Try
        End Sub

        ' Coerce-value callback.
        Private Shared Function CoerceValueCallback(depObj As DependencyObject, value As Object) As Object
            Debug.WriteLine("Derived class CoerceValueCallback running.")

            Try
                s_temperatureLog.Add(value)
            Catch ex As NullReferenceException
                Debug.WriteLine("Derived class CoerceValueCallback: null reference exception.")
            End Try

            Return value
        End Function

        ' OnPropertyChanged event.
        Protected Overrides Sub OnPropertyChanged(e As DependencyPropertyChangedEventArgs)
            Debug.WriteLine("Derived class OnPropertyChanged event running.")

            Try
                s_temperatureLog.Add(e.NewValue)
            Catch ex As NullReferenceException
                Debug.WriteLine("Derived class OnPropertyChanged event: null reference exception.")
            End Try

            ' Mandatory call to base implementation.
            MyBase.OnPropertyChanged(e)
        End Sub

    End Class
    '</TestUnsafeConstructorPattern>

End Namespace
