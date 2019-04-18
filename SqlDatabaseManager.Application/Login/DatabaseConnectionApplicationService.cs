using SqlDatabaseManager.Application.Security;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Login;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Application.Login
{
    public class DatabaseConnectionApplicationService : IDatabaseConnectionApplicationService
    {
        private readonly ILoginLogic loginLogic;
        private readonly ISession session;

        public DatabaseConnectionApplicationService(ILoginLogic loginLogic, ISession session)
        {
            this.loginLogic = loginLogic;
            this.session = session;
        }
        public LoginResultDTO CreateDatabaseConnection(ConnectionInformationDTO connectionInformation)
        {
            LoginResultDTO loginResult = new LoginResultDTO();

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