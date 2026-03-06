namespace ContactsApp.ConsoleUI.Features.DeleteContact
{

    public class DeleteContactView
    {
        public string GetContactName()
        {
            Console.Write("Enter contact name to delete: ");
            return Console.ReadLine() ?? string.Empty;
        }

        public void ShowDeleteResult(bool success, string contactName)
        {
            if (success)
                ShowMessage($"✅ Contact '{contactName}' deleted successfully!");
            else
                ShowMessage($"❌ Contact '{contactName}' not found or could not be deleted.");
        }

        public bool ConfirmDelete(int id)
        {
            Console.Write($"Are you sure you want to delete contact with ID {id}? (y/n): ");
            var input = Console.ReadLine()?.Trim().ToLower();
            return IsAffirmative(input);
        }

        private bool IsAffirmative(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var affirmativeWords = new[]
            {
                "y", "yes", "yeah", "yep", "sure",
                "confirm", "ok", "okay", "affirmative",
                "absolutely", "definitely", "certainly", "indeed"
            };

            return affirmativeWords.Contains(input);
        }

        public int GetContactId()
        {
            Console.Write("Enter contact ID to delete: ");
            var input = Console.ReadLine();

            return int.TryParse(input, out var id) ? id : 0;
        }
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

