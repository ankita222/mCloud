using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
                Response.Redirect("~/Default.aspx");
            }
            if (IsPostBack)
            {
                if (Page.User.Identity.IsAuthenticated)
                {
                    lblLoginUser.Text = HttpContext.Current.User.Identity.Name;
                    Response.Redirect("UserPage/Dashboard.aspx");
                }
                else
                {
                    Session.Clear();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}