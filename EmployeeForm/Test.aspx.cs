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
    public partial class Test : System.Web.UI.Page, IPostBackEventHandler
    {
        
        void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
        {
            if(eventArgument == "ClickBtn")
            {
                Button1_Click();
            }
        }

        

        protected void Button1_Click()
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LogButtonClick", $"console.log('Hello World');", true);
            //Response.Write("hello");
        }
    }
}