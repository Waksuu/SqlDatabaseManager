using SqlDatabaseManager.Base.Enums;

namespace SqlDatabaseManager.Base.Models
{
    public class ConnectionInformation
    {
        public string ServerAddress { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public DatabaseType DatabaseType { get; set; }
    }
}