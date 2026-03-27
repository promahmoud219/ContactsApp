namespace ContactsApp.Core.Contacts.ReadModels
{
    public record ContactReadModel(
        int Id,
        string FirstName,
        string LastName,
        string Phone,
        string CountryId
    );
}
