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

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtmobileno.Value != "")
            {
                SqlParameter[] param = { new SqlParameter("@Email", txtmail.Value), new SqlParameter("@Mobile", txtmobileno.Value) };

                int x = DAL.FunExecuteNonQuerySP("ust_beginreg", param);
                if (x == 1 || x == -1)
                {
                    Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                    Session["Mob"] = txtmobileno.Value;
                    string otp = AL.GenOTP();
                    Session["HashOtp"] = AL.PassHash(otp);

                    //SMS API CODE HERE

                    if (txtmail.Value != "")
                    {
                        Session["Email"] = txtmail.Value;

                        /////Email Verification snippet
                        #region Email Veri
                        //string activationCode = Guid.NewGuid().ToString();
                        //SqlParameter[] param2 = { new SqlParameter("@UserId", txtMob.Value), new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@ActivationCode", activationCode) };
                        //int y = DAL.FunExecuteNonQuerySP("ust_emailverification", param2);
                        //if (y >= 0)
                        //{
                        //    string body = "Dear Customer,";
                        //    body += "<br /><br />Please click the following link to verify your email.<br>";
                        //    body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Default.aspx", "Verification.aspx?ActivationCode=" + activationCode) + "'><h2 style='float:left;padding:10px; background-color:#007acc;color:#f0f0f0;width:160px;text-align:center;'>Click here to verify</h2></a>";
                        //    body += "<br /><br /><br /><br><br>Team MoilCloud";
                        //    int i = AL.SendMail(txtEmail.Value, "MoilCloud Email Verification", body);

                        //}
                        #endregion
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