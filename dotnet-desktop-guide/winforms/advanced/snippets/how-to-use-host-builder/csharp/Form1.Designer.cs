namespace HostBuilderApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblGreeting = new Label();
        btnGreet = new Button();
        SuspendLayout();

        // lblGreeting
        lblGreeting.AutoSize = true;
        lblGreeting.Location = new Point(20, 20);
        lblGreeting.Name = "lblGreeting";
        lblGreeting.Size = new Size(200, 15);
        lblGreeting.Text = "";

        // btnGreet
        btnGreet.Location = new Point(20, 50);
        btnGreet.Name = "btnGreet";
        btnGreet.Size = new Size(100, 30);
        btnGreet.Text = "Greet";
        btnGreet.Click += ButtonGreet_Click;

        // Form1
        ClientSize = new Size(300, 120);
        Controls.Add(lblGreeting);
        Controls.Add(btnGreet);
        Name = "Form1";
        Text = "Host Builder App";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblGreeting;
    private Button btnGreet;
}
