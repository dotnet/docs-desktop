namespace CustomControlProject;

//<control>
public partial class CustomControl1 : Button
{
    //<counter>
    private int _counter = 0;
    //</counter>

    public CustomControl1()
    {
        InitializeComponent();
    }

    //<onpaint>
    protected override void OnPaint(PaintEventArgs pe)
    {
        // Draw the control
        base.OnPaint(pe);

        // Paint our string on top of it
        pe.Graphics.DrawString($"Clicked {_counter} times", Font, Brushes.Purple, new PointF(3, 3));
    }
    //</onpaint>

    //<onclick>
    protected override void OnClick(EventArgs e)
    {
        // Increase the counter and redraw the control
        _counter++;
        Invalidate();

        // Call the base method to invoke the Click event
        base.OnClick(e);
    }
    //</onclick>
}
//</control>
