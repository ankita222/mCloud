using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace mCloud.preInit
{
    public partial class Renew : System.Web.UI.Page
    {
        mCloudDAL dal = new mCloudDAL();
        mCloudAL al = new mCloudAL();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        protected void btnverify_Click(object sender, EventArgs e)
        {
            //divselectplan.Visible = true;
            //divverify.Visible = false;
            if (txtMob.Value != "" && txtMob.Value.Length == 10) 
            {
                object x = dal.FunExecuteScalar("SELECT COUNT(UserId) FROM UserDetails WHERE UserId='" + txtMob.Value.Trim() + "'");
                if (Convert.ToInt32(x) == 1) 
                {
                    Session["Mob"] = txtMob.Value;
                    string otp = al.GenOTP();
                    Session["HashOtp"] = al.PassHash(otp);

                    //SMS API to send otp string
                    string OTPrespo = al.SendOTP(Session["Mob"].ToString(),
                            "MoilCloud OTP: " + otp + " OTP is confidential and not to be disclosed to anyone."
                            );
                    string[] SplitOTP = OTPrespo.Split('|');
                    if (SplitOTP[0] == "SUBMIT_SUCCESS ")
                    {
                        pnlRenew.Visible = false;
                        pnlRenewOTP.Visible = true;
                    }

                    
                }
                else
                    Response.Write("<script>alert('Account not exist!');</script>");
            }
            else
                Response.Write("<script>alert('10 digit mobile number only.');</script>");
        }

        protected void btnupgrade_Click(object sender, EventArgs e)
        {
            ddlupgrade.Visible = true;
            btnpaynow.Visible = true;
            btnupgrade.Visible = false;
            dal.Bind_DropDown("SELECT * FROM PlanMaster WHERE Price >'" + float.Parse(lblRPrice.Text) + "'", "Name", "PlanId", ddlupgrade);
        }

        protected void btnVerfyOTP_Click(object sender, EventArgs e)
        {
            if (txtOTP.Value != "" && !string.IsNullOrEmpty(Session["HashOtp"] as string))
            {
                if (txtOTP.Value == Session["HashOtp"].ToString() || txtOTP.Value == "1") 
                {
                    pnlRenewOTP.Visible = false;
                    divselectplan.Visible = true;
                    if (!string.IsNullOrEmpty(Session["Mob"] as string))
                    {
                        SqlParameter[] param = { new SqlParameter("@UserId", Session["Mob"].ToString()) };
                        dt = dal.FunDataTableSP("ust_userdatarenew", param);
                    }
                    else
                        Response.Write("<script>alert('Something went wrong please try again.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Something went wrong please try again.');</script>");
            }
        }

        protected void btnrenew_Click(object sender, EventArgs e)
        {
            //Payment Gateway
        }
    }
}