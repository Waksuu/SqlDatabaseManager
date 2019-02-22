using SqlDatabaseManager.Base.Models;
using SqlDatabaseManager.Base.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlDatabaseManager.Repository
{
    public class MsSqlRepository : IDatabaseRepository
    {
        public IEnumerable<string> GetDatabases(ConnectionInformation info)
        {
            List<string> databases = new List<string>();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = info.ServerAddress,
                UserID = info.Login,
                Password = info.Password,
            };

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", connection))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            databases.Add(dr[0].ToString());
                        }
                    }
                }
            }

            return databases;
        }
    }
}