using System.Net.Http.Json;
using System.Net;
using ContactsApp.Contracts.Contacts.CreateContact;
using ContactsApp.ConsoleUI.Results;
using ContactsApp.Contracts.Contacts.GetContactById;

namespace ContactsApp.ConsoleUI.Api
{
    public class ContactsApiClient : IContactsApiClient
    {
        private readonly HttpClient _httpClient;

        public ContactsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClientResult<CreateContactResponse?>> CreateContactAsync(CreateContactRequest request)
        {
            try
            {

                var response = await _httpClient.PostAsJsonAsync("/api/contacts", request);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<CreateContactResponse>();
                    return ClientResult<CreateContactResponse?>.Success(response.StatusCode, data!);
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

                return ClientResult<CreateContactResponse?>.Failure(response.StatusCode, error, errorType);
            }
            catch (HttpRequestException ex)
            {
                return ClientResult<CreateContactResponse?>.Failure(HttpStatusCode.ServiceUnavailable, "Server is not reachable.", ClientErrorType.NetworkFailure);
            }
            catch (TaskCanceledException ex)
            {
                return ClientResult<CreateContactResponse?>.Failure(HttpStatusCode.RequestTimeout, "Request timed out.", ClientErrorType.Timeout);
            }
        }

        public async Task<ClientResult<NoContent>> DeleteContactAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/contacts/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return ClientResult<NoContent>.Success(response.StatusCode);
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

                return ClientResult<NoContent>.Failure(response.StatusCode, error, errorType);
            }
            catch (HttpRequestException)
            {
                return ClientResult<NoContent>.Failure(
                    HttpStatusCode.ServiceUnavailable,
                    "Server is not reachable.",
                    ClientErrorType.NetworkFailure);
            }
            catch (TaskCanceledException)
            {
                return ClientResult<NoContent>.Failure(
                    HttpStatusCode.RequestTimeout,
                    "Request timed out.",
                    ClientErrorType.Timeout);
            }
        }

        public async Task<ClientResult<GetContactByIdResponse?>> GetContactByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/contacts/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<GetContactByIdResponse>();
                    return ClientResult<GetContactByIdResponse?>.Success(response.StatusCode, data!);
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

                return ClientResult<GetContactByIdResponse?>.Failure(response.StatusCode, error, errorType);
            }
            catch (HttpRequestException)
            {
                return ClientResult<GetContactByIdResponse?>.Failure(
                    HttpStatusCode.ServiceUnavailable,
                    "Server is not reachable.",
                    ClientErrorType.NetworkFailure);
            }
            catch (TaskCanceledException)
            {
                return ClientResult<GetContactByIdResponse?>.Failure(
                    HttpStatusCode.RequestTimeout,
                    "Request timed out.",
                    ClientErrorType.Timeout);
            }
        }  
    }
}