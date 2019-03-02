using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Security;
using System;
using System.Collections.Generic;
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


        public Task<ObjectExplorer> GetObjectExplorerDataAsync(Guid sessionId) => Task.Run(() => GetObjectExplorerData(sessionId));

        private ObjectExplorer GetObjectExplorerData(Guid sessionId)
        {
            ConnectionInformation connectionInformation = session.GetSession(sessionId);

            ObjectExplorer objectExplorer = new ObjectExplorer();
            objectExplorer.DatabaseDefinitions = databaseLogic.GetDatabases(connectionInformation);
            return objectExplorer;
        }
    }
}