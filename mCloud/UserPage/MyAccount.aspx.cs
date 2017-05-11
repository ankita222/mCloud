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
        string hashotp;

        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}