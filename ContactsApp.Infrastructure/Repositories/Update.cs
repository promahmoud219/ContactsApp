using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;
using System.Data;
using ContactsApp.Core.Shared.Exceptions;



namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task UpdateAsync(Contact contact)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @"
            UPDATE Contacts 
            SET FirstName = @FirstName, 
                LastName = @LastName, 
                Phone = @Phone, 
                Email = @Email,
                GovernorateId = @GovernorateId
            WHERE Id = @id;";

            using var cmd = new SqlCommand(query, connection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = contact.Id;
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = contact.Phone;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = (object?)contact.Email ?? DBNull.Value;
            cmd.Parameters.Add("@GovernorateId", SqlDbType.Int).Value = contact.GovernorateId;

            // i will continue row version later
            // ??????? ?? ?? ????? ?????? ?????
            // https://chatgpt.com/s/t_69c3dc31441c8191a8b78c239153b53f
            //cmd.Parameters.Add("@RowVersion", SqlDbType.Timestamp).Value = contact.RowVersion;


            var rows = await cmd.ExecuteNonQueryAsync();

            if (rows == 0)
                throw new NotFoundException($"Contact {contact.Id} not found");

        }
    }
}