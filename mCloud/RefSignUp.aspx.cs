using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace mCloud
{
    public partial class RefSignUp : System.Web.UI.Page
    {
        mCloudAL AL = new mCloudAL();
        mCloudDAL DAL = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UserPage/Dashboard.aspx");
            }
            else
            {
                if (!String.IsNullOrEmpty(Request.QueryString["RefCode"]))
                {
                    txtRefCode.Value = Request.QueryString["RefCode"];
                }
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtMob.Text != "" && txtMob.Text.Length == 10)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["RefCode"]) && txtRefCode.Value != "")
                {
                    SqlParameter[] param =
                        {
                        new SqlParameter("@UserId", txtMob.Text),
                        new SqlParameter("@Email", txtEmail.Text),
                    };
                    object UserExist = DAL.FunExecuteScalarSP("ust_beginregcheck", param);

                    if (Convert.ToInt32(UserExist) > 0)
                    {
                        Response.Write("<script>alert('Mobile and/or Email already exist!');</script>");
                    }
                    else
                    {
                        SqlParameter[] param0 =
                            {
                                new SqlParameter("@Mobile", txtMob.Text),
                                new SqlParameter("@Email", txtEmail.Text),
                            };
                        DAL.FunExecuteNonQuerySP("ust_beginreg", param0);
                        Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                        Session["Mob"] = txtMob.Text;
                        string otp = AL.GenOTP();
                        Session["HashOtp"] = AL.PassHash(otp);
                        if (txtEmail.Text != "")
                        {
                            Session["Email"] = txtEmail.Text;
                        }
                        Session["RefCode"] = txtRefCode.Value;

                        //SMS API CODE HERE

                        Response.Redirect("preInit/Activity.aspx");
                    }
                }
                Response.Write("<script>alert('Reference code should not be empty.');</script>");

            }
            else
                Response.Write("<script>alert('10 digit mobile number only.');</script>");
        }
    }
}