using Microsoft.AspNetCore.Mvc;
using ContactsApp.Core.Contacts.Interfaces; 
using ContactsApp.Core.Contacts.UseCases.AddContact;
using ContactsApp.WebAPI.Mappings;
using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Core.Shared;

namespace ContactsApp.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IAddContactUseCase _addContactUseCase;

        public ContactsController(IAddContactUseCase addContactUseCase)
        {
            _addContactUseCase = addContactUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody] AddContactRequest request)
        {
            var input = Mappings.AddContactMapping.ToInput(request);
            var result = await _addContactUseCase.ExecuteAsync(input);

            return result.Status switch
            {
                OperationStatus.Success =>
                    Created("", Mappings.AddContactMapping.ToResponse(result.Output!)),
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
    }
}