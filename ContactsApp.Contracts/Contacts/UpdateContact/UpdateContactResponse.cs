namespace ContactsApp.Contracts.Contacts.UpdateContact  
{
    public record UpdateContactResponse
    (
        int Id,
        string FullName,
        string Phone,
        string? Email
    );
}