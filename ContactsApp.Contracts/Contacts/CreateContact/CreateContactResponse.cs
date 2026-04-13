namespace ContactsApp.Contracts.Contacts.CreateContact
{
    public record CreateContactResponse
    (
        int Id,
        string Name,
        string Phone,
        string? Email,
        string? Address,
        int GovernorateId
    );
}