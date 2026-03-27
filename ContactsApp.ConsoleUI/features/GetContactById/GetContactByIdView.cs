

using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.GetContactById;

namespace ContactsApp.ConsoleUI.Features.GetContactById
{
    public class GetContactByIdView
    {
        public int GetId()
        {
            Console.Write("Get Contact Info By ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            return id;
        }


        public void DisplayContact(GetContactByIdResponse response)
        {
            Console.WriteLine($"Id: {response.Id} "); 
            Console.WriteLine($"Name: {response.Name} "); 
            Console.WriteLine($"Phone: {response.Phone} ");
            Console.WriteLine($"Email: {response.Email} ");
            Console.WriteLine($"Address: {response.Address} ");
            Console.WriteLine($"Country: {response.CountryName} ");
        }
    }
}
