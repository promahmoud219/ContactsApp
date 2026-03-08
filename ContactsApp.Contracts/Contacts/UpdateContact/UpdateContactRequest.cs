namespace ContactsApp.Contracts.Contacts.UpdateContact
{
    public record UpdateContactRequest  
    (
        int ContactId,
        string FirstName,
        string LastName,
        string Phone,
        string? Email
    );
}