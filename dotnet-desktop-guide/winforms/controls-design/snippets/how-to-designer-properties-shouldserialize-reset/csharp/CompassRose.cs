namespace UserControlProject;

// <control>
public partial class CompassRose : UserControl
{
    // <property>
    public Directions Direction { get; set; } = Directions.None;
    // </property>

    public CompassRose() =>
        InitializeComponent();

    // <reset>
    private void ResetDirection() =>
        Direction = Directions.None;
    // </reset>

    // <shouldserialize>
    private bool ShouldSerializeDirection() =>
        Direction != Directions.None;
    // </shouldserialize>
}
// </control>
