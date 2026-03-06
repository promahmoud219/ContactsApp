namespace ContactsApp.Core.Contacts.UseCases.CreateContact
{   
    public record CreateContactInput(
        string FirstName,
        string LastName,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}                   