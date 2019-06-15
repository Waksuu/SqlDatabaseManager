using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Database.Table;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Application.Database
{
    public class DatabaseApplicationService : IDatabaseApplicationService
    {
        private readonly ISession session;
        private readonly IDatabaseService databaseService;

        public DatabaseApplicationService(ISession session, IDatabaseService databaseService)
        {
            this.session = session;
            this.databaseService = databaseService;
        }

        public IEnumerable<DatabaseDTO> GetDatabasesFromServer(Guid sessionId)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            return databaseService.GetDatabases(connectionInformation);
        }

        public IEnumerable<TableDTO> GetTables(Guid sessionId, string databaseName)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            return databaseService.GetTables(connectionInformation, databaseName);
        }

        public TableDTO GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            return databaseService.GetTableContents(connectionInformation, databaseName, tableName);
        }
    }
}