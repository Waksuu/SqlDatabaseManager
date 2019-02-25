using SqlDatabaseManager.Base.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Logic.Query
{
    public class MySQLQuery : IQuery
    {
        public string ShowDatabases() => "show databases";
    }
}
