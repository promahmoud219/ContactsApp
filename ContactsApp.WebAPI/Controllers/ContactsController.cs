using ContactsApp.Core.Contacts.Interfaces; 
using ContactsApp.Core.Contacts.UseCases.CreateContact;
using ContactsApp.Core.Contacts.UseCases.DeleteContact;
using ContactsApp.Core.Contacts.UseCases.UpdateContact;
using ContactsApp.Core.Contacts.UseCases.GetContactById;
using ContactsApp.Contracts.Contacts.CreateContact;
using ContactsApp.Core.Shared;
using ContactsApp.WebAPI.Mappings;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ContactsApp.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ICreateContactUseCase _createContactUseCase;
        private readonly IDeleteContactUseCase _deleteContactUseCase;
        private readonly IGetContactByIdUseCase _getContactByIdUseCase;
        private readonly IUpdateContactUseCase _updateContactUseCase;
        public ContactsController(
            ICreateContactUseCase createContactUseCase, 
            IDeleteContactUseCase deleteContactUseCase,
            IGetContactByIdUseCase getContactByIdUseCase,
            IUpdateContactUseCase updateContactUseCase
        )
        {
            _createContactUseCase = createContactUseCase;
            _deleteContactUseCase = deleteContactUseCase;
            _getContactByIdUseCase = getContactByIdUseCase;
            _updateContactUseCase = updateContactUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactAsync([FromBody] CreateContactRequest request)
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
         // يعني ايه كرييتد أت أكشن وراح فاتح كوسين ومدخل فنكشن جت باي أي دي 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactAsync(int id)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactByIdAsync(int id)
        {
            var result = await _getContactByIdUseCase.ExecuteAsync(id);

            return result.Status switch
            {
                OperationStatus.Success =>
                    Ok(Mappings.GetContactByIdMapping.ToResponse(result.Output!)),
                OperationStatus.NotFound =>
                    NotFound(result.ErrorMessage),
                OperationStatus.ValidationError =>
                    BadRequest(result.ErrorMessage),
                OperationStatus.Failure =>
                    StatusCode(500, result.ErrorMessage),
                _ => StatusCode(500, "An unexpected error occurred.")
            };
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContactAsync(int id, [FromBody] UpdateContactRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID in the URL does not match ID in the request body.");

            var input = Mappings.UpdateContactMapping.ToInput(request, id);
            var result = await _updateContactUseCase.ExecuteAsync(input);
            
            return result.Status switch
            {
                OperationStatus.Success =>
                    NoContent(),
                OperationStatus.NotFound =>
                    NotFound(result.ErrorMessage), 
                OperationStatus.Failure =>
                    StatusCode(500, result.ErrorMessage),
                _ => StatusCode(500, "An unexpected error occurred.")
            };

        }
}