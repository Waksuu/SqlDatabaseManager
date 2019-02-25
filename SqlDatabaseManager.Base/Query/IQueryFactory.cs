using SqlDatabaseManager.Base.Enums;
using SqlDatabaseManager.Base.Query;

namespace SqlDatabaseManager.Base.Factories
{
    public interface IQueryFactory
    {
        IQuery GetQuery(DatabaseType databaseType);
    }
}