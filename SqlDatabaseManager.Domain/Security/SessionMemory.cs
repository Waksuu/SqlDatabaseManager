using SqlDatabaseManager.Domain.Connection;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Security
{
    public class SessionMemory : ISession
    {
        private Dictionary<Guid, ConnectionInformation> sessions = new Dictionary<Guid, ConnectionInformation>();

        public ConnectionInformation GetSession(Guid sessionId)
        {
            ValideSessionExistance(sessionId);

            return sessions[sessionId];
        }

        private void ValideSessionExistance(Guid sessionId)
        {
            if (!sessions.ContainsKey(sessionId))
                throw new InvalidOperationException(Properties.Resources.SessionError);
        }

        public Guid CreateSession(ConnectionInformation connection)
        {
            Guid sessionId = Guid.NewGuid();
            sessions.Add(sessionId, connection);

            return sessionId;
        }

        public void DeleteSession(Guid sessionId)
        {
            ValideSessionExistance(sessionId);
            sessions.Remove(sessionId);
        }
    }
}