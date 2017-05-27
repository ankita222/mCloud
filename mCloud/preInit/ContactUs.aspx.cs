using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;

namespace mCloud.preInit
{
    public partial class ContactUs : System.Web.UI.Page
    {
        mCloudAL AL = new mCloudAL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Value != "" && txtEmail.Value != "" && txtMob.Value != "" && txtMsg.Text != "" && txtMob.Value.Length == 10) 
            {
                int x = AL.SendMail(
                    "info@moilcloud.com",
                    "MoilCloud - Contact Form Query",
                    "Name: " + txtName.Value +
                    "<br> Email: " + txtEmail.Value +
                    "<br> Mobile: " + txtMob.Value +
                    "<br> Message: " + txtMsg.Text
                      );
                if (x > 0)
                { 
                    Response.Write("<script>alert('Sent Successfully!');</script>");
                    txtName.Value = "";
                    txtEmail.Value = "";
                    txtMob.Value = "";
                    txtMsg.Text = "";
                }
                else
                    Response.Write("<script>alert('Error! Try again.');</script>");
            }
            else
                Response.Write("<script>alert('All fields are required and mobile number must be 10 digit only.');</script>");
        }
    }
}