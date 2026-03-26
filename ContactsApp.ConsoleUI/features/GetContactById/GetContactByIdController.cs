using ContactsApp.ConsoleUI.Shared;
using ContactsApp.ConsoleUI.Api;
using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.GetContactById;


namespace ContactsApp.ConsoleUI.Features.GetContactById
{
    public class GetContactByIdController
    {
        private readonly IContactsApiClient _api;
        private readonly GetContactByIdView _view;
        public GetContactByIdController(IContactsApiClient api, GetContactByIdView view) {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
        public async Task<ClientResult<GetContactByIdResponse>> RunAsync()
        {
            int id = _view.GetId();
            return await _api.GetContactByIdAsync(id);
        }
    }
}