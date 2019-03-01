using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Security;
using System;
using System.Collections.Generic;

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

        public IEnumerable<DatabaseDefinition> GetDatabaseDefinitions(Guid sessionId)
        {
            ConnectionInformation connectionInformation = session.GetSession(sessionId);

            return databaseLogic.GetDatabases(connectionInformation);
        }
    }
}