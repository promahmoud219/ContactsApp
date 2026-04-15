using ContactsApp.Contracts.Contacts.UpdateContact;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.UpdateContact;

namespace ContactsApp.WebAPI.Mappings
{
    public static class UpdateContactMapping
    {
        public static UpdateContactInput ToInput(UpdateContactRequest request, int id)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return new UpdateContactInput(
                id,
                request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Address,
                request.GovernorateId
            );
        }
 
    }
                 
}   