using ContactsApp.Contracts.Contacts.CreateContact;
using ContactsApp.Contracts.Contacts.GetContactById;
using ContactsApp.ConsoleUI.Results;

namespace ContactsApp.ConsoleUI.Api
{
    public interface IContactsApiClient
    {
        Task<ClientResult<CreateContactResponse?>> CreateContactAsync(CreateContactRequest request);
        Task<ClientResult<NoContent>> DeleteContactAsync(int id);
        Task<ClientResult<GetContactByIdResponse?>> GetContactByIdAsync(int id);
    }
}