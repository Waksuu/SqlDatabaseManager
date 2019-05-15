using SqlDatabaseManager.Domain.Database;
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