namespace ContactsApp.Contracts.Contacts.CreateContact
{
    public record CreateContactResponse
    (
        int Id,
        string FullName,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}