using System.Net.Http.Json;
using ContactsApp.Contracts.Contacts.Requests;
using ContactsApp.Contracts.Contacts.Responses;

namespace ContactsApp.ConsoleUI.Api
{
    public class ContactsApiClient : IContactsApiClient
    {
        private readonly HttpClient _httpClient;

        public ContactsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddContactResponse?> AddContactAsync(AddContactRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/contacts", request);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<AddContactResponse>();

            return null;
        }
    }
}