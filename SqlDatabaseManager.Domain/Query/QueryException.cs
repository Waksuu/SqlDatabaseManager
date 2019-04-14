using System;

namespace SqlDatabaseManager.Domain.Query
{
    public class QueryException : Exception
    {
        public QueryException()
        {
        }

        public QueryException(string message) : base(message)
        {
        }
    }
}