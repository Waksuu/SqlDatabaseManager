using SSqlDatabaseManager.Base.Connection;
using System.Collections.Generic;

namespace SqlDatabaseManager.Base.Database
{
    public interface IDatabaseLogic
    {
        IEnumerable<string> GetDatabases(ConnectionInformation connectionInformation);
    }
}