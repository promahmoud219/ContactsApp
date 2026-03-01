using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Contracts.Contacts.Responses;
using ContactsApp.ConsoleUI.Results;

namespace ContactsApp.ConsoleUI.Api
{
    public interface IContactsApiClient
    {
        Task<ClientResult<AddContactResponse?>> AddContactAsync(AddContactRequest request);
    }
}
