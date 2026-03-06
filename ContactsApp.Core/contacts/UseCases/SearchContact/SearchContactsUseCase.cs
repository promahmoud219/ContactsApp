/*
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.SearchContacts;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.SearchContacts
{
    public class SearchContactsUseCase : ISearchContactsUseCase
    {
        private readonly IContactRepository _repository;

        public SearchContactsUseCase(IContactRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public OperationResult<IReadOnlyList<SearchContactsOutput>> Execute(SearchContactsInput input)
        {
            if (input is null)
                throw new ArgumentNullException(nameof(input));

            var contacts = _repository.SearchContacts(input);
            var results = contacts.Select(MapContactToOutput).ToList();
            return OperationResult<IReadOnlyList<SearchContactsOutput>>.Success(results);
        }

        SearchContactsOutput MapContactToOutput(Contact c)
        {
            return new SearchContactsOutput(
                c.Id,
                $"{c.FirstName} {c.LastName}",
                c.Phone,
                c.Email,
                c.Address,
                c.CountryId
            );
        }
    }
}
*/