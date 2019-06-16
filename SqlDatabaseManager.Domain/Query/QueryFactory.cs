using SqlDatabaseManager.Domain.Database;

namespace SqlDatabaseManager.Domain.Query
{
    public class QueryFactory : IQueryFactory
    {
        public IQueryCommand GetQueryCommand(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.MsSql:
                    return new MsSQLQueryCommand();

                case DatabaseType.MySql:
                    return new MySQLQueryCommand();

                default:
                    throw new NotSupportedDatabaseException(string.Format(
                        Properties.Resources.NotSupportedDatabase,
                        databaseType));
            }
        }
    }
}