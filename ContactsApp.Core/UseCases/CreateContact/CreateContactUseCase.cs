using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces; 
using ContactsApp.Core.Shared;
using System.Security.Cryptography.X509Certificates;

namespace ContactsApp.Core.Contacts.UseCases.CreateContact
{
    public class CreateContactUseCase : ICreateContactUseCase
    {
        private readonly IContactRepository _repository;

        public CreateContactUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<OperationResult<CreateContactOutput>> ExecuteAsync(CreateContactInput input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));
            try
            {
                var contact = new Contact(
                    input.FirstName, 
                    input.LastName, 
                    input.Phone, 
                    input.Email, 
                    input.Address, 
                    input.CountryId
                );

                await _repository.CreateAsync(contact);

                var output = new CreateContactOutput(
                    contact.Id,
                    $"{contact.FirstName} {contact.LastName}",
                    contact.Phone,
                    contact.Email,
                    contact.Address,
                    contact.CountryId
                );
                var result = new OperationResult<CreateContactOutput>
                (
                    OperationStatus.Success,
                    output,
                    null
                );
                return result;
            }
            catch (ArgumentException ex)
            {
                return new OperationResult<CreateContactOutput>(
                    OperationStatus.ValidationError,
                    null,
                    ex.Message
                );
            }
            catch (Exception ex)
            {
                return new OperationResult<CreateContactOutput>(
                    OperationStatus.Failure,
                    null,
                    ex.Message
                );
            }
        }
    }
}
