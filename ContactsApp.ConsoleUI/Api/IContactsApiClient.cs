using ContactsApp.Contracts.Contacts.CreateContact;
using ContactsApp.Contracts.Contacts.GetContactById;
using ContactsApp.Contracts.Contacts.UpdateContact;

using ContactsApp.ConsoleUI.Results;
using ContactsApp.ConsoleUI.Features.UpdateContact;

namespace ContactsApp.ConsoleUI.Api
{
    public interface IContactsApiClient
    {
        Task<ClientResult<CreateContactResponse?>> CreateContactAsync(CreateContactRequest request);
        Task<ClientResult<NoContent>> DeleteContactAsync(int id);
        Task<ClientResult<GetContactByIdResponse?>> GetContactByIdAsync(int id);
        Task<ClientResult<UpdateContactResponse?>> UpdateContactAsync(int id, UpdateContactRequest request);
    }
}