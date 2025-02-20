using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EmployeeForm
{
    public class EmployeeAPI
    {
        public void Insert(Employee emp, SqlConnection dbConnStr)
        {
            dbConnStr.Execute($"exec usp_Insert_Employee '{emp.Name}', {emp.Mobile}, '{emp.Email}', '{emp.DOB}', '{emp.Designation}'");
        }


        public Table Fetch(SqlConnection dbConnStr, string name = null)
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

  

            using (SqlCommand command = new SqlCommand($"exec dbo.usp_Get_Employee {name}", dbConnStr))
            {
                SqlDataReader read = command.ExecuteReader();
                while(read.Read())
                {
                    var tableRow = new TableRow();
                    tableRow.Cells.Add(new TableCell() { Text = (string)read[0], Attributes = { ["data-label"] = "Name" } });
                    tableRow.Cells.Add(new TableCell() { Text = read[1].ToString(), Attributes = { ["data-label"] = "Mobile" } });
                    tableRow.Cells.Add(new TableCell() { Text = (string)read[2], Attributes = { ["data-label"] = "Email" } });
                    tableRow.Cells.Add(new TableCell() { Text = Convert.ToDateTime(read[3]).ToString("dd-MM-yyyy"), Attributes = { ["data-label"] = "Date of Birth" } });
                    tableRow.Cells.Add(new TableCell() { Text = (string)read[4], Attributes = { ["data-label"] = "Designation" } });
                    tableRow.Cells.Add(new TableCell() { Text = "<button class=\"btn btn-secondary\" runat=\"server\" onserverclick=\"Delete_Click\">Delete</button>" });

                    table.Rows.Add(tableRow);
                }

            }

            return table;
        }
        public Table Delete(SqlConnection dbConnStr, string name)
        {
            dbConnStr.Open();

            dbConnStr.Execute($"exec dbo.usp_Delete_Employee '{name}'");
            Table table = Fetch(dbConnStr);

            dbConnStr.Close();

            return table;
        }
    }
}