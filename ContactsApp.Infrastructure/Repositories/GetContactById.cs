using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;
using ContactsApp.Core.Contacts.ReadModels;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task<ContactReadModel?> GetByIdAsync(int ContactId)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @"
        SELECT c.ContactId, c.FirstName, c.LastName, c.Phone, co.CountryName AS Country
        FROM Contacts c
        JOIN Countries co ON c.CountryId = co.ContactId
        WHERE c.ContactId = @ContactId";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ContactId", ContactId);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new ContactReadModel(
                    reader.GetInt32(reader.GetOrdinal("ContactId")),
                    reader.GetString(reader.GetOrdinal("FirstName")),
                    reader.GetString(reader.GetOrdinal("LastName")),
                    reader.GetString(reader.GetOrdinal("Phone")),
                    reader.GetString(reader.GetOrdinal("Country"))
                );
            }

            return null;
        }
    }
}