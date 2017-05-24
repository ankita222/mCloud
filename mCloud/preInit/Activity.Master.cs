using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mCloud.preInit
{
    public partial class Activity : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                string pageName = this.ContentPlaceHolderContent.Page.GetType().FullName;
                if (
                        pageName == "ASP.preinit_pay_aspx" ||
                        pageName == "ASP.preinit_activity_aspx" ||
                        pageName == "ASP.preinit_paymentfailure_aspx" ||
                        pageName == "ASP.preinit_paymentsucces_aspx" ||
                        pageName == "ASP.preinit_renew_aspx"
                    )
                {
                    Response.Redirect("~/UserPage/Dashboard.aspx");
                }
            }
            //if (Page.User.Identity.IsAuthenticated)
            //{
            //    Response.Redirect("~/UserPage/Dashboard.aspx");
            //}
        }
    }
}