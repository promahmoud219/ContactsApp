using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.AddContact;

using ContactsApp.Infrastructure.Data;
using ContactsApp.Infrastructure.Repositories;

using ContactsApp.ConsoleUI;
using ContactsApp.ConsoleUI.Application; 
using ContactsApp.ConsoleUI.Shared; 
using ContactsApp.ConsoleUI.Features.AddContact;
using ContactsApp.ConsoleUI.Features.MainMenu;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Serilog;

internal class Program
{

    static void Main(string[] args)
    {


        DatabaseInitializer.Initialize();
        
        var services = ConfigureServices();
        var provider = services.BuildServiceProvider();
        
        var app = provider.GetRequiredService<ApplicationController>();
        
        app.Run();
    }

    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();

        // Core / Infra
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<IAddContactUseCase, AddContactUseCase>();

        // AddContact feature (Console)
        services.AddTransient<AddContactController>();
        services.AddTransient<IAddContactOutputPort, AddContactOutputPort>();
        services.AddTransient<AddContactView>();

        services.AddTransient<MainMenuView>();

        services.AddSingleton<ApplicationController>();

        // Shared
        services.AddTransient<IShowMessage, ConsoleMessageView>();

        // logging
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog();
        });
            
        return services;
    }

    public IConfiguration BuildConfiguration()
    {

        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables("ContactsApp_")
            .Build();
    }
}