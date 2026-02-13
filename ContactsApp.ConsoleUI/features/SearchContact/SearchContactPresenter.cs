//using ContactsApp.ConsoleUI.Views;
//using ContactsApp.Core.contacts.entities;

//namespace ContactsApp.ConsoleUI.Features.SearchContact
//{
//    public class SearchContactPresenter
//    {
//        private readonly ISearchContactView _view;

//        public SearchContactPresenter(ISearchContactView view)
//        {
//            _view = view;
//        }

//        public void ShowSearchResults(IEnumerable<Contact> results, string query)
//        {
//            if (results.Any())
//            {
//                _view.ShowResults(results);
//            }
//            else
//            {
//                _view.ShowMessage($"? No contacts found matching '{query}'.");
//            }
//        }
//    }
//}
    