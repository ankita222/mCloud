using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mCloud.preInit
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        mCloud.App_Code.mCloudDAL mDAL = new App_Code.mCloudDAL();
        DataTable dt = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPricePlan();
            }
        }

        public void LoadPricePlan()
        {
            string getPlan= "Select Amount, (SpaceInMB_GB+' : '+convert(nvarchar,DurationInDays)+' Days') as Detail from PlanMaster";
            dt= mDAL.FunDataTable(getPlan);
            rptselectplan.DataSource = dt;
            rptselectplan.DataBind();
        }

        protected void btnselect_Command(object sender, CommandEventArgs e)
        {
            string getplan = e.CommandArgument.ToString();
            h3showplan.InnerText ="You have selected : "+ getplan;
        }
    }
}