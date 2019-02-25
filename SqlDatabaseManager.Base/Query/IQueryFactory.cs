using SqlDatabaseManager.Base.Database;

namespace SqlDatabaseManager.Base.Query
{
    public interface IQueryFactory
    {
        IQuery GetQuery(DatabaseType databaseType);
    }
}