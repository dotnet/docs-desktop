using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsProject1
{
    public partial class UserControl1 : UserControl
    {
        //<property_changed>
        // The event
        public event EventHandler AllowInteractionChanged;

        // The backing field for the property
        private bool _allowInteraction;

        // The property
        public bool AllowInteraction
        {
            get => _allowInteraction;
            set
            {
                // When the value has changed, call the method to raise the event
                if (_allowInteraction != value)
                {
                    _allowInteraction = value;
                    OnAllowInteractionChanged();
                }
            }
        }

        // Raises the event
        public virtual void OnAllowInteractionChanged() =>
            AllowInteractionChanged?.Invoke(this, EventArgs.Empty);
        //</property_changed>


        //<eventargs>
        public class ProgressReportEventArgs : EventArgs
        {
            public readonly int Value;
            public readonly int Maximum;

            public ProgressReportEventArgs(int value, int maximum) =>
                (Value, Maximum) = (value, maximum);
        }

        public event EventHandler<ProgressReportEventArgs> ProgressChanged;

        public virtual void OnProgressChanged(int value, int maximum) =>
            ProgressChanged?.Invoke(this, new ProgressReportEventArgs(value, maximum));
        //</eventargs>





        public UserControl1()
        {
            InitializeComponent();
        }


    }
}
