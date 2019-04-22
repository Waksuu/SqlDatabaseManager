using SqlDatabaseManager.Application.Security;
using SqlDatabaseManager.Domain.Connection;
using System;


namespace SqlDatabaseManager.Application.Connection
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
        public Guid CreateDatabaseConnection(ConnectionInformationDTO connectionInformation)
        {
            LoginResultDTO loginResult = new LoginResultDTO();

            loginLogic.ConnectToDatabase(connectionInformation);

            var sessionId = session.CreateSession(connectionInformation);

            return sessionId;
        }

        public void LogoutFromDatabase(Guid sessionId)
        {
            session.DeleteSession(sessionId);
        }
    }
}