namespace ContactsApp.Core.Contacts.Entities
{
    public class Contact
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string Phone { get; private set; } = default!;
        public string? Email { get; private set; }
        public string? Address { get; private set; }
        public int GovernorateId { get; private set; }

        public Contact(string firstName, string lastName, string phone, string? email = null, string? address = null, int GovernorateId = 0)
        {
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhone(phone);
            SetEmail(email);
            SetAddress(address);
            SetGovernorateId(GovernorateId);
        }
        // for update feature, we need to set the Id as well
        public Contact(int Id, string firstName, string lastName, string phone, string? email = null, string? address = null, int GovernorateId = 0)
        {
            this.Id = Id;
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhone(phone);
            SetEmail(email);
            SetAddress(address);
            SetGovernorateId(GovernorateId);
        }
         

        public void SetFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 3 || firstName.Length > 20)
                throw new ArgumentException("First name must be between 3 and 20 characters.");
            FirstName = firstName.Trim();
        }

        public void SetLastName(string lastName)
        {
            var trimmed = lastName?.Trim();
            bool invalid = string.IsNullOrWhiteSpace(trimmed)
                           || trimmed.Length < 3
                           || trimmed.Length > 20
                           || trimmed.Any(c => !(char.IsLetter(c) || c == ' ' || c == '-' || c == '\''));

            if (invalid)
                throw new ArgumentException("Last name must be 3-20 chars and contain only letters, spaces, - or ' .");

            LastName = trimmed!;
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
        
        public void SetGovernorateId(int governorateId)
        {
            if (governorateId < 1)
                throw new ArgumentException("Invalid governorateId.");
            GovernorateId = governorateId;
        }


    }
}
