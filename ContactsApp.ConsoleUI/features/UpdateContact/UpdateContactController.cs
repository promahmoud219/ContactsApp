using ContactsApp.ConsoleUI.Api;
using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.UpdateContact;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ContactsApp.ConsoleUI.Features.UpdateContact
{
    public class UpdateContactController
    {
        private readonly IContactsApiClient _api;
        private readonly UpdateContactView _view;

        public UpdateContactController(IContactsApiClient api, UpdateContactView view)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task<ClientResult<UpdateContactResponse?>> RunAsync()
        {
            var request = _view.Render();
            return await _api.UpdateContactAsync(request.Id, request);
        }
    }
}