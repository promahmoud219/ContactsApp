using Microsoft.AspNetCore.Mvc;
using ContactsApp.Core.Contacts.Interfaces; 
using ContactsApp.Core.Contacts.UseCases.CreateContact;
using ContactsApp.Core.Contacts.UseCases.DeleteContact;
using ContactsApp.WebAPI.Mappings;
using ContactsApp.Contracts.Contacts.CreateContact;
using ContactsApp.Core.Shared;

namespace ContactsApp.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ICreateContactUseCase _createContactUseCase;
        private readonly IDeleteContactUseCase _deleteContactUseCase;

        public ContactsController(ICreateContactUseCase createContactUseCase, IDeleteContactUseCase deleteContactUseCase)
        {
            _createContactUseCase = createContactUseCase;
            _deleteContactUseCase = deleteContactUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactRequest request)
        {
            var input = Mappings.CreateContactMapping.ToInput(request);
            var result = await _createContactUseCase.ExecuteAsync(input);

            return result.Status switch
            {
                OperationStatus.Success =>
                    Created("", Mappings.CreateContactMapping.ToResponse(result.Output!)),
                OperationStatus.ValidationError =>
                    BadRequest(result.ErrorMessage),
                OperationStatus.NotFound =>
                    NotFound(result.ErrorMessage),
                OperationStatus.Failure =>
                    StatusCode(500, result.ErrorMessage),
                _ => StatusCode(500, "An unexpected error occurred.")
            };
        }

        // edit takes the object and id, to insure that the user wants to change this id 
        // يعني ايه كرييتد أت أكشن وراح فاتح كوسين ومدخل فنكشن جت باي أي دي 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _deleteContactUseCase.ExecuteAsync(id);

            return result.Status switch
            {
                OperationStatus.Success =>
                    NoContent(),
                OperationStatus.NotFound =>
                    NotFound(result.ErrorMessage),
                OperationStatus.ValidationError =>
                    BadRequest(result.ErrorMessage),
                OperationStatus.Failure =>
                    StatusCode(500, result.ErrorMessage),
                _ => StatusCode(500, "An unexpected error occurred.")
            };
        }
    }
}