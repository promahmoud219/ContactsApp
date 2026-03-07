using ContactsApp.Contracts.Contacts.GetContactById;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.GetContactById;

namespace ContactsApp.WebAPI.Mappings
{
    public static class GetContactByIdMapping
    {
        public static GetContactByIdResponse ToResponse(GetContactByIdOutput output)
        {
            if (output is null)
                throw new ArgumentNullException(nameof(output));

            return new GetContactByIdResponse(
                output.Id,
                output.FullName,
                output.Phone,
                output.Country
            );
        }
    }
}                       