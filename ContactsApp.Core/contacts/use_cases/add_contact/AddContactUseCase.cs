using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Shared;
using ContactsApp.Core.Contacts.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace ContactsApp.Core.Contacts.UseCases.AddContact
{
    public class AddContactUseCase : IAddContactUseCase
    {
        private readonly IContactRepository _repository;

        public AddContactUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public OperationResult<AddContactOutput> Execute(AddContactInput input)
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
            
                _repository.AddContact(contact);
            
                var output = new AddContactOutput(
                    contact.Id,
                    $"{contact.FirstName} {contact.LastName}",
                    contact.Phone,
                    contact.Email,
                    contact.Address,
                    contact.CountryId
                );
                var result = new OperationResult<AddContactOutput>
                (
                    OperationStatus.Success,
                    output,
                    null
                );
                return result;
            }
            catch (ArgumentException ex)
            {
                return new OperationResult<AddContactOutput>(
                    OperationStatus.ValidationError,
                    null,
                    ex.Message
                );
            }
            catch (Exception ex)
            {
                return new OperationResult<AddContactOutput>(
                    OperationStatus.Failure,
                    null,
                    ex.Message
                );
            }
        }
    }
}
