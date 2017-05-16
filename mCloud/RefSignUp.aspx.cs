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
            if (!String.IsNullOrEmpty(Request.QueryString["RefCode"]))
            {
                txtRefCode.Value = Request.QueryString["RefCode"];
            }

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtMob.Value != "" && txtMob.Value.Length == 10)
            {
                SqlParameter[] param = { new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@Mobile", txtMob.Value) };

                DataTable dt = DAL.FunDataTableSP("ust_beginreg", param);

                if (dt.Rows[0]["Column1"].ToString() == "0")
                {
                    Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                    Session["Mob"] = txtMob.Value;
                    string otp = AL.GenOTP();
                    Session["HashOtp"] = AL.PassHash(otp);
                    Session["RefCode"] = txtRefCode.Value;

                    //SMS API CODE HERE

                    if (txtEmail.Value != "")
                    {
                        Session["Email"] = txtEmail.Value;
                    }

                    Response.Redirect("preInit/Activity.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Account already exist');</script>");
                }
            }
            Response.Write("<script>alert('10 digit mobile number only.');</script>");
        }
    }
}