using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project;

public partial class FormInvokeSync : Form
{
    public FormInvokeSync()
    {
        InitializeComponent();
    }

    //<Good>
    private void button1_Click(object sender, EventArgs e)
    {
        WriteTextSafe("Writing message #1");
        _ = Task.Run(() => WriteTextSafe("Writing message #2"));
    }

    public void WriteTextSafe(string text)
    {
        if (textBox1.InvokeRequired)
            textBox1.Invoke(() => WriteTextSafe($"{text} (NON-UI THREAD)"));

        else
            textBox1.Text += $"{Environment.NewLine}{text}";
    }
    //</Good>

    //<Bad>
    private void button2_Click(object sender, EventArgs e)
    {
        WriteTextUnsafe("Writing message #1 (UI THREAD)");
        _ = Task.Run(() => WriteTextUnsafe("Writing message #2 (OTHER THREAD)"));
    }

    private void WriteTextUnsafe(string text) =>
        textBox1.Text += $"{Environment.NewLine}{text}";
    //</Bad>
}
