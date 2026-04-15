using ContactsApp.Contracts.Contacts.GetAllContacts;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.GetAllContacts;

namespace ContactsApp.WebAPI.Mappings
{
    public static class GetAllContactsMapping
    {
        public static List<GetAllContactsResponse> ToResponse(List<GetAllContactsOutput> output)
        {
            ArgumentNullException.ThrowIfNull(output);

            return output.Select(o => new GetAllContactsResponse(
                o.Id,
                o.FullName,
                o.Phone,
                o.Email,
                o.Address,
                o.GovernorateName
            )).ToList();
        }
    }
}
