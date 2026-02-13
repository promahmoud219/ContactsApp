/*
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public void Update(Contact contact)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            const string query = @"UPDATE Contacts 
                                   SET Name = @Name, Phone = @Phone, Email = @Email 
                                   WHERE Id = @Id";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Id", contact.Id);
            cmd.Parameters.AddWithValue("@Name", contact.Name);
            cmd.Parameters.AddWithValue("@Phone", contact.Phone);
            cmd.Parameters.AddWithValue("@Email", (object?)contact.Email ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }
    }
}
*/