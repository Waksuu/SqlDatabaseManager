using SqlDatabaseManager.Base.Models;
using System.Collections.Generic;

namespace SqlDatabaseManager.Base.Logics
{
    public interface IDatabaseLogic
    {
        IEnumerable<string> GetDatabases(ConnectionInformation connectionInformation);
    }
}