namespace ClipboardExample;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        // Run the Multiple Formats Clipboard Test form
        Application.Run(new ClipboardMultipleFormatsTest());
        
        // Alternative forms available:
        // Application.Run(new ClipboardTextTest());
        // Application.Run(new FileDropClipboardTest());
        // Application.Run(new Form1());
        // Application.Run(new ClipboardOperations.ClipboardImageTest());
    }
}
