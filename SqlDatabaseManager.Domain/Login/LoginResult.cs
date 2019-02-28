using System;

namespace SqlDatabaseManager.Domain.Login
{
    public class LoginResult
    {
        public Guid SessionId { get; set; }
        public string ErrorMessage { get; set; }
    }
}