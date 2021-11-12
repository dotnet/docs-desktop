Namespace CodeSampleVb

    ' <summary>
    ' Interaction logic for MainWindow.xaml.
    ' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub RunTests(sender As Object, e As RoutedEventArgs)
            TestValidationBehavior()
            TestCoercionBehavior()
            TestGetValueSource()
        End Sub

        '<TestValueValidationScenario>
        Public Shared Sub TestValidationBehavior()
            Dim gauge As New Gauge1()

            Debug.WriteLine($"Test value validation scenario:")

            ' Set allowed value.
            gauge.CurrentReading = 5
            Debug.WriteLine($"Current reading: {gauge.CurrentReading}")

            Try
                ' Set disallowed value.
                gauge.CurrentReading = Double.PositiveInfinity
            Catch e As ArgumentException
                Debug.WriteLine($"Exception thrown by ValidateValueCallback: {e.Message}")
            End Try

            Debug.WriteLine($"Current reading: {gauge.CurrentReading}")

            ' Current reading: 5
            ' Exception thrown by ValidateValueCallback: '∞' is not a valid value for property 'CurrentReading'.
            ' Current reading 5
        End Sub
        '</TestValueValidationScenario>

        '<TestCurrentMinMaxScenario>
        Public Shared Sub TestCoercionBehavior()

            ' Set initial values.
            Dim gauge As New Gauge2 With {
                .MinReading = 0,
                .MaxReading = 10,
                .CurrentReading = 5
            }

            Debug.WriteLine($"Test current/min/max values scenario:")

            ' Current reading is not coerced.
            Debug.WriteLine($"Current reading: " &
                $"{gauge.CurrentReading} (min={gauge.MinReading}, max={gauge.MaxReading})")

            ' Current reading is coerced to max value.
            gauge.MaxReading = 3
            Debug.WriteLine($"Current reading: " &
                $"{gauge.CurrentReading} (min={gauge.MinReading}, max={gauge.MaxReading})")

            ' Current reading is coerced, but tracking back to the desired value.
            gauge.MaxReading = 4
            Debug.WriteLine($"Current reading: " &
                $"{gauge.CurrentReading} (min={gauge.MinReading}, max={gauge.MaxReading})")

            ' Current reading reverts to the desired value.
            gauge.MaxReading = 10
            Debug.WriteLine($"Current reading: " &
                $"{gauge.CurrentReading} (min={gauge.MinReading}, max={gauge.MaxReading})")

            ' Current reading remains at the desired value.
            gauge.MinReading = 5
            gauge.MaxReading = 5
            Debug.WriteLine($"Current reading: " &
                $"{gauge.CurrentReading} (min={gauge.MinReading}, max={gauge.MaxReading})")

            ' Current reading: 5 (min=0, max=10)
            ' Current reading: 3 (min=0, max=3)
            ' Current reading: 4 (min=0, max=4)
            ' Current reading: 5 (min=0, max=10)
            ' Current reading: 5 (min=5, max=5)
        End Sub
        '</TestCurrentMinMaxScenario>

        '<TestGetValueSourceScenario>
        Public Shared Sub TestGetValueSource()

            Dim gauge As New Gauge3 With {
                .CurrentReading = 5
            }

            Debug.WriteLine($"Test GetValueSource scenario:")

            ' Locally set value.
            gauge.CurrentReading = 7

            ' Locally set value is rejected.
            Debug.WriteLine($"Current reading: " &
                $"{gauge.CurrentReading}")

            ' Current reading: 5
        End Sub
        '</TestGetValueSourceScenario>

    End Class

    '<ValueValidationScenario>
    Public Class Gauge1
        Inherits Control

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared ReadOnly CurrentReadingProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="CurrentReading",
                propertyType:=GetType(Double),
                ownerType:=GetType(Gauge1),
                typeMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=Double.NaN,
                    flags:=FrameworkPropertyMetadataOptions.AffectsMeasure),
                validateValueCallback:=New ValidateValueCallback(AddressOf IsValidReading))

        Public Property CurrentReading As Double
            Get
                Return GetValue(CurrentReadingProperty)
            End Get
            Set(value As Double)
                SetValue(CurrentReadingProperty, value)
            End Set
        End Property

        Public Shared Function IsValidReading(value As Object) As Boolean
            Dim val As Double = value
            Return Not val.Equals(Double.NegativeInfinity) AndAlso
                Not val.Equals(Double.PositiveInfinity)
        End Function

    End Class
    '</ValueValidationScenario>

    '<CurrentMinMaxScenario>
    Public Class Gauge2
        Inherits Control

        Public Sub New()
            MyBase.New()
        End Sub

        ' Register a dependency property with the specified property name,
        ' property type, owner type, property metadata, And callbacks.
        Public Shared ReadOnly CurrentReadingProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="CurrentReading",
                propertyType:=GetType(Double),
                ownerType:=GetType(Gauge2),
                typeMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=Double.NaN,
                    flags:=FrameworkPropertyMetadataOptions.AffectsMeasure,
                    propertyChangedCallback:=New PropertyChangedCallback(AddressOf OnCurrentReadingChanged),
                    coerceValueCallback:=New CoerceValueCallback(AddressOf CoerceCurrentReading)),
                validateValueCallback:=New ValidateValueCallback(AddressOf IsValidReading))

        ' CLR wrapper with get/set accessors.
        Public Property CurrentReading As Double
            Get
                Return GetValue(CurrentReadingProperty)
            End Get
            Set(value As Double)
                SetValue(CurrentReadingProperty, value)
            End Set
        End Property

        ' Validate-value callback.
        Public Shared Function IsValidReading(value As Object) As Boolean
            Dim val As Double = value
            Return Not val.Equals(Double.NegativeInfinity) AndAlso Not val.Equals(Double.PositiveInfinity)
        End Function

        ' Property-changed callback.
        Private Shared Sub OnCurrentReadingChanged(depObj As DependencyObject, e As DependencyPropertyChangedEventArgs)
            depObj.CoerceValue(MinReadingProperty)
            depObj.CoerceValue(MaxReadingProperty)
        End Sub

        ' Coerce-value callback.
        Private Shared Function CoerceCurrentReading(depObj As DependencyObject, value As Object) As Object
            Dim gauge As Gauge2 = CType(depObj, Gauge2)
            Dim currentVal As Double = value
            currentVal = If(currentVal < gauge.MinReading, gauge.MinReading, currentVal)
            currentVal = If(currentVal > gauge.MaxReading, gauge.MaxReading, currentVal)
            Return currentVal
        End Function

        '<MinMaxReadingProperty>
        Public Shared ReadOnly MaxReadingProperty As DependencyProperty =
            DependencyProperty.Register(
            name:="MaxReading",
            propertyType:=GetType(Double),
            ownerType:=GetType(Gauge2),
            typeMetadata:=New FrameworkPropertyMetadata(
                defaultValue:=Double.NaN,
                flags:=FrameworkPropertyMetadataOptions.AffectsMeasure,
                propertyChangedCallback:=New PropertyChangedCallback(AddressOf OnMaxReadingChanged),
                coerceValueCallback:=New CoerceValueCallback(AddressOf CoerceMaxReading)),
            validateValueCallback:=New ValidateValueCallback(AddressOf IsValidReading))

        ' CLR wrapper with get/set accessors.
        Public Property MaxReading As Double
            Get
                Return GetValue(MaxReadingProperty)
            End Get
            Set(value As Double)
                SetValue(MaxReadingProperty, value)
            End Set
        End Property

        ' Property-changed callback.
        Private Shared Sub OnMaxReadingChanged(depObj As DependencyObject, e As DependencyPropertyChangedEventArgs)
            depObj.CoerceValue(MinReadingProperty)
            depObj.CoerceValue(CurrentReadingProperty)
        End Sub

        ' Coerce-value callback.
        Private Shared Function CoerceMaxReading(depObj As DependencyObject, value As Object) As Object
            Dim gauge As Gauge2 = CType(depObj, Gauge2)
            Dim maxVal As Double = value
            Return If(maxVal < gauge.MinReading, gauge.MinReading, maxVal)
        End Function

        ' Register a dependency property with the specified property name,
        ' property type, owner type, property metadata, And callbacks.
        Public Shared ReadOnly MinReadingProperty As DependencyProperty =
            DependencyProperty.Register(
            name:="MinReading",
            propertyType:=GetType(Double),
            ownerType:=GetType(Gauge2),
            typeMetadata:=New FrameworkPropertyMetadata(
                defaultValue:=Double.NaN,
                flags:=FrameworkPropertyMetadataOptions.AffectsMeasure,
                propertyChangedCallback:=New PropertyChangedCallback(AddressOf OnMinReadingChanged),
                coerceValueCallback:=New CoerceValueCallback(AddressOf CoerceMinReading)),
            validateValueCallback:=New ValidateValueCallback(AddressOf IsValidReading))

        ' CLR wrapper with get/set accessors.
        Public Property MinReading As Double
            Get
                Return GetValue(MinReadingProperty)
            End Get
            Set(value As Double)
                SetValue(MinReadingProperty, value)
            End Set
        End Property

        ' Property-changed callback.
        Private Shared Sub OnMinReadingChanged(depObj As DependencyObject, e As DependencyPropertyChangedEventArgs)
            depObj.CoerceValue(MaxReadingProperty)
            depObj.CoerceValue(CurrentReadingProperty)
        End Sub

        ' Coerce-value callback.
        Private Shared Function CoerceMinReading(depObj As DependencyObject, value As Object) As Object
            Dim gauge As Gauge2 = CType(depObj, Gauge2)
            Dim minVal As Double = value
            Return If(minVal > gauge.MaxReading, gauge.MaxReading, minVal)
        End Function
        '</MinMaxReadingProperty>

    End Class
    '</CurrentMinMaxScenario>

    Public Class Gauge3
        Inherits Control

        Public Sub New()
            MyBase.New()
        End Sub

        ' Register a dependency property with the specified property name,
        ' property type, owner type, property metadata, And callbacks.
        Public Shared ReadOnly CurrentReadingProperty As DependencyProperty =
            DependencyProperty.Register(
                name:="CurrentReading",
                propertyType:=GetType(Double),
                ownerType:=GetType(Gauge3),
                typeMetadata:=New FrameworkPropertyMetadata(
                    defaultValue:=Double.NaN,
                    flags:=FrameworkPropertyMetadataOptions.AffectsMeasure,
                    propertyChangedCallback:=Nothing,
                    coerceValueCallback:=New CoerceValueCallback(AddressOf CoerceCurrentReading)))

        ' CLR wrapper with get/set accessors.
        Public Property CurrentReading As Double
            Get
                Return GetValue(CurrentReadingProperty)
            End Get
            Set(value As Double)
                SetValue(CurrentReadingProperty, value)
            End Set
        End Property

        '<GetValueSourceScenario>
        ' Coerce-value callback.
        Private Shared Function CoerceCurrentReading(depObj As DependencyObject, value As Object) As Object
            ' Get value source.
            Dim valueSource As ValueSource =
                DependencyPropertyHelper.GetValueSource(depObj, CurrentReadingProperty)

            ' Reject any property value that's a locally set value.
            Return If(valueSource.BaseValueSource = BaseValueSource.Local, DependencyProperty.UnsetValue, value)
        End Function
        '</GetValueSourceScenario>

    End Class

End Namespace
