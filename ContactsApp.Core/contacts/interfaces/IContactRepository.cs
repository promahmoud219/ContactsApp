using ContactsApp.Core.Contacts.Entities;
//using ContactsApp.Core.Contacts.UseCases.SearchContacts;

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
