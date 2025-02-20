using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeForm
{
    public class Employee : EmployeeAPI
    {
        private string _name;
        private long _mobile;
        private string _email;
        private string _dob;
        private string _designation;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public long Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string DOB 
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

    }
}