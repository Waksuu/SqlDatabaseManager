using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Login;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Application.Login
{
    public interface IDatabaseConnectionApplicationService
    {
        Task<LoginResultDTO> CreateDatabaseConnectionAsync(ConnectionInformationDTO connectionInformation);

        void LogoutFromDatabase(Guid sessionId);
    }
}