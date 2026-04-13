namespace ContactsApp.Contracts.Contacts.UpdateContact
{
    public record UpdateContactRequest  
    (
        int Id,
        string FirstName,
        string LastName,
        string Phone,
        string? Email,
        string? Address,
        int GovernorateId
    );
}