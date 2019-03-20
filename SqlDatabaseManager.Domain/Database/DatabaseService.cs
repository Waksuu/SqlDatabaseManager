using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.ObjectExplorerData;
using SqlDatabaseManager.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ISession session;
        private readonly IDatabaseLogic databaseLogic;

        public DatabaseService(ISession session, IDatabaseLogic databaseLogic)
        {
            this.session = session;
            this.databaseLogic = databaseLogic;
        }

        public Task<ObjectExplorerDefinition> GetObjectExplorerDataAsync(Guid sessionId) => Task.Run(() => GetObjectExplorerData(sessionId));

        private ObjectExplorerDefinition GetObjectExplorerData(Guid sessionId)
        {
            ConnectionInformation connectionInformation = session.GetSession(sessionId);

            ObjectExplorerDefinition objectExplorer = new ObjectExplorerDefinition();

            var databases = databaseLogic.GetDatabases(connectionInformation);
            var databasesWithAccess = databaseLogic.GetDatabasesWithAccess(connectionInformation).ToList();
            var databasesWithoutAccess = databases.Except(databasesWithAccess);

            GetTablesForDatabasesWithUserAccess(connectionInformation, databasesWithAccess);

            databases = databasesWithAccess.Concat(databasesWithoutAccess).OrderBy(x => x.Name);
            objectExplorer.DatabaseDefinitions = databases;

            return objectExplorer;
        }

        private void GetTablesForDatabasesWithUserAccess(ConnectionInformation connectionInformation, List<DatabaseDefinition> databasesWithAccess)
        {
            foreach (var database in databasesWithAccess)
            {
                database.Tables = databaseLogic.GetTables(connectionInformation, database.Name).ToList();
            }
        }

        public TableDefinition GetTableContents(Guid sessionId, string tableName, string databaseName)
        {
            ConnectionInformation connectionInformation = session.GetSession(sessionId);
            var table = databaseLogic.GetTableContents(connectionInformation, tableName, databaseName);
            table.Name = tableName;
            return table;
        }
    }
}