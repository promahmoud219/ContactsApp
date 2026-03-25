using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.ReadModels;
using ContactsApp.Core.Shared;
using System.Threading;
namespace ContactsApp.Core.Contacts.Interfaces
{
    public interface IContactRepository
    {
        Task<int> CreateAsync(Contact contact);
        Task DeleteAsync(int ContactId);
        Task<ContactReadModel?> GetByIdAsync(int ContactId);
        Task UpdateAsync(Contact contact);

        //IEnumerable<Contact> SearchContacts(SearchContactsInput input);
        //void UpdateContact(Contact contact);
        //IEnumerable<Contact> GetAll();
    }
}
