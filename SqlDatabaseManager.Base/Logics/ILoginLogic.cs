using SqlDatabaseManager.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlDatabaseManager.Base.Logics
{
    public interface ILoginLogic
    {
        IEnumerable<string> GetDatabasesName(ConnectionInformation connection);
    }
}
