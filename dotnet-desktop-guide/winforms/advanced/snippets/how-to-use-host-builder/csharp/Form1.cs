using Microsoft.Extensions.Logging;

namespace HostBuilderApp;

// <Form1>
public partial class Form1 : Form
{
    private readonly ILogger<Form1> _logger;
    private readonly IGreetingService _greetingService;

    public Form1(ILogger<Form1> logger, IGreetingService greetingService)
    {
        InitializeComponent();

        _logger = logger;
        _greetingService = greetingService;
    }

    private void ButtonGreet_Click(object sender, EventArgs e)
    {
        string greeting = _greetingService.GetGreeting();
        lblGreeting.Text = greeting;
        _logger.LogInformation("Greeting displayed: {Greeting}", greeting);
    }
}
// </Form1>
