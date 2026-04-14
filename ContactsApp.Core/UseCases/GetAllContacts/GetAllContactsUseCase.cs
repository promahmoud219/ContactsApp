using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.ReadModels;
using ContactsApp.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.Core.Contacts.UseCases.GetAllContacts
{
    public class GetAllContactsUseCase : IGetAllContactsUseCase
    {
        private readonly IContactRepository _repository;

        public GetAllContactsUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<OperationResult<List<GetAllContactsOutput>>> ExecuteAsync()
        {
            var contacts = await _repository.GetAllAsync();

            var outputList = contacts
                .Where(c => c != null)  
                .Select(c => MapToOutput(c!))
                .ToList();

            return OperationResult<List<GetAllContactsOutput>>.Success(outputList);
        }

        private GetAllContactsOutput MapToOutput(ContactDetails c)
        {
            return new GetAllContactsOutput(
                c.Id,
                c.FullName,
                c.Phone,
                c.Email,
                c.Address,
                c.GovernorateName
            );
        }
    }
}