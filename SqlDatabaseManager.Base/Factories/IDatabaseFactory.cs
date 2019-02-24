using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SqlDatabaseManager.Base.Factories
{
    public interface IDatabaseFactory
    {
        DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformation connectionInformation);
        DbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString);
    }
}
