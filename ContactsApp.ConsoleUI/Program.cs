using ContactsApp.ConsoleUI.Application;
using ContactsApp.ConsoleUI.Features.AddContact;
using ContactsApp.ConsoleUI.Features.MainMenu;
using ContactsApp.ConsoleUI.Shared;
using ContactsApp.ConsoleUI.Api; // فيه IContactsApiClient + implementation

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Serilog;

internal class Program
{
    static void Main(string[] args)
    {
        var configuration = BuildConfiguration();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        var services = ConfigureServices(configuration);

        var provider = services.BuildServiceProvider();

        var app = provider.GetRequiredService<ApplicationController>();
        app.Run();
    }

    private static IServiceCollection ConfigureServices(IConfiguration config)
    {
        var services = new ServiceCollection();

        // ===== Http Client Registration =====
        var baseUrl = config["Api:BaseUrl"];

        services.AddHttpClient<IContactsApiClient, ContactsApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl!);
        });

        // ===== Console Features =====
        services.AddTransient<AddContactController>();
        services.AddTransient<IAddContactOutputPort, AddContactOutputPort>();
        services.AddTransient<AddContactView>();
        services.AddTransient<MainMenuView>();

        services.AddSingleton<ApplicationController>();

        services.AddTransient<IShowMessage, ConsoleMessageView>();

        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog();
        });

        return services;
    }

    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables("ContactsApp_")
            .Build();
    }
}