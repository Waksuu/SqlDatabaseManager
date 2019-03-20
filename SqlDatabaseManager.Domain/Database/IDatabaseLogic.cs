using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.ObjectExplorerData;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseLogic
    {
        IEnumerable<DatabaseDefinition> GetDatabases(ConnectionInformation connectionInformation);
        IEnumerable<DatabaseDefinition> GetDatabasesWithAccess(ConnectionInformation connectionInformation);
        IEnumerable<TableDefinition> GetTables(ConnectionInformation connectionInformation, string databaseName);
        TableDefinition GetTableContents(ConnectionInformation connectionInformation, string tableName);
    }
}