namespace WinFormsApp3;

// <CreateParams>
public partial class CustomControl1 : Control
{
    protected override CreateParams CreateParams
    {
        get
        {
            // Set this style BEFORE base.CreateParams is created and returned.
            SetStyle(ControlStyles.ApplyThemingImplicitly, true);

            CreateParams cp = base.CreateParams;
            
            // Other logic
            return cp;
        }
    }

    // Base class constructor is going to read CreateParams property
    // before your constructor code runs.
    public CustomControl1()  
    {
        // At this point, CreateParams property is already read, you
        // can't set ApplyThemingImplicitly here.
        InitializeComponent();
    }
}
// </CreateParams>
