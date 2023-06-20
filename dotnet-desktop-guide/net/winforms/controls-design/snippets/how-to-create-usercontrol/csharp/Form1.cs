namespace UserControlProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //<event_handlers>
        private void ctlFirstName_TextChanged(object sender, EventArgs e) =>
            UpdateNameLabel();

        private void ctlLastName_TextChanged(object sender, EventArgs e) =>
            UpdateNameLabel();
        //</event_handlers>

        //<load>
        private void Form1_Load(object sender, EventArgs e) =>
            UpdateNameLabel();
        //</load>

        //<update_label>
        private void UpdateNameLabel()
        {
            if (string.IsNullOrWhiteSpace(ctlFirstName.Text) || string.IsNullOrWhiteSpace(ctlLastName.Text))
                lblFullName.Text = "Please fill out both the first name and the last name.";
            else
                lblFullName.Text = $"Hello {ctlFirstName.Text} {ctlLastName.Text}, I hope you're having a good day.";
        }
        //</update_label>
    }
}
