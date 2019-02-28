using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SqlDatabaseManager.Domain.Connection;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformation connectionInformation)
        {
            switch (connectionInformation.DatabaseType)
            {
                case DatabaseType.MsSql:
                    return new SqlConnectionStringBuilder
                    {
                        DataSource = connectionInformation.ServerAddress,
                        UserID = connectionInformation.Login,
                        Password = connectionInformation.Password,
                    };

                case DatabaseType.MySql:
                    return new MySqlXConnectionStringBuilder
                    {
                        Server = connectionInformation.ServerAddress,
                        UserID = connectionInformation.Login,
                        Password = connectionInformation.Password,
                        SslMode = MySqlSslMode.Preferred,
                    };

                default:
                    return null;
            }
        }

        public DbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString)
        {
            switch (databaseType)
            {
                case DatabaseType.MsSql:
                    return new SqlConnection(connectionString);

                case DatabaseType.MySql:
                    return new MySqlConnection(connectionString);

                default:
                    return null;
            }
        }
    }
}