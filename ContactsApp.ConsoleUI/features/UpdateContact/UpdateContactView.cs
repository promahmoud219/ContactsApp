/*
using ContactsApp.Core.contacts.entities;

namespace ContactsApp.ConsoleUI.Features.UpdateContact
{
    public interface IUpdateContactView
    {
        string GetContactNameToUpdate();
        Contact GetUpdatedData();
        void ShowMessage(string message);
    }

    public class UpdateContactView : IUpdateContactView
    {
        public string GetContactNameToUpdate()
        {
            Console.Write("?? Enter the name of the contact to update: ");
            return Console.ReadLine() ?? string.Empty;
        }

        public Contact GetUpdatedData()
        {
            Console.WriteLine("\nEnter new data (leave blank to keep current value):");
            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Phone: ");
            string phone = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            return new Contact
            {
                Name = string.IsNullOrWhiteSpace(name) ? null : name,
                Phone = string.IsNullOrWhiteSpace(phone) ? null : phone,
                Email = string.IsNullOrWhiteSpace(email) ? null : email
            };
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

*/