using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Domain.Connection;
using System;

namespace SqlDatabaseManager.Application.Connection
{
    internal class DatabaseConnectionApplicationService : IDatabaseConnectionApplicationService
    {
        private readonly IConnectionSerivce connectionSerivce;
        private readonly ISession session;

        public DatabaseConnectionApplicationService(IConnectionSerivce connectionSerivce, ISession session)
        {
            this.connectionSerivce = connectionSerivce;
            this.session = session;
        }

        public Guid CreateDatabaseConnection(ConnectionInformationDTO connectionInformation)
        {
            connectionSerivce.ConnectToDatabase(connectionInformation);
            return session.CreateSession(connectionInformation);
        }

        public void LogoutFromDatabase(Guid sessionId)
        {
            session.DeleteSession(sessionId);
        }
    }
}