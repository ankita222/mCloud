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
            if (!string.IsNullOrEmpty(Session["Mob"] as string))
            {
                object exist = mDAL.FunExecuteScalar("SELECT PaymentStatus FROM Payment WHERE UserId='" + Session["Mob"].ToString() + "'");
                if (exist.ToString() == "Credit")
                {
                    int x = mDAL.FunExecuteNonQuery("UPDATE UserDetails SET IsActive=1 WHERE UserId='" + Session["Mob"].ToString() + "'");

                    if (x > 0)
                    {
                        lblSuccMsg.Text = Session["Mob"].ToString() + ", Successfully Registered!";
                    }
                    else
                    {
                        lblSuccMsg.Text = "Something went wrong! Please Contact Support.";
                        Page.Title = "Something went wrong! Please Contact Support.";
                    }

                }
                else
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Redirect("~/error.aspx");
                }
            }
        }
    }
}