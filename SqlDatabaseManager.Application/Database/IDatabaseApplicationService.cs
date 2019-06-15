using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Database.Table;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Application.Database
{
    public interface IDatabaseApplicationService
    {
        IEnumerable<DatabaseDTO> GetDatabasesFromServer(Guid sessionId);

        IEnumerable<TableDTO> GetTables(Guid sessionId, string databaseName);

        TableDTO GetTableContents(Guid sessionId, string databaseName, string tableName);
    }
}