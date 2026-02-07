using Microsoft.Data.SqlClient;

namespace ContactsApp.Infrastructure.Data
{
    public static class DatabaseInitializer
    {
        public static readonly string ConnectionString = System.Environment.GetEnvironmentVariable("Contacts_DB_CONN");

        public static string GetConnectionString() => ConnectionString;

        public static void Initialize()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            string createTableQuery = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Contacts' AND xtype='U')
                CREATE TABLE Contacts (
                    Id UNIQUEIDENTIFIER PRIMARY KEY,
                    Name NVARCHAR(100) NOT NULL,
                    Phone NVARCHAR(50) NOT NULL,
                    Email NVARCHAR(100) NULL
                );
            ";

            using var cmd = new SqlCommand(createTableQuery, connection);
            cmd.ExecuteNonQuery();
        }
    }
}