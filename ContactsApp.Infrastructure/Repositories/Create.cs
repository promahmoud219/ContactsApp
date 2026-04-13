using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task<int> CreateAsync(Contact contact)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @" 
            INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, GovernorateId) 
            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @GovernorateId);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = contact.Phone;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = (object?)contact.Email ?? DBNull.Value;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = (object?)contact.Address ?? DBNull.Value;
            cmd.Parameters.Add("@GovernorateId", SqlDbType.Int).Value = contact.GovernorateId;

            var scalarResult = await cmd.ExecuteScalarAsync();
            if (scalarResult is null || scalarResult is DBNull)
            {
                throw new InvalidOperationException("Failed to retrieve new contact ID after insert.");
            }

            return Convert.ToInt32(scalarResult);
        }
    }
}
