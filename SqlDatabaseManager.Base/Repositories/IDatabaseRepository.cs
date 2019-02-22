using SqlDatabaseManager.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Base.Repositories
{
    public interface IDatabaseRepository
    {
        IEnumerable<string> GetDatabases(ConnectionInformation connection);
    }
}
