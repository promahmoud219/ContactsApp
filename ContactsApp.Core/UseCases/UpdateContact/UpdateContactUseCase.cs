using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Shared;
using System.Security.Cryptography.X509Certificates;

namespace ContactsApp.Core.Contacts.UseCases.UpdateContact
{
    public class UpdateContactUseCase : IUpdateContactUseCase
    {
        private readonly IContactRepository _repository;

        public UpdateContactUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<OperationResult<NoContent>> ExecuteAsync(UpdateContactInput input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));
            try
            {
                var contact = new Contact(
                    input.Id,
                    input.FirstName, 
                    input.LastName, 
                    input.Phone, 
                    input.Email, 
                    input.CountryId
                );
                await _repository.UpdateAsync( contact ); 

                return new OperationResult<NoContent>
                (
                    OperationStatus.Success,
                    new NoContent(),
                    null
                );
            }
            catch (ArgumentException ex)
            {
                return new OperationResult<NoContent>(
                    OperationStatus.ValidationError,
                    null,
                    ex.Message
                );
            }
            catch (Exception ex)
            {
                return new OperationResult<NoContent>(
                    OperationStatus.Failure,
                    null,
                    ex.Message
                );
            }
        }
    }
}
