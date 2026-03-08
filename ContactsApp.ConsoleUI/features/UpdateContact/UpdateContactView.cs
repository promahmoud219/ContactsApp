using ContactsApp.Contracts.Contacts.UpdateContact;

namespace ContactsApp.ConsoleUI.Features.UpdateContact
{
    public class UpdateContactView
    {
        public UpdateContactRequest Render()
        {
            Console.WriteLine("\n=== Update Contact ===\n");


            // right now we are taking the Id from the user here, but 
            // i will take the Id from GetContactById. because, first, the user enters the Id ,
            // then we will show the contact details, will confirm 
            // then the user can update the details and then we will send the update request to the server.

            Console.Write("Enter Contact ID: ");
            int.TryParse(Console.ReadLine(), out var contactId);

            Console.Write("Enter FirstName: ");
            var firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter LastName: ");
            var lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Phone: ");
            var phone = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Email (optional): ");
            var email = Console.ReadLine();

            return new UpdateContactRequest(contactId, firstName, lastName, phone, email);
        }

        public void ShowContactRecord(UpdateContactResponse response)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("? Contact Updated:");
            Console.WriteLine($"FullName: {response.Name}");
            Console.WriteLine($"Phone: {response.Phone}");
            Console.WriteLine($"Email: {response.Email}");

            Console.ResetColor();
        }
    }
}