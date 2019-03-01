using SqlDatabaseManager.Domain.Connection;
using System;
using System.Threading.Tasks;

namespace SqlDatabaseManager.Domain.Login
{
    public interface IDatabaseConnectionService
    {
        Task<LoginResult> CreateDatabaseConnectionAsync(ConnectionInformation connectionInformation);
    }
}