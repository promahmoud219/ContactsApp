//using ContactsApp.ConsoleUI.Views;
//using ContactsApp.ConsoleUI.Presenters;

//namespace ContactsApp.ConsoleUI.Features.Exit
//{
//    public class ExitController
//    {
//        private readonly IExitView _view;
//        private readonly ExitPresenter _presenter;

//        public ExitController(IExitView view, ExitPresenter presenter)
//        {
//            _view = view;
//            _presenter = presenter;
//        }

//        public void Run()
//        {
//            bool confirm = _view.ConfirmExit();
//            if (confirm)
//            {
//                _presenter.ShowExitMessage();
//                Environment.Exit(0);
//            }
//            else
//            {
//                _presenter.ShowCancelExitMessage();
//            }
//        }
//    }
//}
