using SqlDatabaseManager.Domain.Connection;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Application.Security
{
    public class SessionMemory : ISession
    {
        private Dictionary<Guid, ConnectionInformationDTO> sessions = new Dictionary<Guid, ConnectionInformationDTO>();

        public ConnectionInformationDTO GetSession(Guid sessionId)
        {
            ValideSessionExistance(sessionId);

            return sessions[sessionId];
        }

        private void ValideSessionExistance(Guid sessionId)
        {
            if (!sessions.ContainsKey(sessionId))
                throw new SessionException(Domain.Properties.Resources.SessionError);
        }

        public Guid CreateSession(ConnectionInformationDTO connection)
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