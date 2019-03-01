using SqlDatabaseManager.Domain.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Domain.Security
{
    public interface ISession
    {
        ConnectionInformation GetSession(Guid sessionId);
        Guid CreateSession(ConnectionInformation connection);
    }
}
