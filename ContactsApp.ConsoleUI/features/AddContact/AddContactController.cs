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
            while (true)
            {

                var input = _view.Render();
                var result = _useCase.Execute(input);
                _output.Handle(result);
                // i'll ask chat if _output.Handle func is correct, cause it return void,
                // but i want to return the result of the use case execution to the application controller,
                // so application controller can decide what to do based on the result status,
                // if it's success show success message,
                // if it's validation error show validation error message, if it's failure show failure message.
                if (result.Status == OperationStatus.Success)
                    return result;
                if (result.Status == OperationStatus.ValidationError)
                    continue;
                if (result.Status == OperationStatus.Failure)
                    return result;
            }
        }
    }
}