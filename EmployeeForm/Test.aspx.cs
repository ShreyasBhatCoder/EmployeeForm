using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Services.Description;
using System.Web.Script.Serialization;

namespace EmployeeForm
{
    public partial class Test : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            // Check if hidden fields have data before deserializing
            Dictionary<string, Dictionary<string, string>> originalData = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, Dictionary<string, string>> updatedData = new Dictionary<string, Dictionary<string, string>>();

            if (!string.IsNullOrEmpty(OriginalHidden.Value))
            {
                try
                {
                    originalData = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(OriginalHidden.Value);
                }
                catch (Exception ex)
                {
                    Response.Write("Error parsing original data: " + ex.Message);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(UpdatedHidden.Value))
            {
                try
                {
                    updatedData = serializer.Deserialize<Dictionary<string, Dictionary<string, string>>>(UpdatedHidden.Value);
                }
                catch (Exception ex)
                {
                    Response.Write("Error parsing updated data: " + ex.Message);
                    return;
                }
            }

            // Check if originalData has any rows
            if (originalData == null || originalData.Count == 0)
            {
                Response.Write("No data available.");
                return;
            }

            // Process data
            foreach (var row in originalData.Keys)
            {
                string originalName = originalData[row].ContainsKey("Name") ? originalData[row]["Name"] : "";
                string updatedName = updatedData.ContainsKey(row) && updatedData[row].ContainsKey("Name") ? updatedData[row]["Name"] : originalName;

                string originalAge = originalData[row].ContainsKey("Age") ? originalData[row]["Age"] : "";
                string updatedAge = updatedData.ContainsKey(row) && updatedData[row].ContainsKey("Age") ? updatedData[row]["Age"] : originalAge;

                string originalCity = originalData[row].ContainsKey("City") ? originalData[row]["City"] : "";
                string updatedCity = updatedData.ContainsKey(row) && updatedData[row].ContainsKey("City") ? updatedData[row]["City"] : originalCity;

                Response.Write($"Row {row} → Original: {originalName}, {originalAge}, {originalCity} | Updated: {updatedName}, {updatedAge}, {updatedCity} <br/>");
            }
        }







    }
}