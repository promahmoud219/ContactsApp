namespace ContactsApp.Core.Contacts.Exceptions
{
    public class InvalidContactDataException : Exception
    {
        public InvalidContactDataException(string message) : base(message) { }
    }

}