using ContactsApp.Core.Shared.Exceptions;
using ContactsApp.Core.Contacts.Entities;
using ContactsApp.Core.Contacts.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using ContactsApp.Infrastructure.Data;
using ContactsApp.Core.Contacts.ReadModels;

namespace ContactsApp.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public async Task<int> CreateAsync(Contact contact)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @" 
            INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, GovernorateId) 
            VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @GovernorateId);
            SELECT CAST(SCOPE_IDENTITY() as int);";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 20).Value = contact.Phone;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = (object?)contact.Email ?? DBNull.Value;
            cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = (object?)contact.Address ?? DBNull.Value;
            cmd.Parameters.Add("@GovernorateId", SqlDbType.Int).Value = contact.GovernorateId;

            var scalarResult = await cmd.ExecuteScalarAsync();
            if (scalarResult is null || scalarResult is DBNull)
            {
                throw new InvalidOperationException("Failed to retrieve new contact ID after insert.");
            }

            return Convert.ToInt32(scalarResult);
        }

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

        public async Task<ContactReadModel?> GetContactByIdAsync(int id)
        {
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query = @"
            SELECT c.Id, c.FirstName, c.LastName, c.Phone, c.Email, c.Address, g.Name AS GovernorateName
            FROM Contacts c
            JOIN Governorates g ON c.GovernorateId = g.Id
            WHERE c.Id = @id";

            using var cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;


            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                int emailOrdinal = reader.GetOrdinal("Email");
                int addressOrdinal = reader.GetOrdinal("Address");

                return new ContactReadModel(
                    reader.GetInt32(reader.GetOrdinal("Id")),
                    reader.GetString(reader.GetOrdinal("FirstName")),
                    reader.GetString(reader.GetOrdinal("LastName")),
                    reader.GetString(reader.GetOrdinal("Phone")),
                    reader.IsDBNull(emailOrdinal) ? null : reader.GetString(emailOrdinal),
                    reader.IsDBNull(addressOrdinal) ? null : reader.GetString(addressOrdinal),
                    reader.GetString(reader.GetOrdinal("GovernorateName"))
                );
            }

            return null;
        }

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

        public async Task<IEnumerable<ContactDetails?>> GetAllAsync()
        {
            var contacts = new List<ContactDetails?>();
            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            await connection.OpenAsync();

            const string query =    "SELECT " +
                                    "c.Id, " +
                                    "c.FirstName + ' ' + c.LastName As FullName, " +
                                    "c.Phone, " + 
                                    "c.Email, " +
                                    "c.Address, " +
                                    "g.Name as GovernorateName " +
                                    "FROM Contacts c " +
                                    "JOIN Governorates g on c.GovernorateId = g.Id";

            using var cmd = new SqlCommand(query, connection);
            using var reader = await cmd.ExecuteReaderAsync();

            int idOrd = reader.GetOrdinal("Id");
            int nameOrd = reader.GetOrdinal("FullName");
            int phoneOrd = reader.GetOrdinal("Phone");
            int emailOrd = reader.GetOrdinal("Email");
            int addrOrd = reader.GetOrdinal("Address");
            int govOrd = reader.GetOrdinal("GovernorateName");

            while (await reader.ReadAsync())
            {
                contacts.Add(new ContactDetails(
                    reader.GetInt32(idOrd),
                    reader.GetString(nameOrd),
                    reader.GetString(phoneOrd),
                    reader.IsDBNull(emailOrd) ? null! : reader.GetString(emailOrd),
                    reader.IsDBNull(addrOrd) ? null! : reader.GetString(addrOrd),
                    reader.GetString(govOrd)
                ));
            }
            return contacts;
        }
    }
}


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
      public IEnumerable<Contact> SearchContacts(SearchContactInput input)
        {
            var contacts = new List<Contact>();

            using var connection = new SqlConnection(DatabaseInitializer.GetConnectionString());
            connection.Open();

            var sql = new StringBuilder();
            sql.AppendLine("SELECT Id, FirstName, LastName, Phone, Email, Address, CountryId");
            sql.AppendLine("FROM Contacts");
            sql.AppendLine("WHERE 1 = 1");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrWhiteSpace(input.FirstName))
            {
                sql.AppendLine("AND FirstName LIKE @FirstName");
                parameters.Add(new SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = $"{input.FirstName}%"
                });
            }

            if (!string.IsNullOrWhiteSpace(input.LastName))
            {
                sql.AppendLine("AND LastName LIKE @LastName");
                parameters.Add(new SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = $"{input.LastName}%"
                });
            }

            if (!string.IsNullOrWhiteSpace(input.Phone))
            {
                sql.AppendLine("AND Phone LIKE @Phone");
                parameters.Add(new SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 50)
                {
                    Value = $"{input.Phone}%"
                });
            }

            if (!string.IsNullOrWhiteSpace(input.Email))
            {
                sql.AppendLine("AND Email LIKE @Email");
                parameters.Add(new SqlParameter("@Email", System.Data.SqlDbType.NVarChar, 100)
                {
                    Value = $"%{input.Email}%"
                });
            }

            if (!string.IsNullOrWhiteSpace(input.Address))
            {
                sql.AppendLine("AND Address LIKE @Address");
                parameters.Add(new SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 200)
                {
                    Value = $"%{input.Address}%"
                });
            }

            if (input.CountryId is not null)
            {
                sql.AppendLine("AND CountryId = @CountryId");
                parameters.Add(new SqlParameter("@CountryId", System.Data.SqlDbType.Int)
                {
                    Value = input.CountryId.Value
                });
            }

            using var cmd = new SqlCommand(sql.ToString(), connection);
            cmd.Parameters.AddRange(parameters.ToArray());

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var id = reader.GetInt32(reader.GetOrdinal("Id"));
                var firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                var lastName = reader.GetString(reader.GetOrdinal("LastName"));
                var phone = reader.GetString(reader.GetOrdinal("Phone"));

                string? email = null;
                if (!reader.IsDBNull(reader.GetOrdinal("Email")))
                    email = reader.GetString(reader.GetOrdinal("Email"));

                string? address = null;
                if (!reader.IsDBNull(reader.GetOrdinal("Address")))
                    address = reader.GetString(reader.GetOrdinal("Address"));

                var countryId = reader.GetInt32(reader.GetOrdinal("CountryId"));

                contacts.Add(new Contact(id, firstName, lastName, phone, email, address, countryId));
            }

            return contacts;
        }


        
    }
}

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
*/
