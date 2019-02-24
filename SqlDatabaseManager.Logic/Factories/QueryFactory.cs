using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Factories;

namespace SqlDatabaseManager.Logic.Factories
{
    public class QueryFactory : IQueryFactory
    {
        public string ShowDatabases(DatabaseType databaseType)
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