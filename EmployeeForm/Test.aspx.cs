using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services.Description;

namespace EmployeeForm
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                AddElement();
            }
        }


        protected void ClickBtn(object sender, EventArgs e)
        {
            AddElement();
        }

        protected void AddElement()
        {
            var table = new Table();
            var tableHeadRow = new TableHeaderRow();

            

            

            tableHeadRow.Cells.Add(new TableHeaderCell() { Text = "Name", Attributes = { ["style"] = "color: red; position: absolute; top: -9999px; left: -9999px" } });
            tableHeadRow.Cells.Add(new TableHeaderCell() { Text = "Age" });

            table.Rows.Add(tableHeadRow);

            container.Controls.Add(table);
        }

    }
}