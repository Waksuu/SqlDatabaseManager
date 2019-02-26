using SSqlDatabaseManager.Base.Connection;
using System;
using System.Collections.Generic;

namespace SqlDatabaseManager.Service.Database
{
    public class DatabaseConnection
    {
        public static readonly DatabaseConnection _instance = new DatabaseConnection();

        private DatabaseConnection()
        {
        }

        private Dictionary<Guid, ConnectionInformation> sessions = new Dictionary<Guid, ConnectionInformation>();

        public ConnectionInformation GetConnection(Guid sessionId)
        {
            if (!sessions.ContainsKey(sessionId))
                return null;

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