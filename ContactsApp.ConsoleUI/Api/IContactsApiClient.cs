using ContactsApp.ConsoleUI.Features.DeleteContact;
using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.CreateContact;

namespace ContactsApp.ConsoleUI.Api
{
    public interface IContactsApiClient
    {
        Task<ClientResult<CreateContactResponse?>> CreateContactAsync(CreateContactRequest request);
        Task<ClientResult<NoContent>> DeleteContactAsync(int id);

    }
}
