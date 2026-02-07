/*
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.UseCases.SearchContacts;    
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using ContactsApp.Infrastructure.Data;

namespace ContactsApp.Infrastructure.Repositories
{
    public partial class ContactRepository : IContactRepository
    {
//      public IEnumerable<Contact> SearchContacts(SearchContactInput input)
//        {
//            var contacts = new List<Contact>();
//
//            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
//            connection.Open();
//
//            var sql = new StringBuilder();
//            sql.AppendLine("SELECT Id, FirstName, LastName, Phone, Email, Address, CountryId");
//            sql.AppendLine("FROM Contacts");
//            sql.AppendLine("WHERE 1 = 1");
//
//            var parameters = new List<SqlParameter>();
//
//            if (!string.IsNullOrWhiteSpace(input.FirstName))
//            {
//                sql.AppendLine("AND FirstName LIKE @FirstName");
//                parameters.Add(new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
//                {
//                    Value = $"{input.FirstName}%"
//                });
//            }
//
//            if (!string.IsNullOrWhiteSpace(input.LastName))
//            {
//                sql.AppendLine("AND LastName LIKE @LastName");
//                parameters.Add(new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
//                {
//                    Value = $"{input.LastName}%"
//                });
//            }
//
//            if (!string.IsNullOrWhiteSpace(input.Phone))
//            {
//                sql.AppendLine("AND Phone LIKE @Phone");
//                parameters.Add(new SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 50)
//                {
//                    Value = $"{input.Phone}%"
//                });
//            }
//
//            if (!string.IsNullOrWhiteSpace(input.Email))
//            {
//                sql.AppendLine("AND Email LIKE @Email");
//                parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 100)
//                {
//                    Value = $"%{input.Email}%"
//                });
//            }
//
//            if (!string.IsNullOrWhiteSpace(input.Address))
//            {
//                sql.AppendLine("AND Address LIKE @Address");
//                parameters.Add(new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 200)
//                {
//                    Value = $"%{input.Address}%"
//                });
//            }
//
//            if (input.CountryId is not null)
//            {
//                sql.AppendLine("AND CountryId = @CountryId");
//                parameters.Add(new SqlParameter("@CountryId", System.Data.SqlDbType.Int)
//                {
//                    Value = input.CountryId.Value
//                });
//            }
//
//            using var cmd = new SqlCommand(sql.ToString(), connection);
//            cmd.Parameters.AddRange(parameters.ToArray());
//
//            using var reader = cmd.ExecuteReader();
//            while (reader.Read())
//            {
//                var id = reader.GetInt32(reader.GetOrdinal("Id"));
//                var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
//                var lastName = reader.GetString(reader.GetOrdinal("LastName"));
//                var phone = reader.GetString(reader.GetOrdinal("Phone"));
//
//                string? email = null;
//                if (!reader.IsDBNull(reader.GetOrdinal("Email")))
//                    email = reader.GetString(reader.GetOrdinal("Email"));
//
//                string? address = null;
//                if (!reader.IsDBNull(reader.GetOrdinal("Address")))
//                    address = reader.GetString(reader.GetOrdinal("Address"));
//
//                var countryId = reader.GetInt32(reader.GetOrdinal("CountryId"));
//
//                contacts.Add(new Contact(id, firstName, lastName, phone, email, address, countryId));
//            }
//
//            return contacts;
//        }
//
        // i write this by myself to ensure that i understand how to build dynamic queries
        public IEnumerable<Contact> SearchContacts(SearchContactInput input)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            const string query = @"SELECT ContactId, FirstName, LastName, Phone, Email, Address, CountryId
                                   FROM Contacts
                                   WHERE 1 = 1";
            using var command = connection.CreateCommand();
            if(!string.IsNullOrWhiteSpace(input.))
            {
                command.CommandText += " AND FirstName LIKE @FirstName";
                command.Parameters.AddWithValue("@FirstName", $"%{input.firstName}%");
            })

        }
    }
}

*/