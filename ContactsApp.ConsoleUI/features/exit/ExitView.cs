//namespace ContactsApp.ConsoleUI.Features.Exit
//{
//    public interface IExitView
//    {
//        bool ConfirmExit();
//        void ShowMessage(string message);
//    }

//    public class ExitView : IExitView
//    {
//        public bool ConfirmExit()
//        {
//            Console.Write("?? Are you sure you want to exit? (y/n): ");
//            string? input = Console.ReadLine()?.Trim().ToLower();
//            return input == "y" || input == "yes";
//        }

//        public void ShowMessage(string message)
//        {
//            Console.WriteLine(message);
//        }
//    }
//}
