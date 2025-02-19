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
            Table table = new Table();
            TableHeaderRow Headers = new TableHeaderRow();
            Headers.TableSection = TableRowSection.TableHeader;

            Headers.Cells.Add(new TableHeaderCell() { Text = "Name" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Mobile" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Email" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Date of Birth" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Designation" });
            Headers.Cells.Add(new TableHeaderCell());

            table.Rows.Add(Headers);


            using (SqlCommand command = new SqlCommand("exec usp_Delete_Employee @name", dbConnStr))
            {
                //var tableRow1 = new TableRow();

                //tableRow1.Cells.Add(new TableCell() { Text = "Shreyas", Attributes = { ["data-label"] = "Name" } });
                //tableRow1.Cells.Add(new TableCell() { Text = "9820819316", Attributes = { ["data-label"] = "Mobile" } });
                //tableRow1.Cells.Add(new TableCell() { Text = "shreyas@example.com", Attributes = { ["data-label"] = "Email" } });
                //tableRow1.Cells.Add(new TableCell() { Text = "20-09-2002", Attributes = { ["data-label"] = "Date of Birth" } });
                //tableRow1.Cells.Add(new TableCell() { Text = "CSE", Attributes = { ["data-label"] = "Designation" } });
                //tableRow1.Cells.Add(new TableCell() { Text = "<button class=\"btn btn-secondary\" runat=\"server\">Delete</button>" });

                //table.Rows.Add(tableRow1);

            }

            return table;
        }
        public void Delete(SqlConnection dbConnStr)
        {
            using(SqlCommand command = new SqlCommand("exec usp_Delete_Employee @this.Name", dbConnStr))
            {

            }
        }
    }
}