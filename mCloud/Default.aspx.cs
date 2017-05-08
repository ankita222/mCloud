using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using mCloud.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace mCloud
{
    public partial class Default : System.Web.UI.Page
    {
        mCloudAL AL = new mCloudAL();
        mCloudDAL DAL = new mCloudDAL();
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btncreate_ServerClick(object sender, EventArgs e)
        {

            SqlParameter[] param = { new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@Mobile", txtMob.Value) };
            int x = DAL.FunExecuteNonQuerySP("ust_beginreg", param);

            Session["Email"] = txtEmail.Value;
            Session["isdCode"] = IsdCode.Value;
            Session["Mob"] = txtMob.Value;
            string otp = AL.GenerateOTP();
            Session["otp"] = txtMob.Value;
            if (txtEmail.Value != "")
            {
                int i = AL.SendMail(txtEmail.Value, "Moil Cloud Verfication", "Please Verify Your Email Address By Entering This Code:  " + otp + "");
                if (i == 1)
                    Response.Redirect("preInit/Activity.aspx");
                else
                {
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error! Please try again')", true);
                    Response.Write("<script>alert('Error! Please try again');</script>");
                }
            }

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtMob.Value != "")
            {
                SqlParameter[] param = { new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@Mobile", txtMob.Value) };

                int x = DAL.FunExecuteNonQuerySP("ust_beginreg", param);
                if (x == 1 || x == -1)
                {
                    Session["isdCode"] = IsdCode.Value;
                    Session["Mob"] = txtMob.Value;
                    string otp = AL.GenerateOTP();
                    Session["hashotp"] = AL.PassHash(otp);

                    //SMS API CODE HERE

                    if (txtEmail.Value != "")
                    {
                        Session["Email"] = txtEmail.Value;
                        string activationCode = Guid.NewGuid().ToString();
                        SqlParameter[] param2 = { new SqlParameter("@UserId", txtMob.Value), new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@ActivationCode", activationCode) };
                        int y = DAL.FunExecuteNonQuerySP("ust_emailverification", param2);
                        if (y >= 0)
                        {
                            string body = "Dear Customer,";
                            body += "<br /><br />Please click the following link to verify your email.<br>";
                            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Default.aspx", "Activation.aspx?ActivationCode=" + activationCode) + "'><h2 style='float:left;padding:10px; background-color:#007acc;color:#f0f0f0;width:160px;text-align:center;'>Click here to verify</h2></a>";
                            body += "<br /><br /><br /><br><br>Team MoilCloud";
                            int i = AL.SendMail(txtEmail.Value, "MoilCloud Email Verification", body);

                        }
                    }

                    Response.Redirect("preInit/Activity.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Someting went wrong, please try again.');</script>");
                }

            }
        }
    }
}
