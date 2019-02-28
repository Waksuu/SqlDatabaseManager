using SqlDatabaseManager.Domain.Connection;
using System;

namespace SqlDatabaseManager.Domain.Login
{
    public interface IDatabaseConnectionService
    {
        LoginResult CreateDatabaseConnection(ConnectionInformation connectionInformation);
    }
}