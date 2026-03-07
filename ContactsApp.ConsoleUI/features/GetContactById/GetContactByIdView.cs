

using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.GetContactById;

namespace ContactsApp.ConsoleUI.Features.GetContactById
{
    public class GetContactByIdView
    {
        public int GetContactId()
        {
            Console.Write("Get Contact Info By ID: ");
            int.TryParse(Console.ReadLine(), out int contactId);
            return contactId;
        }


        public void DisplayContact(GetContactByIdResponse response)
        {
            // i wanna display the contact record here 

            Console.WriteLine($"ContactId: {response.Id} "); 
            Console.WriteLine($"Name: {response.Name} "); 
            Console.WriteLine($"Phone: {response.Phone} "); 
            Console.WriteLine($"Country: {response.Country} "); 
        }
    }
}
