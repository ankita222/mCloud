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
        //protected void btncreate_ServerClick(object sender, EventArgs e)
        //{

        //    //SqlParameter[] param = { new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@Mobile", txtMob.Value) };
        //    //int x = DAL.FunExecuteNonQuerySP("ust_beginreg", param);

        //    //Session["Email"] = txtEmail.Value;
        //    //Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
        //    //Session["Mob"] = txtMob.Value;
        //    //string otp = AL.GenerateOTP();
        //    //Session["otp"] = txtMob.Value;
        //    //if (txtEmail.Value != "")
        //    //{
        //    //    int i = AL.SendMail(txtEmail.Value, "Moil Cloud Verfication", "Please Verify Your Email Address By Entering This Code:  " + otp + "");
        //    //    if (i == 1)
        //    //        Response.Redirect("preInit/Activity.aspx");
        //    //    else
        //    //    {
        //    //        // ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Error! Please try again')", true);
        //    //        Response.Write("<script>alert('Error! Please try again');</script>");
        //    //    }
        //    //}
        //    Session["id"] = txtUserName.Value;
        //    Response.Redirect("UserPage/Dashboard.aspx?id=" + txtUserName.Value);

        //}

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtMob.Value != "")
            {

                SqlParameter[] param = { new SqlParameter("@Email", txtEmail.Value), new SqlParameter("@Mobile", txtMob.Value) };


                int x = DAL.FunExecuteNonQuerySP("ust_beginreg", param);
                if (x == -1 || x == 1)
                {
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
                else
                {
                    Response.Write("<script>alert('Someting went wrong, please try again.');</script>");
                }

            }
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
                if (dt.Rows.Count > 0 && dt !=null)
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
                            Response.Redirect("UserPage/Dashboard.aspx?id=" + txtUserName.Value);

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
