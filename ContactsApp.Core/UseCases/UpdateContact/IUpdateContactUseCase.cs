using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.UpdateContact
{
    public record NoContent();

    public interface IUpdateContactUseCase
    {
        Task<OperationResult<NoContent>> ExecuteAsync(UpdateContactInput input);
    }
}