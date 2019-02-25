using SqlDatabaseManager.Base.Database;
using SqlDatabaseManager.Base.Query;

namespace SqlDatabaseManager.Logic.Query
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