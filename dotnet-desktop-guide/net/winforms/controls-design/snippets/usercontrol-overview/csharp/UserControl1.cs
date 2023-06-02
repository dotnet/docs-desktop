//<default_event>
using System.ComponentModel;

namespace UserControlProject;

[DefaultEvent(nameof(TextChanged))]
public partial class UserControl1 : UserControl
//</default_event>
{
    //<text_changed>
    [Browsable(true)]
    public new event EventHandler? TextChanged
    {
        add => txtValue.TextChanged += value;
        remove => txtValue.TextChanged -= value;
    }
    //</text_changed>

    //<text>
    [Browsable(true)]
    public new string Text
    {
        get => txtValue.Text;
        set => txtValue.Text = value;
    }
    //</text>

    //<title>
    [Browsable(true)]
    public string Title
    {
        get => lblTitle.Text;
        set => lblTitle.Text = value;
    }
    //</title>

    public UserControl1() =>
        InitializeComponent();

    //<click_event>
    private void btnClear_Click(object sender, EventArgs e) =>
        Text = "";
    //</click_event>
}
