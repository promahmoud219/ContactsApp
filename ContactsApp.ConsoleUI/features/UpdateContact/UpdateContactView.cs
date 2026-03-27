using ContactsApp.Contracts.Contacts.UpdateContact;

namespace ContactsApp.ConsoleUI.Features.UpdateContact
{
    public class UpdateContactView
    {
        public UpdateContactRequest Render()
        {
            Console.WriteLine("\n=== Update Contact ===\n");

            Console.Write("Enter Contact ID: ");
            int.TryParse(Console.ReadLine(), out var id);

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
            
            Console.Write("Enter Country ID: ");
            int.TryParse(Console.ReadLine(), out var countryId);

            return new UpdateContactRequest(id, firstName, lastName, phone, email?.Trim(), address?.Trim(), countryId);
        }
 
    }
}
