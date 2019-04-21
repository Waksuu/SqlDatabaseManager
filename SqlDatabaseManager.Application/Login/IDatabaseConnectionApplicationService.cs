using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Login;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Application.Login
{
    public interface IDatabaseConnectionApplicationService
    {
        Guid CreateDatabaseConnection(ConnectionInformationDTO connectionInformation);

        void LogoutFromDatabase(Guid sessionId);
    }
}