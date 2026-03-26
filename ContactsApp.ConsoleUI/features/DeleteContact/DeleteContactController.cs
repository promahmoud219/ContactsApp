using ContactsApp.ConsoleUI.Api;
using ContactsApp.Contracts.Contacts.GetContactById;
using ContactsApp.ConsoleUI.Results;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ContactsApp.ConsoleUI.Features.DeleteContact
{
 
    public class DeleteContactController
    {
        private readonly IContactsApiClient _api;
        private readonly DeleteContactView _view;

        public DeleteContactController(IContactsApiClient api, DeleteContactView view)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public async Task<ClientResult<NoContent>> RunAsync()
        {
            int id = _view.GetId();

            var contactResult = await _api.GetContactByIdAsync(id);

            if (!contactResult.IsSuccess || contactResult.Data is null)
            {
                return ClientResult<NoContent>.Failure(
                    contactResult.StatusCode,
                    contactResult.ErrorMessage,
                    contactResult.ErrorType);
            }

            _view.DisplayContact(contactResult.Data);

            var confirmed = _view.ConfirmDelete(id);

            if (!confirmed)
            {
                return ClientResult<NoContent>.Failure(
                    HttpStatusCode.BadRequest,
                    "Deletion cancelled",
                    ClientErrorType.Validation);
            }

            return await _api.DeleteContactAsync(id);
        }
    }
}