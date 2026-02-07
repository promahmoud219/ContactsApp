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

internal class Program
{

    static void Main(string[] args)
    {
        DatabaseInitializer.Initialize();

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

        var provider = services.BuildServiceProvider();

        var app = provider.GetRequiredService<ApplicationController>();
        app.Run();
    }
}