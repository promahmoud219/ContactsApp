
namespace ContactsApp.ConsoleUI.Features.MainMenu   
{
    public class MainMenuView
    {
        public enum MenuChoice
        {
            CreateContact = 1,
            DeleteContact = 2,
            GetContactById = 3,
            UpdateContact = 4,
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
            Console.WriteLine("1- Create Contact");
            Console.WriteLine("2- Delete Contact");
            Console.WriteLine("3- Get Contact By Id");
            Console.WriteLine("3- Update Contact");
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
                    1 => MenuChoice.CreateContact,
                    2 => MenuChoice.DeleteContact,
                    3 => MenuChoice.GetContactById,
                    4 => MenuChoice.UpdateContact,
                    _ => MenuChoice.Invalid
                };
            }
            return MenuChoice.Invalid;
        }

    }
}