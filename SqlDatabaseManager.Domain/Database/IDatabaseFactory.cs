using SqlDatabaseManager.Domain.Connection;
using System.Data.Common;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseFactory
    {
        DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformation connectionInformation);

        DbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString);
    }
}