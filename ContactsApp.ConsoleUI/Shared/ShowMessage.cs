using System;

namespace ContactsApp.ConsoleUI.Shared
{
    public class ConsoleMessageView : IShowMessage
    {
        public void ShowMessage(string message, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(message);

            Console.ForegroundColor = previousColor;
        }
    }
}
