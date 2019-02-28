using SqlDatabaseManager.Domain.Connection;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public interface IDatabaseLogic
    {
        IEnumerable<string> GetDatabases(ConnectionInformation connectionInformation);
    }
}