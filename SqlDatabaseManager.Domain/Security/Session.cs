using SqlDatabaseManager.Domain.Connection;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Security
{
    public static class Session
    {
        private static Dictionary<Guid, ConnectionInformation> sessions = new Dictionary<Guid, ConnectionInformation>();

        public static ConnectionInformation GetSession(Guid sessionId)
        {
            ValideSessionExistance(sessionId);

            return sessions[sessionId];
        }

        private static void ValideSessionExistance(Guid sessionId)
        {
            if (!sessions.ContainsKey(sessionId))
                throw new InvalidOperationException(Properties.Resources.SessionError);
        }

        public static Guid CreateSession(ConnectionInformation connection)
        {
            Guid sessionId = Guid.NewGuid();
            sessions.Add(sessionId, connection);

            return sessionId;
        }
    }
}