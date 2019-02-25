using SqlDatabaseManager.Base.Database;

namespace SSqlDatabaseManager.Base.Connection
{
    public class ConnectionInformation
    {
        public string ServerAddress { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DatabaseType DatabaseType { get; set; }
    }
}