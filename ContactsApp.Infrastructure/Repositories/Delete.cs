using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;
using System.Threading;
using System.Data;
using ContactsApp.Core.Shared.Exceptions;


// https://chatgpt.com/s/t_69c3fac3a7508191a26028588711a054

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public async Task DeleteAsync(int id)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = "DELETE FROM Contacts WHERE Id = @id";
            
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            var deleted = await cmd.ExecuteNonQueryAsync();

            if (deleted == 0)
                throw new NotFoundException($"Contact with Id {id} not found");
        }
    }
}
