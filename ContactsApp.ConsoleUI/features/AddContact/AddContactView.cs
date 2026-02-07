using ContactsApp.Core.Contacts.UseCases.AddContact;

namespace ContactsApp.ConsoleUI.Features.AddContact
{
    public class AddContactView
    {
        public AddContactInput Render()
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

            Console.Write("Enter CountryId (numeric): ");
            int.TryParse(Console.ReadLine(), out var countryId);

            return new AddContactInput(firstName, lastName, phone, email, address, countryId);
        }
        
        public void ShowMessage(string msg, ConsoleColor color = ConsoleColor.Green)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
            Console.ForegroundColor = prev;
        }

    }
}