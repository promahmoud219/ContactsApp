namespace ContactsApp.Core.Contacts.UseCases.GetAllContacts
{
    public record GetAllContactsOutput(
        int Id,
        string FullName,
        string Phone,
        string? Email,
        string? Address,
        string GovernorateName
    );
}
