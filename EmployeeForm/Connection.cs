using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EmployeeForm
{
    public class Connection
    {
        public string ConnectTo(string dbname)
        {
            return ConfigurationManager.ConnectionStrings[dbname].ConnectionString;
        }
    }
}