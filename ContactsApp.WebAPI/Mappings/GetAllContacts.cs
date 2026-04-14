using ContactsApp.Contracts.Contacts.GetAllContacts;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.GetAllContacts;

namespace ContactsApp.WebAPI.Mappings
{
    public static class GetAllContactsMapping
    {
        public static GetAllContactsResponse ToResponse(List<GetAllContactsOutput> output)
        {
            ArgumentNullException.ThrowIfNull(output);

            return new GetAllContactsResponse(
                output.Select(o => new GetAllContactsResponse.ContactDto
                {
                    Id = o.Id,
                    FullName = o.FullName,
                    Phone = o.Phone,
                    Email = o.Email,
                    Address = o.Address,
                    GovernorateName = o.GovernorateName
                }).ToList()
            );
        }
    }
}
