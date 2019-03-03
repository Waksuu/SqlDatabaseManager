using SqlDatabaseManager.Domain.Database;

namespace SqlDatabaseManager.Domain.Query
{
    public interface IQueryFactory
    {
        IQueryCommand GetQuery(DatabaseType databaseType);
    }
}