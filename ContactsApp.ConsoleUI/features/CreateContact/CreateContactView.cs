using ContactsApp.Contracts.Contacts.CreateContact;

namespace ContactsApp.ConsoleUI.Features.CreateContact
{
    public class CreateContactView
    {
        public CreateContactRequest Render()
        {
            Console.WriteLine("\n=== Add New Contact ===\n");

            Console.Write("Enter FirstName: ");
            var firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter LastName: ");
            var lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Phone: ");
            var phone = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Email (optional): ");
            var email = Console.ReadLine();

            Console.Write("Enter Address (optional): ");
            var address = Console.ReadLine();

            Console.Write("Enter GovernorateId (numeric): ");
            int.TryParse(Console.ReadLine(), out var governorateId);

            return new CreateContactRequest(firstName, lastName, phone, email, address, governorateId);
        }

        public void ShowContactRecord(CreateContactResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("? Contact Added:");
            Console.WriteLine($"FullName: {response.Name}");
            Console.WriteLine($"Phone: {response.Phone}");
            Console.WriteLine($"Email: {response.Email}");
            Console.WriteLine($"Address: {response.Address}");
            Console.WriteLine($"GovernorateId: {response.GovernorateId}");

            Console.ResetColor();
        } 
    }
}