using ContactsApp.Core.Contacts.Interfaces;
using ContactsApp.Core.Contacts.UseCases.AddContact;
using ContactsApp.Core.Shared;

namespace ContactsApp.ConsoleUI.Features.AddContact
{ 
    public class AddContactController 
    {
        private readonly IAddContactUseCase _useCase;
        private readonly IAddContactOutputPort _output;
        private readonly AddContactView _view;

        public AddContactController(IAddContactUseCase useCase, IAddContactOutputPort output, AddContactView view)
        {
            _useCase = useCase ?? throw new ArgumentNullException(nameof(useCase));
            _output = output ?? throw new ArgumentNullException(nameof(output));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public OperationResult<AddContactOutput> Run()
        {  
            var input = _view.Render();
            var result = _useCase.Execute(input);
            _output.Handle(result);
            return result;
        }
    }
}