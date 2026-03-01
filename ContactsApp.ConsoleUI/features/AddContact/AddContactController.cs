using ContactsApp.ConsoleUI.Api;
using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Contracts.Contacts.Responses;
using System;
using System.Net;
using System.Threading.Tasks;

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

        public async Task<ClientResult<AddContactResponse?>> RunAsync()
        { 
            var request = _view.Render();
            var result = await _api.AddContactAsync(request);
            return result;
        }
    }
}