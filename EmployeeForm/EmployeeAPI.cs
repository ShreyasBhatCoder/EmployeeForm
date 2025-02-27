using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI;

namespace EmployeeForm
{
    public class EmployeeAPI : EmployeeForm
    {
        int i = 0;
        public void Insert(Employee emp, SqlConnection dbConnStr)
        {
            using (SqlCommand cmd = new SqlCommand("exec usp_Insert_Employee @Name, @Mobile, @Email, @DOB, @Designation", dbConnStr))
            {
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = emp.Name;
                cmd.Parameters.Add("@Mobile", SqlDbType.BigInt).Value = emp.Mobile;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = emp.Email;
                cmd.Parameters.Add("@DOb", SqlDbType.Date).Value = emp.DOB;
                cmd.Parameters.Add("@Designation", SqlDbType.VarChar).Value = emp.Designation;

                cmd.ExecuteNonQuery();
            }
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
                EmployeeForm obj = new EmployeeForm();
                
                SqlDataReader read = command.ExecuteReader();
                while(read.Read())
                {
                    var tableRow = new TableRow()
                    {
                        Attributes =
                        {
                            ["data-command-argument"] = read[0].ToString()
                        }
                    };
                    tableRow.Cells.Add(new TableCell() { Text = (string)read[0], Attributes = { ["data-label"] = "Name" } });
                    tableRow.Cells.Add(new TableCell() { Text = read[1].ToString(), Attributes = { ["data-label"] = "Mobile" } });
                    tableRow.Cells.Add(new TableCell() { Text = (string)read[2], Attributes = { ["data-label"] = "Email" } });
                    tableRow.Cells.Add(new TableCell() { Text = Convert.ToDateTime(read[3]).ToString("dd-MM-yyyy"), Attributes = { ["data-label"] = "Date of Birth" } });
                    tableRow.Cells.Add(new TableCell() { Text = (string)read[4], Attributes = { ["data-label"] = "Designation" } });




                    Button deleteBtn = new Button
                    {
                        ID = $"{read[0].ToString()}_Delete",
                        Text = "Delete",
                        CssClass = "btn btn-danger",
                        CommandArgument = read[0].ToString()
                    };

                    deleteBtn.Click += Delete_Click;

                    Button editBtn = new Button
                    {
                        ID = $"{read[0].ToString()}_Edit",
                        Text = "Edit",
                        CssClass = "btn btn-secondary",
                        CommandArgument = read[0].ToString()
                    };


                    Button saveBtn = new Button
                    {
                        ID = $"{read[0].ToString()}_Save",
                        Text = "Save",
                        CssClass = "btn btn-success replaced",
                        CommandArgument = read[0].ToString()
                    }; 
                    

                    Panel actionButtons = new Panel() { CssClass = "btn-group gap-2", ID = $"actions_{read[0].ToString()}" };
                    actionButtons.Controls.Add(editBtn);
                    actionButtons.Controls.Add(deleteBtn);


                    TableCell deleteRow = new TableCell();
                    deleteRow.Controls.Add(actionButtons);
                    deleteRow.Controls.Add(saveBtn);

                    tableRow.Cells.Add(deleteRow);

                    table.Rows.Add(tableRow);
                }

            }

            return table;
        }

        

        public void Delete(SqlConnection dbConnStr, string name)
        {
            using(SqlCommand cmd = new SqlCommand("exec dbo.usp_Delete_Employee @Name", dbConnStr))
            {
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)).Value = name;
                cmd.ExecuteNonQuery();
            }
        }


        public void Update(SqlConnection dbConnStr)
        {

        }
    }
}