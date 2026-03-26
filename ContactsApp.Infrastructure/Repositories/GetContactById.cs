using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;
using ContactsApp.Core.Contacts.ReadModels;
using System.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task<ContactReadModel?> GetContactByIdAsync(int id)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @"
            SELECT c.Id, c.FirstName, c.LastName, c.Phone, co.Name AS Country
            FROM Contacts c
            JOIN Countries co ON c.CountryId = co.Id
            WHERE c.Id = @id";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new ContactReadModel(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("FirstName")),
                    reader.GetString(reader.GetOrdinal("LastName")),
                    reader.GetString(reader.GetOrdinal("Phone")),
                    reader.GetString(reader.GetOrdinal("CountryId"))
                );
            }

            return null;
        }
    }
}