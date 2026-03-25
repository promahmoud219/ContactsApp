namespace ContactsApp.Contracts.Contacts.CreateContact
{
    public record CreateContactResponse
    (
        int ContactId,
        string Name,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}