namespace ContactsApp.Contracts.Contacts.GetContactById
{
    public record GetContactByIdResponse(
        int ContactId,
        string Name,
        string Phone,  
        string Country 
    );
}