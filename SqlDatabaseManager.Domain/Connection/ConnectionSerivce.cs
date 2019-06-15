using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using System.Data;
using System.Data.Common;

namespace SqlDatabaseManager.Domain.Connection
{
    public class ConnectionSerivce : IConnectionSerivce
    {
        private readonly IDatabaseFactory databaseFactory;

        public ConnectionSerivce(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        public void ConnectToDatabase(ConnectionInformationDTO connectionInformation)
        {
            string connectionString = GetConnectionString(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, connectionString))
            {
                connection.Open();
            }
        }

        private string GetConnectionString(ConnectionInformationDTO connectionInformation) => databaseFactory.DbConnectionStringBuilderFactory(connectionInformation).ConnectionString;

        private IDbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => databaseFactory.DbConnectionFactory(databaseType, connectionString);
    }
}