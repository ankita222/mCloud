using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using mCloud.App_Code;
using System.Data;

namespace mCloud
{
    public partial class Default : System.Web.UI.Page
    {
        mCloudAL AL = new mCloudAL();
        mCloudDAL DAL = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btncreate_ServerClick(object sender, EventArgs e)
        {
            string CheckUser = "select * from PreRegistration where Email='"+ txtEmail.Value.Trim() + "' and Mobile='"+ txtMob.Value.Trim() + "'";
            DataTable dttable = DAL.FunDataTable(CheckUser);
            if (dttable == null || dttable.Rows.Count == 0)
            {

                Session["Email"] = txtEmail.Value;
                Session["isdCode"] = IsdCode.Value;
                Session["Mob"] = txtMob.Value;


                string otp = AL.GenerateOTP();
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
            else
            {
                
            } 
        }
    }
}