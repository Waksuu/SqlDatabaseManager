using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Factories;
using SqlDatabaseManager.Base.Query;
using SqlDatabaseManager.Logic.Query;

namespace SqlDatabaseManager.Logic.Factories
{
    public class QueryFactory : IQueryFactory
    {
        public IQuery GetQuery(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.MsSql:
                    return new MsSQLQuery();

                case DatabaseType.MySql:
                    return new MySQLQuery();

                default:
                    return null;
            }
        }
    }
}