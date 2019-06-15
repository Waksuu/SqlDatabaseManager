using SqlDatabaseManager.Domain.Connection;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseService
    {
        IEnumerable<DatabaseDTO> GetDatabases(ConnectionInformationDTO connectionInformation);

        IEnumerable<TableDTO> GetTables(ConnectionInformationDTO connectionInformation, string databaseName);

        TableDTO GetTableContents(ConnectionInformationDTO connectionInformation, string databaseName, string tableName);
    }
}