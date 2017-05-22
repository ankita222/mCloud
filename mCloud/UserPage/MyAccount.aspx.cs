using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace mCloud.UserPage
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        mCloudDAL mDAL = new App_Code.mCloudDAL();
        mCloudAL AL = new mCloudAL();
        DataTable dt = new DataTable();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            loadinfo();
            ///loadPlanDetails();
        }

        public void loadPlanDetails()
        {
            try
            {
                string username = Session["id"].ToString();
                string getinfo = "select * from UserDetails where UserId='" + username + "'";
                DataTable dt = new DataTable();
                dt = mDAL.FunDataTable(getinfo);
                if (dt.Rows.Count > 0)
                {
                    txtFirstname.Text = dt.Rows[0]["Name"].ToString();
                    txtmail.Value = dt.Rows[0]["Email"].ToString();
                    txtmob.Value = dt.Rows[0]["UserId"].ToString();
                    if (dt.Rows[0]["IsEmailVerified"].ToString() == "False")
                        divvery.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void loadinfo()
        {
            try {
                string username = Session["id"].ToString();
                string getinfo = "select u.Name as username, u.Email as email,u.IsEmailVerified, u.UserId as userid, p.Name as planName, p.SpaceInByte as SpaceInByte,convert(nvarchar(12),u.ExpiryDate) as ExpiryDate, u.UsedSpace as usedspace  from UserDetails u join PlanMaster p on p.PlanId = u.PlanId where u.UserId='" + username + "'";
                DataTable dt = new DataTable();
                dt = mDAL.FunDataTable(getinfo);
                if (dt.Rows.Count > 0)
                {
                    txtFirstname.Text = dt.Rows[0]["username"].ToString();
                    txtmail.Value = dt.Rows[0]["email"].ToString();
                    txtmob.Value= dt.Rows[0]["userid"].ToString();
                    if (dt.Rows[0]["IsEmailVerified"].ToString() == "False")
                        divvery.Visible = true;
                    lblplan.InnerText = dt.Rows[0]["planName"].ToString();
                    lbltotal.InnerText = dt.Rows[0]["SpaceInByte"].ToString()+" Bytes";
                    lblexp.InnerText = dt.Rows[0]["ExpiryDate"].ToString();
                    lblavailspace.InnerText =(Int64.Parse(dt.Rows[0]["SpaceInByte"].ToString())- Int64.Parse(dt.Rows[0]["usedspace"].ToString())).ToString() + " Bytes";
                    lblusedspace.InnerText = dt.Rows[0]["usedspace"].ToString() + " Bytes";

                }
            }
            catch
            {

            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            string username = Session["id"].ToString();

            string insertmenu, firstname, lastname, mail;
            firstname = txtFirstname.Text;
          
            mail = txtmail.Value;

            SqlCommand cmd1;
            string contenttype = string.Empty;
            string filename = string.Empty;
            string ext = string.Empty;
            byte[] bytes = null;
            try
            {
                if (imgupload.HasFile)
                {
                    filename = Path.GetFileName(imgupload.PostedFile.FileName);
                    ext = Path.GetExtension(imgupload.PostedFile.FileName);
                    imgupload.SaveAs(Server.MapPath("~/Users/Profile/" + username+ext));
                    insertmenu = "update UserDetails set Name='"+firstname+ "' ,Email='"+ mail + "' where UserId='"+username+"'  ";
                }
                else
                {
                    insertmenu = "update UserDetails set Name='" + firstname + "' ,Email='" + mail + "' where UserId='" + username + "'";
                }
             
                int i = mDAL.FunExecuteNonQuery(insertmenu);

                if (i == 1)
                {
                    txtFirstname.Text = "";
                    txtmail.Value = "";
                }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Menu Added.');", true);
               // loadInfo(number);
               Response.Redirect(Request.RawUrl);

            }
            catch (Exception ex)
            { }

        }

        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            string old,newpass,confrm;
            string username = Session["id"].ToString();
            old = txtoldpass.Value;
            newpass = txtnewpass.Value;
            confrm = txtcnfrmpass.Value;

            if(newpass.Equals(confrm))
            {
                string hash = AL.PassHash(newpass);
                string updatepass = "update UserDetails set Password='"+hash+"' where UserId='"+ username + "' and Password='"+AL.PassHash(old) +"' ";

                int i = mDAL.FunExecuteNonQuery(updatepass);

                if(i==1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Password Changed Successfully');", true);
                    txtcnfrmpass.Value = txtnewpass.Value = txtcnfrmpass.Value = "";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Techinal Error Occured');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Password Did Not Match ');", true);
        }

        protected void btnvery_ServerClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["id"] as string))
            {
                string activationCode = AL.GenEmailVerificationCode();
                SqlParameter[] param2 = { new SqlParameter("@UserId", Session["id"].ToString()), new SqlParameter("@Email", txtmail.Value), new SqlParameter("@ActivationCode", activationCode) };
                int y = mDAL.FunExecuteNonQuerySP("ust_emailverification", param2);
                if (y >= 0) 
                {
                    string body = "Dear Customer,";
                    body += "<br /><br />Please click the following link to verify your email.<br>";
                    body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("MyAccount.aspx", "EmailVerification.aspx?ActivationCode=" + activationCode) + "'><h2 style='float:left;padding:10px; background-color:#007acc;color:#f0f0f0;width:200px;text-align:center;'>Click here to verify</h2></a><br><br>";
                    body += "<br /><br /><br /><br><br>Team MoilCloud<br><br>";
                    int i = AL.SendMail(txtmail.Value, "MoilCloud Email Verification", body);
                    if (i > 0) 
                    {
                        Response.Write("<script>alert('Please check your inbox.');</script>");
                    }

                }
            }
        }
    }
}