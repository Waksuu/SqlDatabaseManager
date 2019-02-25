using SqlDatabaseManager.Base.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Logic.Query
{
    public class MsSQLQuery : IQuery
    {
        public string ShowDatabases() => "SELECT name from sys.databases";
    }
}
