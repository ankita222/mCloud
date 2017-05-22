using mCloud.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mCloud.UserPage
{
    public partial class EmailVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                //string constr = ConfigurationManager.ConnectionStrings["mConstr"].ConnectionString;
                if (!string.IsNullOrEmpty(Request.QueryString["ActivationCode"]))
                {
                    string activationCode = Request.QueryString["ActivationCode"];

                    mCloudDAL dal = new mCloudDAL();
                    object userid = dal.FunExecuteScalar("SELECT UserId FROM EmailActivation WHERE ActivationCode='" + activationCode + "'");

                    int x = dal.FunExecuteNonQuery("DELETE FROM EmailActivation WHERE ActivationCode ='" + activationCode + "'");
                    if (x > 0)
                    {
                        int a = dal.FunExecuteNonQuery("UPDATE UserDetails SET IsEmailVerified=1 WHERE UserId='" + userid.ToString() + "'");
                        lblVerifyMsg.Text = "Activation successful.";
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
