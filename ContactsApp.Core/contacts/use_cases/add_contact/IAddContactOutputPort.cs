using ContactsApp.Core.Contacts.UseCases.AddContact;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.AddContact
{
    public interface IAddContactOutputPort
    {
        void Handle(OperationResult<AddContactOutput> result);
    }
}