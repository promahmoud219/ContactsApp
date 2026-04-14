using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.GetContactById;
using ContactsApp.Core.Shared;
using ContactsApp.Core.Contacts.ReadModels;

namespace ContactsApp.Core.Contacts.UseCases.GetContactById         
{
    public class GetContactByIdUseCase : IGetContactByIdUseCase
    {
        private readonly IContactRepository _repository;

        public GetContactByIdUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<OperationResult<GetContactByIdOutput>> ExecuteAsync(int id)
        { 
            var contactReadModel = await _repository.GetContactByIdAsync(id);
            if (contactReadModel is not ContactReadModel model)
                return OperationResult<GetContactByIdOutput>.NotFound("Contact not found");

            var output = MapContactToOutput(model);
            return OperationResult<GetContactByIdOutput>.Success(output);
        }

        GetContactByIdOutput MapContactToOutput(ContactReadModel c)
        {
            ArgumentNullException.ThrowIfNull(c);

            return new GetContactByIdOutput(
                c.Id,
                $"{c.FirstName} {c.LastName}",
                c.Phone,
                c.Email,
                c.Address,
                c.GovernorateName
            );
        }
    }
}
