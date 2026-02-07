
namespace ContactsApp.ConsoleUI.Features.MainMenu   
{
    public class MainMenuView
    {
        public enum MenuChoice
        {
            AddContact = 1,
            Exit = 6,
            Invalid = -1
        }

        public MenuChoice ShowMenuAndGetChoice()
        {
            Render();
            return GetUserChoice();
        }
        
        private void Render()
        {
            Console.WriteLine("\t\t\tMain Menu");
            Console.WriteLine("1- Add Contact");
            //Console.WriteLine("2- Delete Contact");
            //Console.WriteLine("3- Update Contact");
            //Console.WriteLine("4- Search Contact");
            //Console.WriteLine("5- Show All Contacts");
            Console.WriteLine("6- Exit");
            Console.WriteLine("------------------------");
        }
        
        private MenuChoice GetUserChoice()
        {
            Console.Write("Enter your choice: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice))
            {
                return choice switch
                {
                    1 => MenuChoice.AddContact,
                    _ => MenuChoice.Invalid
                };
            }
            return MenuChoice.Invalid;
        }

    }
}