using System.ComponentModel;

namespace UserControlProject;

public partial class CompassRose : UserControl
{
    // <defaultvalue>
    [DefaultValue(typeof(Directions), "North")]
    public Directions PointerDirection { get; set; } = Directions.North;

    [DefaultValue(10)]
    public int DistanceInFeet { get; set; } = 10;
    // </defaultvalue>

    // <browsable>
    [Browsable(false)]
    public bool IsSelected { get; set; }
    // </browsable>

    public CompassRose() =>
        InitializeComponent();

    // <shouldserialize_reset>
    public Directions Direction { get; set; } = Directions.None;

    private void ResetDirection() =>
        Direction = Directions.None;

    private bool ShouldSerializeDirection() =>
        Direction != Directions.None;
    // </shouldserialize_reset>
}
