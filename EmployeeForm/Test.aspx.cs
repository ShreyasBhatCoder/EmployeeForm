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
            if (IsPostBack)
            {
                string originalValue = originalText.Value;
                string updatedValue = updatedText.Value;

                if (!string.IsNullOrEmpty(updatedValue) && originalValue != updatedValue)
                {
                    // Process updated value (store in database, session, etc.)
                    Response.Write($"Original: {originalValue}, Updated: {updatedValue}");
                }
            }
        }





    }
}