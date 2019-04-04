using System;
using System.Collections.Generic;
using System.Text;

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
