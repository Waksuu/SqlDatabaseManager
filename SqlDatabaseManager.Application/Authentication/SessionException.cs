using System;
using System.Collections.Generic;
using System.Text;

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
