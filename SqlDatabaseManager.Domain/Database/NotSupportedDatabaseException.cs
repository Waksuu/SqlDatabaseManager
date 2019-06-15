using System;
using System.Runtime.Serialization;

namespace SqlDatabaseManager.Domain.Database
{
    [Serializable]
    internal class NotSupportedDatabaseException : Exception
    {
        public NotSupportedDatabaseException()
        {
        }

        public NotSupportedDatabaseException(string message) : base(message)
        {
        }

        public NotSupportedDatabaseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSupportedDatabaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}