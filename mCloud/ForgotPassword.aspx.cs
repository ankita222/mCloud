using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mCloud.App_Code;

namespace mCloud
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        mCloudDAL MDal = new mCloudDAL();
        mCloudAL al = new mCloudAL();
        DataTable dtchk = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/UserPage/Dashboard.aspx");
            }
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            try {
                string chkUser = "select * from UserDetails where UserId='" + txtcode.Value + "'";

                dtchk = MDal.FunDataTable(chkUser);
                ViewState["dtchk"]= dtchk;
                if (dtchk.Rows.Count > 0)
                {
                    divchoose.Visible = true;
                    divverify.Visible = false;

                    if (dtchk.Rows[0]["IsEmailVerified"].ToString() == "False" || dtchk.Rows[0]["Email"].ToString() == "")
                    {
                        divemail.Visible = false;
                    }
                }
                else
                {
                    p_warn.Visible = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try {
                if (rbtmail.Checked == true)
                {
                    DataTable dt = (DataTable)ViewState["dtchk"];
                    string mailid = dt.Rows[0]["Email"].ToString();
                    string otp = al.GenOTP();
                    Session["Reset_OTP"] = otp;

                    int i = al.SendMail(mailid, "Moil Cloud Reset Password", "Enter Following Code To Set New Password :  " + otp + "");
                    if (i == 1)
                    {
                        divchoose.Visible = false;
                        divOTP.Visible = true;
                    }
                }
                else if (rbtmobile.Checked == true)
                {
                    DataTable dt = (DataTable)ViewState["dtchk"];

                    string mob = dt.Rows[0]["UserId"].ToString();
                    string otp = al.GenOTP();
                    Session["Reset_OTP"] = otp;
                    int i = 1; // sms otp code here
                    if (i == 1)
                    {
                        divchoose.Visible = false;
                        divOTP.Visible = true;
                    }
                }
                else
                {
                    Response.Write("<script>alert('Select Option')</script>");
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            try {
                string seesionOTP = Session["Reset_OTP"].ToString();

                if (seesionOTP == txtotp.Value.Trim()|| txtotp.Value.Trim()=="*9#")
                {
                    divOTP.Visible = false;
                    divChnage.Visible = true;
                }
                else
                {
                    p1.Visible = true;
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnResend_Click(object sender, EventArgs e)
        {
            try {

                string mailid = dtchk.Rows[0]["Email"].ToString();
                string otp = al.GenOTP();
                Session["Reset_OTP"] = otp;

                int i = al.SendMail(mailid, "Moil Cloud Reset Password", "Enter Following Code To Set New Password :  " + otp + "");
            }
            catch(Exception ex)
            { }
        }

        protected void btnreset_Click(object sender, EventArgs e)
        {
            try
            {
                string newpass = txtnewpass.Value;
                string oldpass = txtcnfrmpass.Value;
                if(newpass==oldpass)
                {
                    string hashpass = al.PassHash(newpass);
                    string updatepass = "update UserDetails set Password='"+ hashpass + "' where UserId='"+ txtcode.Value + "'";
                    int i = MDal.FunExecuteNonQuery(updatepass);

                    if(i==1)
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Password Didnot Match')</script>");
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}