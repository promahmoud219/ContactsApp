namespace ContactsApp.Contracts.Contacts.Responses
{
    public record AddContactResponse
    (
        Guid Id,
        string FullName,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}