using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mCloud.UserPage
{
    public partial class Storage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Session["id"].ToString();
                sp1.InnerText = id;
            }
            catch(Exception)
            {
                Response.Redirect("~/Logout.aspx");
            }
        }
    }
}