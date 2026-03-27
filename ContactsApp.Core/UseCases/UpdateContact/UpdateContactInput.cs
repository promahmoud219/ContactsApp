namespace ContactsApp.Core.Contacts.UseCases.UpdateContact
{   
    public record UpdateContactInput(
        int Id,
        string FirstName,
        string LastName,
        string Phone,
        string? Email,
        int CountryId
    );
}                   