using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.GetContactById
{
    public interface IGetContactByIdUseCase
    {
        Task<OperationResult<GetContactByIdOutput>> ExecuteAsync(int id);
    }
}