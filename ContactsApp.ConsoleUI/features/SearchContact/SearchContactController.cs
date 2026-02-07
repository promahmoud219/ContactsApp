//using ContactsApp.ConsoleUI.Views;
//using ContactsApp.Core.contacts.use_cases;
//using ContactsApp.ConsoleUI.Presenters;

//namespace ContactsApp.ConsoleUI.Features.SearchContact
//{
//    public class SearchContactController
//    {
//        private readonly ISearchContactView _view;
//        private readonly SearchContactsUseCase _useCase;
//        private readonly SearchContactPresenter _presenter;

//        public SearchContactController(
//            ISearchContactView view,
//            SearchContactsUseCase useCase,
//            SearchContactPresenter presenter)
//        {
//            _view = view;
//            _useCase = useCase;
//            _presenter = presenter;
//        }

//        public void Run()
//        {
//            string query = _view.GetSearchQuery();
//            var results = _useCase.Execute(query);

//            _presenter.ShowSearchResults(results, query);
//        }
//    }
//}
