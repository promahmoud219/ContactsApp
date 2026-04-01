using ContactsApp.Contracts.Contacts.GetContactById;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.GetContactById;

namespace ContactsApp.WebAPI.Mappings
{
    public static class GetContactByIdMapping
    {
        public static GetContactByIdResponse ToResponse(GetContactByIdOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            return new GetContactByIdResponse(
                output.Id,
                output.FullName,
                output.Phone,
                output.Email,
                output.Address,
                output.CountryName
            );
        }
    }
}                       
