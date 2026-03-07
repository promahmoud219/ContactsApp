using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.ReadModels;
using ContactsApp.Core.Contacts.UseCases.CreateContact;
using ContactsApp.Core.Shared;
using System.Threading;
namespace ContactsApp.Core.Contacts.Interfaces
{
    public interface IContactRepository
    {
        Task CreateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
        Task<ContactReadModel?> GetContactDetailsByIdAsync(int id);

        //IEnumerable<Contact> SearchContacts(SearchContactsInput input);
        //void UpdateContact(Contact contact);
        //IEnumerable<Contact> GetAll();
    }
}
