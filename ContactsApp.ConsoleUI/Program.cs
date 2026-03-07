using ContactsApp.ConsoleUI.Application;
using ContactsApp.ConsoleUI.Features.CreateContact;
using ContactsApp.ConsoleUI.Features.DeleteContact;
using ContactsApp.ConsoleUI.Features.GetContactById;
using ContactsApp.ConsoleUI.Features.MainMenu;
using ContactsApp.ConsoleUI.Shared;
using ContactsApp.ConsoleUI.Api; // فيه IContactsApiClient + implementation

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Microsoft.Extensions.Configuration;
using Serilog.Settings.Configuration;
 



internal class Program
{
    static async Task Main(string[] args)
    {
        var configuration = BuildConfiguration();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        var services = ConfigureServices(configuration);

        var provider = services.BuildServiceProvider();

        var app = provider.GetRequiredService<ApplicationController>();
        await app.RunAsync();
    }

    private static IServiceCollection ConfigureServices(IConfiguration config)
    {
        var services = new ServiceCollection();
         
        var baseUrl = config["Api:BaseUrl"];

        services.AddHttpClient<IContactsApiClient, ContactsApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl!);
        });

        // ===== Console Features =====
        services.AddTransient<MainMenuView>();
        services.AddTransient<CreateContactController>();
        services.AddTransient<CreateContactView>();
        services.AddTransient<DeleteContactController>();
        services.AddTransient<DeleteContactView>();
        services.AddTransient<GetContactByIdController>();
        services.AddTransient<GetContactByIdView>();

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