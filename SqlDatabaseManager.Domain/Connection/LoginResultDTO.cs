using System;

namespace SqlDatabaseManager.Domain.Connection
{
    public class LoginResultDTO
    {
        public Guid SessionId { get; set; }
        public string ErrorMessage { get; set; }
    }
}