//<default_event>
using System.ComponentModel;

namespace UserControlProject
{
    [DefaultEvent(nameof(TextChanged))]
    public partial class ClearableTextBox : UserControl
    {
        private Person _mother;

        [Browsable(true)]
        public new event EventHandler? TextChanged
        {
            add => txtValue.TextChanged += value;
            remove => txtValue.TextChanged -= value;
        }
        [Browsable(true)]
        public new string Text
        {
            get => txtValue.Text;
            set => txtValue.Text = value;
        }
        [Browsable(true)]
        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        //<property>
        [Browsable(false)]
        public Person Mother
        {
            get => _mother;
            set => _mother = value;
        }
        //</property>

        public ClearableTextBox() =>
            InitializeComponent();

        private void btnClear_Click(object sender, EventArgs e) =>
            Text = "";
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
