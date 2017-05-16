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

            if (Page.User.Identity.IsAuthenticated)
            {
                //string fname;
                lblLoginUser.Text = HttpContext.Current.User.Identity.Name;
                string id = HttpContext.Current.User.Identity.Name;
                try {
                    System.IO.DirectoryInfo prodir = new System.IO.DirectoryInfo(Server.MapPath(@"~/Users/Profile/"));
                    System.IO.FileInfo[] files = prodir.GetFiles(id + ".*");
                    foreach (System.IO.FileInfo f in files)
                    {
                        string fname = f.Name;
                        img1.ImageUrl = "~/Users/Profile/" + fname;
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();
                Response.Redirect("~/Default.aspx");
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