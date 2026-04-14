namespace ContactsApp.Contracts.Contacts.GetAllContacts
{
    public record GetAllContactsResponse(
        int Id,
        string FullName,
        string Phone, 
        string? Email,
        string? Address,
        string GovernorateName
    );
}