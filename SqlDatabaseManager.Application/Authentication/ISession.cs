using SqlDatabaseManager.Domain.Connection;
using System;

namespace SqlDatabaseManager.Application.Authentication
{
    internal interface ISession
    {
        ConnectionInformationDTO GetSession(Guid sessionId);

        Guid CreateSession(ConnectionInformationDTO connection);

        void DeleteSession(Guid sessionId);
    }
}