using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.ReadModels;
using ContactsApp.Core.Shared;
using System.Threading;
namespace ContactsApp.Core.Contacts.Interfaces
{
    public interface IContactRepository
    {
        Task CreateAsync(Contact contact);
        Task<bool> DeleteAsync(int id);
        Task<ContactReadModel?> GetByIdAsync(int id);
        Task UpdateAsync(Contact contact);

        //IEnumerable<Contact> SearchContacts(SearchContactsInput input);
        //void UpdateContact(Contact contact);
        //IEnumerable<Contact> GetAll();
    }
}
