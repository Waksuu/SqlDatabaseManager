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

            foreach (var database in databases)
            {
                List<TableDefinition> tables = new List<TableDefinition>();
                if (database.Name == "model")
                {
                    database.Tables = tables;
                    continue;
                }

                tables = databaseLogic.GetTables(connectionInformation, database).ToList();
                database.Tables = tables;
            }

            objectExplorer.DatabaseDefinitions = databases;

            return objectExplorer;
        }
    }
}