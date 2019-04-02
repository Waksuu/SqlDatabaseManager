using SqlDatabaseManager.Domain.Connection;
using System;

namespace SqlDatabaseManager.Application.Security
{
    public interface ISession
    {
        ConnectionInformationDTO GetSession(Guid sessionId);

        Guid CreateSession(ConnectionInformationDTO connection);

        void DeleteSession(Guid sessionId);
    }
}