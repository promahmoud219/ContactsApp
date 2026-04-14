using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.GetAllContacts
{
    public interface IGetAllContactsUseCase
    {
        Task<OperationResult<List<GetAllContactsOutput>>> ExecuteAsync();
    }
}