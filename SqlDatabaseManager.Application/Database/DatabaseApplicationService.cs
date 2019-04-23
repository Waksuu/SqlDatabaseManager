using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Application.Database
{
    public class DatabaseApplicationService : IDatabaseApplicationService
    {
        private readonly ISession session;
        private readonly IDatabaseLogic databaseLogic;

        public DatabaseApplicationService(ISession session, IDatabaseLogic databaseLogic)
        {
            this.session = session;
            this.databaseLogic = databaseLogic;
        }

        public IEnumerable<DatabaseDTO> GetDatabasesFromServer(Guid sessionId)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            return databaseLogic.GetDatabases(connectionInformation);
        }

        public IEnumerable<TableDTO> GetTables(Guid sessionId, string databaseName)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            return databaseLogic.GetTables(connectionInformation, databaseName);
        }

        public TableDTO GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            return databaseLogic.GetTableContents(connectionInformation, databaseName, tableName);
        }
    }
}