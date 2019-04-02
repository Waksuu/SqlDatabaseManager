using SqlDatabaseManager.Application.Security;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.ObjectExplorerData;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<IEnumerable<DatabaseDTO>> GetDatabasesFromServerAsync(Guid sessionId) => Task.Run(() => GetDatabasesFromServer(sessionId));

        private IEnumerable<DatabaseDTO> GetDatabasesFromServer(Guid sessionId)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);

            var databases = databaseLogic.GetDatabases(connectionInformation);
            var databasesWithAccess = databaseLogic.GetDatabasesWithAccess(connectionInformation).ToList();
            var databasesWithoutAccess = databases.Except(databasesWithAccess);

            GetTablesForDatabasesWithUserAccess(connectionInformation, databasesWithAccess);

            databases = databasesWithAccess.Concat(databasesWithoutAccess).OrderBy(x => x.Name);

            return databases;
        }

        private void GetTablesForDatabasesWithUserAccess(ConnectionInformationDTO connectionInformation, List<DatabaseDTO> databasesWithAccess)
        {
            foreach (var database in databasesWithAccess)
            {
                database.Tables = databaseLogic.GetTables(connectionInformation, database.Name).ToList();
            }
        }

        public TableDTO GetTableContents(Guid sessionId, string tableName, string databaseName)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);
            var table = databaseLogic.GetTableContents(connectionInformation, tableName, databaseName);
            return table;
        }
    }
}