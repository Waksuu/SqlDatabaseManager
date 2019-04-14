using SqlDatabaseManager.Domain.Database;

namespace SqlDatabaseManager.Domain.Connection
{
    public class ConnectionInformationDTO
    {
        public string ServerAddresss { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DatabaseType DatabaseType { get; set; }
    }
}