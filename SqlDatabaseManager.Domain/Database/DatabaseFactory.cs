using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SqlDatabaseManager.Domain.Connection;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformationDTO connectionInformation)
        {
            switch (connectionInformation.DatabaseType)
            {
                case DatabaseType.MsSql:
                    return new SqlConnectionStringBuilder
                    {
                        DataSource = connectionInformation.ServerAddresss,
                        UserID = connectionInformation.Login,
                        Password = connectionInformation.Password,
                    };

                case DatabaseType.MySql:
                    return new MySqlXConnectionStringBuilder
                    {
                        Server = connectionInformation.ServerAddresss,
                        UserID = connectionInformation.Login,
                        Password = connectionInformation.Password,
                        SslMode = MySqlSslMode.Preferred,
                    };

                default:
                    throw new NotSupportedDatabaseException(string.Format(
                        Properties.Resources.NotSupportedDatabase,
                        connectionInformation.DatabaseType));
            }
        }

        public IDbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString)
        {
            switch (databaseType)
            {
                case DatabaseType.MsSql:
                    return new SqlConnection(connectionString);

                case DatabaseType.MySql:
                    return new MySqlConnection(connectionString);

                default:
                    throw new NotSupportedDatabaseException(string.Format(
                        Properties.Resources.NotSupportedDatabase,
                        databaseType));
            }
        }

        public IDbDataAdapter DataAdapterFactory(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.MsSql:
                    return new SqlDataAdapter();

                case DatabaseType.MySql:
                    return new MySqlDataAdapter();

                default:
                    throw new NotSupportedDatabaseException(string.Format(
                        Properties.Resources.NotSupportedDatabase,
                        databaseType));
            }
        }
    }
}