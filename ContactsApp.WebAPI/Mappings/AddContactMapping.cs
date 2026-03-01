using ContactsApp.Contracts.Contacts.Responses;
using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.AddContact;

namespace ContactsApp.WebAPI.Mappings
{
    public static class AddContactMapping
    {
        public static AddContactInput ToInput(AddContactRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            
            return new AddContactInput(
                request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Address,
                request.CountryId
            );
        }
        public static AddContactResponse ToResponse(AddContactOutput output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));
            
            return new AddContactResponse(
                output.Id,
                output.FullName,
                output.Phone,
                output.Email,
                output.Address,
                output.CountryId
            );
        }
    }
}   