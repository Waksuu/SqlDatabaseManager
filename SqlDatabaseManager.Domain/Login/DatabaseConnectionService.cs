using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Security;
using System;

namespace SqlDatabaseManager.Domain.Login
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private readonly ILoginLogic loginLogic;

        public DatabaseConnectionService(ILoginLogic loginLogic)
        {
            this.loginLogic = loginLogic;
        }

        public LoginResult CreateDatabaseConnection(ConnectionInformation connectionInformation)
        {
            LoginResult loginResult = new LoginResult();

            try
            {
                loginLogic.ConnectToDatabase(connectionInformation);
            }
            catch (Exception ex)
            {
                loginResult.ErrorMessage = ex.Message;
                return loginResult;
            }

            var sessionId = Session.CreateSession(connectionInformation);
            loginResult.SessionId = sessionId;

            return loginResult;
        }
    }
}