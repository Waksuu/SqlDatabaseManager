using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using System.Data.Common;

namespace SqlDatabaseManager.Domain.Login
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IDatabaseFactory _databaseFactory;

        public LoginLogic(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void ConnectToDatabase(ConnectionInformation connectionInformation)
        {
            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (DbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                connection.Open();
            }
        }

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => _databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private DbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => _databaseFactory.DbConnectionFactory(databaseType, connectionString);
    }
}