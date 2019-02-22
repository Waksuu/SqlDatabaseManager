using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Models;
using System.Data.Common;
using System.Data.SqlClient;

namespace SqlDatabaseManager.Base.Factories
{
    public class QueryFactory
    {
        static public string ShowDatabases(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.MsSql:
                    return "SELECT name from sys.databases";
                case DatabaseType.MySql:
                    return "show databases";
                default:
                    return null;
            }
        }
    }
}