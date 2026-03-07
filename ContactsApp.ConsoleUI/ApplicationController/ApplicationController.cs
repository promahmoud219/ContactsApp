using ContactsApp.ConsoleUI.Features.CreateContact;
using ContactsApp.ConsoleUI.Features.DeleteContact;
using ContactsApp.ConsoleUI.Features.GetContactById;
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
        private readonly CreateContactController _createController;
        private readonly DeleteContactController _deleteController;
        private readonly GetContactByIdController _getByIdController;
        private readonly GetContactByIdView _getByIdView;
        private readonly DeleteContactView _deleteView;


        public ApplicationController(
            MainMenuView mainMenuView,
            CreateContactController createController,
            DeleteContactController deleteController,
            GetContactByIdController getByIdController,
            GetContactByIdView getContactByIdView,
            DeleteContactView deleteView,
            IShowMessage messageView)
        {
            _mainMenuView = mainMenuView;
            _createController = createController;
            _deleteController = deleteController;
            _getByIdController = getByIdController;
            _getByIdView = getContactByIdView;
            _deleteView = deleteView;
            _messageView = messageView;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                var choice = _mainMenuView.ShowMenuAndGetChoice();

                switch (choice)
                {
                    case MainMenuView.MenuChoice.CreateContact:
                        await HandleCreateContactFlow();
                        break;
                    case MainMenuView.MenuChoice.DeleteContact:
                        await HandleDeleteContactFlow();
                        break;
                    case MainMenuView.MenuChoice.GetContactById:
                        await HandleGetContactByIdFlow();
                        break;
                }
            }
        }

        private async Task HandleCreateContactFlow()
        {
            var result = await _createController.RunAsync();

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

        private async Task HandleDeleteContactFlow()
        {

            // i will implement this when i finish search feature:
            //var contacts = await _searchController.Run();
            //var selected = _selectContactView.Select(contacts);
            //var confirmed = _confirmDeleteView.Confirm(selected);

            var result = await _deleteController.RunAsync();
            if (result.IsSuccess)
            {
                _messageView.ShowMessage("Contact deleted successfully!", ConsoleColor.Green);
                return;
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

        private async Task HandleGetContactByIdFlow()
        {
            var result = await _getByIdController.RunAsync();

            if (result.Data is not null)
            {
                _messageView.ShowMessage("Contact retrieved successfully!", ConsoleColor.Green);
                _getByIdView.DisplayContact(result.Data);
                return;
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