using ContactsApp.ConsoleUI.Api;    
using System;
namespace ContactsApp.ConsoleUI.Features.AddContact
{ 
    public class AddContactController 
    {
        private readonly IContactsApiClient _api;
        private readonly AddContactView _view;

        public AddContactController(IContactsApiClient api, AddContactView view)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task Run()
        {
            while (true)
            {
                var input = _view.Render();
                var result = await _api.AddContactAsync(input);
                _view.ShowMessage(result);

                if (result.IsSuccess)
                    return result;
                if (result.IsValidationError)
                    continue;
                if (result.IsFailure)
                    return result;
            }
        }
    }
}