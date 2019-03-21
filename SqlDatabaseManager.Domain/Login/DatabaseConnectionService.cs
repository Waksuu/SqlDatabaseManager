using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Security;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Login
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private readonly ILoginLogic loginLogic;
        private readonly ISession session;

        public DatabaseConnectionService(ILoginLogic loginLogic, ISession session)
        {
            this.loginLogic = loginLogic;
            this.session = session;
        }

        public Task<LoginResult> CreateDatabaseConnectionAsync(ConnectionInformation connectionInformation) => Task.Run(() => CreateDatabaseConnection(connectionInformation));

        private LoginResult CreateDatabaseConnection(ConnectionInformation connectionInformation)
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

            var sessionId = session.CreateSession(connectionInformation);
            loginResult.SessionId = sessionId;

            return loginResult;
        }

        public void LogoutFromDatabase(Guid sessionId)
        {
            session.DeleteSession(sessionId);
        }
    }
}