using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;
using System.Threading;

// ???? ????? ??????????? ???? ????? ?? ??????? ??: 
// https://chatgpt.com/s/t_69c3fac3a7508191a26028588711a054
// ????? ????? ???????? ?????? ??? ??? ???? ?? ??? ???? ???? ??????? ?? ?? ????? ????

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task DeleteAsync(int ContactId)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = "DELETE FROM Contacts WHERE ContactId = @ContactId";
            
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@ContactId", SqlDbType.Int).Value = ContactId;

            var deleted = await cmd.ExecuteNonQueryAsync();
            
            if(!deleted)
                throw new NotFoundException($"Contact with id {ContactId} not found");
        }
    }
}
