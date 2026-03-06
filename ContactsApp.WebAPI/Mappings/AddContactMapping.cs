using ContactsApp.Contracts.Contacts.CreateContact;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.CreateContact;

namespace ContactsApp.WebAPI.Mappings
{
    public static class CreateContactMapping
    {
        public static CreateContactInput ToInput(CreateContactRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            return new CreateContactInput(
                request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Address,
                request.CountryId
            );
        }
        public static CreateContactResponse ToResponse(CreateContactOutput output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            return new CreateContactResponse(
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