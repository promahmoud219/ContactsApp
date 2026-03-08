namespace ContactsApp.Core.Contacts.UseCases.UpdateContact
{   
    public record UpdateContactInput(
        int ContactId,
        string FirstName,
        string LastName,
        string Phone,
        string? Email
    );
}                   