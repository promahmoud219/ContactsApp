using System.Net.Http.Json;
using System.Net;
using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Contracts.Contacts.Responses;
using ContactsApp.ConsoleUI.Results;

namespace ContactsApp.ConsoleUI.Api
{
    public class ContactsApiClient : IContactsApiClient
    {
        private readonly HttpClient _httpClient;

        public ContactsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClientResult<AddContactResponse?>> AddContactAsync(AddContactRequest request)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync("/api/contacts", request);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<AddContactResponse>();
                    return ClientResult<AddContactResponse?>.Success(response.StatusCode, data!);
                }

                var error = await response.Content.ReadAsStringAsync();
                var errorType = response.StatusCode switch
                {
                    HttpStatusCode.BadRequest => ClientErrorType.Validation,
                    HttpStatusCode.NotFound => ClientErrorType.NotFound,
                    HttpStatusCode.Unauthorized => ClientErrorType.Unauthorized,
                    HttpStatusCode.InternalServerError => ClientErrorType.ServerError,
                    _ => ClientErrorType.ServerError
                };

                return ClientResult<AddContactResponse?>.Failure(response.StatusCode, error, errorType);
            }
            catch (HttpRequestException ex)
            {
                return ClientResult<AddContactResponse?>.Failure(HttpStatusCode.ServiceUnavailable, "Server is not reachable.", ClientErrorType.NetworkFailure);
            }
            catch (TaskCanceledException ex)
            {
                return ClientResult<AddContactResponse?>.Failure(HttpStatusCode.RequestTimeout, "Request timed out.", ClientErrorType.Timeout);
            }
        }
    }
}