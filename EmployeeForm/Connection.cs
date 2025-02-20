using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;

namespace EmployeeForm
{
    public struct ConnectionParams
    {
        private Connection _db; 
        private SqlConnection _conn;
        private EmployeeAPI _api;


        public Connection db { 
            get { return _db; }
            set { _db = value; } 
        }
        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public EmployeeAPI api
        {
            get { return _api; }
            set { _api = value; }
        }

        public ConnectionParams(string dbname)
        {
            db = new Connection();
            conn = new SqlConnection(_db.ConnectTo(dbname));
            api = new EmployeeAPI();
        }
    }
    public class Connection
    {
        public string ConnectTo(string dbname)
        {
            return ConfigurationManager.ConnectionStrings[dbname].ConnectionString;
        }
    }
}