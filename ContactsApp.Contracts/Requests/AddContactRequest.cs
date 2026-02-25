namespace ContactsApp.Contracts.Requests
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