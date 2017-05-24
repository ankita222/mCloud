using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using mCloud.App_Code;

namespace mCloud.preInit
{
    public partial class Pay : System.Web.UI.Page
    {
        mCloudDAL DAL = new mCloudDAL();
        mCloudAL AL = new mCloudAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (
                    !string.IsNullOrEmpty(Session["Name"] as string) &&
                    !string.IsNullOrEmpty(Session["Mob"] as string) &&
                    !string.IsNullOrEmpty(Session["DataSize"] as String) &&
                    !string.IsNullOrEmpty(Session["Amount"] as string)
                   )
                {
                    lblName.Text = Session["Name"].ToString();
                    lblMob.Text = Session["Mob"].ToString();
                    string planDescription = Session["PlanName"].ToString() + " (" + Session["DataSize"].ToString() + " GB for " + Session["Days"].ToString() + " Days)";
                    lblpalDescription.Text = planDescription;
                    lblAmount.Text = Session["Amount"].ToString();

                    string paylink = "";

                    switch (Session["Amount"].ToString())
                    {
                        case "20":
                            paylink = "https://www.instamojo.com/moilcloud/moil-lite-package/";
                            break;
                        case "50":
                            paylink = "https://www.instamojo.com/moilcloud/moil-standard-package/";
                            break;
                        case "100":
                            paylink = "https://www.instamojo.com/moilcloud/moil-premium-package/";
                            break;
                    }
                    paybtn.Attributes.Add("href", paylink);
                }
            }
            catch (Exception ex)
            {
                DAL.OnError(ex);
            }

        }
    }
}