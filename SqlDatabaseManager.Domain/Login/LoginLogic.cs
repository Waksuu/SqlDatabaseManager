using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using System.Data;
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

        public void ConnectToDatabase(ConnectionInformationDTO connectionInformation)
        {
            string connectionString = GetConnectionStringBuilder(connectionInformation);

            using (IDbConnection connection = ConnectToDatabase(connectionInformation.DatabaseType, connectionString))
            {
                connection.Open();
            }
        }

        private string GetConnectionStringBuilder(ConnectionInformationDTO connectionInformation) => _databaseFactory.DbConnectionStringBuilderFactory(connectionInformation).ConnectionString;

        private IDbConnection ConnectToDatabase(DatabaseType databaseType, string connectionString) => _databaseFactory.DbConnectionFactory(databaseType, connectionString);
    }
}