using System.Drawing.Drawing2D;

namespace MyExampleProject;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void Button1_Click(object sender, EventArgs e)
    {
        label1.Text = "Starting....";
        await label1.InvokeAsync(ChangeLabel);
        //Form1 secondForm = new();
        //await secondForm.ShowDialogAsync();
        label1.Text = "Done";
        
    }

    void ChangeLabel()
    {
        for (int i = 0; i < 5; i++)
        {
            label1.Text = $"Counting down {6 - i} seconds..";
            Task.Delay(1000);
        }
    }
}
