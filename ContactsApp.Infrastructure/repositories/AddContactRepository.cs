using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public void AddContact(Contact contact)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            const string query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryId) 
                                   VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @CountryId)";
            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
            cmd.Parameters.AddWithValue("@LastName", contact.LastName);
            cmd.Parameters.AddWithValue("@Email", (object?)contact.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", contact.Phone);
            cmd.Parameters.AddWithValue("@Address", (object?)contact.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CountryId", contact.CountryId);
            cmd.ExecuteNonQuery();
        }
    }
}