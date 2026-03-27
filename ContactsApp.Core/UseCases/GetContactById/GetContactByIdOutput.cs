namespace ContactsApp.Core.Contacts.UseCases.GetContactById
{
    public record GetContactByIdOutput(
        int Id,
        string FullName,
        string Phone,
        string? Email,
        string? Address,
        string CountryName
    );
}
