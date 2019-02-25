using SqlDatabaseManager.Base.Database;
using SqlDatabaseManager.Base.Login;
using SSqlDatabaseManager.Base.Connection;
using System;
using System.Data.Common;

namespace SqlDatabaseManager.Logic.Login
{
    public class LoginLogic : ILoginLogic
    {
        private readonly IDatabaseFactory _databaseFactory;

        public LoginLogic(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public bool ConnectToDatabase(ConnectionInformation connectionInformation)
        {
            DbConnectionStringBuilder builder = GetConnectionStringBuilder(connectionInformation);

            using (DbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, builder.ConnectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        private DbConnectionStringBuilder GetConnectionStringBuilder(ConnectionInformation connectionInformation) => _databaseFactory.DbConnectionStringBuilderFactory(connectionInformation);

        private DbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => _databaseFactory.DbConnectionFactory(databaseType, connectionString);
    }
}