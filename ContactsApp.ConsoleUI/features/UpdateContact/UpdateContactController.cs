/*
using ContactsApp.ConsoleUI.Views;
using ContactsApp.Core.contacts.entities;
using ContactsApp.Core.contacts.use_cases;
using ContactsApp.ConsoleUI.Presenters;

namespace ContactsApp.ConsoleUI.Features.UpdateContact
{
    public class UpdateContactController
    {
        private readonly IUpdateContactView _view;
        private readonly UpdateContactUseCase _useCase;
        private readonly UpdateContactPresenter _presenter;

        public UpdateContactController(
            IUpdateContactView view,
            UpdateContactUseCase useCase,
            UpdateContactPresenter presenter)
        {
            _view = view;
            _useCase = useCase;
            _presenter = presenter;
        }

        public void Run()
        {
            string nameToUpdate = _view.GetContactNameToUpdate();

            var updatedData = _view.GetUpdatedData();

            bool success = _useCase.Execute(nameToUpdate, updatedData);

            _presenter.ShowUpdateResult(success, nameToUpdate);
        }
    }
}

*/