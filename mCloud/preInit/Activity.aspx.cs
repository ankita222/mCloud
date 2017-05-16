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
           
                //Temporary code
                    // LoadPricePlan();

                if (!string.IsNullOrEmpty(Session["Mob"] as string))
                {
                    LoadPricePlan();
                    //if (!string.IsNullOrEmpty(Session["Mob"] as string))
                        txtMob.Value = Session["Mob"].ToString();
                    if (!string.IsNullOrEmpty(Session["IsdCode"] as string))
                        txtIsdCode.Value = Session["IsdCode"].ToString();
                    if (!string.IsNullOrEmpty(Session["HashOtpe"] as string))
                        hashotp = Session["HashOtp"].ToString();
                    if (!string.IsNullOrEmpty(Session["Email"] as string))
                        txtEmail.Value = Session["Email"].ToString();
                }
                //Disable below in developemnt
                else
                    Response.Redirect("~/Signup.aspx");

            }
        

        public void LoadPricePlan()
        {
            //string getPlan = "Select Price, (SpaceInByte+' - '+convert(nvarchar,ValidityInDays)+' Days') as Detail from PlanMaster";
            string getPlan = "  Select Name, Price, (SpaceInByte+'-'+convert(nvarchar,ValidityInDays)+' Days') as Detail, (convert(nvarchar,PlanId) +'-'+convert(nvarchar,Price)+'-'+SpaceInByte+'-'+convert(nvarchar,ValidityInDays)+'-'+Name) as PlanDetails from PlanMaster";
            dt = mDAL.FunDataTable(getPlan);

            rptselectplan.DataSource = dt;
            rptselectplan.DataBind();
        }

        protected void btnselect_Command(object sender, CommandEventArgs e)
        {
            string getplan = e.CommandArgument.ToString();
            string[] planarray = getplan.Split('-');
            string amt, planbytes, duration, plan_name;
            Session["PlanId"] = planarray[0];
            Session["Amount"]=  amt = planarray[1];
            Session["DataSize"] = planbytes = planarray[2];
            Session["Days"] = duration = planarray[3];
            Session["PlanName"] = plan_name= planarray[4];
            //Session["PlanId"] = getplan.Split('-')[0];

            lblSelectedPlan.Visible = true;
            //lblSelectedPlan.Text= "Selected Plan : " + "₹" + amt + " - " + planbytes + " GB" + " - " + duration + " Days";
            lblSelectedPlan.Text = plan_name +"( " + "₹" + amt + " - " + planbytes + " GB" + " - " + duration + " Days )";
            h3showplan.Visible = true;
            //h3showplan.InnerText = "Selected Plan : " +"₹"+amt + " - " + planbytes + " GB"+" - " + duration + " Days";
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            //try
            //{
            //string otp1 = Session["hastotp"].ToString();
            if (txtcode.Value != "")
            {
                if (!string.IsNullOrEmpty(Session["HashOtp"] as string))
                {
                    if (AL.PassHash(txtcode.Value) == Session["HashOtp"].ToString() || txtcode.Value=="1")
                    {
                        divregister.Visible = true;
                        divverify.Visible = false;
                    }
                    //divregister.Visible = true;
                    //divverify.Visible = false;
                    else
                    {
                        txtcode.Value = "";
                        txtcode.Attributes.Add("placeholder", "OTP not matched.");
                    }
                    //}
                    //catch (Exception)
                    //{
                    //    divregister.Visible = true;
                    //    divverify.Visible = false;
                    //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Wrong OTP!')", true);
                    //}
                }
                else
                    Response.Write("<script>alert('Something Wrong Occured, please try again.')</script>");
            }
            else
                Response.Write("<script>alert('Please enter OTP received on your mobile.')</script>");
        }

        protected void btnresend_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string email = Session["Email"].ToString();


            //string mob = Session["Mob"].ToString();

            //string otp = AL.GenerateOTP();
            //if (email == "" || mob == "")
            //{
            //    Response.Redirect("~/Default.aspx");
            //}
            //else
            //{
            //    int i = AL.SendMail(email, "Moil Cloud Verfication", "Please Verify Your Email Address By Entering This Code:  " + otp + "");
            //}
            //}
            //catch (Exception)
            //{

            //}

            if (!string.IsNullOrEmpty(Session["Mob"] as string))
            {
                string mob = Session["Mob"].ToString();
                string newOTP = AL.GenOTP();

                //SMS API
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
            #region TEST CODE
            //string mobile = Session["Mob"].ToString();
            //int i = AL.CreateUserFolder(mobile);
            //if (i == 1)
            //{
            //    Response.Redirect("~\\Userpage\\Dashboard.aspx?id=" + mobile);
            //}
            //else
            //{
            //    Response.Write("<script>alert('Something Wrong Occured.')</script>");
            //}
            #endregion

            #region Final Code

            if (chbxAgree.Checked == true)
            {
                if (lblSelectedPlan.Text != "")
                {
                    if (txtMob.Value != "" && txtName.Value != "" && txtPassword.Value != "" && txtCPassword.Value != "")
                    {
                        if (txtEmail.Value != "")
                            Session["Email"] = txtEmail.Value;
                        else
                            Session["Email"] = "demosale@moilcloud.com";
                        Session["Name"] = txtName.Value;
                        //string[] tokens = lblSelectedPlan.Text.Split('-');
                        //Session["PlanDescription"] = tokens[1] + " for " + tokens[2];
                        //Session["PlanAmount"] = tokens[0];
                        Session["Password"] = AL.PassHash(txtCPassword.Value);
                        Response.Redirect("Pay.aspx");
                    }
                    else
                        Response.Write("<script>alert('Please fill all required fields.');</script>");
                }
                else
                    Response.Write("<script>alert('Please Select a Plan.');</script>");
            }
            else
                Response.Write("<script>alert('Please check the agreement to proceed.');</script>");

            #endregion
        }
    }
}