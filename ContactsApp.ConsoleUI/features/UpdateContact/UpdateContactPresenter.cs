/*
using ContactsApp.ConsoleUI.Views;

namespace ContactsApp.ConsoleUI.Features.UpdateContact
{
    public class UpdateContactPresenter
    {
        private readonly IUpdateContactView _view;

        public UpdateContactPresenter(IUpdateContactView view)
        {
            _view = view;
        }

        public void ShowUpdateResult(bool success, string contactName)
        {
            if (success)
                _view.ShowMessage($"? Contact '{contactName}' updated successfully!");
            else
                _view.ShowMessage($"? Failed to update contact '{contactName}'. Contact not found.");
        }
    }
}
*/