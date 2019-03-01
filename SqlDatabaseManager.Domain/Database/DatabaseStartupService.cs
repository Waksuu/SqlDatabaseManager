using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Security;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseStartupService : IDatabaseStartupService
    {
        private readonly ISession session;
        private readonly IDatabaseLogic databaseLogic;

        public DatabaseStartupService(ISession session, IDatabaseLogic databaseLogic)
        {
            this.session = session;
            this.databaseLogic = databaseLogic;
        }


        public Task<IEnumerable<DatabaseDefinition>> GetDatabaseDefinitionsAsync(Guid sessionId) => Task.Run(() => GetDatabaseDefinitions(sessionId));

        private IEnumerable<DatabaseDefinition> GetDatabaseDefinitions(Guid sessionId)
        {
            ConnectionInformation connectionInformation = session.GetSession(sessionId);

            return databaseLogic.GetDatabases(connectionInformation);
        }
    }
}