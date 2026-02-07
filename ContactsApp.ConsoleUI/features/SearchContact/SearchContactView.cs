//using ContactsApp.Core.contacts.entities;

//namespace ContactsApp.ConsoleUI.Features.SearchContact
//{
//    public interface ISearchContactView
//    {
//        string GetSearchQuery();
//        void ShowResults(IEnumerable<Contact> contacts);
//        void ShowMessage(string message);
//    }

//    public class SearchContactView : ISearchContactView
//    {
//        public string GetSearchQuery()
//        {
//            Console.Write("?? Enter name or part of it to search: ");
//            return Console.ReadLine() ?? string.Empty;
//        }

//        public void ShowResults(IEnumerable<Contact> contacts)
//        {
//            Console.WriteLine();
//            Console.WriteLine("?? Search Results:");
//            foreach (var c in contacts)
//            {
//                Console.WriteLine($"- {c.Name} | {c.Phone} | {c.Email}");
//            }
//            Console.WriteLine();
//        }

//        public void ShowMessage(string message)
//        {
//            Console.WriteLine(message);
//        }
//    }
//}
