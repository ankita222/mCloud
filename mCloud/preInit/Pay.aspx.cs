using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mCloud.preInit
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session["Name"] as string))
            {
                lblName.Text = Session["Name"].ToString();
            }
            if (!string.IsNullOrEmpty(Session["PlanName"] as string))
            {
                lblPlan.Text = Session["PlanName"].ToString();
            }
            if (!string.IsNullOrEmpty(Session["Mob"] as string))
            {
                lblMob.Text = Session["Mob"].ToString();
            }

        }
    }
}