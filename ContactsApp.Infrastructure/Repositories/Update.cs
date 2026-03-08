using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task UpdateAsync(Contact contact)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @"UPDATE Contacts 
                                SET FirstName = @FirstName, 
                                    LastName = @LastName, 
                                    Phone = @Phone, 
                                    Email = @Email 
                                WHERE ContactId = @Id;";

            using var cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = contact.Id;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = contact.Phone;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = (object?)contact.Email ?? DBNull.Value;


            var rowsAffected = await cmd.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }
}