using SqlDatabaseManager.Domain.Connection;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseLogic
    {
        IEnumerable<DatabaseDTO> GetDatabases(ConnectionInformationDTO connectionInformation);

        IEnumerable<DatabaseDTO> GetDatabasesWithAccess(ConnectionInformationDTO connectionInformation);

        IEnumerable<TableDTO> GetTables(ConnectionInformationDTO connectionInformation, string databaseName);

        TableDTO GetTableContents(ConnectionInformationDTO connectionInformation, string tableName, string databaseName);
    }
}