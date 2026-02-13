/*
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
        public IEnumerable<Contact> GetAll()
        {
            var contacts = new List<Contact>();
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            const string query = "SELECT Id, Name, Phone, Email FROM Contacts";
            using var cmd = new SqlCommand(query, connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                contacts.Add(new Contact(
                    reader["Name"].ToString()!,
                    reader["Phone"].ToString()!,
                    reader["Email"]?.ToString()
                ));
            }

            return contacts;
        }
    }
}


*/