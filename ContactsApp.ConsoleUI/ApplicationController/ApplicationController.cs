using ContactsApp.ConsoleUI.Features.AddContact;    
using ContactsApp.ConsoleUI.Features.MainMenu;
using ContactsApp.ConsoleUI.Shared;
using ContactsApp.Core.Shared;
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

        private void HandleAddContactFlow()
        {
            var result = _addController.Run();

            if (result.Status == OperationStatus.Success)
            {
                _messageView.ShowMessage("Contact added successfully!", ConsoleColor.Green);
                return;
            }

            if (result.Status == OperationStatus.ValidationError)
            {
                _messageView.ShowMessage($"Validation Error: {result.ErrorMessage}", ConsoleColor.Yellow);
                return;
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