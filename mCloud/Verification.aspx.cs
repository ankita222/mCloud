using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using mCloud.App_Code;

namespace mCloud
{
    public partial class Verification : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["mConstr"].ConnectionString;
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM EmailActivation WHERE ActivationCode = @ActivationCode"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                            cmd.Connection = con;
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rowsAffected == 1)
                            {
                                lblVerifyMsg.Text = "Activation successful.";
                                mCloudDAL dal = new mCloudDAL();
                                dal.FunExecuteNonQuery("UPDATE UserDetails SET IsEmailVerified=1 WHERE UserId=(SELECT UserId FROM EmailActivation WHERE ActivationCode=" + activationCode + ")");
                                
                            }
                            else
                            {
                                lblVerifyMsg.Text = "Invalid Activation code.";
                            }
                        }
                    }
                }
            }
        }
    }
}