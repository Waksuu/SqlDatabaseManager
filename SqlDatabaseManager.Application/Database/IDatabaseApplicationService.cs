using SqlDatabaseManager.Domain.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Application.Database
{
    public interface IDatabaseApplicationService
    {
        Task<IEnumerable<DatabaseDTO>> GetDatabasesFromServerAsync(Guid sessionId);

        IEnumerable<TableDTO> GetTables(Guid sessionId, string databaseName);

        TableDTO GetTableContents(Guid sessionId, string databaseName, string tableName);
    }
}