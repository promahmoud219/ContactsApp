namespace ContactsApp.Contracts.Contacts.UpdateContact  
{
    public record UpdateContactResponse
    (
        int ContactId,
        string FullName,
        string Phone,
        string? Email
    );
}