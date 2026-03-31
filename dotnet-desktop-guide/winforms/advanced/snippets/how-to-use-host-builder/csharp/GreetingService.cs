using Microsoft.Extensions.Configuration;

namespace HostBuilderApp;

// <GreetingService>
public class GreetingService : IGreetingService
{
    private readonly IConfiguration _configuration;

    public GreetingService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetGreeting()
    {
        return _configuration.GetValue<string>("GreetingMessage")
            ?? "Hello, World!";
    }
}
// </GreetingService>
