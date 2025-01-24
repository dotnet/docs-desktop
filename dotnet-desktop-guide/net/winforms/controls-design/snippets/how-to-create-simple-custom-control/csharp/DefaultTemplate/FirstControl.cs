using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlProject.DefaultTemplate;

// <template>
public partial class FirstControl : Control
{
    public FirstControl()
    {
        InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);
    }
}
// </template>

public class SomethingElse : Control
{
    private HorizontalAlignment _textAlignment = HorizontalAlignment.Left;

    [System.ComponentModel.Category("Alignment"),
    System.ComponentModel.Description("Specifies the alignment of text."),
    System.ComponentModel.DefaultValue(HorizontalAlignment.Left)]
    // <property>
    public HorizontalAlignment TextAlignment
    {
        get => _textAlignment;
        set
        {
            _textAlignment = value;
            Invalidate();
        }
    }
    // </property>
}
