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
            AddEmployees();
        }

        protected void Submit_Click(object sender, EventArgs er)
        {

            try
            {
                Connection db = new Connection();
                SqlConnection conn = new SqlConnection(db.ConnectTo("EmployeeDB"));
                conn.Open();

                //ADO connection

                if (IsPostBack)
                {
                    
                }
            }
            catch (Exception e)
            {
                if(IsPostBack)
                {
                    string script = $$"""
                        document.getElementsByClassName('modal-body')[0].innerHTML = '{{e.Message}}';
                        (new bootstrap.Modal(document.getElementById('staticBackdrop'))).show();
                    """;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
                }
            }


        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            TextName.Text = "";
            TextMobile.Text = "";
            TextEmail.Text = "";
            TextDOB.Text = "";
            TextDesignation.Text = "";
        }
        protected void Fetch_Click(object sender, EventArgs e)
        {

        }

        protected void AddEmployees()
        {
            //< asp:TableHeaderRow >
            //    < asp:TableHeaderCell > Name </ asp:TableHeaderCell >
            //    < asp:TableHeaderCell > Mobile </ asp:TableHeaderCell >
            //    < asp:TableHeaderCell > Email </ asp:TableHeaderCell >
            //    < asp:TableHeaderCell > Date of Birth</ asp:TableHeaderCell >
            //    < asp:TableHeaderCell > Designation </ asp:TableHeaderCell >
            //    < asp:TableHeaderCell ></ asp:TableHeaderCell >
            //</ asp:TableHeaderRow >
            //< asp:TableRow >
            //    < asp:TableCell > Shreyas </ asp:TableCell >
            //    < asp:TableCell > Shreyas </ asp:TableCell >
            //    < asp:TableCell > Shreyas </ asp:TableCell >
            //    < asp:TableCell > Shreyas </ asp:TableCell >
            //    < asp:TableCell > Shreyas </ asp:TableCell >
            //    < asp:TableCell ><button class="btn btn-secondary" runat="server">Delete</button></asp:TableCell>
            //</asp:TableRow>

            var table = new Table();
            var Headers = new TableHeaderRow();
            Headers.TableSection = TableRowSection.TableHeader;

            Headers.Cells.Add(new TableHeaderCell() { Text = "Name" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Mobile" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Email" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Date of Birth" });
            Headers.Cells.Add(new TableHeaderCell() { Text = "Designation" });
            Headers.Cells.Add(new TableHeaderCell());

            table.Rows.Add(Headers);

            var tableRow1 = new TableRow();

            tableRow1.Cells.Add(new TableCell() { Text = "Shreyas", Attributes = { ["data-label"] = "Name" } });
            tableRow1.Cells.Add(new TableCell() { Text = "9820819316", Attributes = { ["data-label"] = "Mobile" } });
            tableRow1.Cells.Add(new TableCell() { Text = "shreyas@example.com", Attributes = { ["data-label"] = "Email" } });
            tableRow1.Cells.Add(new TableCell() { Text = "20-09-2002", Attributes = { ["data-label"] = "Date of Birth" } });
            tableRow1.Cells.Add(new TableCell() { Text = "CSE", Attributes = { ["data-label"] = "Designation" } });
            tableRow1.Cells.Add(new TableCell() { Text = "<button class=\"btn btn-secondary\" runat=\"server\">Delete</button>" });

            table.Rows.Add(tableRow1);

            

            EmpTable.Controls.Add(table);
        }
    }
}