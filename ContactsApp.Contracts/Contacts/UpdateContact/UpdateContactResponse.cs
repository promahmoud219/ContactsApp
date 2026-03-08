namespace ContactsApp.Contracts.Contacts.UpdateContact  
{
    public record UpdateContactResponse
    (
        int Id,
        string Name,
        string Phone,
        string? Email
    );
}