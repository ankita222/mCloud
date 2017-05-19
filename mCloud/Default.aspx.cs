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
using System.Web.Security;

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

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtMob.Value != "" && txtMob.Value.Length == 10)
            {
                SqlParameter[] param =
                    {
                        new SqlParameter("@UserId", txtMob.Value),
                        new SqlParameter("@Email", txtEmail.Value),
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
                        new SqlParameter("@Mobile", txtMob.Value),
                        new SqlParameter("@Email", txtEmail.Value),
                    };
                    DAL.FunExecuteNonQuerySP("ust_beginreg", param0);
                    Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                    Session["Mob"] = txtMob.Value;
                    string otp = AL.GenOTP();
                    Session["HashOtp"] = AL.PassHash(otp);
                    if (txtEmail.Value != "")
                    {
                        Session["Email"] = txtEmail.Value;
                    }

                    //SMS API CODE HERE

                    Response.Redirect("preInit/Activity.aspx");
                }
            }
            else
                Response.Write("<script>alert('10 digit mobile number only.');</script>");

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            #region TEMP LOGIN CODE
            //Session["id"] = txtUserName.Value;
            //Session["CurrentPath"] = "UserPage";
            //Response.Redirect("UserPage/Dashboard.aspx?id=" + txtUserName.Value);
            #endregion

            #region LOGIN CODE

            if (txtUserName.Value != "" && txtPassword.Value != "")
            {
                SqlParameter[] param = { new SqlParameter("@UserId", txtUserName.Value), new SqlParameter("@Password", AL.PassHash(txtPassword.Value.Trim())) };

                DataTable dt = DAL.FunDataTableSP("ust_login", param);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    string x = dt.Rows[0]["IsActive"].ToString();
                    if (x == "True")
                    {
                        DateTime exptime = DateTime.Parse((dt.Rows[0]["ExpiryDate"]).ToString());
                        System.TimeSpan diffResult = exptime - System.DateTime.Today;
                        if (diffResult.Days >= 0F)
                        {
                            Session["DaysLeft"] = diffResult.Days;
                            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUserName.Value, DateTime.Now, DateTime.Now.AddMinutes(30), CheckBoxPersist.Checked, FormsAuthentication.FormsCookiePath);
                            string hash = FormsAuthentication.Encrypt(ticket);
                            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                            if (ticket.IsPersistent)
                            {
                                cookie.Expires = ticket.Expiration;
                            }
                            Response.Cookies.Add(cookie);
                            Session["UserId"] = txtUserName.Value;
                            Session["id"] = txtUserName.Value;
                            Session["CurrentPath"] = "UserPage";

                            FormsAuthentication.SetAuthCookie(txtUserName.Value, CheckBoxPersist.Checked);
                            Response.Redirect("UserPage/Dashboard.aspx");

                        }
                        else
                        {

                            DAL.FunExecuteNonQuery("UPDATE UserDetails SET IsActive = 0 WHERE UserId='" + txtUserName.Value + "'");
                            this.lblErrorMsg.Visible = true;
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                            this.lblErrorMsg.Text = "Account expire please renew.";
                        }
                    }

                    else if (x == "False")
                    {
                        this.lblErrorMsg.Visible = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                        this.lblErrorMsg.Text = "Account is not active, contact support.";
                    }
                }
                else
                {
                    this.lblErrorMsg.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "ShowPopup();", true);
                    this.lblErrorMsg.Text = "Invalid Username and/or Password";
                }
            }

            #endregion

        }
    }
}
