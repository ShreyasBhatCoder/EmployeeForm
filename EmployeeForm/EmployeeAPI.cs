using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EmployeeForm
{
    internal class EmployeeAPI : Employee
    {
        public void Insert(SqlConnection dbConnStr)
        {
            dbConnStr.Execute("usp_Insert_Employee @this.Name, cast(@this.Mobile as bigint), @this.Email, cast(@this.DOB as date), @this.Designation");
        }


        public static Table Fetch(SqlConnection dbConnStr, string name = null)
        {
            Table employees = new Table();
            using (SqlCommand command = new SqlCommand("exec usp_Delete_Employee @name", dbConnStr))
            {

            }

            throw new NotImplementedException();
        }
        public void Delete(SqlConnection dbConnStr)
        {
            using(SqlCommand command = new SqlCommand("exec usp_Delete_Employee @this.Name", dbConnStr))
            {

            }
        }
    }
}