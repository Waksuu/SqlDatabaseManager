using SqlDatabaseManager.Domain.Connection;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Domain.Database
{
    public class DatabaseConnection
    {
        public static readonly DatabaseConnection instance = new DatabaseConnection();

        private DatabaseConnection()
        {
        }

        private Dictionary<Guid, ConnectionInformation> sessions = new Dictionary<Guid, ConnectionInformation>();

        public ConnectionInformation GetConnection(Guid sessionId)
        {
            if (!sessions.ContainsKey(sessionId))
                throw new InvalidOperationException(Properties.Resources.SessionError);

            return sessions[sessionId];
        }

        public void SetConnection(Guid sessionId, ConnectionInformation connection)
        {
            if (sessions.ContainsKey(sessionId))
                return;

            sessions.Add(sessionId, connection);
        }
    }
}