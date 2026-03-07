namespace ContactsApp.Core.Contacts.UseCases.CreateContact
{
    public record CreateContactOutput(
        int Id,
        string FullName,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}
