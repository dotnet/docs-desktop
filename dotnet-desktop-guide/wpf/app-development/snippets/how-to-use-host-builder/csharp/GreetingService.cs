using Microsoft.Extensions.Configuration;

namespace HostBuilderApp;

// <GreetingService>
public class GreetingService(IConfiguration configuration) : IGreetingService
{
    public string GetGreeting() =>
        configuration.GetValue<string>("GreetingMessage")
        ?? "Hello from the Generic Host!";
}
// </GreetingService>
