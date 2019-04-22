using SqlDatabaseManager.Domain.Connection;
using System;

namespace SqlDatabaseManager.Application.Connection
{
    public interface IDatabaseConnectionApplicationService
    {
        Guid CreateDatabaseConnection(ConnectionInformationDTO connectionInformation);

        void LogoutFromDatabase(Guid sessionId);
    }
}