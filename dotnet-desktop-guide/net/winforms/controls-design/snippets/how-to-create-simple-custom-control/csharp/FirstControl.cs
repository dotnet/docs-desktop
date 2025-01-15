using System.ComponentModel;

namespace UserControlProject;

// <firstcontrol>
public partial class FirstControl : Control
{
    // <field>
    private HorizontalAlignment _textAlignment = HorizontalAlignment.Left;
    // </field>

    // <attributes>
    [Category("Alignment"),
    Description("Specifies the alignment of text."),
    DefaultValue(HorizontalAlignment.Left)]
    // <property>
    public HorizontalAlignment TextAlignment
    // </attributes>
    {
        get => _textAlignment;
        set
        {
            _textAlignment = value;
            Invalidate();
        }
    }
    // </property>

    public FirstControl()
    {
        InitializeComponent();
    }

    // <ontextchanged>
    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        Invalidate();
    }
    // </ontextchanged>

    // <onpaint>
    protected override void OnPaint(PaintEventArgs pe)
    {
        // <stringformat>
        StringFormat style = new();
        // </stringformat>

        // <alignment>
        style.Alignment = _textAlignment switch
        {
            // Map the HorizontalAlignment enum to the StringAlignment enum
            HorizontalAlignment.Left => StringAlignment.Near,
            HorizontalAlignment.Right => StringAlignment.Far,
            HorizontalAlignment.Center => StringAlignment.Center,
            
            // Default to Near alignment
            _ => StringAlignment.Near
        };
        // </alignment>

        // <drawstring>
        // Create the brush, which must be disposed after use
        using SolidBrush foreBrush = new(ForeColor);

        // Call the DrawString method to write text.
        // Text, Font, and ClientRectangle are inherited properties.
        pe.Graphics.DrawString(Text, Font, foreBrush, ClientRectangle, style);

        base.OnPaint(pe);
        // </drawstring>
    }
    // </onpaint>
}
// </firstcontrol>
