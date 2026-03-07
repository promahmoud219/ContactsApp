using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.CreateContact
{
    public interface ICreateContactUseCase
    {
        Task<OperationResult<CreateContactOutput>> ExecuteAsync(CreateContactInput input);
    }
}
