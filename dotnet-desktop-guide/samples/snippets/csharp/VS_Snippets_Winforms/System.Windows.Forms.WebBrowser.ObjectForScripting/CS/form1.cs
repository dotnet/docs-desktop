//<snippet0>
using System;
using System.Windows.Forms;

public class Form1 : Form
{
    private WebBrowser webBrowser1 = new WebBrowser();
    private Button button1 = new Button();

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }

    public Form1()
    {
        button1.Text = "call script code from client code";
        button1.Dock = DockStyle.Top;
        button1.Click += new EventHandler(button1_Click);
        webBrowser1.Dock = DockStyle.Fill;
        Controls.Add(webBrowser1);
        Controls.Add(button1);
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        //<snippet1>
        webBrowser1.AllowWebBrowserDrop = false;
        //</snippet1>
        //<snippet2>
        webBrowser1.IsWebBrowserContextMenuEnabled = false;
        //</snippet2>
        //<snippet3>
        webBrowser1.WebBrowserShortcutsEnabled = false;
        //</snippet3>
        //<snippet4>
        webBrowser1.ObjectForScripting = new MyScriptObject(this);
        //</snippet4>
        //<snippet9>
        // Uncomment the following line when you are finished debugging.
        //webBrowser1.ScriptErrorsSuppressed = true;
        //</snippet9>

        webBrowser1.DocumentText =
            "<html><head><script>" +
            "function test(message) { alert(message); }" +
            "</script></head><body><button " +
            "onclick=\"window.external.Test('called from script code')\">" +
            "call client code from script code</button>" +
            "</body></html>";
    }

    private void button1_Click(object sender, EventArgs e)
    {
        //<snippet8>
        webBrowser1.Document.InvokeScript("test",
            new String[] { "called from client code" });
        //</snippet8>
    }
}

//<snippet5>
public class MyScriptObject
{
    private Form1 _form;

    public MyScriptObject(Form1 form)
    {
        _form = form;
    }

    public void Test(string message)
    {
        MessageBox.Show(message, "client code");
    }
}
//</snippet5>
//</snippet0>