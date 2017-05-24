using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mCloud.App_Code;

namespace mCloud.UserPage
{
    public partial class Storage : System.Web.UI.MasterPage
    {
        mCloudDAL dal = new mCloudDAL();

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

                    string getplanname = "select p.Name from UserDetails u join PlanMaster p  on u.PlanId=p.PlanId where u.UserId='" + id + "'";
                    DataTable dt = new DataTable();
                    dt = dal.FunDataTable(getplanname);
                    if(dt.Rows.Count>0)
                    sp2.InnerText = dt.Rows[0][0].ToString();
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