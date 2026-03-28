namespace ContactsApp.Contracts.Contacts.GetContactById
{
    public record GetContactByIdResponse(
        int Id,
        string FullName,
        string Phone, 
        string? Email,
        string? Address,
        string Country
    );
}