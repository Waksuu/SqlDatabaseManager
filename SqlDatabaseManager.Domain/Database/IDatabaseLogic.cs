using SqlDatabaseManager.Domain.Connection;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseLogic
    {
        IEnumerable<DatabaseDefinition> GetDatabases(ConnectionInformation connectionInformation);
    }
}