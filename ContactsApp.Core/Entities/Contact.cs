namespace ContactsApp.Core.Contacts.Entities
{
    public class Contact
    {
        public int ContactId { get; private set; }
        public string FirstName { get; private set; } 
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public int CountryId { get; private set; }
        
        public Contact(string firstName, string lastName, string phone, string? email = null, string? address = null, int countryId = 0)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhone(phone);
            SetEmail(email);
            SetAddress(address);
            SetCountryId(countryId);
        }
         

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 3 || firstName.Length > 30)
                throw new ArgumentException("First name must be between 3 and 30 characters.");
            FirstName = firstName.Trim();
        }

        public void SetLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName)
                || lastName.Length < 3
                || lastName.Length > 30
                || !lastName.All(char.IsLetter))
                throw new ArgumentException("Last name must contain only letters and be between 3 and 30 characters.");

            LastName = lastName.Trim();
        }

        public void SetPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || !phone.All(char.IsDigit))
                throw new ArgumentException("Invalid phone number.");
            Phone = phone.Trim();
        }

        public void SetEmail(string? email)
        {
            if (!string.IsNullOrWhiteSpace(email) && (!email.Contains('@') || !email.Contains('.')))
                throw new ArgumentException("Invalid email format.");
            Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim();
        }

        public void SetAddress(string? address)
        {
            Address = string.IsNullOrWhiteSpace(address) ? null : address.Trim();
        }
        
        public void SetCountryId(int countryId)
        {

            if (countryId < 1 || countryId > 5)
                throw new ArgumentException("Invalid CountryId.");
            CountryId = countryId;
        }


    }
}