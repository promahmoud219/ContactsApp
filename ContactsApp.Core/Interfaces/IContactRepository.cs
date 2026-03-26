using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.ReadModels;
using ContactsApp.Core.Shared;
using System.Threading;
namespace ContactsApp.Core.Contacts.Interfaces
{
    public interface IContactRepository
    {
        Task<int> CreateAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<ContactReadModel?> GetContactByIdAsync(int id);
        Task UpdateAsync(Contact contact);

        //IEnumerable<Contact> SearchContacts(SearchContactsInput input);
        //void UpdateContact(Contact contact);
        //IEnumerable<Contact> GetAll();
    }
}
