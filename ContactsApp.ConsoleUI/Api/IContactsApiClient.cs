using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Contracts.Contacts.Responses;
namespace ContactsApp.ConsoleUI.Api
{
    public interface IContactsApiClient
    {
        Task<AddContactResponse?> AddContactAsync(AddContactRequest request);
    }
}
