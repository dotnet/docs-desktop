using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;

namespace TextBlockExample;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CreateInlineExample();
        CreateTypographyExample();
    }

    private void CreateInlineExample()
    {
        // <InlineCode>
        TextBlock textBlock = new TextBlock();
        textBlock.Inlines.Add(new Bold(new Run("Important:")));
        textBlock.Inlines.Add(new Run(" This is a message."));
        // </InlineCode>

        InlineExamplePanel.Children.Add(textBlock);
    }

    private void CreateTypographyExample()
    {
        // <TypographyCode>
        TextBlock textBlock = new TextBlock();
        textBlock.Text = "Typography Features";
        Typography.SetKerning(textBlock, true);
        Typography.SetCapitals(textBlock, FontCapitals.SmallCaps);
        // </TypographyCode>

        TypographyExamplePanel.Children.Add(textBlock);
    }

    // <HyperlinkHandler>
    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = e.Uri.AbsoluteUri,
            UseShellExecute = true
        });
        e.Handled = true;
    }
    // </HyperlinkHandler>
}
