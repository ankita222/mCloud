using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mCloud.App_Code;
using System.Data;
using System.Data.SqlClient;

namespace mCloud
{
    public partial class Signup : System.Web.UI.Page
    {
        mCloudAL AL = new mCloudAL();
        mCloudDAL DAL = new mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if (txtMob.Text != "" && txtMob.Text.Length == 10)
            {
                SqlParameter[] param = { new SqlParameter("@Email", txtmail.Text), new SqlParameter("@Mobile", txtMob.Text) };

              
                int x = DAL.FunExecuteNonQuerySP("ust_beginreg", param);
                DataTable dt = DAL.FunDataTableSP("ust_beginreg", param);
                if (dt.Rows.Count > 0 && dt != null)
                {
                    if (dt.Rows[0]["Column1"].ToString() == "1")//if exist in preregistration
                    {
                        SqlParameter[] param0 = { new SqlParameter("@UserId", txtMob.Text), new SqlParameter("@UEmail", txtmail.Text) };
                        DataTable dt0 = DAL.FunDataTableSP("ust_beginreguserdetail", param0);
                        if ((dt0.Rows[0]["Column1"].ToString() == "1"))//if exist in userdetails
                        {
                            Response.Write("<script>alert('Account already exist');</script>");
                        }
                        else
                        {
                            //int y = DAL.FunExecuteNonQuerySP("ust_beginreg", param);
                            Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                            Session["Mob"] = txtMob.Text;
                            string otp = AL.GenOTP();
                            Session["HashOtp"] = AL.PassHash(otp);
                            if (txtmail.Text != "")
                            {
                                Session["Email"] = txtmail.Text;
                            }

                            //SMS API CODE HERE

                            Response.Redirect("preInit/Activity.aspx");
                        }
                    }
                }
                else
                {
                    // SqlParameter[] param1 = { new SqlParameter("@UEmail", txtmail.Text), new SqlParameter("@UserId", txtMob.Text) };
                    SqlParameter[] param2 = { new SqlParameter("@Email", txtmail.Text), new SqlParameter("@Mobile", txtMob.Text) };
                    int y = DAL.FunExecuteNonQuerySP("ust_beginreg", param2);
                    Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                    Session["Mob"] = txtMob.Text;
                    string otp = AL.GenOTP();
                    Session["HashOtp"] = AL.PassHash(otp);
                    if (txtmail.Text != "")
                    {
                        Session["Email"] = txtmail.Text;
                    }

                    //SMS API CODE HERE

                    Response.Redirect("preInit/Activity.aspx");

                }

            }
            else
                Response.Write("<script>alert('10 digit mobile number only.');</script>");
        }
    }
}