namespace ContactsApp.Contracts.Contacts.Requests
{
    public record AddContactRequest
    (
        string FirstName,
        string LastName,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}