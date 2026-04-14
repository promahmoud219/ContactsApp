namespace ContactsApp.Core.Contacts.ReadModels
{
    public record ContactReadModel(
        int Id,
        string FirstName,
        string LastName,
        string Phone,
        string? Email,
        string? Address,
        string GovernorateName
    );

    public record ContactDetails(
      int Id,
      string FullName,
      string Phone,
      string? Email,
      string? Address,
      string GovernorateName
    );

}
