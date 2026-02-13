/*
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public Contact? GetById(Guid id)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            const string query = "SELECT Id, Name, Phone, Email FROM Contacts WHERE Id = @Id";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Contact(
                    reader["Name"].ToString()!,
                    reader["Phone"].ToString()!,
                    reader["Email"]?.ToString()
                );
            }

            return null;
        }
    }
}

*/