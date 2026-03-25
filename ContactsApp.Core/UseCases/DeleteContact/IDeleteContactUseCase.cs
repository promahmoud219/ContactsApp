using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.DeleteContact
{
    public interface IDeleteContactUseCase
    {
        Task<OperationResult<bool>> ExecuteAsync(int ContactId);
    }
}
