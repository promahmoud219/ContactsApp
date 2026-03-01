using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.AddContact
{
    public interface IAddContactUseCase
    {
        Task<OperationResult<AddContactOutput>> ExecuteAsync(AddContactInput input);
    }
}
