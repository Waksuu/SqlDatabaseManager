using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Domain.Query
{
    public interface IQueryCommand
    {
        string ShowDatabases();
        string ShowDatabasesWithAccess();
        string ShowTables(string databaseName);
    }
}
