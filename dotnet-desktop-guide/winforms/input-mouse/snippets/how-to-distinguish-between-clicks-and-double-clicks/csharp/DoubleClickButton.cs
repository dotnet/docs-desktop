using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    //<DoubleClickButton>
    public partial class DoubleClickButton : Button
    {
        public DoubleClickButton()
        {
            // Set the style so a double click event occurs.
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }
    //</DoubleClickButton>
}
