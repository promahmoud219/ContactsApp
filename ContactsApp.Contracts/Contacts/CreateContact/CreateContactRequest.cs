namespace ContactsApp.Contracts.Contacts.CreateContact
{
    public record CreateContactRequest  
    (
        string FirstName,
        string LastName,
        string Phone,
        string? Email,
        string? Address,
        int GovernorateId
    );
}