﻿using SqlDatabaseManager.Domain.Connection;
using System.Data;
using System.Data.Common;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseFactory
    {
        DbConnectionStringBuilder DbConnectionStringBuilderFactory(ConnectionInformationDTO connectionInformation);

        IDbConnection DbConnectionFactory(DatabaseType databaseType, string connectionString);

        IDbDataAdapter DataAdapterFactory(DatabaseType databaseType);
    }
}