using ContactsApp.ConsoleUI.Api;
using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.CreateContact;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ContactsApp.ConsoleUI.Features.CreateContact
{
    public class CreateContactController
    {
        private readonly IContactsApiClient _api;
        private readonly CreateContactView _view;

        public CreateContactController(IContactsApiClient api, CreateContactView view)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task<ClientResult<CreateContactResponse?>> RunAsync()
        {
            var request = _view.Render();
            var result = await _api.CreateContactAsync(request);
            return result;
        }
    }
}