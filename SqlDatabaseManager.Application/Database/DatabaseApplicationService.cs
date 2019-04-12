using SqlDatabaseManager.Application.Security;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
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

            return databaseLogic.GetDatabases(connectionInformation);
        }

        public TableDTO GetTableContents(Guid sessionId, string databaseName, string tableName)
        {
            ConnectionInformationDTO connectionInformation = session.GetSession(sessionId);
            var table = databaseLogic.GetTableContents(connectionInformation, databaseName, tableName);
            return table;
        }
    }
}