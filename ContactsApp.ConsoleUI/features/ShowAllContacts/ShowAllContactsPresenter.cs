//using ContactsApp.Core.Contacts.Entities;

//namespace ContactsApp.ConsoleUI.Features.ShowAllContacts
//{
//    public class ShowAllContactsPresenter
//    {
//        private readonly ShowAllContactsView _view;

//        public ShowAllContactsPresenter(ShowAllContactsView view)
//        {
//            _view = view ?? throw new ArgumentNullException(nameof(view));
//        }

//        public void Present(IEnumerable<Contact> contacts)
//        {
//            if (!contacts.Any())
//            {
//                _view.ShowMessage("No contacts found.");
//                return;
//            }

//            _view.ShowContacts(contacts);
//        }
//    }
//}
