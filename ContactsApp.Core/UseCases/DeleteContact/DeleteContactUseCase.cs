using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Shared;
using ContactsApp.Core.Contacts.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ContactsApp.Core.Contacts.UseCases.DeleteContact
{
    public class DeleteContactUseCase : IDeleteContactUseCase
    {
        private readonly IContactRepository _repository;

        public DeleteContactUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<OperationResult<bool>> ExecuteAsync(int ContactId)
        {
            var deleted = await _repository.DeleteContactAsync(ContactId);

            if (!deleted)
                return OperationResult<bool>.NotFound("Contact not found");

            return OperationResult<bool>.Success(true);
        }
    }
}
