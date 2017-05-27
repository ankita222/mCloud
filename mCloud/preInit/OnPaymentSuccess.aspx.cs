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
    public partial class OnPaymentSuccess : System.Web.UI.Page
    {
        mCloudDAL mDAL = new App_Code.mCloudDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (
                    !string.IsNullOrEmpty(Session["Mob"] as string) &&
                    !string.IsNullOrEmpty(Request.QueryString["status"] as string) &&
                    !string.IsNullOrEmpty(Request.QueryString["payment_id"] as string)
               )
            {
                if (Request.QueryString["status"] == "success")
                {
                    int PupStat= mDAL.FunExecuteNonQuery("UPDATE Payment SET PaymentStatus='success',TransactionId='" + Request.QueryString["payment_id"] + "',PaymentMode='WebSite' WHERE UserId='" + Session["Mob"].ToString() + "'");
                    if (PupStat > 0)
                    {
                        int ActStat = mDAL.FunExecuteNonQuery("UPDATE UserDetails SET IsActive=1 WHERE UserId='" + Session["Mob"].ToString() + "'");

                        if (ActStat > 0)
                        {
                            lblSuccMsg.Text = Session["Mob"].ToString() + ", Successfully Registered!";
                        }
                        else
                        {
                            Session.Abandon();
                            Session.Clear();
                            lblSuccMsg.ForeColor = System.Drawing.Color.Red;
                            lblSuccMsg.Text = "Payment failed! If amount is deducted from your account please contact support.";
                            Page.Title = "Payment Failed! Please Contact Support";
                        }
                    }
                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    lblSuccMsg.ForeColor = System.Drawing.Color.Red;
                    lblSuccMsg.Text = "Payment failed! If amount is deducted from your account please contact support.";
                    Page.Title = "Payment Failed! Please Contact Support";
                }
            }
        }
    }
}