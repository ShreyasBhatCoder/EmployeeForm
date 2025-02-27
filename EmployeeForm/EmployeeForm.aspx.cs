using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Web.UI.HtmlControls;

namespace EmployeeForm
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                EmpTable.Controls.Clear();
                ConnectionParams connection = new ConnectionParams("EmployeeDesktop");

                connection.conn.Open();


                Table newTable = connection.api.Fetch(connection.conn);

                EmpTable.Controls.Add(newTable);
                connection.conn.Close();
            }
        }

        protected void Submit_Click(object sender, EventArgs er)
        {
            Table empTable;
            ConnectionParams connection = new ConnectionParams("EmployeeDesktop");
            Employee employee = new Employee
            {
                Name = TextName.Text,
                Mobile = Convert.ToInt64(TextMobile.Text),
                Email = TextEmail.Text,
                DOB = TextDOB.Text,
                Designation = TextDesignation.Text
            };
            try
            {
                connection.conn.Open();

                connection.api.Insert(employee, connection.conn);

                ResetFields();

                EmpTable.Controls.Clear();
                empTable = connection.api.Fetch(connection.conn);
                EmpTable.Controls.Add(empTable);
                connection.conn.Close();


            } catch(Exception e)
            {
                InvokeErrorModal(e.Message);
            }
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            EmpTable.Controls.Clear();
            ConnectionParams connection = new ConnectionParams("EmployeeDesktop"); 
            try
            {
                connection.conn.Open();

                Table newTable = connection.api.Fetch(connection.conn, FetchEmp.Text);

                EmpTable.Controls.Add(newTable);

                connection.conn.Close();
            }
            catch (Exception ex)
            {
                InvokeErrorModal(ex.Message);
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Button deleteButton = (Button)sender;
            ConnectionParams connection = new ConnectionParams("EmployeeDesktop");
            connection.conn.Open();
            connection.api.Delete(connection.conn, deleteButton.CommandArgument.ToString());
            connection.conn.Close();

            ResetFields();
        }

        

        

        private void InvokeErrorModal(string message)
        {
            if (IsPostBack)
            {
                string errorMsg = HttpUtility.JavaScriptStringEncode(message);
                string script = $$"""
                            document.getElementsByClassName('modal-body')[0].innerHTML = '{{errorMsg}}';
                            (new bootstrap.Modal(document.getElementById('staticBackdrop'))).show();
                        """;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            }
        }

        protected void ResetFields()
        {
            TextName.Text = "";
            TextMobile.Text = "";
            TextEmail.Text = "";
            TextDOB.Text = "";
            TextDesignation.Text = "";
            FetchEmp.Text = "";
        }
    }
}