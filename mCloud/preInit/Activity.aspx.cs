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
        string hashotp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPricePlan();
                if (!string.IsNullOrEmpty(Session["ClientId"] as string))
                    txtMob.Value = Session["Mob"].ToString();
                if (!string.IsNullOrEmpty(Session["IsdCode"] as string))
                    txtIsdCode.Value = Session["IsdCode"].ToString();
                if (!string.IsNullOrEmpty(Session["HashOtp"] as string))
                    hashotp = Session["HashOtp"].ToString();
                if (!string.IsNullOrEmpty(Session["Email"] as string))
                    txtEmail.Value = Session["Email"].ToString();
            }
        }

        public void LoadPricePlan()
        {
            //string getPlan = "Select Price, (SpaceInByte+' - '+convert(nvarchar,ValidityInDays)+' Days') as Detail from PlanMaster";
            string getPlan = "  Select Price, (SpaceInByte+'-'+convert(nvarchar,ValidityInDays)+' Days') as Detail, (convert(nvarchar,Price)+'-'+SpaceInByte+'-'+convert(nvarchar,ValidityInDays)) as PlanDetails from PlanMaster";
            dt = mDAL.FunDataTable(getPlan);
            rptselectplan.DataSource = dt;
            rptselectplan.DataBind();
        }

        protected void btnselect_Command(object sender, CommandEventArgs e)
        {
            string getplan = e.CommandArgument.ToString();
            string[] planarray = getplan.Split('-');
            string amt, planbytes, duration;
            Session["Amount"]=  amt = planarray[0];
            Session["Bytes"] = planbytes = planarray[1];
            Session["Days"] = duration = planarray[2];
            h3showplan.Visible = true;
            h3showplan.InnerText = "Selected Plan : " +planbytes+" - "+duration+" Days";
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            try
            {
                //string otp1 = Session["hastotp"].ToString();
                if (AL.PassHash(txtcode.Value) == Session["hastotp"].ToString())
                {
                    divregister.Visible = true;
                    divverify.Visible = false;

                }
                divregister.Visible = true;
                divverify.Visible = false;
            }
            catch (Exception)
            {
                divregister.Visible = true;
                divverify.Visible = false;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Wrong OTP!')", true);
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

        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (Session["Mob"].ToString() != "" || Session["Email"].ToString() != "")
            {
                string mobile = Session["Mob"].ToString();
                int i = AL.CreateUserFolder(mobile);
                if (i == 1)
                {
                    Response.Redirect("~\\Userpage\\Dashboard.aspx?id=" + mobile);
                }
                else
                {
                    Response.Write("<script>alert('Something Wrong Occured.')</script>");
                }
            }
        }
    }
}