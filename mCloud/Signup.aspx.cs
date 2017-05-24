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
    public partial class Signup : System.Web.UI.Page
    {
        mCloudAL AL = new mCloudAL();
        mCloudDAL DAL = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UserPage/Dashboard.aspx");
            }
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtMob.Text != "" && txtMob.Text.Length == 10)
                {
                    SqlParameter[] param =
                        {
                        new SqlParameter("@UserId", txtMob.Text),
                        new SqlParameter("@Email", txtmail.Text),
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
                        new SqlParameter("@Email", txtmail.Text),
                    };
                        DAL.FunExecuteNonQuerySP("ust_beginreg", param0);
                        Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                        Session["Mob"] = txtMob.Text;
                        string otp = AL.GenOTP();
                        Session["HashOtp"] = AL.PassHash(otp);
                        if (txtmail.Text != "")
                        {
                            Session["Email"] = txtmail.Text;
                        }

                        string OTPrespo = AL.SendOTP(Session["Mob"].ToString(),
                            "MoilCloud OTP: " + otp + " OTP is confidential and not to be disclosed to anyone."
                            );
                        string[] SplitOTP = OTPrespo.Split('|');
                        if (SplitOTP[0] == "SUBMIT_SUCCESS ")
                        {
                            Response.Redirect("~/preInit/Activity.aspx");
                        }
                    }
                }
                else
                    Response.Write("<script>alert('10 digit mobile number only.');</script>");

            }
            catch(Exception ex)
            {
                DAL.OnError(ex);
            }
        }
    }
}