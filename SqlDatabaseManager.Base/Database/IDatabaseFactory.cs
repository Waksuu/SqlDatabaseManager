using SSqlDatabaseManager.Base.Connection;
using System.Data.Common;

namespace SqlDatabaseManager.Base.Database
{
    public interface IDatabaseFactory
    {
        DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformation connectionInformation);

        DbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString);
    }
}