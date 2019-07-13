using System;

namespace SqlDatabaseManager.Application.Authentication
{
    public class SessionException : Exception
    {
        public SessionException()
        {
        }

        public SessionException(string message) : base(message)
        {
        }
    }
}