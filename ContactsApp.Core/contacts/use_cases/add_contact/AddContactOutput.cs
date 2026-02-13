namespace ContactsApp.Core.Contacts.UseCases.AddContact
{
    public record AddContactOutput(
        Guid Id,
        string FullName,
        string Phone,
        string? Email,
        string? Address,
        int CountryId
    );
}
