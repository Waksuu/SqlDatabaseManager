using System;

namespace SqlDatabaseManager.Domain.Login
{
    public class LoginResultDTO
    {
        public Guid SessionId { get; set; }
        public string ErrorMessage { get; set; }
    }
}