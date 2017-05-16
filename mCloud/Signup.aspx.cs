﻿using System;
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

                DataTable dt = DAL.FunDataTableSP("ust_beginreg", param);

                if (dt.Rows[0]["Column1"].ToString() == "0") 
                {
                    
                    Session["IsdCode"] = ddlIsdCode.SelectedValue.ToString();
                    Session["Mob"] = txtMob.Text;
                    string otp = AL.GenOTP();
                    Session["HashOtp"] = AL.PassHash(otp);

                    //SMS API CODE HERE

                    if (txtmail.Text != "")
                    {
                        Session["Email"] = txtmail.Text;
                    }

                    Response.Redirect("preInit/Activity.aspx");

                }
                else
                {
                    Response.Write("<script>alert('Account already exist');</script>");
                }

            }
            else
            Response.Write("<script>alert('10 digit mobile number only.');</script>");
        }
    }
}