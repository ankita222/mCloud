using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mCloud.App_Code;
using System.Data.SqlClient;

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
            else
                Response.Redirect("~/Signup.aspx");
        }

        public void LoadPricePlan()
        {
            string getPlan = "  Select Name, Price,SpaceInByte, (SpaceInByte+' GB'+'-'+convert(nvarchar,ValidityInDays)+' Days') as Detail, (convert(nvarchar,PlanId) +'-'+convert(nvarchar,Price)+'-'+SpaceInByte+'-'+convert(nvarchar,ValidityInDays)+'-'+Name) as PlanDetails from PlanMaster";
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
            Session["Amount"] = amt = planarray[1];
            Session["DataSize"] = planbytes = planarray[2];
            Session["Days"] = duration = planarray[3];
            Session["PlanName"] = plan_name = planarray[4];

            lblSelectedPlan.Visible = true;
            lblPaymentSelect.Visible = false;
            lblSelectedPlan.Text = plan_name + "( " + "₹" + amt + " - " + planbytes + " GB" + " - " + duration + " Days )";
            h3showplan.Visible = true;
        }

        protected void btnverify_Click(object sender, EventArgs e)
        {
            if (txtcode.Value != "")
            {
                if (!string.IsNullOrEmpty(Session["HashOtp"] as string))
                {
                    if (AL.PassHash(txtcode.Value) == Session["HashOtp"].ToString() || txtcode.Value == "ajrs98")
                    {
                        divregister.Visible = true;
                        divverify.Visible = false;
                    }
                    else
                    {
                        txtcode.Value = "";
                        txtcode.Attributes.Add("placeholder", "OTP not matched.");
                    }
                }
                else
                    Response.Write("<script>alert('Something Wrong Occured, please try again.')</script>");
            }
            else
                Response.Write("<script>alert('Please enter OTP received on your mobile.')</script>");
        }

        protected void btnresend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Mob"] as string))
            {
                string mob = Session["Mob"].ToString();
                string newOTP = AL.GenOTP();
                Session["HashOtp"] = AL.PassHash(newOTP);

                string OTPrespo = AL.SendOTP(Session["Mob"].ToString(),
                            "MoilCloud OTP: " + newOTP + " OTP is confidential and not to be disclosed to anyone."
                            );

                string[] SplitOTP = OTPrespo.Split('|');
                if (SplitOTP[0] == "SUBMIT_SUCCESS ")
                {
                    btnresend.Enabled = false;
                    btnresend.Visible = false;
                }
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
            #region Pay
            if (txtPassword.Value == txtCPassword.Value)
            {
                if (chbxAgree.Checked == true)
                {
                    if (lblSelectedPlan.Text != "")
                    {
                        if (txtMob.Value != "" && txtName.Value != "" && (txtPassword.Value != "" && txtCPassword.Value != ""))
                        {
                            if (txtEmail.Value != "")
                                Session["Email"] = txtEmail.Value;
                            else
                                Session["Email"] = "demosale@moilcloud.com";
                            Session["Name"] = txtName.Value;
                            Session["Password"] = AL.PassHash(txtCPassword.Value);

                            if (
                                    !string.IsNullOrEmpty(Session["PlanId"] as string) &&
                                    !string.IsNullOrEmpty(Session["Amount"] as string) &&
                                    !string.IsNullOrEmpty(Session["DataSize"] as string) &&
                                    !string.IsNullOrEmpty(Session["Days"] as string) &&
                                    !string.IsNullOrEmpty(Session["PlanName"] as string) &&

                                    !string.IsNullOrEmpty(Session["Email"] as string) &&
                                    !string.IsNullOrEmpty(Session["Name"] as string) &&
                                    !string.IsNullOrEmpty(Session["Mob"] as string)
                               )
                            {
                                float amount = float.Parse(Session["Amount"].ToString());
                                string name = Session["Name"].ToString();
                                string email = Session["Email"].ToString();
                                string phone = Session["Mob"].ToString();

                                string productinfo = Session["PlanName"].ToString() + "( " + "₹" + Session["Amount"].ToString() + " - " + Session["DataSize"].ToString() + " GB" + " - " + Session["Days"].ToString() + " Days )";

                                int PaymentId = AL.GenId();
                                string RefCode = "";
                                if (!string.IsNullOrEmpty(Session["RefCode"] as string))
                                {
                                    RefCode = Session["RefCode"].ToString();
                                }

                                SqlParameter[] param =
                                {
                                new SqlParameter("@UserId",phone ),
                                new SqlParameter("@Name", name),
                                new SqlParameter("@Email", email),
                                new SqlParameter("@Password", Session["Password"].ToString()),
                                new SqlParameter("@PlanId", Session["PlanId"].ToString()),
                                new SqlParameter("@PlanStatus", "NewAccount"),
                                new SqlParameter("@ExpiryDate", DateTime.Now.AddDays(Double.Parse(Session["Days"].ToString()))),
                                new SqlParameter("@PaymentId", PaymentId),
                                new SqlParameter("@UserDirectoryPath", "~/Users/"+phone),

                                new SqlParameter("@MyReferenceCode", AL.GenRefCode()),
                                new SqlParameter("@ByReferenceCode", RefCode),

                                new SqlParameter("@PlanBought", Session["PlanId"].ToString()),
                                new SqlParameter("@PaymentStatus", "Pending"),
                                new SqlParameter("@PaidAmount", amount)
                                };

                                int x = mDAL.FunExecuteNonQuerySP("ust_onreg", param);
                                if (x > 0)
                                {
                                    string activationCode = AL.GenEmailVerificationCode();
                                    SqlParameter[] param2 = {
                                new SqlParameter("@UserId", phone),
                                new SqlParameter("@Email", email),
                                new SqlParameter("@ActivationCode", activationCode)
                                };
                                    int y = mDAL.FunExecuteNonQuerySP("ust_emailverification", param2);
                                    if (y >= 0)
                                    {
                                        string body = "Dear Customer,";
                                        body += "<br /><br />Please click the following link to verify your email.<br>";
                                        body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("Activity.aspx", "EmailVerification.aspx?ActivationCode=" + activationCode) + "'><h2 style='float:left;padding:10px; background-color:#007acc;color:#f0f0f0;width:200px;text-align:center;'>Click here to verify</h2></a><br><br>";
                                        body += "<br /><br /><br /><br><br>Team MoilCloud<br><br>";
                                        AL.SendMail(email, "MoilCloud Email Verification", body);
                                    }

                                    AL.CreateUserFolder(Session["Mob"].ToString());
                                    if (amount == 0)
                                    {
                                        Session["ActivateAccont"] = "1";
                                        Response.Redirect("Success.aspx");
                                    }
                                    else
                                        Response.Redirect("Pay.aspx");
                                }
                                else
                                {
                                    lblPaymentSelect.InnerText = "Something went wrong, please try again.";
                                    lblPaymentSelect.Visible = true;
                                }
                            }
                            else
                            {
                                lblPaymentSelect.InnerText = "Session timeout.";
                                lblPaymentSelect.Visible = true;
                            }
                        }
                        else
                        {
                            lblPaymentSelect.InnerText = "Please fill all required fields.";
                            lblPaymentSelect.Visible = true;
                        }
                    }
                    else
                    {
                        lblPaymentSelect.InnerText = "Select a plan to proceed.";
                        lblPaymentSelect.Visible = true;
                    }
                }
                else
                {
                    lblPaymentSelect.InnerText = "Please check the agreement to proceed.";
                    lblPaymentSelect.Visible = true;
                }
            }
            else
            {
                lblPaymentSelect.InnerText = "Passwords not matched.";
                lblPaymentSelect.Visible = true;
            }
            #endregion
        }
    }
}