/*
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public void Delete(Guid id)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            const string query = "DELETE FROM Contacts WHERE Id = @Id";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}

*/