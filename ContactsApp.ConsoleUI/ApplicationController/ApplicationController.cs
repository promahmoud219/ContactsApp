using ContactsApp.ConsoleUI.Features.AddContact;    
using ContactsApp.ConsoleUI.Features.MainMenu;
using ContactsApp.ConsoleUI.Shared;
using ContactsApp.ConsoleUI.Results;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Dynamic;

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

        public async Task RunAsync()
        {
            while (true)
            {
                var choice = _mainMenuView.ShowMenuAndGetChoice();

                switch (choice)
                {
                    case MainMenuView.MenuChoice.AddContact:
                        await HandleAddContactFlow();
                        break;
                    
                }
            }
        }
        
        private async Task HandleAddContactFlow()
        {
            var result = await _addController.RunAsync();
 
            if (result.IsSuccess)
            {
                _messageView.ShowMessage("Contact added successfully!", ConsoleColor.Green);
                return;

                // Navigation decision centralized here, i will call _showAllContactsController.RunAsync()
                // to show the updated list of contacts after adding a new one.
                // now it's commented till i implement it. 
                // or i can do this instead: await NavigateToAfterAdd();
                //await _showAllContactsController.RunAsync();
            } 

            switch (result.ErrorType)
            {
                case ClientErrorType.NetworkFailure:
                    _messageView.ShowMessage("Server is down. Please try again later.", ConsoleColor.Red);
                    break;

                case ClientErrorType.Timeout:
                    _messageView.ShowMessage("The request timed out.", ConsoleColor.Yellow);
                    break;

                default:
                    _messageView.ShowMessage(result.ErrorMessage ?? "ApplicationControllerOperation failed.", ConsoleColor.Red);
                    break;
            }
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