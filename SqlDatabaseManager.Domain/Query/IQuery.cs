using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Domain.Query
{
    public interface IQuery
    {
        string ShowDatabases();
        string ShowTables(string databaseName);
    }
}
