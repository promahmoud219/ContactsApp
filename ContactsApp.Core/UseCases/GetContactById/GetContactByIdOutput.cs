namespace ContactsApp.Core.Contacts.UseCases.GetContactById
{
    public record GetContactByIdOutput(
        int ContactId,
        string FullName,
        string Phone,
        string Country
    );
}
