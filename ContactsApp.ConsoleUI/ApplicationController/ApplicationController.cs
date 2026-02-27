using ContactsApp.ConsoleUI.Features.AddContact;    
using ContactsApp.ConsoleUI.Features.MainMenu;
using ContactsApp.ConsoleUI.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

namespace ContactsApp.ConsoleUI.Application
{
    public class ApplicationController 
    {
        private readonly MainMenuView _mainMenuView;
        private readonly IShowMessage _messageView;
        private readonly AddContactController _addController;

        public ApplicationController(MainMenuView mainMenuView, AddContactController addController, IShowMessage messageView)
        {
            _mainMenuView = mainMenuView;
            _addController = addController;
            _messageView = messageView;
        }

        public void Run()
        {
            while (true)
            {
                var choice = _mainMenuView.ShowMenuAndGetChoice();

                switch (choice)
                {
                    case MainMenuView.MenuChoice.AddContact:
                        HandleAddContactFlow();
                        break;
                    
                }
            }
        }
        
        private async Task HandleAddContactFlow()
        {
            var result = await _addController.Run();

            if (result.IsSuccess)
            {
                _messageView.ShowMessage("Contact added successfully!", ConsoleColor.Green);
                return;
            }

            if (result.IsValidationError)
            {
                _messageView.ShowMessage($"Validation Error: {result.ErrorMessage}", ConsoleColor.Yellow);
                return;
            }

            _messageView.ShowMessage(result.ErrorMessage ?? "Operation failed.", ConsoleColor.Yellow);
        }
        
        private void HandleExitFlow()
        {
            _messageView.ShowMessage("Exiting application.... Goodbye!", ConsoleColor.Cyan);
            Thread.Sleep(3000);
 
            for (int i = 0; i < 10; i++)
                Console.Beep();
        }
    }
}