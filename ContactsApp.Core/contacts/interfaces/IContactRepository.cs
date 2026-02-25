using ContactsApp.Core.Contacts.Entities;

namespace ContactsApp.Core.Contacts.Interfaces
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        //IEnumerable<Contact> SearchContacts(SearchContactsInput input);
        //void DeleteContact(Guid id);
        //void UpdateContact(Contact contact);
        //Contact? GetById(Guid id);
        //IEnumerable<Contact> GetAll();
    }
}
