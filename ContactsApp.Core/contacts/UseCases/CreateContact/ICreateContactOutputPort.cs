using ContactsApp.Core.Contacts.UseCases.CreateContact;
using ContactsApp.Core.Shared;

namespace ContactsApp.Core.Contacts.UseCases.CreateContact
{
    public interface ICreateContactOutputPort
    {
        void Handle(OperationResult<CreateContactOutput> result);
    }
}