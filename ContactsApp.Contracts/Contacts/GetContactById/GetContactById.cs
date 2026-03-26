namespace ContactsApp.Contracts.Contacts.GetContactById
{
    public record GetContactByIdResponse(
        int Id,
        string Name,
        string Phone,  
        string Country 
    );
}