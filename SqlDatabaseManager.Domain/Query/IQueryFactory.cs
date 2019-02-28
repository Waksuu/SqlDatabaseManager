using SqlDatabaseManager.Domain.Database;

namespace SqlDatabaseManager.Domain.Query
{
    public interface IQueryFactory
    {
        IQuery GetQuery(DatabaseType databaseType);
    }
}