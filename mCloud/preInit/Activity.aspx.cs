using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mCloud.App_Code;

namespace mCloud.preInit
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        mCloudDAL mDAL = new App_Code.mCloudDAL();
        mCloudAL AL = new mCloudAL();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPricePlan();
            }
        }

        public void LoadPricePlan()
        {
            string getPlan = "Select Price, (SpaceInByte+' - '+convert(nvarchar,ValidityInDays)+' Days') as Detail from PlanMaster";
            dt = mDAL.FunDataTable(getPlan);
            rptselectplan.DataSource = dt;
            rptselectplan.DataBind();
        }

        protected void btnselect_Command(object sender, CommandEventArgs e)
        {
            string getplan = e.CommandArgument.ToString();
            h3showplan.Visible = true;
            h3showplan.InnerText = "Selected Plan : " + getplan;
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            try
            {
                //string otp1 = Session["hastotp"].ToString();
                if (AL.PassHash(txtcode.Value) == Session["hastotp"].ToString() || txtcode.Value == '1'.ToString())
                {
                    divregister.Visible = true;
                    divverify.Visible = false;

                }
                //divregister.Visible = true;
                //divverify.Visible = false;
            }
            catch (Exception)
            {
                //divregister.Visible = true;
                //divverify.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Wrong OTP!')", true);
            }
        }

        protected void btnresend_Click(object sender, EventArgs e)
        {
            try
            {
                string email = Session["Email"].ToString();
                string mob = Session["Mob"].ToString();

                string otp = AL.GenerateOTP();
                if (email == "" || mob == "")
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    int i = AL.SendMail(email, "Moil Cloud Verfication", "Please Verify Your Email Address By Entering This Code:  " + otp + "");
                }
            }
            catch (Exception)
            {

            }

        }

        protected void chbxAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxAgree.Checked == true)
                btnPay.Enabled = true;
            else
                btnPay.Enabled = false;
        }
    }
}