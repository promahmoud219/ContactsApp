using ContactsApp.Core.Contacts.UseCases.AddContact;
using ContactsApp.Core.Shared;

namespace ContactsApp.ConsoleUI.Features.AddContact
{
    public class AddContactOutputPort : IAddContactOutputPort
    {
        private readonly AddContactView _view;

        public AddContactOutputPort(AddContactView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Handle(OperationResult<AddContactOutput> result)
        {
            if (result.Output is not null && result.Status == OperationStatus.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                _view.ShowMessage(
                    $"✅ Contact:\n" +
                    $"FullName: '{result.Output.FullName}' \n" +
                    $"Phone: '{result.Output.Phone}' \n" +
                    $"Email: '{result.Output.Email}' \n" +
                    $"Address: '{result.Output.Address}' \n" +
                    $"CountryId: '{result.Output.CountryId}' \n" +
                    $"added successfully!\n", ConsoleColor.Green);
            }
            else if (result.Status == OperationStatus.ValidationError)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                _view.ShowMessage($"⚠️ Validation Error: {result.ErrorMessage}", ConsoleColor.Yellow);
            }
            else if (result.Status == OperationStatus.Failure)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                _view.ShowMessage("❌ Failed to add contact.", ConsoleColor.Red);
            }
            Console.ResetColor();
        }
    }
}