//using ContactsApp.Core.Contacts.Interfaces;
//using ContactsApp.Core.Contacts.UseCases;

//namespace ContactsApp.ConsoleUI.Features.DeleteContact
//{
//    public class DeleteContactController
//    {
//        private readonly IContactRepository _repository;
//        private readonly DeleteContactPresenter _presenter;
//        private readonly DeleteContactView _view;

//        public DeleteContactController(IContactRepository repository)
//        {
//            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
//            _view = new DeleteContactView();
//            _presenter = new DeleteContactPresenter(_view);
//        }

//        public void Run()
//        {
//            string name = _view.GetContactName();
//            //var useCase = new Delete
//            bool result = useCase.Execute(name);

//            _presenter.ShowDeleteResult(success, name);
//        }
//    }
//}