using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Models;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlDatabaseManager.Base.Factories
{
    public class DatabaseFactory
    {
        static public DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformation connectionInformation)
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
                        SslMode = MySqlSslMode.None, // TODO: Check what sslmode - none does.
                    };

                default:
                    return null;
            }
        }

        static public DbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString)
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